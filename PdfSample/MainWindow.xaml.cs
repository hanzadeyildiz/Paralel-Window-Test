
using System;
using System.Collections.Generic;
using System.Data.MoonPdf.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PdfSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private Microsoft.Office.Interop.PowerPoint.Application app;
        static private Presentations ppts;
        PdfWindow pdfWindow = new PdfWindow();
        public MainWindow()
        {
            InitializeComponent();
            app = new ApplicationClass();
            ppts = app.Presentations;
            Presentation ppt = ppts.Open(pptPath, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
            SlideShowSettings sss = ppt.SlideShowSettings;
            sss.Run();

            while (app.SlideShowWindows.Count <= 0) ;

            SlideShowWindow ssw = ppt.SlideShowWindow;
            SlideShowView ssv = ssw.View;
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                pdfWindow.Show();
            }));
        }

        private void goNextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                pdfWindow.GoNextPage();
            }));
        }

        private void goPreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                pdfWindow.GoPreviousPage();
            }));
        }
    }
}
