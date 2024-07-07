using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlgoVisualizationProject
{
    public class Node
    {
        public int ID { get; set; }
        public Point Location { get; set; }
        private const int Radius = 15;
        public bool Selected { get; set; }

        public Node(int ID, Point location)
        {
            this.ID = ID;
            this.Location = location;
            this.Selected = false;
        }

        public bool Contains(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - Location.X, 2) + Math.Pow(point.Y - Location.Y, 2)) <= Radius;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Selected ? Brushes.OrangeRed : Brushes.WhiteSmoke, Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);

            Pen pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);

            // Define a StringFormat object for centering the text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(this.ID.ToString(), SystemFonts.DefaultFont, Brushes.Black, Location.X, Location.Y, sf);

        }
    }

}
