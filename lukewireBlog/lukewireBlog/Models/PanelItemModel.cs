using System;
using lukewireBlog.Services.Models;

namespace lukewireBlog.Models;

public class PanelItemModel
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Date { get; set; }

    public PanelItemModel(Metadata metadata)
    {
        this.Title = metadata.Title;
        this.SubTitle = metadata.Subtitle;
        TimeSpan dateDiff = metadata.Date.Value - DateTime.Now;

        var tempDiffTotalDay = Math.Abs(dateDiff.TotalDays);
        if (tempDiffTotalDay == 0)
        {
            this.Date = $"방금 전";
        }
        else if (tempDiffTotalDay < 7)
        {
            this.Date = $"{dateDiff.Days}일 전";
        }
        else if (tempDiffTotalDay < 14)
        {
            this.Date = $"1 주 전";
        }
        else if (tempDiffTotalDay < 21)
        {
            this.Date = $"2 주 전";
        }
        else
        {
            this.Date = $"{Math.Ceiling(tempDiffTotalDay / 30)} 개월 전";
        }
    }
}