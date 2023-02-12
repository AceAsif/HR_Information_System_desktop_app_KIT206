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
using HRIS.Controller;
using HRIS.Entity;

namespace HRIS.View
{
    /// <summary>
    /// Interaction logic for HeatMapView.xaml
    /// </summary>
    public partial class HeatMapView : UserControl
    {
        //private readonly HeatMapController controller;
        public HeatMapView()
        {
			//controller = (HeatMapController)Application.Current.FindResource("HeatMapController");
			InitializeComponent();

			var random = new Random();
			PickColour.SelectedIndex = random.Next(PickColour.Items.Count);
		}

	
		/*
		/// <summary>
		/// Update the timetable colors when a new color value is selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectColor(object sender, SelectionChangedEventArgs e)
		{
			var brush = (SolidColorBrush)e.AddedItems[0];
			controller.ChooseColour = brush.Color;
			controller.RowsUpdate();
		}*/

		private void ColorGrid_Loaded(object sender, RoutedEventArgs e)
		{

		}

        private void ColourSelect(object sender, SelectionChangedEventArgs e)
        {
			var brush = (SolidColorBrush)e.AddedItems[0];
			//controller.ChooseColour = brush.Color;
			//controller.RowsUpdate();
		}

		/*
        private void CampusSelect(object sender, SelectionChangedEventArgs e)
        {
			controller.CurrCampus = (Campus)FilterCampus.SelectedItem;
		}*/
    }
}




    /*
    var random = new Random();
    PickColour.SelectedIndex = random.Next(PickColour.Items.Count);
        }

private void ColourSelect(object send, SelectionChangedEventArgs e)
{
    var brush = (SolidColorBrush)e.AddedItems[0];
    controller.ChooseColour = brush.Color;
    controller.RowsUpdate();
}

private void ColourGrid_Loaded(object send, RoutedEventArgs e)
{

}
    }*/