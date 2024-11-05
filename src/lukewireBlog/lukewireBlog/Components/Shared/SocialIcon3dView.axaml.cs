using System.Collections.Generic;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Threading;
using AvaloniaEdit.Utils;

namespace lukewireBlog.Components.Shared;

public class SocialIcon3dView : TemplatedControl
{
    private ContentControl PART_faceBook;
    private ContentControl PART_twitter;
    private ContentControl PART_instagram;
    private ContentControl PART_linkedin;
    private ContentControl PART_youtube;

    private List<ContentControl> icons;
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        icons = new();
        this.PART_faceBook = e.NameScope.Get<ContentControl>("PART_faceBook");
        this.PART_twitter = e.NameScope.Get<ContentControl>("PART_twitter");
        this.PART_instagram =e.NameScope.Get<ContentControl>("PART_instagram");
        this.PART_linkedin =e.NameScope.Get<ContentControl>("PART_linkedin");
        this.PART_youtube = e.NameScope.Get<ContentControl>("PART_youtube");
        icons.Add((this.PART_faceBook));
        icons.Add((this.PART_twitter));
        icons.Add((this.PART_instagram));
        icons.Add((this.PART_linkedin));
        icons.Add((this.PART_youtube));
        
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            TriggerPointerOver(icons[0]);
        });
        int i = 0;
        var tm = new Timer();
        tm.Interval = 1000;
        tm.Elapsed += (s, e) =>
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (i == 4)
                {
                    RemovePointerOver(icons[4]);
                    TriggerPointerOver(icons[0]);
                    i = 0;
                    return;
                }
                RemovePointerOver(icons[i]);    
                TriggerPointerOver(icons[i+1]);
                i++;
            });
        };
        tm.Start(); 
    }
    public void TriggerPointerOver(Control childControl)
    {
        // "pointerover" 가상 클래스를 추가하여 PointerOver 상태를 시뮬레이션
        ((IPseudoClasses)childControl.Classes).Add(":pointerover");
    }

// PointerOver 상태를 제거할 때는 다음과 같이 제거
    public void RemovePointerOver(Control childControl)
    {
        ((IPseudoClasses)childControl.Classes).Remove(":pointerover");
    }
}