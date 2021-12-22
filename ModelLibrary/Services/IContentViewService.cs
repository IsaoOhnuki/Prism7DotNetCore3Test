using ModelLibrary.Enumerate;
using System.Windows.Controls;

namespace ModelLibrary.Services
{
    public interface IContentViewService
    {
        void RegisterWindowContent(ContentViewType contentViewType, ContentControl contentControl);

        ContentControl GetWindowContent(ContentViewType contentViewType);
    }
}
