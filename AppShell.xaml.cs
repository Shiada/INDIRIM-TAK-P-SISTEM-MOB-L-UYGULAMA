namespace Indirimci;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("branddetail", typeof(Views.BrandDetailPage));
    }
}
