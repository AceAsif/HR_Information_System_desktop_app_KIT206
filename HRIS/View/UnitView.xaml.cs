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
using HRIS.Entity;
using HRIS.Controller;

namespace HRIS.View
{
    public partial class UnitView : UserControl
    {
        ObjectDataProvider unitListProvider;
        UnitController unitController;

        ObjectDataProvider staffListProvider;
        StaffController staffController;

        public UnitView()
        {
            InitializeComponent();

            CampusFilteredBox.ItemsSource = Enum.GetValues(typeof(Campus));
            unitListProvider = (ObjectDataProvider)FindResource("MyUnitList");
            unitController = (UnitController)unitListProvider.ObjectInstance;
            UnitDayandTime.DataContext = unitController.UnitSelected;
            UnitList.SelectedIndex = 0;

            staffListProvider = (ObjectDataProvider)FindResource("MyStaffList");
            staffController = (StaffController)staffListProvider.ObjectInstance;
        }

        private void UnitListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetModel(UnitList.SelectedItem as Unit);
            unitController.ApplyFilters();
        }

        private void SetModel(Unit unit)
        {
            unitController.LoadUnitDetails(unit);
            unitController.ApplyFilters();
        }

        private void NameFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            unitController.currNameFilter = UnitNameFilterBox.Text;
            unitController.ApplyFilters();
            UnitList.SelectedIndex = 2;
        }

        private void CampusFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitController.currCampusFilter = (Campus)CampusFilteredBox.SelectedItem;
            unitController.ApplyFilters();
        }

        private void UnitCoordinatorSelected(object sender, SelectionChangedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).SetMainTab(0);
        }
    }
}
