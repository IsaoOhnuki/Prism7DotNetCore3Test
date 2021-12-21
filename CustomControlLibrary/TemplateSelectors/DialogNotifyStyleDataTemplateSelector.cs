using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.TemplateSelectors
{
    public class DialogNotifyStyleDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InformationStyleTemplate { get; set; }
        public DataTemplate WarningStyleTemplate { get; set; }
        public DataTemplate ErrorStyleTemplate { get; set; }
        public DataTemplate ConfirmStyleTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            DialogNotifyStyle dialogNotifyStyle = (DialogNotifyStyle)item;
            switch (dialogNotifyStyle)
            {
                case DialogNotifyStyle.Confirm:
                    return ConfirmStyleTemplate;
                case DialogNotifyStyle.Error:
                    return ErrorStyleTemplate;
                case DialogNotifyStyle.Warning:
                    return WarningStyleTemplate;
                case DialogNotifyStyle.Information:
                    return InformationStyleTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
