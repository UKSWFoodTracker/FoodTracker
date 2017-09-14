namespace FoodTracker.ViewModel.Pages
{
    /// <summary>
    /// Class is bridge between MainPage and other components
    /// </summary>
    class MainPageViewModel
    {
        public MainPageViewModel(Settings.StartNotificationHandler startNotifyMethod, Settings.StopNotificationHandler stopNotifyMethod)
        {
            Settings = new Settings(startNotifyMethod, stopNotifyMethod);
        }

        public Settings Settings { get; }

        public void ChangeNotifyState()
        {
            Settings.NotifyValue = !Settings.NotifyValue;
        }

        public string TimerValue
        {
            get { return Settings.TimerValue; }
        }

        public string NotifyButton
        {
            get { return Settings.NotifyButton; }
        }
    }
}
