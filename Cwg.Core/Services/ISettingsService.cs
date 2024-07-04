using Cwg.Core.Dto;

namespace Cwg.Core.Services;

public interface ISettingsService
{
    Task<SettingsDto> GetAsync();
    Task SaveAsync(SettingsDto settingsDto);
}
