namespace lukewireBlog.Models.Messenger;

public class RouteModel
{
    public object Data { get; }
    public object Sender { get; }
    public RouteModel(object sender, object data)
    {
        this.Sender = sender;
        this.Data = data;   
    }
}