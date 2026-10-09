namespace Indirimci.Models;

public class UserPreference
{
    public string BrandId { get; set; } = string.Empty;
    public bool Enabled { get; set; }
    public List<string> SelectedCategories { get; set; } = new();
}

public class BrandPreferenceItem
{
    public string BrandId { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string LogoText { get; set; } = string.Empty;
    public Color GradientStart { get; set; } = Colors.Gray;
    public Color GradientEnd { get; set; } = Colors.DarkGray;
    public bool IsEnabled { get; set; }
    public List<CategoryPreferenceItem> Categories { get; set; } = new();
}

public class CategoryPreferenceItem
{
    public string BrandId { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public bool IsSelected { get; set; }
}
