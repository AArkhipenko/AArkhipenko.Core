using System.Text;

namespace AArkhipenko.Core.Models
{
    /// <summary>
    /// Модель раздела логирования
    /// </summary>
    public class MethodLogModel
    {
        /// <summary>
        /// Название класса, из которого был выполнен вызов
        /// </summary>
        public string ClassName { get; set; } = "unknown";

        /// <summary>
        /// Название метода, из которого был выполнен вызов
        /// </summary>
        public string MethodName { get; set; } = "unknown";

        /// <summary>
        /// Преобразование в строку
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(ClassName);
            builder.Append(".");
            builder.Append(MethodName);

            return builder.ToString();
        }
    }
}
