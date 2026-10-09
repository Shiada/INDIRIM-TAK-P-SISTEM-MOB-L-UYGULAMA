using Indirimci.Models;
using Indirimci.Services;

namespace Indirimci.Views;

public partial class HomePage : ContentPage
{
    private readonly DataService _dataService;
    private readonly PreferenceService _prefService;

    public HomePage()
    {
        InitializeComponent();
        _dataService = App.DataService;
        _prefService = App.PrefService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }

    private void LoadData()
    {
        var deals = _dataService.GetDeals();
        var brands = _dataService.GetBrands();
        var categories = _dataService.GetCategories();

        // Stats
        LblActiveDealCount.Text = deals.Count.ToString();
        LblTrackedBrandCount.Text = _prefService.GetTrackedBrandCount().ToString();
        LblNewDealCount.Text = deals.Count(d => d.IsNew).ToString();

        // Categories
        CategoriesLayout.Children.Clear();
        foreach (var cat in categories)
        {
            var frame = new Frame
            {
                CornerRadius = 16,
                Padding = new Thickness(16),
                HasShadow = false,
                Margin = new Thickness(4),
                WidthRequest = (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density / 2) - 24,
                HeightRequest = 90,
                BackgroundColor = Color.FromArgb("#16213e"),
                BorderColor = Color.FromArgb("#1f2b47")
            };

            var stack = new VerticalStackLayout { Spacing = 4 };
            stack.Children.Add(new Label { Text = cat.Icon, FontSize = 28 });
            stack.Children.Add(new Label { Text = cat.Name, FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Colors.White });
            stack.Children.Add(new Label { Text = $"{cat.BrandCount} marka", FontSize = 11, TextColor = Color.FromArgb("#6c7a9c") });
            frame.Content = stack;

            var tapGesture = new TapGestureRecognizer();
            var catId = cat.Id;
            tapGesture.Tapped += async (s, e) =>
            {
                await Shell.Current.GoToAsync("//brands");
            };
            frame.GestureRecognizers.Add(tapGesture);

            CategoriesLayout.Children.Add(frame);
        }

        // Trending Deals
        TrendingDealsCV.ItemsSource = deals.Where(d => d.IsTrending).ToList();

        // Popular Brands
        var popularBrands = brands.Where(b => b.IsPopular).ToList();
        foreach (var brand in popularBrands)
        {
            brand.ActiveDealCount = deals.Count(d => d.BrandId == brand.Id);
            brand.IsTracked = _prefService.IsBrandTracked(brand.Id);
        }
        PopularBrandsCV.ItemsSource = popularBrands;

        // New Deals
        NewDealsCV.ItemsSource = deals.Where(d => d.IsNew).ToList();
    }

    private async void OnDealTapped(object? sender, EventArgs e)
    {
        if (sender is Frame frame && frame.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is Deal deal)
        {
            await DisplayAlert($"{deal.BrandName} - {deal.Discount}",
                $"{deal.Title}\n\n{deal.Description}\n\nKategori: {deal.Category}\n{deal.TimeAgo}",
                "Tamam");
        }
    }

    private async void OnBrandTapped(object? sender, EventArgs e)
    {
        if (sender is Frame frame && frame.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is Brand brand)
        {
            await Shell.Current.GoToAsync($"branddetail?brandId={brand.Id}");
        }
    }

    private async void OnSeeAllBrandsClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//brands");
    }
}
