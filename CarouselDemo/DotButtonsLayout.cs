using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Near.DotCarousel
{
    public class DotButtonsLayout : StackLayout
    {
        //This array will hold the buttons
        public DotButton[] dots;
        public DotButtonsLayout(int dotCount,Color dotColor,int dotSize)
        {
            //Create as many buttons as desired.
            dots = new DotButton[dotCount];
            //This class inherits from a StackLayout, so we can stack
            //the buttons together from left to right.
            Orientation = StackOrientation.Horizontal;
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Center;
            //Here we create the buttons.
            for (int i = 0; i< dotCount; i++)
            {
                dots[i] = new DotButton
                    {
                        BorderRadius = Convert.ToInt32(dotSize / 2),
                        HeightRequest = dotSize,
                        WidthRequest = dotSize,
                        BackgroundColor = dotColor,
                        //All buttons except the first one will get an opacity
                        //of 0.5 to visualize the first one is selected.
                        Opacity = 0.5
                    };
                dots[i].index = i;
                dots[i].layout = this;
                Children.Add(dots[i]);
            }
            dots[0].Opacity = 1;
        }        
    }
}