namespace Indirimci.Models;

public class Category
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public Color GradientStart { get; set; } = Colors.Purple;
    public Color GradientEnd { get; set; } = Colors.Blue;
    public List<string> SubCategories { get; set; } = new();
    public int BrandCount { get; set; }
}
