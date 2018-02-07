using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace pure.zlo_2.source {
    class Render{
        private GLControl _GLC;
        private List<Shape> _figs;
        private Shape _shape;

        public int Count { get { return _figs.Count; } }
        public static Color defColor { get { return Color.FromArgb(224, 192, 0); } }
        public const double zoomIn = 1.1;
        public const double zoomOut = .9;
        private const double _rotStep = Math.PI / 18;

        public int cellSize = 10;
        public int merge = 0;
        public int modelView = 2;
        public byte renderMode = 3;

        public Render(GLControl g){
            this._GLC = g;
            _figs = new List<Shape>();
            _shape = new Shape(new Point(50, 50), new Point(50, 100));
        }

        public void initialize(){
            GL.ClearColor(255, 255, 255, 1);
            GL.Viewport(0, 0, (int)_GLC.Width, (int)_GLC.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, _GLC.Width, _GLC.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        public void resize(int width, int height){
            initialize();
        }

        public void refresh(){
            _GLC.Invalidate();
        }
        public void drawGrid(){
            GL.LoadIdentity();
            GL.LineWidth(1);
            GL.Color3(Color.DarkGray);
            GL.Begin(PrimitiveType.Lines);
            for (int i = 0; i < _GLC.Width; i += cellSize) {
                GL.Vertex2(i, 0);
                GL.Vertex2(i, _GLC.Height);
            }
            for (int i = 0; i < _GLC.Height; i += cellSize){
                GL.Vertex2(0, i);
                GL.Vertex2(_GLC.Width, i);
            }
            GL.End();
        }
        public static int loadTexture(string filename){
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(filename);
            BitmapData bmpData = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(
                TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width,
                bmpData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte,
                bmpData.Scan0);

            bmp.UnlockBits(bmpData);
            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return id;
        }

        public void applyTexture(int id, string filename){
            int texid = loadTexture(filename);
            _figs[id].texid = texid;
        }

        public void changeColor(int id, Color cl){
            _figs[id].cl = cl;
        }
        public void resizeFig(int id, bool scaleIn){
            _figs[id].Scale(scaleIn);
        }
        public void rotateFig(int id, bool clockwatch = true){
            _figs[id].rotate(clockwatch ? _rotStep : -_rotStep);
        }

        public void moveFig(int id, int dx, int dy){
            _figs[id].move(dx, dy);
        }
        public void rasterizePolygon(Shape f){
            List<Point> bras = new List<Point>();
            List<Point> points = f.points;
            int lx = 0, ly = 0;
            for (int k = 0; k < Shape.details; k++){
                int x1 = points[k].X;
                int y1 = points[k].Y;
                int x2 = points[(k + 1) % Shape.details].X;
                int y2 = points[(k + 1) % Shape.details].Y;
                int deltaX = Math.Abs(x2 - x1);
                int deltaY = Math.Abs(y2 - y1);
                int signX = x1 < x2 ? 1 : -1;
                int signY = y1 < y2 ? 1 : -1;
                int error = deltaX - deltaY;
                
                lx = x2 - (x2 % cellSize) * Math.Sign(x2);
                ly = y2 - (y2 % cellSize) * Math.Sign(y2);

                Point pt = new Point(lx, ly);
                if (!bras.Contains(pt))
                    bras.Add(pt);

                while (x1 != x2 || y1 != y2){
                    lx = x1 - (x1 % cellSize) * Math.Sign(x1);
                    ly = y1 - (y1 % cellSize) * Math.Sign(y1);

                    int error2 = error * 2;
                    if (error2 > -deltaY){
                        error -= deltaY;
                        x1 += signX;
                    }

                    if (error2 < deltaX){
                        error += deltaX;
                        y1 += signY;
                    }
                    
                    if (lx < 0 || lx > _GLC.Width || ly < 0 || ly > _GLC.Height) continue;
                    pt = new Point(lx, ly);
                    if (!bras.Contains(pt))
                        bras.Add(pt);
                }
            }
            
            foreach (Point p in bras){
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex2(p.X, p.Y);
                GL.Vertex2(p.X, p.Y + cellSize);
                GL.Vertex2(p.X + cellSize, p.Y + cellSize);
                GL.Vertex2(p.X + cellSize, p.Y);
                GL.End();
            }
        }
        public void addFigure(Point p1, Point p2){
            _figs.Add(new Shape(p1, p2));
        }

        public static Point rotateVector(Point pt, double tetta){
            Point ps = new Point();
            ps.X = (int)(pt.X * Math.Cos(tetta) - pt.Y * Math.Sin(tetta));
            ps.Y = (int)(pt.X * Math.Sin(tetta) + pt.Y * Math.Cos(tetta));
            return ps;
        }

        internal void drawPolygon(Shape f, int width = 3){
            List<Point> points = f.points;
            GL.LineWidth(width);
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i < Shape.details; i++){
                GL.Vertex2(points[i].X, points[i].Y);
            }
            GL.End();
        }

        internal void fillPolygon(Shape f){
            List<Point> points = f.points;
            List<Point> texCoord = _shape.points;

            if (f.texid >= 0){
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, f.texid);
            }
            GL.Begin(PrimitiveType.Polygon);
            for (int i = 0; i < Shape.details; i++){
                if (f.texid >= 0)
                    GL.TexCoord2(((double)texCoord[i].X) / 100, ((double)texCoord[i].Y) / 100);
                GL.Vertex2(points[i].X, points[i].Y);
            }
            GL.End();
            if (f.texid >= 0) GL.Disable(EnableCap.Texture2D);
        }

        internal void drawObjects(){
            switch (merge){
                case 0: break;
                case 1:{
                        GL.Enable(EnableCap.ColorLogicOp);
                        GL.LogicOp(LogicOp.Xor);
                    }
                    break;
                case 2:{
                        GL.Enable(EnableCap.ColorLogicOp);
                        GL.LogicOp(LogicOp.Equiv);
                    }
                    break;
            }

            if ((renderMode & (1 << 2)) != 0) foreach (var obj in _figs){
                    GL.Color3(obj.cl);
                    fillPolygon(obj);
                }

            if ((renderMode & (1 << 1)) != 0) foreach (var obj in _figs){
                    GL.Color3(obj.cl);
                    rasterizePolygon(obj);
                }

            if ((renderMode & (1 << 0)) != 0) foreach (var obj in _figs){
                    GL.Color3(Color.FromArgb(obj.cl.ToArgb() ^ 0xffffff));
                    drawPolygon(obj);
                }
            GL.Disable(EnableCap.ColorLogicOp);
        }


    }
}
