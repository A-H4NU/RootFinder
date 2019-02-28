using org.mariuszgromada.math.mxparser;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RootFinder.Properties;

namespace RootFinder
{
    class VisualFunction : GameWindow
    {
        private readonly double _speed;
        private double _x;
        private readonly double _range;
        private readonly double _deltaX;
        private Function _function;
        private readonly double _ySqueeze;
        public const double SenseRange = 1E-3;

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

        private double? _lastX = null;
        private double? _lastY = null;
        private double? _lastDiff = null;
        private int _stackCnt = 0;

        private double _step = 0;

        private bool lastDone = false;

        //private PossibleRoots _current = null;

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

                double _currentY = _function.calculate(_arg);
                double _currentDiff = Math.Abs(_currentY);
                
                while (true)
                {
                    if (_lastX == null)
                    {
                        _lastX = _x;
                        _lastY = _function.calculate(_arg);
                        _lastDiff = Math.Abs(_lastY.Value);
                        break;
                    }

                    if (Math.Abs(_currentY - _lastY.Value) >= byte.MaxValue)
                    {
                        lastDone = false;
                        _pList.Add(new Vector2(float.NaN, float.NaN));
                        break;
                    }

                    if (_currentDiff <= double.Epsilon)
                    {
                        _form.AddRoot(_x);
                        lastDone = true;
                        break;
                    }

                    if (_lastY * _currentY <= 0)
                    {
                        double? root = (FindRoot1(_lastX.Value, _deltaX, double.Epsilon));
                        if (root.HasValue)
                        {
                            _form.AddRoot(root.Value);
                            lastDone = true;
                        }
                        break;
                    }

                    if (_currentDiff < _lastDiff && _currentDiff <= SenseRange)
                    {
                        if (!lastDone)
                        {
                            double? root = FindRoot2(_lastX.Value - _deltaX, _deltaX * 2, double.Epsilon);
                            if (root != null)
                            {
                                _form.AddRoot(root.Value);
                                lastDone = true;
                            }
                        }
                        lastDone = true;
                        break;
                    }
                    lastDone = false;
                    break;
                }

                _lastX = _x;
                _lastY = _currentY;
                _lastDiff = _currentDiff;

                _stackCnt++;
                if (_stackCnt >= 1)
                {
                    _pList.Add(new Vector2((float)_x, (float)_currentY));
                    _stackCnt = 0;
                }
                _x += _deltaX;
            }
        }

        public double? FindRoot1(double x, double deltaX, double possibleError)
        {
            double x1 = x;
            double x2 = x + deltaX;
            while (true) {
                double val1 = FuncValue(x1);
                double val2 = FuncValue((x1 + x2) / 2);
                double val3 = FuncValue(x2);
                if (Math.Abs(val1) < possibleError)
                {
                    return x1;
                }
                if (Math.Abs(val2) < possibleError)
                {
                    return x2;
                }
                if (Math.Abs(val3) < possibleError)
                {
                    return (x1 + x2) / 2;
                }
                deltaX /= 2;
                if (deltaX < double.Epsilon) return null;
                if (val1 * val2 <= 0)
                {
                    x2 = x1 + deltaX;
                }
                else
                {
                    x1 += deltaX;
                }
            }
        }

        public double? FindRoot2(double x, double deltaX, double possibleError)
        {
            double xp = double.MaxValue;
            double div = double.NaN;
            double x1 = x;
            double x2 = x + deltaX;
            
            while(Math.Abs(x1-x2) > possibleError)
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
