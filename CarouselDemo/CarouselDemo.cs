using System;

using Xamarin.Forms;
using Near.Classes;
using System.Collections.ObjectModel;
using Near.DotCarousel;

namespace CarouselDemo
{
    public class App : Application
    {
        public App()
        {
            var page1 = new CarouselContent();
            var page2 = new CarouselContent();
            var page3 = new CarouselContent();
            var page4 = new CarouselContent();
            page1.BackgroundColor = Color.FromHex("e74c3c");
            page2.BackgroundColor = Color.FromHex("16a085");
            page3.BackgroundColor = Color.FromHex("2c3e50");
            page4.BackgroundColor = Color.FromHex("3498db");
            page1.Header = "CarouselView!";
            page1.Content1 = "With Page Indicators";
            page1.Content2 = "In Xamarin.Forms!";
            page2.Header = "Inidicators==Buttons";
            page2.Content1 = "You Can Press Them";
            page2.Content2 = "To Navigate Around!";
            page3.Header = "It's A View";
            page3.Content1 = "So You Can Place It";
            page3.Content2 = "EVERYWHERE!";
            page4.Header = "Contact Us";
            page4.Content1 = "Support@Hot-Totem.com";
            page4.Content2 = "If You Have Any Questions!";
            var pages = new ObservableCollection<CarouselContent>();
            pages.Add(page1);
            pages.Add(page2);
            pages.Add(page3);
            pages.Add(page4);
            var carouselView = new Carousel(pages);
            //Thats it! Simply add the carouselView to any Layout and you are all set!
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = carouselView
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

