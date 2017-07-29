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
        private ObservableCollection<Ingredient> ingreds;
		public MealPage ()
		{
			InitializeComponent();

            // Creating connection with database
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
		}

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Ingredient>();
            var foods = await _connection.Table<Ingredient>().ToListAsync();
            ingreds = new ObservableCollection<Ingredient>(foods);
            lvIngreds.ItemsSource = ingreds;

            base.OnAppearing();
        }

        private async void btn_add_Clicked(object sender, EventArgs e)
        {
            int weight = int.Parse(entWeight.Text);
            int calories = int.Parse(entCalories.Text);
            //TODO: Add picker widget in MealPage
            var food = new Ingredient(entName.Text, weight, calories, IngredientType.Bread);

            await _connection.InsertAsync(food);

            ingreds.Add(food);
            setEntries("", "", "");

            lvIngreds.SelectedItem = null;
        }

        private async void btn_update_Clicked(object sender, EventArgs e)
        {
            if (ingreds.Count == 0)
            {
                return;
            }
            var food = lvIngreds.SelectedItem as Ingredient;
            if (!ingreds.Contains(food))
            {
                return;
            }

            food.Name = entName.Text;
            food.Weight = int.Parse(entWeight.Text);
            food.Calories100 = int.Parse(entCalories.Text);

            await _connection.UpdateAsync(food);
            setEntries("", "", "");

            lvIngreds.SelectedItem = null;
        }

        private async void btn_delete_Clicked(object sender, EventArgs e)
        {
            if (ingreds.Count == 0)
            {
                return;
            }
            var food = lvIngreds.SelectedItem as Ingredient;
            if (!ingreds.Contains(food))
            {
                return;
            }

            await _connection.DeleteAsync(food);

            ingreds.Remove(food);
            setEntries("", "", "");
        }

        private void lvIngreds_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvIngreds.SelectedItem == null)
            {
                return;
            }
            var ing = e.SelectedItem as Ingredient;
            setEntries(ing);
        }
    

        private void setEntries(Ingredient ing)
        {
            entName.Text = ing.Name;
            entWeight.Text = ing.Weight.ToString();
            entCalories.Text = ing.Calories100.ToString();
        }
        private void setEntries(string name, string weight, string calories)
        {
            entName.Text = name;
            entWeight.Text = weight;
            entCalories.Text = calories;
        }
    }
}
