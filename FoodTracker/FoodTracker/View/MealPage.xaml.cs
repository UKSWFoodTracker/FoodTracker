using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodTracker.View
{
    public partial class MealPage : ContentPage
    {
        public MealPage()
        {
            InitializeComponent();
            //TODO: Dynamic page for meal - for more info see Trello
            //TODO: Adjust this solution to my project
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
            };

            var btn = new Button() { Text = "Add meal" };
            btn.Clicked += btn_Clicked;
            layout.Children.Add(btn);

            Content = layout;
        }

        private ScrollView scrollView = new ScrollView
        {
            Padding = 2,
            Content = listView_serverList,
            BackgroundColor = Color.White,
            VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
        };

        private static ListView listView_serverList = new ListView
        {
            ItemsSource = mealList,
            ItemTemplate = new DataTemplate(() =>
            {
                var serverName = new Label();
                serverName.SetBinding(Label.TextProperty, new Binding("ServerName"));
                var errorReson = new Label() { };
                errorReson.SetBinding(Label.TextProperty, new Binding("ErrorReson"));

                var grid = new Grid()
                {
                    ColumnSpacing = 0,
                    RowSpacing = 0,
                    BackgroundColor = Color.White
                };
                ////-----------------------------
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Absolute) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Absolute) });
                ////-----------------------------
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Absolute) });  //logo
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Absolute) }); //logo
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });      //area name


                grid.Children.Add(icon, 1, 2, 0, 2); // Left, First element//icon
                grid.Children.Add(serverName, 2, 3, 0, 1); // Right, First element//name
                grid.Children.Add(errorReson, 2, 1); //error

                //======== make view Cell =========
                return new ViewCell()
                {
                    View = grid
                };
            })
        };
        private static ObservableCollection<Model.Meals.MealModel> mealList = new ObservableCollection<Model.Meals.MealModel>
        {
            new Model.Meals.MealModel("Chicken", 1),
            new Model.Meals.MealModel("Bread", 2),
        };

        private void btn_Clicked(object sender, EventArgs e)
        {
            listView_serverList.ItemsSource = null;
            index++;
            serverList.Add(new ServerModel() { Icon = "icon.png", ServerName = index.ToString() + ":192.168.0.87", ErrorReson = "ok" });
            listView_serverList.ItemsSource = serverList;
            scrollView.ForceLayout();
        }
    }
}
