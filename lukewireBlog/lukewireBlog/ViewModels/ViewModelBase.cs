using System.Threading.Tasks;
using lukewireBlog.Services;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected readonly IContentService _contentService;
    public ViewModelBase(IContentService contentService)
    {
        _contentService = contentService;
    }
    public virtual void Load()
    {
        Task.Run(async () =>
        {
            await _contentService.GetAllPosts();

        });
    }
}