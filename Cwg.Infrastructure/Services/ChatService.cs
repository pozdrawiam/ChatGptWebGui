using Cwg.Core.Services;
using OpenAI.Chat;

namespace Cwg.Infrastructure.Services;

public class ChatService : IChatService
{
    private ChatClient? _chat;

    public void Initialize(string apiKey, string model = "gpt-4o")
    {
        _chat = new ChatClient(model, apiKey);
    }

    public async Task<string> SendAsync(string msg)
    {
        if (_chat == null)
            throw new InvalidOperationException();
        
        ChatCompletion completion = await _chat.CompleteChatAsync(msg);

        return completion.ToString();
    }
}
