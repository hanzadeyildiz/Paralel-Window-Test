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

namespace PdfSample
{
    /// <summary>
    /// Interaction logic for PdfWindow.xaml
    /// </summary>
    public partial class PdfWindow : Window
    {
        public PdfWindow()
        {
            InitializeComponent();
            Loaded += PdfWindow_Loaded;
            SizeChanged += PdfWindow_SizeChanged;
            moonPdfPanel.PdfLoaded += MoonPdfPanel_PdfLoaded;
        }

        private void MoonPdfPanel_PageRowDisplayChanged(object? sender, EventArgs e)
        {
            Console.WriteLine($"GetCurrentPageNumber: {moonPdfPanel.GetCurrentPageNumber()}");
        }

        private void MoonPdfPanel_PdfLoaded(object? sender, EventArgs e)
        {
            moonPdfPanel.ZoomToWidth();
            Console.WriteLine($"TotalPages: {moonPdfPanel.TotalPages}");
            Console.WriteLine($"GetCurrentPageNumber: {moonPdfPanel.GetCurrentPageNumber()}");
        }

        private void PdfWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (moonPdfPanel.IsLoaded)
            {
                moonPdfPanel.ZoomToWidth();
            }
        }

        private void PdfWindow_Loaded(object sender, RoutedEventArgs e)
        {
            moonPdfPanel.OpenFile(@"C:\Users\BurakSIMSEK\Downloads\WallServiceCore Media List (1).pdf");
        }
        public void GoNextPage()
        {
            moonPdfPanel.GotoNextPage();
        }
        public void GoPreviousPage()
        {
            moonPdfPanel.GotoPreviousPage();
        }
    }
}
