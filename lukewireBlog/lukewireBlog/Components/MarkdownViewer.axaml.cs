using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;
using TheArtOfDev.HtmlRenderer.Avalonia;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.Core.Entities;

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

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        // HtmlPanel _htmlPanel  = e.NameScope.Get<HtmlPanel>("_htmlPanel") as HtmlPanel;
        //
        // var fontKey = "NotoSansKR"; // 불러오고자 하는 리소스의 키
        // ThemeVariant currentTheme = Application.Current.ActualThemeVariant;
        // if (Application.Current.Resources.TryGetResource(fontKey, currentTheme, out var fontResource))
        // {
        //     // 리소스가 성공적으로 불러와졌을 경우
        //     var myResource = (FontFamily)fontResource;
        //     _htmlPanel.AddFontFamily(myResource);
        //     
        //     
        // }
    }
}