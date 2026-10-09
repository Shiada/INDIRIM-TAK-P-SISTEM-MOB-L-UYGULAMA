namespace Indirimci.Models;

public class Brand
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public string LogoText { get; set; } = string.Empty;
    public Color GradientStart { get; set; } = Colors.Gray;
    public Color GradientEnd { get; set; } = Colors.DarkGray;
    public List<string> SubCategories { get; set; } = new();
    public bool IsPopular { get; set; }
    public int ActiveDealCount { get; set; }
    public bool IsTracked { get; set; }
}
