# NewsApp-WebAPI

A RESTful **ASP.NET Core Web API** for managing news articles, built with .NET 9, Entity Framework Core and SQL Server.

## ✨ Features

- Full CRUD operations for news articles
- Layered structure with the **Repository Pattern** and **Dependency Injection**
- **Entity Framework Core** (Code-First) with migrations, Fluent API configuration and seed data
- Unique index on the article slug, so every article has a unique URL
- Model validation and appropriate HTTP status codes (`201`, `204`, `400`, `404`)
- Asynchronous operations with `CancellationToken` support
- Interactive API documentation with **Swagger**
- Pending migrations are applied automatically on startup

## 📡 Endpoints

| Method | Endpoint | Description | Success response |
|---|---|---|---|
| `GET` | `/api/NewsArticles` | Lists all articles (newest first by publish date) | `200 OK` |
| `GET` | `/api/NewsArticles/{id}` | Returns a single article | `200 OK` / `404 Not Found` |
| `POST` | `/api/NewsArticles` | Creates a new article | `201 Created` |
| `PUT` | `/api/NewsArticles/{id}` | Updates an article | `204 No Content` |
| `DELETE` | `/api/NewsArticles/{id}` | Deletes an article | `204 No Content` |

## 🗂️ Data Model

| Field | Type | Rules |
|---|---|---|
| `Id` | `int` | Primary key |
| `Title` | `string` | Required, max 200 characters |
| `Slug` | `string` | Required, max 220 characters, unique |
| `Summary` | `string` | Max 500 characters |
| `Content` | `string` | Required |
| `PublishedAt` | `DateTime?` | Optional |
| `Status` | `NewsStatus` | `Draft`, `Published` or `Archived` (stored as text) |
| `AuthorName` | `string` | Required, max 100 characters |

### Example request body

```json
{
  "title": "Sample Article",
  "slug": "sample-article",
  "summary": "A short summary of the article",
  "content": "<p>Article content</p>",
  "publishedAt": "2026-11-16T10:00:00Z",
  "status": 1,
  "authorName": "Jane Doe"
}
```

`status` values: `0` = Draft, `1` = Published, `2` = Archived.

## 🛠️ Tech Stack

- .NET 9, C#
- ASP.NET Core Web API
- Entity Framework Core (SQL Server)
- Swagger (Swashbuckle)

## 🚀 Getting Started

**Prerequisites:** .NET 9 SDK, SQL Server LocalDB (included with Visual Studio)

```bash
git clone https://github.com/ZehraAslantas/NewsApp-WebAPI.git
cd NewsApp-WebAPI
dotnet run --project News --launch-profile https
```

Then open **https://localhost:7080/swagger** in your browser.

The database is created and filled with sample articles automatically on first run. The connection string can be changed in `News/appsettings.json` (`ConnectionStrings:NewsDb`).

## 📁 Project Structure

```
News/
├── Controllers/          # NewsArticlesController
├── Models/               # NewsArticle, NewsStatus
├── Repositories/
│   ├── INewsRepository.cs
│   ├── NewsRepository.cs
│   ├── NewsDbContext.cs
│   └── Config/           # NewsArticleConfiguration (Fluent API + seed data)
├── Migrations/
└── Program.cs            # DI registrations, Swagger and middleware pipeline
```

## 🔗 Related Project

This API is consumed by an MVC app and a Razor Pages app in the [ApiConsume-Architecture](https://github.com/ZehraAslantas/ApiConsume-Architecture) repository.
