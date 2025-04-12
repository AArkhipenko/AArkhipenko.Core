using AArkhipenko.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace AArkhipenko.Core.Logging
{
    /// <summary>
    /// Базовый контроллер с поддержкой логирования
    /// </summary>
    public class LoggingControllerBase : ControllerBase, ILoggerWrapper
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingControllerBase"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LoggingControllerBase(ILogger logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public ILogger Logger => this._logger;

        /// <inheritdoc/>
        public LoggerWrapperScope BeginLoggingScope([CallerMemberName] string? callerMethodName = null, string? callerClassName = null)
        {
            var scopeModel = new MethodLogModel
            {
                ClassName = callerClassName ?? this.GetType().Name,
                MethodName = callerMethodName ?? "unknown",
            };

            return new LoggerWrapperScope(this._logger, scopeModel);
        }
    }
}
