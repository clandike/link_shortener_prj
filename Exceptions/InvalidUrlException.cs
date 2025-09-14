namespace UrlShortener.Exceptions
{
    public class InvalidUrlException : Exception
    {
        public InvalidUrlException() { }

        public InvalidUrlException(string message) : base(message) { }
    }
}
