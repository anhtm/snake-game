using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class Dot {
        Point location;
        Color color;
        int width;

        public Dot(Point p, Color c, int w) {
            this.location = p;
            this.color = c;
            this.width = w;
        }

        public Point Location {
            get => location;
            set => location = value;
        }

        public Color Color {
            get => color;
            set => color = value;
        }

        public int Width {
            get => width;
            set => width = value;
        }
    }
}
