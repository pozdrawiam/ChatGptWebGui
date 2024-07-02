namespace Cwg.Core.Services;

public interface IChatService
{
    void Initialize(string apiKey, string model = "gpt-4o");
    Task<string> SendAsync(string msg);
}
