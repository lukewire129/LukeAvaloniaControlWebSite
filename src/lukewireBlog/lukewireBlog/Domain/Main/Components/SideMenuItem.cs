using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Domain.Home.Components;

public class SideMenuItem : TemplatedControl
{
    public static readonly AvaloniaProperty TextProperty =
        AvaloniaProperty.Register<SideMenuItem, string>(nameof(Text));

    public string Text 
    {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public static readonly AvaloniaProperty CommandProperty =
        AvaloniaProperty.Register<SideMenuItem, ICommand?>(nameof(Command));

    public ICommand? Command 
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public SideMenuItem()
    {
        this.Tapped += (s, e) =>
        {
            this.Command?.Execute(this.DataContext);
        };
    }
}