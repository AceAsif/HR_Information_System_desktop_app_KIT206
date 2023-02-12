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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRIS.View;

namespace HRIS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {      
            InitializeComponent();         
        }

        public void SetMainTab(int index)
        {
            HrisTabs.SelectedIndex = index;
        }

        private void HeatMapUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
