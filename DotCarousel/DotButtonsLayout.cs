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
        public DotButton[] dots;
        public DotButtonsLayout(int dotCount,Color dotColor,int dotSize)
        {
            dots = new DotButton[dotCount];
            Orientation = StackOrientation.Horizontal;
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Center;
            for (int i = 0; i< dotCount; i++)
            {
                dots[i] = new DotButton
                {
                    BorderRadius = Convert.ToInt32(dotSize / 2),
                    HeightRequest = dotSize,
                    WidthRequest = dotSize,
                    BackgroundColor = dotColor,
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
