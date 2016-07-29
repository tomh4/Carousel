using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Near.DotCarousel
{
    public class DotButton : BoxView
    {
        public int index;
        public DotButtonsLayout layout;
        public event ClickHandler Clicked;
        public delegate void ClickHandler(DotButton sender);
        public DotButton()
        {
            var clickCheck = new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                        {
                            if (Clicked != null)
                            {
                                Clicked(this);
                            }
                        })
                };
            GestureRecognizers.Add(clickCheck);
        }
    }
}