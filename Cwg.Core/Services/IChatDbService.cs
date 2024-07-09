using Cwg.Core.Dto;

namespace Cwg.Core.Services;

public interface IChatDbService
{
    IEnumerable<ChatInfo> GetChats();
    ChatSessionDto GetChatSession(Guid id);
}
