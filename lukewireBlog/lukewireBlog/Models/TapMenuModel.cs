namespace lukewireBlog.Models;

public class TapMenuModel
{
    public int Idx { get; set; }
    public string Name { get; set; }

    public TapMenuModel()
    {
        
    }
    public TapMenuModel(int idx, string name)
    {
        this.Idx = idx;
        this.Name = name;
    }
}