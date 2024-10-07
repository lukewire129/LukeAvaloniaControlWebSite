using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Components;

public class MarkdownViewer : TemplatedControl
{
    public static readonly AvaloniaProperty TextProperty =
        AvaloniaProperty.Register<MarkdownViewer, string>(nameof(Text));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}