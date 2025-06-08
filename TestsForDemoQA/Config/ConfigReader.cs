using Newtonsoft.Json.Linq;

namespace TestsForDemoQA.Config
{
    public static class ConfigReader
    {
        private static readonly JObject config =
        JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Config", "testdata.json")))
            ?? throw new InvalidOperationException("Конфиг не загружен");

        public static string BaseUrl
            => config.GetValue("baseUrl")?.Value<string>()
               ?? throw new InvalidOperationException("baseUrl не найден в конфиге");

        public static string VisibilityForBrowser => config["browserSettings"]?["visibility"]?.Value<string>()
                ?? throw new InvalidOperationException("режим браузера - не найден");

        public static string BrowserName => config["browserSettings"]?["browserName"]?.Value<string>()?.ToLower()
                ?? throw new InvalidOperationException("browserName не найден в конфиге");

        public static string Language => config["browserSettings"]?["language"]?.Value<string>()
                ?? throw new InvalidOperationException("language не найден в конфиге");
    }
}
