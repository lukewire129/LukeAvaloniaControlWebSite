using CommunityToolkit.Mvvm.Messaging.Messages;
using lukewireBlog.Models;

namespace lukewireBlog.ViewModels.MessengerModel;

public class ReadmBlogChange:ValueChangedMessage<PanelItemModel>
{
    public ReadmBlogChange(PanelItemModel value) : base(value)
    {
    }
}