using AArkhipenko.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Добавление АПИ контроля состояния программы
builder.Services.AddCustomHealthCheck();
// Добавление версионирования
builder.Services.AddVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Использование прослойки, которая добавляет в заголовки ИД запроса
app.UseRequestChainMiddleware();
// Использование простойки, которая обрабатывает исключения
app.UseExceptionMiddleware();
// Использование прослойки контроля состояния программы
app.UseCustomHealthCheck();
app.UseAuthorization();

app.MapControllers();

app.Run();
