using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;

namespace FlaUI.Adapter.Fss
{
    public interface IFlaUiApplication
    {
        Application Application { get; }
        UIA3Automation Automation { get; }
        ConditionFactory By { get; }
        Window MainWindow { get; }

        void Focus();
    }
}