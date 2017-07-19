using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Model;

using Xamarin.Forms;

namespace FoodTracker.View
{
	public partial class MealPage : ContentPage
	{
		public MealPage ()
		{
			InitializeComponent ();

            //Creating connection with database
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTableAsync<Food>();
		}

        private void btn_add_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_update_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
