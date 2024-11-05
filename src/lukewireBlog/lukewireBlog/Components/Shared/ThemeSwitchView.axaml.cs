using System.Timers;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using lukewireBlog.ViewModels;

namespace lukewireBlog.Components.Shared;

public class ThemeSwitchView : TemplatedControl
{
    public ThemeSwitchView()
    {
        this.DataContext = new ThemeSwitchViewModel();
    }
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        
        var toggleButton = e.NameScope.Get<ToggleButton>("PART_tg");
        
        var tm = new Timer();
        
        tm.Interval = 1000;
        tm.Elapsed += (s, e) =>
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                toggleButton.IsChecked = ! toggleButton.IsChecked ;
            });
        };
        tm.Start(); 
    }
}