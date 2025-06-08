using OpenQA.Selenium;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Core
{
    public static class Browser
    {
        public static void AcceptAlert()
        {
            var alert = TryGetAlert();
            if (alert != null)
            {
                alert.Accept();
                Logger.Info("Принят alert");
            }
            else
            {
                Logger.Warning("Не удалось принять alert");
            }
        }

        public static void DismissAlert()
        {
            var alert = TryGetAlert();
            if (alert != null)
            {
                alert.Dismiss();
                Logger.Info("Отклонен alert");
            }
            else
            {
                Logger.Warning("Не удалось отклонить alert");
            }
        }

        public static string GetAlertText()
        {
            var alert = TryGetAlert();
            if (alert != null)
            {
                return alert.Text ?? string.Empty; ;
            }
            Logger.Warning("Не удалось получить текст alert");
            return string.Empty;
        }

        public static void SendKeysToAlert(string text)
        {
            var alert = TryGetAlert();
            if (alert != null)
            {
                alert.SendKeys(text);
                alert.Accept();
                Logger.Info($"Отправлено сообщение в alert: '{text}'");
            }
            else
            {
                Logger.Warning("Не удалось отправить сообщение в alert");
            }
        }

        public static string GetCurrentWindowHandle()
        {
            return DriverSingleton.Instance.CurrentWindowHandle;
        }

        public static string SwitchToNewWindow()
        {
            var original = DriverSingleton.Instance.CurrentWindowHandle;
            var other = DriverSingleton.Instance.WindowHandles.FirstOrDefault(h => h != original) 
                ?? throw new NoSuchWindowException("Не найдено второе окно");
            DriverSingleton.Instance.SwitchTo().Window(other);
            Logger.Info($"Switched to new window: {other}");
            return original;
        }

        public static void CloseCurrentAndSwitchTo(string handleToSwitch)
        {
            DriverSingleton.Instance.Close();
            DriverSingleton.Instance.SwitchTo().Window(handleToSwitch);
            Logger.Info($"Закрываем текущее окно и переключаемся на: {handleToSwitch}");
        }

        private static IAlert? TryGetAlert()
        {
            try
            {
                return DriverSingleton.Instance.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }

        public static void SwitchToFrame(string frameName)
        {
            DriverSingleton.Instance.SwitchTo().Frame(frameName);
            Logger.Info($"Переключение на фрейм '{frameName}'");
        }

        public static void SwitchToFrame(int index)
        {
            DriverSingleton.Instance.SwitchTo().Frame(index);
            Logger.Info($"Переключение на фрейм №{index}");
        }

        public static void SwitchToDefaultContent()
        {
            DriverSingleton.Instance.SwitchTo().DefaultContent();
            Logger.Info("Возврат к основному контенту");
        }
    }
}
