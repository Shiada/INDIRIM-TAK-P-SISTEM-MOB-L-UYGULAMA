namespace Indirimci.Models;

public class Deal
{
    public string Id { get; set; } = string.Empty;
    public string BrandId { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Discount { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string TimeAgo { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public bool IsNew { get; set; }
    public bool IsTrending { get; set; }
    public Color BrandColorStart { get; set; } = Colors.Gray;
    public Color BrandColorEnd { get; set; } = Colors.DarkGray;
}
