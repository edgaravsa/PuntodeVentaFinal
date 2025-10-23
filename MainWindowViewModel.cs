public IRelayCommand ShowHardwareConfigCommand { get; }

public MainWindowViewModel(Func<HardwareConfigViewModel> hardwareConfigVmFactory)
{
    ShowHardwareConfigCommand = new RelayCommand(OpenHardwareConfigView);
    _hardwareConfigVmFactory = hardwareConfigVmFactory;
}

private void OpenHardwareConfigView()
{
    CurrentViewModel = _hardwareConfigVmFactory();
}