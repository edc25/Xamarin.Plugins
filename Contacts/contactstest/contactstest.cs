using System;
using Plugin.Contacts.Abstractions;
using Plugin.Contacts;
using Xamarin.Forms;
using System.Linq;
using System.IO;

namespace contactstest
{
    public class App : Application
    {
        public App()
        {// The root page of your application
            CrossContacts.Current.RequestPermission ();
            var contacts = CrossContacts.Current.Contacts.ToList();
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label
                        {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        },
                        new Image{
                            Source = ImageSource.FromStream(contacts.First().ImageStream)
                        },
                                    new ListView{
                                    }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

