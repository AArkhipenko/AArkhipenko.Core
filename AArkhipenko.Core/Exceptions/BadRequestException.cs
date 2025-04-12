namespace AArkhipenko.Core.Exceptions
{
	/// <summary>
	/// Класс исключения для случаев, когда имеется ошибка в параметрах
	/// </summary>
	public class BadRequestException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		public BadRequestException(): base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="message">сообщение об ошибке</param>
		public BadRequestException(string message): base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="message">сообщение об ошибке</param>
		/// <param name="innerException">внутреннее исключение</param>
		public BadRequestException(string message, Exception innerException): base(message, innerException) { }
	}
}
