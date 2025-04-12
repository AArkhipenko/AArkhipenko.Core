using AArkhipenko.Core.Middlwares;
using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using User.Service.API.Exceptions;

namespace AArkhipenko.Core
{
	/// <summary>
	/// Методы расширешения
	/// </summary>
	public static class CoreExtension
    {
        /// <summary>
        /// Использование прослойки для работы с цепочкой вызовов
        ///     (чем выше в цепочке middleware, тем раньше в headers будет добавлен заголовок)
        /// </summary>
        /// <param name="builder"><see cref="IApplicationBuilder"/></param>
        /// <returns><see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseRequestChainMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestChainMiddleware>();
        }

        /// <summary>
        /// Добавления настроект для работы с healthcheck
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();

            return services;
        }

        /// <summary>
        /// Использование прослойки обработки healthcheck
        /// </summary>
        /// <param name="builder"><see cref="IApplicationBuilder"/></param>
        /// <returns><see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder builder)
        {
            return builder.UseHealthChecks("/check"); ;
        }

        /// <summary>
        /// Добавления настроект версионирования АПИ
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddVersioning(this IServiceCollection services)
		{
			var apiVersioningBuilder = services.AddApiVersioning(o =>
			{
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
				o.ReportApiVersions = true;
				o.ApiVersionReader = new UrlSegmentApiVersionReader();
			});
			apiVersioningBuilder.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}

        /// <summary>
        /// Использование прослойки обработки исключений
        /// </summary>
        /// <param name="builder"><see cref="IApplicationBuilder"/></param>
        /// <returns><see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
