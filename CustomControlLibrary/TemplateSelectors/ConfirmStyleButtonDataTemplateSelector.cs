using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.TemplateSelectors
{
    public class ConfirmStyleButtonDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ConfirmStyleTemplate { get; set; }
        public DataTemplate ApprovalStyleTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return item is bool confirmStyleButton ? confirmStyleButton ? ConfirmStyleTemplate : ApprovalStyleTemplate : null;
        }
    }
}
