namespace AArkhipenko.Core.Models
{
	/// <summary>
	/// Модель исключения для записи в ответ на http запрос
	/// </summary>
	internal class ResponseExceptionModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseExceptionModel"/> class.
		/// </summary>
		/// <param name="exception">исключение в процессе выполнения запроса</param>
		public ResponseExceptionModel(Exception exception)
		{
			Source = exception.Source;

			if (exception.TargetSite is not null)
			{
				var targetSite = string.Empty;
				if(exception.TargetSite.ReflectedType is not null)
				{
					targetSite += $"{exception.TargetSite.ReflectedType.Name}.";
				}
				else if (exception.TargetSite.DeclaringType is not null)
				{
					targetSite += $"{exception.TargetSite.DeclaringType.Name}.";
				}

				TargetSite = targetSite + exception.TargetSite.Name;
			}

			StackTrace = exception.StackTrace;
			Message = exception.Message;
			InnerExceptionMessage = GetInnerExceptionMessages(exception.InnerException);
		}

		/// <summary>
		/// Название проекта, что выдал исключение
		/// </summary>
		public string? Source { get; set; }

		/// <summary>
		/// Название метоа, что выдал исключение
		/// </summary>
		public string? TargetSite { get; set; }

		/// <summary>
		/// Стек вызовов методов
		/// </summary>
		public string? StackTrace { get; set; }

		/// <summary>
		/// Сообщение исключения
		/// </summary>
		public string? Message { get; set; }

		/// <summary>
		/// Сообщения всех вложенных исключений
		/// </summary>
		public string? InnerExceptionMessage { get; set; }

		/// <summary>
		/// Получение всех сообщений со всех внутренних исключений
		/// </summary>
		/// <param name="exception">исключение</param>
		/// <param name="level">уровень исключения</param>
		/// <returns>сообщения со всех вложенных исключений</returns>
		private static string? GetInnerExceptionMessages(Exception? exception, int level = 1)
		{
			string? result = null;

			if(exception is not null)
			{
				result = $"Уровень исключения {level}:\"{exception.Message}\"" + Environment.NewLine;
				var innerMessage = GetInnerExceptionMessages(exception.InnerException, level + 1);
				if(innerMessage is not null)
				{
					result += innerMessage + Environment.NewLine;
				}
			}

			return result;
		}
	}
}
