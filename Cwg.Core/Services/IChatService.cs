using Cwg.Core.Dto;

namespace Cwg.Core.Services;

public interface IChatService
{
    Task CompleteChatAsync(ChatSessionDto chatSession);
    void Initialize(string apiKey, string model = "gpt-4o");
    Task<string> SendAsync(string msg);
}
