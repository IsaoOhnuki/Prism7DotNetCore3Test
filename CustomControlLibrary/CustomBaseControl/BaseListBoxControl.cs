using System.Windows;

namespace CustomControlLibrary.CustomBaseControl
{
    public class BaseListBoxControl : BaseCustomControl
    {
        static BaseListBoxControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseListBoxControl), new FrameworkPropertyMetadata(typeof(BaseListBoxControl)));
        }
    }
}
