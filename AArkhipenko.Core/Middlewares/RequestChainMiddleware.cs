using AArkhipenko.Core;
using Microsoft.AspNetCore.Http;

namespace User.Service.API.Exceptions
{
    /// <summary>
    /// Прослойка для работы с цепочкой вызовов
    /// </summary>
    internal class RequestChainMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestChainMiddleware"/> class.
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/></param>
        public RequestChainMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Выполнение запроса
        /// </summary>
        /// <param name="httpContext"><see cref="HttpContext"/></param>
        /// <returns><see cref="Task"/></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Добавление в заголовок запроса RequestId, если его нет
            if (!httpContext.Request.Headers.TryGetValue(Consts.RequestChainId, out var requestId))
            {
                httpContext.Request.Headers.Add(Consts.RequestChainId, Guid.NewGuid().ToString());
            }
            // Замена заголовка запроса, если это не гуид
            else if (!Guid.TryParse(requestId, out var requestId1))
            {
                httpContext.Request.Headers.Remove(Consts.RequestChainId);
                httpContext.Request.Headers.Add(Consts.RequestChainId, Guid.NewGuid().ToString());
            }

            await _next(httpContext);
        }
    }
}
