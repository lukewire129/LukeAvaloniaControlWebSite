using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Components;

public class BlogPanelItem : TemplatedControl
{
    public static readonly AvaloniaProperty CommandProperty =
        AvaloniaProperty.Register<BlogPanelItem, ICommand?>(nameof(Command));

    public ICommand? Command 
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    public BlogPanelItem()
    {
        this.Tapped += (s, e) =>
        {
            this.Command?.Execute(this.DataContext);
        };
    }
}