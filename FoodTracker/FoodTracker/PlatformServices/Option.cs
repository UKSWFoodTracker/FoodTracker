namespace FoodTracker.PlatformServices
{
    public abstract class Option<T>
    {
        private T _value;

        protected Option(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Properties using to display value
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Options have to have Value properties but that depends on needed type
        /// </summary>
        public T Value
        {
            get
            {
                _value = GetFromMyProperties();
                return _value;
            }
            set
            {
                _value = value;
                SaveToMyProperties(value);
            }
        }

        protected abstract T GetFromMyProperties();

        protected abstract void SaveToMyProperties(T value);
    }
}
