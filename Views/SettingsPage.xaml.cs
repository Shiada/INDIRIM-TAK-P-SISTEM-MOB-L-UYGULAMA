using Indirimci.Models;
using Indirimci.Services;

namespace Indirimci.Views;

public partial class SettingsPage : ContentPage
{
    private readonly DataService _dataService;
    private readonly PreferenceService _prefService;

    public SettingsPage()
    {
        InitializeComponent();
        _dataService = App.DataService;
        _prefService = App.PrefService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BuildSettingsList();
    }

    private void BuildSettingsList()
    {
        BrandsSettingsList.Children.Clear();
        var brands = _dataService.GetBrands();

        foreach (var brand in brands)
        {
            bool isTracked = _prefService.IsBrandTracked(brand.Id);

            var mainFrame = new Frame
            {
                CornerRadius = 16,
                BackgroundColor = Color.FromArgb("#16213e"),
                BorderColor = isTracked ? Color.FromArgb("#e94560") : Color.FromArgb("#1f2b47"),
                HasShadow = false,
                Padding = 0
            };

            var container = new VerticalStackLayout();

            // Brand header row
            var headerGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new(44), new(GridLength.Star), new(52)
                },
                ColumnSpacing = 12,
                Padding = new Thickness(16)
            };

            // Logo
            var logoFrame = new Frame
            {
                WidthRequest = 44,
                HeightRequest = 44,
                CornerRadius = 10,
                Padding = 0,
                HasShadow = false,
                BackgroundColor = brand.GradientStart
            };
            logoFrame.Content = new Label
            {
                Text = brand.LogoText,
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            headerGrid.Add(logoFrame, 0, 0);

            // Brand info
            var brandInfo = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 2
            };
            brandInfo.Children.Add(new Label
            {
                Text = brand.Name,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.White
            });
            brandInfo.Children.Add(new Label
            {
                Text = _dataService.GetCategoryName(brand.CategoryId),
                FontSize = 11,
                TextColor = Color.FromArgb("#6c7a9c")
            });
            headerGrid.Add(brandInfo, 1, 0);

            // Toggle switch
            var toggleSwitch = new Switch
            {
                IsToggled = isTracked,
                OnColor = Color.FromArgb("#e94560"),
                ThumbColor = Colors.White,
                VerticalOptions = LayoutOptions.Center
            };
            var brandId = brand.Id;
            var brandSubs = brand.SubCategories;
            toggleSwitch.Toggled += (s, e) =>
            {
                _prefService.ToggleBrand(brandId, brandSubs);
                BuildSettingsList(); // Rebuild to show/hide categories
            };
            headerGrid.Add(toggleSwitch, 2, 0);

            container.Children.Add(headerGrid);

            // Sub-categories (only shown when tracked)
            if (isTracked)
            {
                var catContainer = new VerticalStackLayout
                {
                    Padding = new Thickness(16, 0, 16, 12),
                    Spacing = 2
                };

                var divider = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.FromArgb("#1f2b47"),
                    Margin = new Thickness(0, 0, 0, 8)
                };
                catContainer.Children.Add(divider);

                foreach (var subCat in brand.SubCategories)
                {
                    bool isCatSelected = _prefService.IsCategorySelected(brand.Id, subCat);

                    var catGrid = new Grid
                    {
                        ColumnDefinitions = new ColumnDefinitionCollection
                        {
                            new(GridLength.Star), new(GridLength.Auto)
                        },
                        Padding = new Thickness(8, 6)
                    };

                    catGrid.Add(new Label
                    {
                        Text = subCat,
                        FontSize = 14,
                        TextColor = isCatSelected ? Colors.White : Color.FromArgb("#6c7a9c"),
                        VerticalOptions = LayoutOptions.Center
                    }, 0, 0);

                    var checkbox = new CheckBox
                    {
                        IsChecked = isCatSelected,
                        Color = Color.FromArgb("#e94560"),
                        VerticalOptions = LayoutOptions.Center
                    };
                    var catName = subCat;
                    checkbox.CheckedChanged += (s, e) =>
                    {
                        _prefService.ToggleCategory(brandId, catName, brandSubs);
                        BuildSettingsList();
                    };
                    catGrid.Add(checkbox, 1, 0);

                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += (s, e) =>
                    {
                        _prefService.ToggleCategory(brandId, catName, brandSubs);
                        BuildSettingsList();
                    };
                    catGrid.GestureRecognizers.Add(tapGesture);

                    catContainer.Children.Add(catGrid);
                }

                container.Children.Add(catContainer);
            }

            mainFrame.Content = container;
            BrandsSettingsList.Children.Add(mainFrame);
        }
    }
}
