using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Near.Classes
{
    public class CarouselContent
    {
        public int position { get; set; }
        public string Header { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public Color BackgroundColor { get; set; }
        public CarouselContent(string _header,string _content1,string _content2,string _color,int _position)
        {
            position = _position;
            Header = _header;
            Content1 = _content1;
            Content2 = _content2;
            BackgroundColor = Color.FromHex(_color);
        }
        public CarouselContent(string _header, string _content1, string _color, int _position)
        {
            position = _position;
            Header = _header;
            Content1 = _content1;
            Content2 = "";
            BackgroundColor = Color.FromHex(_color);
        }
        public CarouselContent(string _header, string _color, int _position)
        {
            position = _position;
            Header = _header;
            Content1 = "";
            Content2 = "";
            BackgroundColor = Color.FromHex(_color);
        }
    }
}
