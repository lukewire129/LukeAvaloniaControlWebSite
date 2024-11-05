using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using AvaloniaNavigationBar.Style;

namespace lukewireBlog.Components.Shared;

public class NavigationView_Custom1 : TemplatedControl
{
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