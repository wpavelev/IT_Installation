namespace Services.Interface
{
    public interface IApiRequestService
    {
        Task<T> Request<T>(HttpMethod method, string endpoint, string body = null);
    }
}