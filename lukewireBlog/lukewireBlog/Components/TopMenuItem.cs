using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Components;

public class TopMenuItem : TemplatedControl
{
    public static readonly AvaloniaProperty TextProperty =
        AvaloniaProperty.Register<TopMenuItem, string>(nameof(Text));

    public string Text 
    {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public static readonly AvaloniaProperty CommandProperty =
        AvaloniaProperty.Register<TopMenuItem, ICommand?>(nameof(Command));

    public ICommand? Command 
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public TopMenuItem()
    {
        this.Tapped += (s, e) =>
        {
            this.Command?.Execute(this.DataContext);
        };
    }
}