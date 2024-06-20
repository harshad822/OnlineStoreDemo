using Newtonsoft.Json;
using OnlineStore.Web.Models;

namespace OnlineStore.Web.Helper;
public class BaseMethod
{
    /// <summary>
    /// Description: To handle API response 
    /// </summary>
    /// <param name="responseMessage"></param>    
    public static async Task<APIResponse<T>> DeserializeApiResponseAsync<T>(
        HttpResponseMessage responseMessage)
    {
        var result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        var response = JsonConvert.DeserializeObject<APIResponse<T>>(result);
        return response;
    }
}
