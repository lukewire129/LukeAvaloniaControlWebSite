using AvaloniaNavigationView.ViewModels;

namespace lukewireBlog.Domain.NavigationView.Components.ViewModels;

public class NaviViewMOdel : NavigationViewModel
{
    public string Title { get; }
    public NaviViewMOdel(string title)
    {
            this.Title = title; 
    }
}