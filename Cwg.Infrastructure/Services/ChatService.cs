using Cwg.Core.Dto;
using Cwg.Core.Services;
using OpenAI.Chat;

namespace Cwg.Infrastructure.Services;

public class ChatService : IChatService
{
    private ChatClient? _chat;

    public async Task CompleteChatAsync(ChatSessionDto chatSession)
    {
        IEnumerable<ChatMessage> messages = chatSession.Messages.Select(x =>
            x.Type == ChatMessageType.Assistant ? new AssistantChatMessage(x.Message) as ChatMessage : new UserChatMessage(x.Message)
        );

        if (_chat == null)
            throw new InvalidOperationException();
        
        ChatCompletion completion = await _chat.CompleteChatAsync(messages);

        string? message = completion.ToString();
        
        chatSession.Messages.Add(new ChatMessageDto
        {
            Message = message,
            Type = ChatMessageType.Assistant
        });
    }

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
