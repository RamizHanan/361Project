using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Security.Authentication.Web;
using Windows.Web.Http;
using Windows.Data.Json;
using Google.Apis;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace COMPE361_Project
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
         public async void accessData(string token)
        {
            var restApi = new Uri(@"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + token);
            using (var client = new HttpClient())
            {
                var infoResult = await client.GetAsync(restApi);
                string content = await infoResult.Content.ReadAsStringAsync();
                status.Text = content;
                var jsonObject = JsonObject.Parse(content);
                //string name = jsonObject["email"].GetString();

               // status.Text = "Id: " + id;
                //status.Text = "Name: " + name;
            }

        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var googleUrl = new System.Text.StringBuilder();
            googleUrl.Append("https://accounts.google.com/o/oauth2/auth?client_id=");
            googleUrl.Append(Uri.EscapeDataString("386704258758-9cjrkli52jod17eu2785helpu59oda0a.apps.googleusercontent.com"));
            googleUrl.Append("&scope=openid%20email%20profile");
            googleUrl.Append("&redirect_uri=");
            googleUrl.Append(Uri.EscapeDataString("urn:ietf:wg:oauth:2.0:oob:auto"));
            googleUrl.Append("&response_type=code");
            googleUrl.Append("&include_granted_scopes=true");
            var startURI = new System.Uri(googleUrl.ToString());
            var endURI = new System.Uri("https://accounts.google.com/o/oauth2/approval");

            try
            {
                WebAuthenticationResult result =
                    await WebAuthenticationBroker.AuthenticateAsync(
                        WebAuthenticationOptions.None, startURI, endURI);

                switch (result.ResponseStatus)
                {
                    case WebAuthenticationStatus.Success:
                        var restApi = new Uri(result.ResponseData.ToString());
                        using (var client = new HttpClient())
                        {
                            var infoResult = await client.GetAsync(restApi);
                            string content = await infoResult.Content.ReadAsStringAsync();
                            var jsonObject = JsonObject.Parse(content);
                            string id = jsonObject["id"].GetString();
                            string name = jsonObject["name"].GetString();

                            //UserIdTextBlock.Text = "Id: " + id;
                            status.Text = "Name: " + name;
                        }

                        break;
                    case WebAuthenticationStatus.ErrorHttp:
                        status.Text = "404";
                        break;
                    default:
                        status.Text = "What Happened?";
                        break;
                }
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
            }


        }


        private void EnterPress(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) this.Login_Click(sender, e);
        }
    }
}
