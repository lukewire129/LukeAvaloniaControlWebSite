namespace lukewireBlog.Services;

public class _Readme
{
    protected string _path;

    public _Readme()
    {
        
    }
    public _Readme(string path)
    {
        _path = path;
    }
    
    public string GetPath() => _path;
    
}