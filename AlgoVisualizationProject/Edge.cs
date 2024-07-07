using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;

namespace AlgoVisualizationProject
{
    public class Edge
    {
        public Node Start { get; private set; }
        public Node End { get; private set; }
        public float Weight { get;  set; }
        public bool IsDirected { get;  set; }
        public bool Selected { get; set; }

        public Edge(Node start, Node end, float weight = 1, bool isDirected = false)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
            this.IsDirected = isDirected;
            this.Selected = false;
        }


        public void Draw(Graphics g)
        {
            const int nodeRadius = 15; // Define the radius of the node
            var pen = new Pen(Selected ? Color.OrangeRed : Color.Black,2);
            var arrowPen = new Pen(Selected ? Color.OrangeRed : Color.Black, 2);

            // Calculate direction and unit vector
            var startPoint = this.Start.Location;
            var endPoint = this.End.Location;

            // Vector from start to end
            var direction = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

            // Normalize direction vector to get unit vector
            var distance = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            var unitVector = new PointF(direction.X / distance, direction.Y / distance);

            // Move end point back by the node radius to point to the edge of the end node
            PointF adjustedEndPointF = new PointF(
                endPoint.X - unitVector.X * nodeRadius,
                endPoint.Y - unitVector.Y * nodeRadius);

            // Convert PointF to Point
            var adjustedEndPoint = Point.Round(adjustedEndPointF);

            // Draw the line
            g.DrawLine(pen, startPoint, adjustedEndPoint);

            if (this.IsDirected)
            {
                // Draw the arrowhead at the end of the line
                DrawArrow(g, arrowPen, startPoint, adjustedEndPointF, unitVector);
            }

            if (this.Weight != 0)
            {
                // Draw the weight in the middle of the edge
                var midPoint = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
                g.DrawString(this.Weight.ToString(), SystemFonts.DefaultFont, Brushes.Blue, midPoint);
            }
        }

        private void DrawArrow(Graphics g, Pen pen, PointF start, PointF end, PointF unitVector)
        {
            const float arrowSize = 8.0f; // Size of the arrowhead

            // Calculate perpendicular vectors for arrowhead
            var perpendicular1 = new PointF(-unitVector.Y, unitVector.X); // Rotate 90 degrees
            var perpendicular2 = new PointF(unitVector.Y, -unitVector.X); // Rotate -90 degrees

            // Points for the arrowhead
            var arrowPoint1 = new PointF(
                end.X - unitVector.X * arrowSize + perpendicular1.X * arrowSize / 2,
                end.Y - unitVector.Y * arrowSize + perpendicular1.Y * arrowSize / 2);

            var arrowPoint2 = new PointF(
                end.X - unitVector.X * arrowSize + perpendicular2.X * arrowSize / 2,
                end.Y - unitVector.Y * arrowSize + perpendicular2.Y * arrowSize / 2);

            // Draw the arrowhead
            g.DrawLine(pen, end, arrowPoint1);
            g.DrawLine(pen, end, arrowPoint2);
        }

    }

}
