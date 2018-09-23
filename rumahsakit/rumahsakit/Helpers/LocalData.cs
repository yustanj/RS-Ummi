
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace rumahsakit.Helpers
{
    class LocalData
    {
        private static ISettings AppSettings => CrossSettings.Current;


        public static bool IsLogin
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLogin), false);

            set => AppSettings.AddOrUpdateValue(nameof(IsLogin), value);

        }
    }
}
