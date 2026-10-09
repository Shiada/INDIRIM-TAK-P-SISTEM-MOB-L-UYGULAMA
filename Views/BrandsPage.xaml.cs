using Indirimci.Models;
using Indirimci.Services;

namespace Indirimci.Views;

public class BrandDisplayItem
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string CategoryId { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public string LogoText { get; set; } = "";
    public Color GradientStart { get; set; } = Colors.Gray;
    public Color GradientEnd { get; set; } = Colors.DarkGray;
    public List<string> SubCategories { get; set; } = new();
    public bool IsPopular { get; set; }
    public int ActiveDealCount { get; set; }
    public bool IsTracked { get; set; }
}

public partial class BrandsPage : ContentPage
{
    private readonly DataService _dataService;
    private readonly PreferenceService _prefService;
    private string _activeFilter = "all";
    private List<Brand> _allBrands = new();
    private List<Deal> _allDeals = new();

    public BrandsPage()
    {
        InitializeComponent();
        _dataService = App.DataService;
        _prefService = App.PrefService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _allBrands = _dataService.GetBrands();
        _allDeals = _dataService.GetDeals();
        BuildFilterChips();
        ApplyFilter();
    }

    private void BuildFilterChips()
    {
        FilterChips.Children.Clear();
        var categories = _dataService.GetCategories();

        AddChipButton("Tümü", "all");
        foreach (var cat in categories)
            AddChipButton($"{cat.Icon} {cat.Name}", cat.Id);
    }

    private void AddChipButton(string text, string filterId)
    {
        var btn = new Button
        {
            Text = text,
            Style = (Style)Application.Current!.Resources["ChipButton"],
            BackgroundColor = _activeFilter == filterId ? Color.FromArgb("#e94560") : Color.FromArgb("#16213e"),
            TextColor = _activeFilter == filterId ? Colors.White : Color.FromArgb("#a8b2d1"),
        };
        btn.Clicked += (s, e) =>
        {
            _activeFilter = filterId;
            BuildFilterChips();
            ApplyFilter();
        };
        FilterChips.Children.Add(btn);
    }

    private void ApplyFilter()
    {
        var filtered = _activeFilter == "all"
            ? _allBrands
            : _allBrands.Where(b => b.CategoryId == _activeFilter).ToList();

        var displayItems = filtered.Select(b => new BrandDisplayItem
        {
            Id = b.Id,
            Name = b.Name,
            CategoryId = b.CategoryId,
            CategoryName = _dataService.GetCategoryName(b.CategoryId),
            LogoText = b.LogoText,
            GradientStart = b.GradientStart,
            GradientEnd = b.GradientEnd,
            SubCategories = b.SubCategories,
            IsPopular = b.IsPopular,
            ActiveDealCount = _allDeals.Count(d => d.BrandId == b.Id),
            IsTracked = _prefService.IsBrandTracked(b.Id)
        }).ToList();

        BrandsCV.ItemsSource = displayItems;
    }

    private async void OnBrandTapped(object? sender, EventArgs e)
    {
        if (sender is Frame frame && frame.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is BrandDisplayItem brand)
        {
            await Shell.Current.GoToAsync($"branddetail?brandId={brand.Id}");
        }
    }
}
