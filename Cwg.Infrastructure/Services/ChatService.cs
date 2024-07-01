using Cwg.Core.Services;
using OpenAI.Chat;

namespace Cwg.Infrastructure.Services;

public class ChatService : IChatService
{
    private readonly ChatClient _chat;

    public ChatService()
    {
        _chat = new ChatClient(model: "gpt-4o", Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "");
    }

    public string Send(string msg)
    {
        ChatCompletion completion = _chat.CompleteChat(msg);

        return completion.ToString();
    }
}
