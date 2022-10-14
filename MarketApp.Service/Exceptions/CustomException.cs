namespace MarketApp.Service.Exceptions;

public class CustomException : Exception
{
    public int Code;
    public CustomException(int code, string message)
        : base(message)
    {
        Code = code;
    }
}
