using org.mariuszgromada.math.mxparser;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace RootFinder
{
    class VisualFunction : GameWindow
    {
        private double _speed;
        private double _x;
        private double _range;
        private double _deltaX;
        private Function _function;

        public VisualFunction(int width, int height, string function, double speed, double range, double deltaX)
            : base(width, height)
        {
            WindowBorder = WindowBorder.Fixed;
            _function = new Function("f(x)="+function);
            _speed = speed;
            _x = -range;
            _range = range;
            _deltaX = deltaX;
            _pList = new List<Vector2>((int)Math.Ceiling(range * 2 / deltaX));
            if(!_function.checkSyntax())
            {
                MessageBox.Show("error");
                this.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);

        }

        private double? _lastValue = null;

        private Argument _arg = new Argument("x", double.NaN);
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            _arg.setArgumentValue(_x);

            if (_x > _range)
                this.Close();

            double value = _function.calculate(_arg);
            if (_lastValue != null)
            {
                double lastCalc = _function.calculate(new Argument("x", _lastValue.Value));
                if(value * lastCalc <= 0)
                {
                    MessageBox.Show(FindRoot(_lastValue.Value, _deltaX, 10 * double.Epsilon).ToString());
                }
            }
            _lastValue = _x;
            _pList.Add(new Vector2((float)_x, (float)value));
            _x += _deltaX;
        }

        public double FindRoot(double x, double deltaX, double possibleError)
        {
            double xVal = _function.calculate(new Argument("x", x));
            double dxVal = _function.calculate(new Argument("x", x + deltaX));
            double value = _function.calculate(new Argument("x", x + deltaX / 2));
            if (Math.Abs(value) <= possibleError)
            {
                return Math.Round(x + deltaX / 2, 14);
            }
            if (Math.Abs(xVal) <= possibleError)
            {
                return Math.Round(x, 14);
            }
            if (Math.Abs(dxVal) <= possibleError)
            {
                return Math.Round(x + deltaX, 14);
            }
            else
            {
                if(xVal * value <= 0)
                {
                    return FindRoot(x, deltaX / 2, possibleError);
                }
                else
                {
                    return FindRoot(x + deltaX / 2, deltaX / 2, possibleError);
                }
            }
        }

        List<Vector2> _pList;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Viewport(this.ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-Width / 2, Width / 2, -Height / 2, Height / 2, -1.0, 1.0);

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(Color.White);
            foreach(Vector2 point in _pList)
            {
                GL.Vertex3(point.X * Width / 2 / _range, point.Y * Width / 2 / _range, 0);
            }
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, Height, 0);
            GL.Vertex3(0, -Height, 0);
            GL.Vertex3(-Width, 0, 0);
            GL.Vertex3(Width, 0, 0);
            GL.End();

            this.SwapBuffers();
        }
    }
}
