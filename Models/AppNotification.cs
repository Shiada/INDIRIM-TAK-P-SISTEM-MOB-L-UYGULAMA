namespace Indirimci.Models;

public class AppNotification
{
    public string Id { get; set; } = string.Empty;
    public string BrandId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public bool IsUnread { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string? DealId { get; set; }
    public Color BrandColorStart { get; set; } = Colors.Gray;
    public Color BrandColorEnd { get; set; } = Colors.DarkGray;
}
