using Cwg.Core.Dto;

namespace Cwg.Core.Services;

public interface IChatDbService
{
    Task<IEnumerable<ChatInfo>> GetChatsAsync();
    Task<ChatSessionDto> GetChatSessionAsync(Guid id);
}
