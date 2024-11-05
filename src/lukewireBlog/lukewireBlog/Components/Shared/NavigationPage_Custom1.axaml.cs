using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using AvaloniaNavigationBar.Style;
using lukewireBlog.Domain.NavigationView.Components.ViewModels;

namespace lukewireBlog.Components.Shared;

public class NavigationPage_Custom1 : TemplatedControl
{
    public NavigationPage_Custom1()
    {
        this.DataContext = new _BottomNavigationBarStyle2ViewModel();
    } 
    private BottomNavigatorBarStyle2 _magicBar = null!;
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        
        _magicBar = e.NameScope.Get<BottomNavigatorBarStyle2>("PART_NAVI");
        
        var tm = new Timer();
        
        tm.Interval = 1000;
        int i = 1;
        tm.Elapsed += (s, e) =>
        {
            if (i == 5)
            {
                i = 0;
            }

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                _magicBar.SelectedIndex = i++;
            });
        };
        tm.Start(); 
    }
}