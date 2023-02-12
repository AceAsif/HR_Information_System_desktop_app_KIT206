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
    public partial class StaffView : UserControl
    {
        ObjectDataProvider staffListProvider;
        StaffController staffController;

        ObjectDataProvider unitListProvider;
        UnitController unitController;

        public StaffView()
        {
            InitializeComponent();

            CategoryFilterBox.ItemsSource = Enum.GetValues(typeof(Category));
            staffListProvider = (ObjectDataProvider)FindResource("MyStaffList");
            staffController = (StaffController)staffListProvider.ObjectInstance;
            StaffList.SelectedIndex = 0;

            unitListProvider = (ObjectDataProvider)FindResource("MyUnitList");
            unitController = (UnitController)unitListProvider.ObjectInstance;
        }

        private void StaffMemberSelected(object sender, SelectionChangedEventArgs e)
        {
            SetModel(StaffList.SelectedItem as Staff);
        }

        private void SetModel(Staff staff)
        {
            staffController.ShowStaffDetails(staff);
            StaffDetailsOutput.DataContext = staffController.StaffSelected;
            AvailabilityTextBox.Text = staffController.ShowStaffAvailability().ToString();
        }

        private void CategoryFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            staffController.CurrCategoryFilter = (Category)CategoryFilterBox.SelectedItem;
            staffController.ApplyFilters();
            StaffList.SelectedIndex = 0;
        }

        private void NameFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            staffController.CurrNameFilter = NameFilterBox.Text;
            staffController.ApplyFilters();
            StaffList.SelectedIndex = 0;
        }

        private void TaughtUnitSelected(object sender, SelectionChangedEventArgs e)
        {
            unitController.UnitSelected = StaffTaughtUnits.SelectedItem as Unit;
            unitController.LoadUnitDetails(unitController.UnitSelected);
            unitController.ApplyFilters();
            
            ((MainWindow)System.Windows.Application.Current.MainWindow).SetMainTab(1);
        }

        private void StaffConsultationHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void ConsultationTable(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).SetMainTab(2);
        }
    }
}
