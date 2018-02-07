using System;
using System.Collections.Generic;
using System.Drawing;

namespace pure.zlo_2.source{
    class Shape{
        public const int details = 5;
        private Point _center;
        private Point _vertex1;
        private double angle = 0;
        private double scale = 1;
        public Color cl = Render.defColor;
        public int texid = -1;
        private List<Point> _points;

        public List<Point> points{
            get{
                List<Point> ret = new List<Point>(_points);
                for (int i = 0; i < _points.Count; i++){
                    Point f = Render.rotateVector(new Point(_points[i].X - _center.X, _points[i].Y - _center.Y), angle);
                    f.X += _center.X;
                    f.Y += _center.Y;
                    ret[i] = f;
                }
                for (int i = 0; i < _points.Count; i++){
                    ret[i] = new Point(
                        (int)((ret[i].X - _center.X) * scale) + _center.X,
                        (int)((ret[i].Y - _center.Y) * scale) + _center.Y);
                }
                return ret;
            }
        }

        public Shape(Point _center, Point vertex){
            this._center = _center;
            this._vertex1 = vertex;
            _points = new List<Point>();
            int dx = vertex.X - _center.X;
            int dy = vertex.Y - _center.Y;
            Point curr = new Point(dx, dy);
            for (int i = 0; i < details; i++){
                curr = Render.rotateVector(curr, Math.PI * 2 / details);
                _points.Add(new Point(_center.X + curr.X, _center.Y + curr.Y));
            }
        }

        public void rotate(double tetta){
            this.angle += tetta;
        }

        public void move(int dx, int dy){
            _center.X += dx;
            _center.Y += dy;
            _vertex1.X += dx;
            _vertex1.Y += dy;
            for (int i = 0; i < _points.Count; i++){
                _points[i] = new Point(_points[i].X + dx, _points[i].Y + dy);
            }
        }

        public void Scale(bool scale_in = true){
            if (!scale_in && VectorLength(_points[0], _center) * scale <= 10) return;
            scale *= (scale_in ? Render.zoomIn : Render.zoomOut);
        }

        public static double VectorLength(Point p1, Point p2){
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
