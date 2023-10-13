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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ParalelWindowTest
{
    /// <summary>
    /// Interaction logic for WallWindow.xaml
    /// </summary>
    public partial class WallWindow : Window
    {
        public Storyboard fadeIn
        {
            get
            {
                return FindResource("fadeInAnim") as Storyboard;
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
        public WallWindow(int left, int top)
        {
            InitializeComponent();
            StartFrom = left-(int)Width;
            Left = left;
            Top = top;
            DataContext = this;
        }

        private void wallWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= wallWindow_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromMilliseconds(250));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }
    }
}
