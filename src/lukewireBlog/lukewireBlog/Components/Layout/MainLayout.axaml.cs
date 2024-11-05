using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Components.Layout;

public partial class MainLayout : UserControl
{
    public MainLayout()
    {
        InitializeComponent();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
    }

    public void ChnageScroolHeight(bool NoneScrollViewer = false)
    {
    }
}