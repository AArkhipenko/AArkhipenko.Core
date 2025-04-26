# AArkhipenko.Core

Nuget-проект с базовым функционалом

## Базовые исключения

1. Ошибка задания параметров запроса [BadRequestException](./AArkhipenko.Core/Exceptions/BadRequestException.cs)
1. Не найдена сущность [NotFoundException](./AArkhipenko.Core/Exceptions/NotFoundException.cs)
1. Ошибка авторизации [AuthorizationException](./AArkhipenko.Core/Exceptions/AuthorizationException.cs)

## Методы расширения

Все методы расширения находятся [здесь](./AArkhipenko.Core/CoreExtension.cs)

### ИД запроса

На каждый запрос к АПИ добавляет в заголовки **Request-Chain-Id** с ИД запроса

Такой подход позволяет:
* находить в логах данные только по одному запросу
* отслеживать цепочку вызовов в микросервисной системе

Подключение:
```C#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
...
var app = builder.Build();
// Использование прослойки, которая добавляет в заголовки ИД запроса
app.UseRequestChainMiddleware();
...
app.MapControllers();

app.Run();
```

### Контроль состояния программы

Добавление АПИ контроля состояния программы
Запрос *http://localhost:5066/check* вернет информацию о состоянии программы *Healthy*

Подключение:
```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Добавление АПИ контроля состояния программы
builder.Services.AddCustomHealthCheck();
...
var app = builder.Build();
// Использование прослойки контроля состояния программы
app.UseCustomHealthCheck();
...
app.MapControllers();

app.Run();
```

### Версионирование АПИ

В АПИ добавляется информация о версии, что позволяет группировать АПИ по версиям

Подключение:
```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Добавление версионирования
builder.Services.AddVersioning();
...
var app = builder.Build();
...
app.MapControllers();

app.Run();
```

### Единая обработка исключений

Добавление прослойки обработки исключений на самом нижнем уровне

Такой подход позволяет:
* реагировать на все исключения в одном месте
* возращать информацию о исключениях в одном виде
* менять http статус ответа в зависимости от типа исключения

Подключение:
```C#

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
...
var app = builder.Build();
// Использование простойки, которая обрабатывает исключения
app.UseExceptionMiddleware();
...
app.MapControllers();

app.Run();
```

## Логирование

Nuget-пакет имеет дополнительный функционал, который позволяет расширить логирования

Возможности:
* обогащение лога информацией о начале и завершении выполнении метода