namespace SantaApi.Helpers
{
    public class ServiceResult<T>
    {
        public ServiceResult() { }
        
        public ServiceResult(bool isSuccess, T data, string message = "", int dataCount = 0)
        {
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
            DataCount = dataCount;
        }

        /// <summary>
        /// Конструктор для ошибки (стандартизированный)
        /// </summary>
        /// <param name="response"></param>
        public ServiceResult(ErrorResponse response)
        {
            Error = response;
            IsSuccess = false;
        }

        /// <summary>
        /// Конструктор для ошибки (старый)
        /// </summary>
        /// <param name="message"></param>
        public ServiceResult(string message)
        {
            Message = message;
            IsSuccess = false;
        }

        /// <summary>
        /// Выполнил ли сервис работу без ошибок
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение (в случае ошибки)
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Количество записей
        /// </summary>
        public int DataCount { get; set; }

        /// <summary>
        /// Объект ошибка
        /// </summary>
        public ErrorResponse Error { get; set; }
    }
}