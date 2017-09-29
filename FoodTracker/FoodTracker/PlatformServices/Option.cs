namespace FoodTracker.PlatformServices
{
    public abstract class Option<T>
    {
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
            get => GetFromMyProperties();
            set => SaveToMyProperties(value);
        }

        protected abstract T GetFromMyProperties();

        protected abstract void SaveToMyProperties(T value);
    }
}
