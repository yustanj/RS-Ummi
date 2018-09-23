using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using rumahsakit.Services;
using rumahsakit.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace rumahsakit.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string NIRM { get; set; }
        public string Paswword { get; set; }
        public ICommand Login => new Command(async () =>
        {
            string[,] header = {
                {"Content-Type" ,"application/json"},
                {"client-id","62000"},
                {"access-token","eHl1XBvw7S0LXdVU5MvYgA"}
            };

            IRestResponse response = API.CallAPI("Pasien", null, RestSharp.Method.GET, header);

            JToken content = (JToken)JsonConvert.DeserializeObject(response.Content);

            foreach (var item in content)
            {
                if (item["NIRM"].ToString() == NIRM && item["Password"].ToString() == Paswword)
                {
                    await Navigation.PushAsync(new HomePage());
                    return;
                }
            }
            Message = "NIRM/Password Salah";


        });
    }
}
