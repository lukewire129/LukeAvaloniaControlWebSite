using lukewireBlog.Services;
using lukewireBlog.ViewModels;

namespace lukewireBlog.ViewModels;

public class BlogViewModel : ViewModelBase
{
    public BlogViewModel(IContentService contentService) : base(contentService)
    {
    }
}