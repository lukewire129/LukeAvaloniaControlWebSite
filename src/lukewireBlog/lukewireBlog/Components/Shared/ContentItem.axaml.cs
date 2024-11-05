using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Components.Shared;

public class ContentItem : Button
{
    public static readonly AvaloniaProperty CommandProperty =
        AvaloniaProperty.Register<ContentItem, ICommand?>(nameof(BorderBrush));

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        
        var tb = e.NameScope.Get<TextBlock>("PART_Detail");

        tb.Tapped += (s, e) =>
        {
            Command?.Execute(this.DataContext);
        };
    }
}