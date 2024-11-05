using CommunityToolkit.Mvvm.Messaging.Messages;

namespace lukewireBlog.Models.Messenger;

public class RouteChangeMessage : ValueChangedMessage<RouteModel>
{
    public RouteChangeMessage(RouteModel value) : base(value)
    {
    }
}