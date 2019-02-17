using org.mariuszgromada.math.mxparser;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using RootFinder.Properties;

namespace RootFinder
{
    class VisualFunction : GameWindow
    {
        private double _speed;
        private double _x;
        private double _range;
        private double _deltaX;
        private Function _function;
        private double _ySqueeze;

        private RootFinder _form;

        public VisualFunction(int width, int height, string function, double speed, double range, double deltaX, double ySqueeze, RootFinder rootFinder)
            : base(width, height)
        {
            Title = "Visualizing Function...";
            WindowBorder = WindowBorder.Fixed;
            _function = new Function("f(x)="+function);
            _speed = speed;
            _x = -range;
            _range = range;
            _deltaX = deltaX;
            _pList = new List<Vector2>();
            _form = rootFinder;
            _ySqueeze = ySqueeze;
            this.Icon = Resources.RootFinder;
            if(!_function.checkSyntax())
            {
                MessageBox.Show($"Function Syntax Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);

        }

        private double? _lastValue = null;
        private int _stackCnt = 0;

        private double _step = 0;

        private Argument _arg = new Argument("x", double.NaN);
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            _step += _speed * e.Time / _deltaX ;
            int updateCnt = (int)Math.Floor(_step);
            _step -= updateCnt;
            for (int i = 0; i < updateCnt; i++)
            {
                _arg.setArgumentValue(_x);

                if (_x > _range)
                    this.Close();

                double value = _function.calculate(_arg);
                if (_lastValue != null)
                {
                    double lastCalc = _function.calculate(new Argument("x", _lastValue.Value));
                    if (Math.Abs(value) <= 0.5)
                    {
                        if (value * lastCalc >= -100)
                        {
                            double? root = FindRoot(_lastValue.Value, _deltaX, double.Epsilon);
                            if (root.HasValue) if(root.Value != double.NaN) _form.AddRoot(root.Value);

                        }
                        else
                            _pList.Add(new Vector2(float.NaN, float.NaN));
                    }
                    else
                    {

                    }
                }
                _lastValue = _x;
                _stackCnt++;
                if (_stackCnt >= 1)
                {
                    _pList.Add(new Vector2((float)_x, (float)value));
                    _stackCnt = 0;
                }
                _x += _deltaX;
            }
        }

        public double? FindRoot(double x, double deltaX, double possibleError)
        {
            double xp = double.NaN;
            double div = double.NaN;
            double x1 = x;
            double x2 = x + deltaX;
            
            while(Math.Abs(FuncValue(x1 - x2)) > possibleError)
            {
                div = FuncValue(x1) - FuncValue(x2);
                if (Math.Abs(div) < double.Epsilon) return null;
                xp = x1 - FuncValue(x1) * (x1 - x2) / div;
                x1 = x2;
                x2 = xp;
            }
            if (double.IsNaN(xp)) return null;
            return xp;
        }

        private double FuncValue(double x)
        {
            return _function.calculate(new Argument("x", x));
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

            //Title = (1 / e.Time).ToString();

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, Height / 2, 0);
            GL.Vertex3(0, -Height / 2, 0);
            GL.Vertex3(-Width / 2, 0, 0);
            GL.Vertex3(Width / 2, 0, 0);
            GL.End();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(Color.White);
            foreach(Vector2 point in _pList)
            {
                GL.Vertex3(point.X * Width / 2 / _range, point.Y * Height / 2 / _range / _ySqueeze, 0);
            }
            GL.End();

            this.SwapBuffers();
        }
    }
}
