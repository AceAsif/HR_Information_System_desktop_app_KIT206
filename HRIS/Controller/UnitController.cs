//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//This file is about unit Controller 
//This file is used to implement and support the most basic features of the unit

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Entity;
using HRIS.Database;
using System.Collections.ObjectModel;

namespace HRIS.Controller
{
    class UnitController
    {
        // Connecting with the database for fetching the information 
        ISchoolDBAdapter database;

        protected List<Unit> EveryUnits;
        protected ObservableCollection<Unit> ViewUnits;
        protected ObservableCollection<UnitClass> viewableClasses = new ObservableCollection<UnitClass>();

        public List<UnitClass> EveryUnitClasses;
        //set Getter and Setter
        public Unit UnitSelected { get; set; }
        public string currNameFilter { get; set; }
        public Campus currCampusFilter { get; set; }
        //Use the 'ObservableCollection' function to perform the sorting and load the unitlist
        public ObservableCollection<Unit> GetUnitList()
        {
            return ViewUnits;
        }
        //Use the 'ObservableCollection' function to perform the sorting and load the unitclasses
        public ObservableCollection<UnitClass> GetUnitClasses()
        {
            return viewableClasses;
        }
        //Achieve sorting, connect to the database and load unit function
        public UnitController()
        {
            database = new SchoolDBAdapter();
            EveryUnits = LoadUnits();
            SortUnits();
            ViewUnits = new ObservableCollection<Unit>(EveryUnits);
        }
        //Load the unit information by call database FetchUnits function
        public List<Unit> LoadUnits()
        {
            return new List<Unit>(database.FetchUnits());
        }
        //Load the unit class information by call database Fetchclasses function
        public List<UnitClass> LoadUnitClass(Unit unit)
        {
            return new List<UnitClass>(database.FetchClasses(unit));
        }
        //sort function, arrange all units in unit.code
        public void SortUnits()
        {
            var sortedUnits = from unit in EveryUnits
                              orderby unit.UnitCode
                              select unit;

            EveryUnits = new List<Unit>(sortedUnits);
        }
        //Load a unit information when the number of units that can be loaded is not zero
        public void LoadUnitDetails(Unit unit)
        {
            if (ViewUnits.Count != 0)
            {
                EveryUnitClasses = LoadUnitClass(unit);
            }
        }

        ////Filter function, filter by campus
        public void FilterByCampus(Campus campus)
        {
            var filteredClasses = from classes in EveryUnitClasses
                                  where classes.Campus == campus
                                  select classes;

            viewableClasses.Clear();

            foreach (UnitClass unitClass in new ObservableCollection<UnitClass>(filteredClasses))
            {
                viewableClasses.Add(unitClass);
            }
        }
        
        //Filter function, filter by Name
        public void FilterByName(string name)
        {
            if (name != null)
            {
                var filteredUnits = from unit in ViewUnits
                                    where unit.UnitCode.StartsWith(name, StringComparison.InvariantCultureIgnoreCase) || unit.UnitTitle.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)
                                    select unit;

                ObservableCollection<Unit> filtered = new ObservableCollection<Unit>(filteredUnits);
                ViewUnits.Clear();

                foreach (Unit unit in filtered)
                {
                    ViewUnits.Add(unit);
                }
            }
        }
        //apply the function 'FilterByName' and 'FilterByCampus'
        public void ApplyFilters()
        {
            viewableClasses.Clear();

            foreach (UnitClass unitClass in new ObservableCollection<UnitClass>(EveryUnitClasses))
            {
                viewableClasses.Add(unitClass);
            }

            if (currCampusFilter != Campus.All)
            {
                FilterByCampus(currCampusFilter);
            }

            ViewUnits.Clear();

            foreach (Unit unit in new ObservableCollection<Unit>(EveryUnits))
            {
                ViewUnits.Add(unit);
            }

            if (currNameFilter != "")
            {
                FilterByName(currNameFilter);
            }
        }




        // set the the staff status, and return it to teaching
        public Availability IsClassBeingTaught(Staff staff)
        {
            return Availability.Teaching;
        }
    }
}
