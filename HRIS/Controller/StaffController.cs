//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//This file is about Staff Controller 
//This file is used to implement and support the most basic features of the Staff and staff list

using System;
using System.Collections.Generic;
using System.Linq;
using HRIS.Entity;
using System.Collections.ObjectModel;
using HRIS.Database;

namespace HRIS.Controller
{
    class StaffController
    {
        protected ObservableCollection<Staff> viewableStaff;
        protected List<Staff> EveryStaff;

        // Connecting with the database for fetching the information  
        ISchoolDBAdapter database;

        //Getter and Setter
        public Staff StaffSelected { get; set; }
        public string CurrNameFilter { get; set; }
        public Category CurrCategoryFilter { get; set; }
        

        // //Establish a connection to the database, apply NameFilter
        public StaffController()
        {
            database = new SchoolDBAdapter();
            EveryStaff = LoadStaff();
            CurrNameFilter = "";
            viewableStaff = new ObservableCollection<Staff>(EveryStaff); //define the new staff list
        }

        //load the staff information from database
        public List<Staff> LoadStaff()
        {
            return new List<Staff>(database.FetchBasicStaffInformation());
        }

        //Filter function to staff, Filter by category
        public void FilterByCategory(Category category)
        {
            //Use LINQ function here
            var categoryFilter = from staff in EveryStaff
                                 where staff.Category == category
                                 select staff;

            viewableStaff.Clear();

            // call ObservableCollection<Staff> to load staff
            foreach (Staff s in new ObservableCollection<Staff>(categoryFilter))
            {
                viewableStaff.Add(s);
            }
        }

        // Filter function to staff, Filter by staff name
        public void FilterByName(string name)
        {
            // Use LINQ function here
            var nameFilter = from staff in viewableStaff
                             where staff.GivenName.StartsWith(name, StringComparison.InvariantCultureIgnoreCase) || staff.FamilyName.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)
                             select staff;

            // Read staff information through "ObservableCollection" and use LINQ function to filt
            ObservableCollection<Staff> filtered = new ObservableCollection<Staff>(nameFilter);
            viewableStaff.Clear();

            foreach (Staff s in filtered)
            {
                viewableStaff.Add(s);
            }
        }

        //apply the function 'FilterByName' and 'FilterByCategory'
        public void ApplyFilters()
        {
            if (CurrCategoryFilter != Category.All)
            {
                FilterByCategory(CurrCategoryFilter);
            }
            else
            {
                viewableStaff.Clear();

                foreach (Staff s in new ObservableCollection<Staff>(EveryStaff))
                {
                    viewableStaff.Add(s);
                }
            }

            if (CurrNameFilter != "")
            {
                FilterByName(CurrNameFilter);
            }
        }

        //Call the getter and setter to get staff information.
        public void ShowStaffDetails(Staff staff)
        {
            if (viewableStaff.Count != 0)
            {
                StaffSelected = database.CompleteStaffDetails(staff);
            }
        }

        public ObservableCollection<Staff> GetStaff()
        {
            return viewableStaff;
        }

        //Set the availability value here
        public Availability ShowStaffAvailability()
        {
            return StaffSelected.GetAvailability();
        }
    }
}
