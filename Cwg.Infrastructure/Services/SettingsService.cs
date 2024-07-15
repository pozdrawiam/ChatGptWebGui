using Blazored.LocalStorage;
using Cwg.Core.Dto;
using Cwg.Core.Services;

namespace Cwg.Infrastructure.Services;

public class SettingsService(ILocalStorageService storageService) : ISettingsService
{
    private const string SettingsKey = "Settings";

    public async Task<SettingsDto> GetAsync()
    {
        var settingsDto = await storageService.GetItemAsync<SettingsDto>(SettingsKey) ??
                          new SettingsDto();

        return settingsDto;
    }

    public async Task SaveAsync(SettingsDto settingsDto)
    {
        await storageService.SetItemAsync(SettingsKey, settingsDto);
    }
}
