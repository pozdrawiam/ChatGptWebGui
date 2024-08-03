using Blazored.LocalStorage;
using Cwg.Core.Dto;
using Cwg.Core.Services;

namespace Cwg.Infrastructure.Services;

public class ChatDbService(ILocalStorageService storageService) : IChatDbService
{
    private const string ChatsKey = "Chats";
    private const string ChatSessionKeyPrefix = "ChatSession_";
    
    public async Task<IEnumerable<ChatInfo>> GetChatsAsync()
    {
        var chats = await storageService.GetItemAsync<ChatInfo[]>(ChatsKey);
        
        return chats ?? ArraySegment<ChatInfo>.Empty;
    }

    public async Task<ChatSessionDto> GetChatSessionAsync(Guid id)
    {
        ChatSessionDto? chatSession = await storageService.GetItemAsync<ChatSessionDto>($"{ChatSessionKeyPrefix}{id}");

        return chatSession ?? new();
    }

    public async Task AddChatAsync(ChatInfo chatInfo)
    {
        List<ChatInfo> chats = (await GetChatsAsync()).ToList();
        
        chats.Add(chatInfo);

        await storageService.SetItemAsync(ChatsKey, chats);
    }

    public async Task DeleteChatAsync(Guid chatId)
    {
        List<ChatInfo> chats = (await GetChatsAsync()).ToList();

        var chatToDelete = chats.FirstOrDefault(x => x.Id == chatId);

        if (chatToDelete == null)
            return;

        chats.Remove(chatToDelete);

        await storageService.SetItemAsync(ChatsKey, chats);
    }

    public async Task UpdateChatAsync(ChatInfo chatInfo)
    {
        List<ChatInfo> chats = (await GetChatsAsync()).ToList();

        var chatToUpdate = chats.FirstOrDefault(x => x.Id == chatInfo.Id);

        if (chatToUpdate == null)
            return;

        chatToUpdate.Title = chatInfo.Title;

        await storageService.SetItemAsync(ChatsKey, chats);
    }
}
