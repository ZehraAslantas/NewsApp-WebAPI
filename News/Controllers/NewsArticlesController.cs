 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.Repositories;

namespace News.Controllers;

[Route("api/[controller]")]
[ApiController]//bu otomatik geldi.hata yönetimini sağlıyor
public class NewsArticlesController : ControllerBase
{
    private readonly INewsRepository _newsRepository;
 
    public NewsArticlesController(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsArticle>>> GetAll(CancellationToken cancellation) 
    {
        var articles =await _newsRepository.GetAllAsync(cancellation);
        return Ok(articles);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<NewsArticle>> GetById(int id,CancellationToken cancellationToken)
    { 
        var article = await _newsRepository.GetByIdAsync(id,cancellationToken);
        if (article is null)
        {
            return NotFound();
        }
        return Ok(article);
    }
    
    [HttpPost]
    public async Task<ActionResult<NewsArticle>> Create([FromBody] NewsArticle article,CancellationToken cancellationToken)
    {
      

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        var created = await _newsRepository.AddAsync(article, cancellationToken);
        return CreatedAtAction(nameof(GetById), new {id=created.Id},created);
        
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<NewsArticle>> Update([FromRoute(Name ="id")] int id, [FromBody] NewsArticle article,CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        if(id != article.Id)
        {
            return BadRequest("Route data is not valid!"); //400 kodu
        }
        var existing = await _newsRepository.GetByIdAsync(id,cancellationToken);
        if (existing is null)
        {
            return NotFound(); //status kodları
        }
        await _newsRepository.UpdateAsync(article,cancellationToken);
        return NoContent(); //204 koduyla dönüş
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<NewsArticle>> Delete([FromRoute(Name="id")] int id,
        CancellationToken cancellationToken)
    {
        var existing = await _newsRepository.GetByIdAsync(id,cancellationToken);
        if(existing is null)
            return NotFound();
        await _newsRepository.DeleteAsync(id, cancellationToken);
        return NoContent(); //204 koduyla dönüş
    }

}
