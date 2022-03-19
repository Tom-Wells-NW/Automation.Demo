using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;
using System;
using System.Runtime.CompilerServices;

namespace FlaUI.Adapter.Fss
{
    public abstract class PageObjectBase
    {
        public PageObjectBase() { }

        private Window _window;

        protected void TryAction(Action action, bool throwException = false, [CallerMemberName] string memberName = "")
        {
            try
            {
                action();
            }
            catch(Exception ex)
            {
                // TODO: Log exception
                if(throwException)
                {
                    throw new Exception($"TryAction(() => action, ...) called from {memberName} threw exception {ex.Message}", ex);
                }
            }
        }

        protected T TryFunc<T>(Func<T> func, T defaultValue, bool throwException = false, [CallerMemberName] string memberName = "")
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                // TODO: Log exception
                if (throwException)
                {
                    throw new Exception($"TryFunc(() => func<{typeof(T)}>, ...) called from {memberName} threw exception {ex.Message}", ex);
                }
            }
            return defaultValue;
        }

        public bool WaitForElement(AutomationElement automationElement, double timeoutInSeconds, double retryIntervalInSeconds)
        {
            var result = false;

            var retry = Retry.WhileFalse
                (
                    () => TryFunc(() => automationElement?.IsEnabled ?? false, false, false),
                    TimeSpan.FromSeconds(Math.Abs(timeoutInSeconds)),
                    TimeSpan.FromSeconds(Math.Abs(retryIntervalInSeconds))
                );
            if (retry.Success) result = retry.Success;

            return result;
        }
    }
}
