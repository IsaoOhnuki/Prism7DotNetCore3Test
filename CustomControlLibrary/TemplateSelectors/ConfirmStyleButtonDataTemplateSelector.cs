using CustomControlLibrary.MessageDialog;
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
            if (item == null)
                return null;

            bool confirmStyleButton = (bool)item;

            if (confirmStyleButton)
            {
                return ConfirmStyleTemplate;
            }
            else
            {
                return ApprovalStyleTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
