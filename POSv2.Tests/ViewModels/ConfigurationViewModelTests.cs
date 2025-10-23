using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Configuration;
using System.IO;
using System.Text.Json;

namespace POSv2.Tests.ViewModels
{
    public class ConfigurationViewModelTests
    {
        [Fact]
        public void LoadConfiguration_ShouldLoadDefaultsIfFileMissing()
        {
            if (File.Exists("config.json")) File.Delete("config.json");
            var vm = new ConfigurationViewModel();
            vm.BranchName.Should().Be("Central Branch");
            vm.DatabasePath.Should().Be("posv2.db");
            vm.Currency.Should().Be(POSv2.Domain.Entities.CurrencyType.MXN);
            vm.DecimalFormat.Should().Be("dot");
            vm.TimeZone.Should().Be("America/Mexico_City");
            vm.Language.Should().Be("es-ES");
        }

        [Fact]
        public void SaveConfiguration_ShouldWriteFileAndNotifyOnDbPathChange()
        {
            var vm = new ConfigurationViewModel();
            vm.DatabasePath = "otra.db";
            vm.SaveConfigurationCommand.Execute(null);

            File.Exists("config.json").Should().BeTrue();
            var json = File.ReadAllText("config.json");
            json.Should().Contain("otra.db");
            vm.ShowRestartNotification.Should().BeTrue();
            vm.NotificationMessage.Should().Contain("reiniciar");
        }
    }
}