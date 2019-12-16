using SwipeViewExample.Models;
using SwipeViewExample.ServiceManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeViewExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonListPage : ContentPage
    {
        public IList<Result> List = new ObservableCollection<Result>();
        Provider provider = new Provider();
        public PersonListPage()
        {
            InitializeComponent();
            this.BindingContext = List;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List.Clear();
            var result = await provider.GetPersons();
            foreach(var item in result.results)
            {
                List.Add(item);
            }
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = (SwipeItem)sender;
            var parameter = (Result)item.CommandParameter;
            List.Remove(parameter);
        }
    }
}