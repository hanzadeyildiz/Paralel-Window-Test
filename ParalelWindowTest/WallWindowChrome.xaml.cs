using CefSharp.Wpf;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Interop;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ParalelWindowTest
{
    /// <summary>
    /// Interaction logic for WallWindow.xaml
    /// </summary>
    public partial class WallWindowChrome : Window, INotifyPropertyChanged
    {
        ChromiumWebBrowser chromiumWebBrowser;
        public Storyboard fadeIn
        {
            get
            {
                return FindResource("fadeInAnim") as Storyboard;
            }
        }
        public Storyboard setWindow
        {
            get
            {
                return FindResource("setWindowAnim") as Storyboard;
            }
        }
        private int _StartFrom;
        public int StartFrom
        {
            get
            {
                return _StartFrom;
            }
            set
            {
                _StartFrom = value;
            }
        }
        Point currentPoint = new Point();

        private bool _IsOpenMenu;
        public bool IsOpenMenu
        {
            get
            {
                return _IsOpenMenu;
            }
            set
            {
                _IsOpenMenu = value;
                RaisePropertyChanged();
            }
        }
        private Thickness _RadialMenuMargin;
        public Thickness RadialMenuMargin
        {
            get
            {
                return _RadialMenuMargin;
            }
            set
            {
                _RadialMenuMargin = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CloseRadialMenu
        {
            get
            {
                return new RelayCommand(() => IsOpenMenu = false);
            }
        }
        public WallWindowChrome(int left, int top)
        {
            InitializeComponent();
            StartFrom = left - (int)Width;
            Left = left;
            Top = top;
            IsOpenMenu = false;
            RadialMenuMargin = new Thickness(0, 0, 0, 0);
            DataContext = this;
            setWindow.Completed += SetWindowAnim_Completed;
            SizeChanged += WallWindowChrome_SizeChanged;
            LocationChanged += WallWindowChrome_LocationChanged;
             Loaded += WallWindowChrome_Loaded;
        }
        private void WallWindowChrome_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            setWindow.Begin();
            Topmost = false;
            Topmost = true;
        }
        private void WallWindowChrome_LocationChanged(object? sender, EventArgs e)
        {
            fadeIn.Begin();
            Topmost = false;
            Topmost = true;
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);

            */
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            /*
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.StrokeThickness = 2;
                line.Stroke = new SolidColorBrush(Colors.Red);
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                paintSurface.Children.Add(line);
            }
            */
        }

        /*
        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);
        }

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        const int SC_RESTORE = 0xF120;
        const int WM_LBUTTONDBLCLK = 0x0203;
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_LBUTTONDBLCLK:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        // prevent user from moving the window
                        handled = true;
                    }
                    else if (command == SC_RESTORE && WindowState == WindowState.Maximized)
                    {
                        // prevent user from restoring the window while it is maximized
                        // (but allow restoring when it is minimized)
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }
        */


        public void SetImage(string name)
        {
            ImageBrush imageBrush = new ImageBrush();
            Uri uri = new Uri(@"C:\images\mickey-mouse-pictures.jpg");
            Console.WriteLine(uri.ToString());
            imageBrush.ImageSource = new BitmapImage(uri);
            this.bgImage.ImageSource = new BitmapImage(uri);
        }
        public void SetWindowAnimClip()
        {
            RectangleGeometry rectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(0, 0, ActualWidth, ActualHeight),
                RadiusX = 25,
                RadiusY = 25
            };
            // this.Clip = rectangleGeometry;
        }
        public void MoveWindow(int left, int top, int width, int height)
        {
            fadeIn.Begin();
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Topmost = false;
            Topmost = true;


        }
        public void SetZOrderText(string text)
        {
            zIndexTextBlock.Text = text;
            Console.WriteLine(text);
        }
        private void SetWindowAnim_Completed(object? sender, EventArgs e)
        {
            // this.Clip = null;
        }


        private void WallWindowChrome_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Cef.IsInitialized)
            {
                InitCef();
            }
            InitializeChrome();
        }
        private void InitCef()
        {
            CefSettings settings = new CefSettings();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settings.CachePath = path.ToString();
            Console.WriteLine("CefSharp Browser" + Cef.CefSharpVersion);
            settings.UserAgent = "CefSharp Browser" + Cef.CefSharpVersion;
            settings.CefCommandLineArgs.Add("ignore-certificate-errors");
            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream", "1");
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capture", "1");
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.LogSeverity = LogSeverity.Disable;
            settings.MultiThreadedMessageLoop = true;
            Cef.Initialize(settings);
        }
        private void InitializeChrome()
        {
            
            chromiumWebBrowser = new ChromiumWebBrowser();
            chromiumWebBrowser.Address = "http://192.168.0.5:5500/excel.html";
            ChromeDock.Children.Add(chromiumWebBrowser);

        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromMilliseconds(250));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = new Point();
            if (e.ButtonState == MouseButtonState.Pressed)
                point = e.GetPosition(this);
            if (!IsOpenMenu)
            {
                IsOpenMenu = true;
                Console.WriteLine($"{point.X},{point.Y}");
                // RadialMenuMargin = new Thickness(point.X, point.Y, 0, 0);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
