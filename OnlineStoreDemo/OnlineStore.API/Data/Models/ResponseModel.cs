namespace OnlineStore.API.Data.Models;
public class ResponseModel
{
    public bool IsSuccess { get; }

    public string Message { get; }

    public int StatusCode { get; set; } = StatusCodes.Status200OK;

    public ResponseModel(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public ResponseModel(bool isSuccess, string message, int statusCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
    }

    public static ResponseModel ReturnSuccess()
    {
        return new ResponseModel(true);
    }

    public static ResponseModel ReturnFailed(string message)
    {
        return new ResponseModel(false, message, StatusCodes.Status400BadRequest);
    }

    public static ResponseModel ReturnNotFound(string message)
    {
        return new ResponseModel(false, message, StatusCodes.Status404NotFound);
    }
}


public class ResponseResult<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
}
