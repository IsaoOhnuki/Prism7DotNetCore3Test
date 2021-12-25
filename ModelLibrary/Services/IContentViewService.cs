using ModelLibrary.Enumerate;
using System.Windows;
using System.Windows.Controls;

namespace ModelLibrary.Services
{
    public interface IContentViewService
    {
        public Size GetContentSize(string key);
 
        void RegisterWindowContent(ContentViewType contentViewType, ContentControl contentControl);

        ContentControl GetWindowContent(ContentViewType contentViewType);
    }
}
