using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using pure.zlo_2.source;

namespace pure.zlo_2
{
    public partial class Canvas : Form{
        private bool _initialized = false;
        private Render renderer;
        private Point _mouse1;
        private bool _hasCenter = false;
        public Canvas()
        {
            InitializeComponent();
            renderer = new Render(glViewer);
        }

        private void glViewer_Load(object sender, EventArgs e)
        {
            glViewer.MakeCurrent();
            GL.ClearColor(Color.White);
            
            GL.Viewport(glViewer.ClientSize);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glViewer.ClientSize.Width, glViewer.ClientSize.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            _initialized = true;
        }

        private void glViewer_Resize(object sender, EventArgs e)
        {
            if (!_initialized) return;
            renderer.resize(((GLControl)sender).Width, ((GLControl)sender).Height);
        }

        private void glViewer_MouseDown(object sender, MouseEventArgs e)
        {
            _hasCenter = !_hasCenter;
            if (_hasCenter)
            {
                _mouse1 = e.Location;
                _mouse1.X -= 1;
                _mouse1.Y -= 1;
                renderer.addFigure(_mouse1, e.Location);
                renderer.refresh();
                dashbord.Enabled = false;
                currentId_comboBox.Items.Add("" + renderer.Count);
                currentId_comboBox.SelectedIndex = currentId_comboBox.Items.Count - 1;
                return;
            }
            dashbord.Enabled = true;
        }

        private void glViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_hasCenter){
                renderer.tempFig(currentId_comboBox.SelectedIndex, _mouse1, e.Location);
                renderer.refresh();
            }
        }

        private void glViewer_Paint(object sender, PaintEventArgs e)
        {
            if (!_initialized) return;
            glViewer.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Disable(EnableCap.ColorLogicOp);

            renderer.drawObjects();
            renderer.drawGrid();
            
            glViewer.SwapBuffers();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_hasCenter)
            {
                if (currentId_comboBox.SelectedIndex == -1) return;
                bool refresh = true;

                switch (e.KeyCode)
                {
                    case Keys.Q:
                    case Keys.E:
                        renderer.rotateFig(currentId_comboBox.SelectedIndex, e.KeyCode == Keys.E);
                        break;
                    case Keys.Z:
                    case Keys.X:
                        renderer.resizeFig(currentId_comboBox.SelectedIndex, e.KeyCode == Keys.X);
                        break;
                    case Keys.W: renderer.moveFig(currentId_comboBox.SelectedIndex, 0, -renderer.cellSize); break;
                    case Keys.S: renderer.moveFig(currentId_comboBox.SelectedIndex, 0, renderer.cellSize); break;
                    case Keys.A: renderer.moveFig(currentId_comboBox.SelectedIndex, -renderer.cellSize, 0); break;
                    case Keys.D: renderer.moveFig(currentId_comboBox.SelectedIndex, renderer.cellSize, 0); break;
                    default: refresh = false; break;
                }
                if (refresh) renderer.refresh();
            }
        }

        private void cellSize_trackBar_Scroll(object sender, EventArgs e)
        {
            cellSize_lbl.Text = cellSize_trackBar.Value + "";
            renderer.cellSize = cellSize_trackBar.Value;
            renderer.refresh();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            renderer.merge = Byte.Parse(((RadioButton)sender).Tag.ToString());
            renderer.refresh();
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            renderer.renderMode ^= (byte)(1 << int.Parse(((CheckBox)sender).Tag.ToString()));
            renderer.refresh();
        }


        private void color_button_Click(object sender, EventArgs e)
        {
            if (currentId_comboBox.SelectedIndex == -1) return;
            using (var d = new ColorDialog())
            {
                if (DialogResult.OK == d.ShowDialog())
                {
                    renderer.changeColor(currentId_comboBox.SelectedIndex, d.Color);
                    renderer.refresh();
                }
            }
        }

        private void textureChoose_button_Click(object sender, EventArgs e)
        {
            if (currentId_comboBox.SelectedIndex == -1) return;
            using (var d = new OpenFileDialog())
            {
                DialogResult a;
                if (DialogResult.OK == (a = d.ShowDialog()))
                {
                    renderer.applyTexture(currentId_comboBox.SelectedIndex, d.FileName);
                    renderer.refresh();
                }
            }
        }


    }
}
