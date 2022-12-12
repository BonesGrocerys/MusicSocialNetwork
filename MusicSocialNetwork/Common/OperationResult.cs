namespace MusicSocialNetwork.Common;

public class OperationResult
{
    public bool Success => ErrorCode == 0;
    public OperationCode ErrorCode { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }

    public static OperationResult OK => new OperationResult();
    public static OperationResult Fail(OperationCode errorCode, string message = null, string stackTrace = null)
        => new OperationResult(errorCode, message, stackTrace);

    protected OperationResult()
    {
    }

    public OperationResult(OperationCode errorCode, string message = null, string stackTrace = null)
    {
        ErrorCode = errorCode;
        Message = message;
        StackTrace = stackTrace;
    }
}

public class OperationResult<T> : OperationResult
{
    public T Result { get; set; }

    public static new OperationResult<T> Fail(OperationCode errorCode, string message = null, string stackTrace = null)
        => new OperationResult<T>(errorCode, message, stackTrace);

    public OperationResult()
    {
    }

    public OperationResult(T result)
    {
        Result = result;
    }

    public OperationResult(OperationCode errorCode, string message = null, string stackTrace = null)
        : base(errorCode, message, stackTrace)
    {
    }
}

public enum OperationCode
{
    Ok = 1,
    UnhandledError = 2,
    Error = 3,
    ValidationError = 4,
    EntityWasNotFound = 5,
    AlreadyExists = 6,
    Unauthorized = 7,
    Forbidden = 8
}
