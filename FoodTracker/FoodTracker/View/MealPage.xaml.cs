using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Model;

using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;

namespace FoodTracker.View
{
	public partial class MealPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Food> _foods;
		public MealPage ()
		{
			InitializeComponent ();

            //Creating connection with database
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
		}

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Food>();
            var foods = await _connection.Table<Food>().ToListAsync();
            _foods = new ObservableCollection<Food>(foods);
            lvMeals.ItemsSource = _foods;

            base.OnAppearing();
        }

        private void btn_add_Clicked(object sender, EventArgs e)
        {
            var food = new Food { Name = "Food " + DateTime.Now.Ticks, Weight = _foods.Count };

            _connection.InsertAsync(food);

            _foods.Add(food);
        }

        private void btn_update_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
