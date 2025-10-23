using System.Globalization;
using System.Resources;

namespace POSv2.UI.Services
{
    /// <summary>
    /// Servicio para internacionalización y acceso a recursos.
    /// </summary>
    public class LocalizationService
    {
        private readonly ResourceManager resourceManager;
        private CultureInfo currentCulture;

        public LocalizationService()
        {
            resourceManager = new ResourceManager("POSv2.UI.Resources.Strings", typeof(LocalizationService).Assembly);
            currentCulture = CultureInfo.CurrentUICulture; // Por defecto
        }

        public void ChangeCulture(string cultureName)
        {
            currentCulture = new CultureInfo(cultureName);
        }

        public string GetString(string key)
        {
            return resourceManager.GetString(key, currentCulture) ?? key;
        }
    }
}