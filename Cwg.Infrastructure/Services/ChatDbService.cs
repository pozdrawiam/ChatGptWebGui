using Blazored.LocalStorage;
using Cwg.Core.Dto;
using Cwg.Core.Services;

namespace Cwg.Infrastructure.Services;

public class ChatDbService(ILocalStorageService storageService) : IChatDbService
{
    private const string ChatsKey = "Chats";
    
    public async Task<IEnumerable<ChatInfo>> GetChatsAsync()
    {
        var chats = await storageService.GetItemAsync<ChatInfo[]>(ChatsKey);
        
        return chats ?? ArraySegment<ChatInfo>.Empty;
    }

    public Task<ChatSessionDto> GetChatSessionAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddChat(ChatInfo chatInfo)
    {
        List<ChatInfo> chats = (await GetChatsAsync()).ToList();
        
        chats.Add(chatInfo);

        await storageService.SetItemAsync(ChatsKey, chats);
    }
}
