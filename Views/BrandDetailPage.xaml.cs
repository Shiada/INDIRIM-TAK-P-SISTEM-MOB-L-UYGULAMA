using Indirimci.Models;
using Indirimci.Services;

namespace Indirimci.Views;

[QueryProperty(nameof(BrandId), "brandId")]
public partial class BrandDetailPage : ContentPage
{
    private readonly DataService _dataService;
    private readonly PreferenceService _prefService;
    private Brand? _brand;
    private string _activeCategory = "all";

    public string BrandId { get; set; } = "";

    public BrandDetailPage()
    {
        InitializeComponent();
        _dataService = App.DataService;
        _prefService = App.PrefService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _brand = _dataService.GetBrands().FirstOrDefault(b => b.Id == BrandId);
        if (_brand != null)
            LoadBrandData();
    }

    private void LoadBrandData()
    {
        if (_brand == null) return;

        Title = _brand.Name;
        BrandLogoFrame.BackgroundColor = _brand.GradientStart;
        BrandLogoLabel.Text = _brand.LogoText;
        BrandNameLabel.Text = _brand.Name;
        BrandCategoryLabel.Text = _dataService.GetCategoryName(_brand.CategoryId);
        UpdateTrackButton();
        BuildCategoryChips();
        LoadDeals();
    }

    private void UpdateTrackButton()
    {
        if (_brand == null) return;
        bool isTracked = _prefService.IsBrandTracked(_brand.Id);
        TrackButton.Text = isTracked ? "✅ Takip Ediliyor" : "🔔 Takip Et";
        TrackButton.BackgroundColor = isTracked ? Color.FromArgb("#2ecc71") : Color.FromArgb("#e94560");
    }

    private void BuildCategoryChips()
    {
        if (_brand == null) return;
        BrandCategoryChips.Children.Clear();

        AddCatChip("Tümü", "all");
        foreach (var sc in _brand.SubCategories)
            AddCatChip(sc, sc);
    }

    private void AddCatChip(string text, string filterId)
    {
        var btn = new Button
        {
            Text = text,
            Style = (Style)Application.Current!.Resources["ChipButton"],
            BackgroundColor = _activeCategory == filterId ? Color.FromArgb("#e94560") : Color.FromArgb("#16213e"),
            TextColor = _activeCategory == filterId ? Colors.White : Color.FromArgb("#a8b2d1"),
        };
        btn.Clicked += (s, e) =>
        {
            _activeCategory = filterId;
            BuildCategoryChips();
            LoadDeals();
        };
        BrandCategoryChips.Children.Add(btn);
    }

    private void LoadDeals()
    {
        if (_brand == null) return;
        DealsContainer.Children.Clear();

        var deals = _dataService.GetDeals().Where(d => d.BrandId == _brand.Id);
        if (_activeCategory != "all")
            deals = deals.Where(d => d.Category == _activeCategory);

        var dealList = deals.ToList();
        EmptyState.IsVisible = dealList.Count == 0;

        foreach (var deal in dealList)
        {
            var frame = new Frame
            {
                CornerRadius = 16,
                BackgroundColor = Color.FromArgb("#16213e"),
                BorderColor = Color.FromArgb("#1f2b47"),
                HasShadow = false,
                Padding = new Thickness(12)
            };

            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition(60),
                    new ColumnDefinition(GridLength.Star)
                },
                ColumnSpacing = 12
            };

            var thumb = new Frame
            {
                WidthRequest = 60,
                HeightRequest = 60,
                CornerRadius = 12,
                Padding = 0,
                HasShadow = false,
                BackgroundColor = deal.BrandColorStart
            };
            thumb.Content = new Label { Text = deal.Icon, FontSize = 24, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            grid.Add(thumb, 0, 0);

            var info = new VerticalStackLayout { Spacing = 4, VerticalOptions = LayoutOptions.Center };
            info.Children.Add(new Label { Text = deal.Title, FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Colors.White });
            info.Children.Add(new Label { Text = deal.Category, FontSize = 11, TextColor = Color.FromArgb("#6c7a9c") });

            var bottom = new Grid { ColumnDefinitions = new ColumnDefinitionCollection { new(GridLength.Star), new(GridLength.Auto) } };
            bottom.Add(new Label { Text = deal.Discount, FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Color.FromArgb("#2ecc71") }, 0, 0);
            bottom.Add(new Label { Text = deal.TimeAgo, FontSize = 11, TextColor = Color.FromArgb("#6c7a9c") }, 1, 0);
            info.Children.Add(bottom);

            grid.Add(info, 1, 0);
            frame.Content = grid;

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) =>
            {
                await DisplayAlert($"{deal.BrandName} - {deal.Discount}",
                    $"{deal.Title}\n\n{deal.Description}\n\nKategori: {deal.Category}\n{deal.TimeAgo}",
                    "Tamam");
            };
            frame.GestureRecognizers.Add(tapGesture);

            DealsContainer.Children.Add(frame);
        }
    }

    private void OnTrackClicked(object? sender, EventArgs e)
    {
        if (_brand == null) return;
        _prefService.ToggleBrand(_brand.Id, _brand.SubCategories);
        UpdateTrackButton();

        bool isTracked = _prefService.IsBrandTracked(_brand.Id);
        DisplayAlert("Bildirim", isTracked ? $"{_brand.Name} takibe alındı! 🎉" : $"{_brand.Name} takipten çıkarıldı.", "Tamam");
    }
}
