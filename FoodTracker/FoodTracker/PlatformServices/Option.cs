namespace FoodTracker.PlatformServices
{
    /*This class holds data for single setting which is passing to list in View.SettingsPage*/
    public abstract class Option<T>
    {
        private T _value;

        public Option(string name)
        {
            Name = name;
        }

        //properties using to display value
        public string Name { get; private set; }

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        // Options have to have Value properties but that depends on needed type
        protected abstract T GetFromMyProperties();
    }
}
