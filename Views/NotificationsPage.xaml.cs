using Indirimci.Services;

namespace Indirimci.Views;

public partial class NotificationsPage : ContentPage
{
    private readonly DataService _dataService;

    public NotificationsPage()
    {
        InitializeComponent();
        _dataService = App.DataService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        NotificationsCV.ItemsSource = _dataService.GetSampleNotifications();
    }
}
