using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace POSv2.UI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ApplyTheme(bool darkMode, bool largeFont, bool highContrast)
        {
            Resources.MergedDictionaries.Clear();
            var themeDict = new ResourceDictionary
            {
                Source = darkMode ?
                    new Uri("avares://POSv2.UI/Styles/DarkTheme.axaml") :
                    new Uri("avares://POSv2.UI/Styles/LightTheme.axaml")
            };
            Resources.MergedDictionaries.Add(themeDict);

            // Cambia fuente
            Resources["BaseFontSize"] = largeFont ? 24d : 18d;

            // Alto contraste: sobreescribe los colores si está activado
            if (highContrast)
            {
                Resources["BackgroundColor"] = Resources["HighContrastBackgroundColor"];
                Resources["TextColor"] = Resources["HighContrastTextColor"];
            }
            else
            {
                // Restaura colores normales del tema
                Resources["BackgroundColor"] = themeDict["BackgroundColor"];
                Resources["TextColor"] = themeDict["TextColor"];
            }
        }
    }
}