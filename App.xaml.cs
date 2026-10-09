using Indirimci.Services;

namespace Indirimci;

public partial class App : Application
{
    public static DataService DataService { get; } = new();
    public static PreferenceService PrefService { get; } = new();

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}