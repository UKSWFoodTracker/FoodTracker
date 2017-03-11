using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model;
using Xamarin.Forms;

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
                vmoptions.Add(new VMOption(item.Name, item.Value));
                switch (item.PageToOpen)
                {
                    case "IntervalOptionPage":
                        pagesToDisplay.Add("IntervalOptionPage", new View.OptionPages.IntervalOptionPage(this, item.Name));
                        break;
                    default:
                        break;
                }
            }
        }

        public Page GetPageToDisplay(VMOption opt)
        {
            Page page = null;
            foreach (Option item in sets.GetOptions)
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
            foreach (Option item in sets.GetOptions)
            {
                if (item.Name == optName)
                {
                    item.Value = optValue;
                }
            }
        }
    }
}
