using Avalonia.Controls;
using Avalonia.Input;
using ExCSS;

namespace lukewireBlog.Domain.Main;

public partial class Index : UserControl
{
    public Index()
    {
        InitializeComponent();

        this.grdTop.SizeChanged += (s, e) =>
        {
                this.sideMenu.IsVisible = !(e.NewSize.Width < 900);
                if (this.sideMenu.IsVisible == true)
                {
                    pannel.IsVisible = false;
                }
        };
    }

    private void Ico_OnTapped(object? sender, TappedEventArgs e)
    {
        pannel.IsVisible = !pannel.IsVisible;
    }
}