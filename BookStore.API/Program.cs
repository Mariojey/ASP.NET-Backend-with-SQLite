using BookStore.API.Dtos;
using BookStore.API.Controllers;
using BookStore.API.Data;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddEndpointsMetadataProviderApiExplorer(); in .NET < 10.0

var connectionString = builder.Configuration.GetConnectionString("BookStore");
builder.Services.AddSqlite<BooksContext>(connectionString);

var app = builder.Build();

app.MapBooksController();


app.Run();
