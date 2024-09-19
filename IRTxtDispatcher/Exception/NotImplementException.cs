namespace IRTxtDispatcher.Exceptions;
public class NotImplementException : Exception
{
    public NotImplementException()
    {

    }
    public NotImplementException(string implementTypeTitle)
    : base(implementTypeTitle)
    {

    }
    public NotImplementException(string implementTypeTitle, Exception innerException)
    : base(implementTypeTitle, innerException)
    {

    }
}