namespace TheShop.Application.Common.Exceptions
{
    public class CouldNotSaveArticleException : Exception
    {
        public CouldNotSaveArticleException() { }

        public CouldNotSaveArticleException(string? message) : base(message)
        {
        }

        public CouldNotSaveArticleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
