using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParalelWindowTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WallWindowChrome> wallWindows = new List<WallWindowChrome>();
        public Point CanvasPoint = new Point(0, 0);
        public int WindowRatio = 2;
        public bool IsWindowDrag = false;
        public bool IsWindowResize = false;
        public Point StartPoint;
        public const string CANVAS_SLUG = "";
        private double originalWidth, originalHeight;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //  InitWallWindows();
        }
        public Rectangle CreateCanvasWindow(Rect rect)
        {
            Rectangle rectangle = new Rectangle();
            Random r = new Random();
            rectangle.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
            rectangle.Width = rect.Width;
            rectangle.Height = rect.Height;
            return rectangle;
        }
        public Rect ConvertToCanvasRect(double left, double top, double width, double height)
        {
            Rect rect = new Rect()
            {
                X = left / WindowRatio,
                Y = top / WindowRatio,
                Width = width / WindowRatio,
                Height = height / WindowRatio
            };
            return rect;
        }
        public Rect ConvertToWindowRect(double left, double top, double width, double height)
        {
            Rect rect = new Rect()
            {
                X = left * WindowRatio,
                Y = top * WindowRatio,
                Width = width * WindowRatio,
                Height = height * WindowRatio
            };
            return rect;
        }
        public void AddToCanvas(Window window)
        {
            Rect canvasRect = ConvertToCanvasRect(window.Left, window.Top, window.Width, window.Height);
            Rectangle rectangle = CreateCanvasWindow(new Rect() { Width = canvasRect.Width, Height = canvasRect.Height });
            rectangle.Tag = $"{CANVAS_SLUG}{window.Title}";
            rectangle.ToolTip = $"{CANVAS_SLUG}{window.Title}";
            windowCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, canvasRect.X);
            Canvas.SetLeft(rectangle, canvasRect.Y);
            ListenCanvasEvent();
        }
        private void addWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                WallWindowChrome wallWindow = new WallWindowChrome((int)CanvasPoint.X, (int)CanvasPoint.Y);
                wallWindow.Title = Guid.NewGuid().ToString();
                wallWindow.fadeIn.Begin();
                wallWindow.Show();
                wallWindows.Add(wallWindow);
                AddToCanvas(wallWindow);
            });
        }

        private void clearLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < windowCanvas.Children.Count; i++)
            {
                Rectangle canvasItem = windowCanvas.Children[i] as Rectangle;
                this.Dispatcher.Invoke(() =>
                {
                    Window window = wallWindows.Where(o => $"{CANVAS_SLUG}{o.Title}" == $"{canvasItem.Tag}").FirstOrDefault();
                    if (window is not null)
                    {
                        window.Close();
                    }
                });
            }
            wallWindows.Clear();
            windowCanvas.Children.Clear();
            IsWindowDrag = false;
            IsWindowResize = false;
        }
        private void applyLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < windowCanvas.Children.Count; i++)
            {
                Rectangle canvasItem = windowCanvas.Children[i] as Rectangle;
                this.Dispatcher.Invoke(() =>
                {
                    Window window = wallWindows.Where(o => $"{CANVAS_SLUG}{o.Title}" == $"{canvasItem.Tag}").FirstOrDefault();
                    if (window is not null)
                    {
                        window.Close();
                    }
                });
            }
            wallWindows.Clear();
            for (int i = 0; i < windowCanvas.Children.Count; i++)
            {
                Rectangle canvasItem = windowCanvas.Children[i] as Rectangle;
                this.Dispatcher.Invoke(() =>
                {
                    double left = Canvas.GetLeft(canvasItem);
                    double top = Canvas.GetTop(canvasItem);
                    Rect windowRect = ConvertToWindowRect(left , top, canvasItem.Width, canvasItem.Height);

                    WallWindowChrome wallWindow = new WallWindowChrome((int)windowRect.Left, (int)windowRect.Top);
                    wallWindow.Width = windowRect.Width;
                    wallWindow.Height = windowRect.Height;
                    wallWindow.Title = canvasItem.Tag.ToString();
                    wallWindow.fadeIn.Begin();
                    wallWindow.Show();
                    wallWindows.Add(wallWindow);
                });
            }
        }

        public void ListenCanvasEvent()
        {
            for (int i = 0; i < windowCanvas.Children.Count; i++)
            {
                Rectangle canvasItem = windowCanvas.Children[i] as Rectangle;
                canvasItem.MouseDown -= (o, e) => { };
                canvasItem.MouseMove -= (o, e) => { };
                canvasItem.MouseUp -= (o, e) => { };
                canvasItem.MouseEnter -= (o, e) => { };
                canvasItem.MouseLeave -= (o, e) => { };

            }
            for (int i = 0; i < windowCanvas.Children.Count; i++)
            {
                Rectangle canvasItem = windowCanvas.Children[i] as Rectangle;
                canvasItem.MouseLeftButtonDown += (o, e) =>
                {
                    canvasItem.Cursor = Cursors.Arrow;
                    IsWindowDrag = false;
                    IsWindowResize = true;
                    StartPoint = Mouse.GetPosition(windowCanvas);
                    originalWidth = canvasItem.Width;
                    originalHeight = canvasItem.Height;
                };
                canvasItem.MouseRightButtonDown += (o, e) =>
                {
                    canvasItem.Cursor = Cursors.Arrow;
                    IsWindowDrag = true;
                    IsWindowResize = false;
                    StartPoint = Mouse.GetPosition(windowCanvas);
                };
                canvasItem.MouseMove += (o, e) =>
                {
                    if (IsWindowDrag && e.RightButton == MouseButtonState.Pressed)
                    {
                        canvasItem.Cursor = Cursors.Hand;
                        Point newPoint = Mouse.GetPosition(windowCanvas);
                        double left = Canvas.GetLeft(canvasItem);
                        double top = Canvas.GetTop(canvasItem);
                        Canvas.SetLeft(canvasItem, left + (newPoint.X - StartPoint.X));
                        Canvas.SetTop(canvasItem, top + (newPoint.Y - StartPoint.Y));
                        StartPoint = newPoint;
                    }
                    else if (IsWindowResize && e.LeftButton == MouseButtonState.Pressed)
                    {
                        canvasItem.Cursor = Cursors.Hand;
                        Point currentPoint = e.GetPosition(windowCanvas);
                        double offsetX = currentPoint.X - StartPoint.X;
                        double offsetY = currentPoint.Y - StartPoint.Y;

                        // Update rectangle size
                        canvasItem.Width = Math.Max(0, originalWidth + offsetX);
                        canvasItem.Height = Math.Max(0, originalHeight + offsetY);

                    }
                };
                canvasItem.MouseLeftButtonUp += (o, e) =>
                {
                    canvasItem.Cursor = Cursors.Arrow;
                    Point newPoint = Mouse.GetPosition(windowCanvas);
                    double left = Canvas.GetLeft(canvasItem);
                    double top = Canvas.GetTop(canvasItem);
                    Rect windowRect = ConvertToWindowRect(left + (newPoint.X - StartPoint.X), top + (newPoint.Y - StartPoint.Y), canvasItem.Width, canvasItem.Height);
                    this.Dispatcher.Invoke(() =>
                    {
                        Window window = wallWindows.Where(o => $"{CANVAS_SLUG}{o.Title}" == $"{canvasItem.Tag}").FirstOrDefault();
                        if (window is not null)
                        {
                            window.Width = windowRect.Width;
                            window.Height = windowRect.Height;
                        }
                    });
                    IsWindowDrag = false;
                    IsWindowResize = false;

                };

                canvasItem.MouseRightButtonUp += (o, e) =>
                {
                    canvasItem.Cursor = Cursors.Arrow;
                    Point newPoint = Mouse.GetPosition(windowCanvas);
                    double left = Canvas.GetLeft(canvasItem);
                    double top = Canvas.GetTop(canvasItem);
                    Rect windowRect = ConvertToWindowRect(left + (newPoint.X - StartPoint.X), top + (newPoint.Y - StartPoint.Y), canvasItem.Width, canvasItem.Height);
                    this.Dispatcher.Invoke(() =>
                    {
                        Window window = wallWindows.Where(o => $"{CANVAS_SLUG}{o.Title}" == $"{canvasItem.Tag}").FirstOrDefault();
                        if (window is not null)
                        {
                            window.Left = windowRect.Left;
                            window.Top = windowRect.Top;
                        }
                    });
                    IsWindowDrag = false;
                    IsWindowResize = false;
                };
                canvasItem.MouseWheel += (o, e) =>
                {
                    if (e.Delta < 0)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Window window = wallWindows.Where(o => $"{CANVAS_SLUG}{o.Title}" == $"{canvasItem.Tag}").FirstOrDefault();
                            if (window is not null)
                            {
                                window.Close();
                            }
                            windowCanvas.Children.Remove(canvasItem);
                        });
                        IsWindowDrag = false;
                        IsWindowResize = false;
                    }
                };
                canvasItem.MouseEnter += (o, e) =>
                {
                    Console.WriteLine("Mouse Enter");
                    canvasItem.Cursor = Cursors.Hand;
                };
                canvasItem.MouseLeave += (o, e) =>
                {
                    Console.WriteLine("Mouse Leave");
                    canvasItem.Cursor = Cursors.Arrow;
                    IsWindowDrag = false;
                    IsWindowResize = false;
                    /*
                                     canvasItem.CaptureMouse();
                canvasItem.ReleaseMouseCapture(); 
                     
                     */
                };
            }
        }
    }
}
