//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//This file is about Heat Map Controller 
//This file is used to implement and support the most basic features of the HEATMap

using System;
using System.Collections.Generic;
using System.Linq;
using HRIS.Entity;
using HRIS.Database;
using HRIS.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Media;

namespace HRIS.Controller
{
    class HeatMapController
    {
        // Connecting with the database for fetching the information       
        ISchoolDBAdapter database;

        // For filtering the campus location for heatmap
        public Campus CurrCampus { get; set; } = Campus.All;

        // For making the class time heatmap row
        private ObservableCollection<ColourGrid> UnitClassRow { get; } = new ObservableCollection<ColourGrid>();

        // For making the consultation time heatmap row
        private ObservableCollection<ColourGrid> ConsultationRow { get; } = new ObservableCollection<ColourGrid>();

        // Method for getting the class time heatmap row data
        public ObservableCollection<ColourGrid> GetUnitClassRow() => UnitClassRow;

        // Method for getting the consultation time heatmap row data
        public ObservableCollection<ColourGrid> GetConsultationRow() => ConsultationRow;

        // For getting the information for Unit class
        private List<Tuple<Event, Campus>> UnitClassData { get; set; }

        // For getting the information for Staff Consultation
        private List<Tuple<Event, Campus>> StaffConsultationData { get; set; }

        //Start hour of the day 
        private const int StartHour = 9;
        //End hour of the day
        private const int EndHour = 16;
        //For getting the number of hours worked by a staff
        private const int HourDomain = EndHour - StartHour + 1;
        //Start Day of the week
        private const int StartDay = 1;
        //End Day of the week
        private const int EndDay = 5;
        //For getting the number of days worked by a staff
        private const int DayDomain = EndDay - StartDay + 1;
        //For setting the colour for empty cells as white
        private static readonly Color BlankCellColour = Colors.AntiqueWhite;
        //Giving user the choice to change the color of the heatmap 
        public static readonly List<Color> ColourValues = new List<Color>
        {
            Colors.Red,
            Colors.Green,
            Colors.DarkBlue,
            Colors.Yellow,
            Colors.Purple,
            Colors.Gray,

        };
        //For getting a list of colour as brush
        public static IEnumerable<Brush> FetchColourOption() => ColourValues.Select(colour => new SolidColorBrush(colour));

        // Choose colour for activity grid
        public Color ChooseColour = ColourValues[0];

        //Constructor for heatmapcontroller class
        public HeatMapController()
        {
            database = new SchoolDBAdapter();
            UnitClassData = database.GetAllUnitClasses();
            //StaffConsultationData = database.GetAllConsult()
            RowsUpdate();
        }
        
        //For generating rows for displaying the heatmap
        private IEnumerable<ColourGrid> GenerateRows(EventTable frequency)
        {
            var lowThers = 0;
            var highThre = frequency.Max();
            var result = new ColourGrid[HourDomain];

            for (var hour = StartHour; hour <= EndHour; hour++)
            {
                var row = new ColourGrid
                {
                    Time = DateTime.Today.AddHours(hour),
                };

                for (var day = StartDay; day <= EndDay; day++)
                {
                    var freq = frequency[day, hour];

                    if (freq == 0)
                    {
                        continue;
                    }

                    row.Value[day - StartDay] = freq;

                    var colour = ChooseColour - BlankCellColour;
                    var weight = (float)(freq - lowThers) / (highThre - lowThers);
                    if (weight <= 1.0)
                    {
                        colour = colour * weight;
                        colour = colour + BlankCellColour;
                    }
                    else
                    {
                        colour = ChooseColour;
                    }

                    colour.A = 255;
                    row.Colours[day - StartDay] = new SolidColorBrush(colour);
                }

                result[hour - StartHour] = row;
              
            }

            return result;
           
        }

        //Rows will try to match the campus filter selected by the user
        private void RowsUpdateFor(IEnumerable<Tuple<Event, Campus>> events, ICollection<ColourGrid> destination)
        {
            var chose = from Tuple<Event, Campus> EventCampus in events
                        where CurrCampus == Campus.All || CurrCampus == EventCampus.Item2
                        select EventCampus.Item1;

            var freq = new EventTable(chose);
            destination.Clear();
            GenerateRows(freq).ToList().ForEach(destination.Add);
        }

        //The row of heatmap will be updated according to the user selection of filer
        public void RowsUpdate()
        {
            RowsUpdateFor(UnitClassData, UnitClassRow);
            //RowsUpdateFor(StaffConsultationData, ConsultationRow);
        }
    }
}
