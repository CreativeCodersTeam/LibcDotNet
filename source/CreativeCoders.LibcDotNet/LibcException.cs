namespace CreativeCoders.LibcDotNet;

public class LibcException : Exception
{
    public LibcException(int errorNum)
        : this(errorNum, LibcFunctions.GetErrorString(errorNum))
    {
    }
    
    public LibcException(int errorNum, string errorText)
    {
        ErrorNum = errorNum;

        ErrorText = errorText;
    }

    public string ErrorText { get; }

    public int ErrorNum { get; }
}