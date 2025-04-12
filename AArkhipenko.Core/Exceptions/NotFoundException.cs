namespace AArkhipenko.Core.Exceptions
{
	/// <summary>
	/// Класс исключения для случаев, когда не найден объект
	/// </summary>
	public class NotFoundException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NotFoundException"/> class.
		/// </summary>
		public NotFoundException(): base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotFoundException"/> class.
		/// </summary>
		/// <param name="message">сообщение об ошибке</param>
		public NotFoundException(string message): base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotFoundException"/> class.
		/// </summary>
		/// <param name="message">сообщение об ошибке</param>
		/// <param name="innerException">внутреннее исключение</param>
		public NotFoundException(string message, Exception innerException): base(message, innerException) { }
	}
}
