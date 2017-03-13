using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model;
using Xamarin.Forms;
using System.ComponentModel;

namespace FoodTracker.ViewModel
{
    public class VMSettings
    {
        private Settings sets;
        private List<VMOption> vmoptions;   //list to display in SettingsPage
        public List<VMOption> VMOptions { get { return vmoptions; } }
        private Dictionary<string, Page> pagesToDisplay;

        public VMSettings()
        {
            sets = new Model.Settings();
            vmoptions = new List<VMOption>();
            pagesToDisplay = new Dictionary<string, Page>();
            foreach (Option item in sets.GetOptions)
            {
                vmoptions.Add(new VMOption(item));
                setPageForEachOption(item);
            }
        }

        //connect the option with proper Page
        private void setPageForEachOption(Option option)
        {
            switch (option.PageToOpen)
            {
                case "IntervalOptionPage":
                    pagesToDisplay.Add("IntervalOptionPage", new View.OptionPages.IntervalOptionPage(this, option.Name));
                    break;
                default:
                    break;
            }
        }

        public Page GetPageToDisplay(VMOption opt)
        {
            Page page = null;
            foreach (VMOption item in vmoptions)
            {
                if (item.Name == opt.Name)
                {
                    page = pagesToDisplay[item.PageToOpen];
                }
            }
            return page;
        }

        public void SetValue(string optName, string optValue)
        {
            foreach (VMOption item in vmoptions)
            {
                if (item.Name == optName)
                {
                    item.Value = optValue;
                }
            }
            //OnPropertyChanged("VMOptions");
        }
        
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}
    }
}
