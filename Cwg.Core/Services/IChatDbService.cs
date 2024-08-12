using Cwg.Core.Dto;

namespace Cwg.Core.Services;

public interface IChatDbService
{
    Task<IEnumerable<ChatInfo>> GetChatsAsync();
    Task<ChatSessionDto> GetChatSessionAsync(Guid id);
    Task UpdateChatSessionAsync(Guid id, ChatSessionDto chatSession);
    Task AddChatAsync(ChatInfo chatInfo);
    Task DeleteChatAsync(Guid chatId);
    Task UpdateChatAsync(ChatInfo chatInfo);
}
