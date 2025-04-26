namespace AArkhipenko.Core.Exceptions
{
	/// <summary>
	/// Класс исключения для случаев ошибки авторизации
	/// </summary>
	public class AuthorizationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NotFoundException"/> class.
		/// </summary>
		public AuthorizationException(): base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotFoundException"/> class.
		/// </summary>
		/// <param name="message">сообщение об ошибке</param>
		public AuthorizationException(string message): base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotFoundException"/> class.
		/// </summary>
		/// <param name="message">сообщение об ошибке</param>
		/// <param name="innerException">внутреннее исключение</param>
		public AuthorizationException(string message, Exception innerException): base(message, innerException) { }
	}
}
