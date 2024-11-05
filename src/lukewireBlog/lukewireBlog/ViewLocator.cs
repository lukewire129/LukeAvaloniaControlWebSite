using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using lukewireBlog.ViewModels;

namespace lukewireBlog;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var pathName = data.GetType().Namespace!.Replace("ViewModels", "Components.Pages");
        var folderName = data.GetType().Name!.Replace("ViewModel", "" );
        // var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType($"{pathName}.{folderName}");
        
        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + $"{pathName}.{folderName}.index" };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}