using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Near.DotCarousel
{
    public class Carousel: AbsoluteLayout
    {
        private DotButtonsLayout dotLayout;
        private CarouselView carousel;

        public Carousel(ObservableCollection<CarouselContent> pages)
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            carousel = new CarouselView();
            carousel.HorizontalOptions = LayoutOptions.FillAndExpand;
            carousel.VerticalOptions = LayoutOptions.FillAndExpand;
            var template = new DataTemplate (() => {
                var page1 = new AbsoluteLayout();
                page1.BackgroundColor = Color.FromHex("2C2E31");
                page1.HorizontalOptions = LayoutOptions.FillAndExpand;
                page1.VerticalOptions = LayoutOptions.FillAndExpand;
                page1.SetBinding(AbsoluteLayout.BackgroundColorProperty, "BackgroundColor");
                var lab = new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))+10,
                    FontAttributes = FontAttributes.Bold
                };
                lab.TextColor = Color.White;
                lab.HorizontalOptions = LayoutOptions.Center;
                lab.VerticalOptions = LayoutOptions.Center;
                lab.SetBinding(Label.TextProperty, "Header");
                var lab2 = new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                };
                lab2.TextColor = Color.White;
                lab2.HorizontalOptions = LayoutOptions.Center;
                lab2.VerticalOptions = LayoutOptions.Center;
                lab2.SetBinding(Label.TextProperty, "Content1");
                var lab3 = new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                };
                lab3.TextColor = Color.White;
                lab3.HorizontalOptions = LayoutOptions.Center;
                lab3.VerticalOptions = LayoutOptions.Center;
                lab3.SetBinding(Label.TextProperty, "Content2");

                page1.Children.Add(lab);
                page1.Children.Add(lab2);
                page1.Children.Add(lab3);
                var bgImage = new Image();
                bgImage.Aspect = Aspect.AspectFill;
                bgImage.HorizontalOptions = LayoutOptions.FillAndExpand;
                bgImage.VerticalOptions = LayoutOptions.FillAndExpand;
                bgImage.SetBinding(Image.SourceProperty, "Background");
                page1.Children.Add(bgImage);
                AbsoluteLayout.SetLayoutBounds(bgImage, new Rectangle(0, 0, 1, 1));
                AbsoluteLayout.SetLayoutFlags(bgImage, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(lab, new Rectangle(0, 0.3, 1, 0.2));
                AbsoluteLayout.SetLayoutFlags(lab, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(lab2, new Rectangle(0, 0.4, 1, 0.2));
                AbsoluteLayout.SetLayoutFlags(lab2, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(lab3, new Rectangle(0, 0.5, 1, 0.2));
                AbsoluteLayout.SetLayoutFlags(lab3, AbsoluteLayoutFlags.All);
                return page1;
            });
            carousel.ItemsSource = pages;
            carousel.ItemTemplate = template;
            carousel.ItemSelected += pageChanged;
            Children.Add(carousel);
            AbsoluteLayout.SetLayoutBounds(carousel, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(carousel, AbsoluteLayoutFlags.All);
            dotLayout = new DotButtonsLayout(pages.Count, Color.White, 10);
            foreach (Button dot in dotLayout.dots)
                dot.Clicked += dotClicked;
            Children.Add(dotLayout);
            AbsoluteLayout.SetLayoutBounds(dotLayout, new Rectangle(0, 0.92, 1, .05));
            AbsoluteLayout.SetLayoutFlags(dotLayout, AbsoluteLayoutFlags.All);
        }

        private void pageChanged(object sender, SelectedItemChangedEventArgs e)
        {
            var page = (CarouselContent)(e.SelectedItem);
            var position = page.position-1;
            for(int i = 0;i<dotLayout.dots.Length;i++)
                if(position == i)
                    dotLayout.dots[i].Opacity = 1;
                else
                    dotLayout.dots[i].Opacity = 0.5;
        }

        private void dotClicked(object sender, EventArgs e)
        {
            var button = (DotButton)sender;
            int index = button.index;
            carousel.Position = index;
        }
    }
}
