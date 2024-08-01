namespace Cwg.Core.Dto;

public class ChatInfo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "New chat";
}
