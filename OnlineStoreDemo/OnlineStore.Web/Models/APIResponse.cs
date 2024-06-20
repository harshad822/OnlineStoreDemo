namespace OnlineStore.Web.Models;
public class APIResponse
{
    public string Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class APIResponse<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
}

