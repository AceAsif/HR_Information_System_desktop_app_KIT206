//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//The database file, As a file that collects database operations
//This file also contains the code to operate on the database

using System;
using System.Collections.Generic;
using HRIS.Entity;
using MySql.Data.MySqlClient;

namespace HRIS.Database
{
    class SchoolDBAdapter : ISchoolDBAdapter
    {
        //Connect to the database
        private const string database = "kit206";
        private const string userID = "kit206";
        private const string password = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        protected static MySqlConnection conn = null;//set connection function to 'conn'

        // Converts a string to an enumeration
        public T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        //connect to database
        public MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database = {0}; Data Source = {1}; User Id = {2}; Password = {3}; Convert Zero Datetime=true", database, server, userID, password);
                conn = new MySqlConnection(connectionString);
            }

            return conn;
        }


        // This function will fetch the origin staff information by data reader.
        public List<Staff> FetchBasicStaffInformation()
        {
            List<Staff> staff = new List<Staff>();

            MySqlConnection conn = GetConnection(); //call conn to make connection
            MySqlDataReader rdr = null; //set a data reader

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, category from staff", conn); //Staff information in the database is obtained by restricting conditions and stored in data reader
                rdr = cmd.ExecuteReader(); //use data reader to read the information

                while (rdr.Read())
                {
                    staff.Add(new Staff
                    {
                        Id = rdr.GetInt32(0), //use GetInt read the ID that stored in data reader
                        GivenName = rdr.GetString(1), //use GetString read the Given Name that stored in data reader
                        FamilyName = rdr.GetString(2), //use GetString read the Family Name that stored in data reader
                        Title = rdr.GetString(3), //use GetString read the Title that stored in data reader
                        Category = ParseEnum<Category>(rdr.GetString(4)) //call function parseEnum to get the value of category from datareader
                    });
                }
            }
            catch (MySqlException e)//Debug code, display an error message when an accident happens 
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return staff;
        }

        // This function will fetch staff detail by data reader.
        public Staff CompleteStaffDetails(Staff staffToRetrieve)
        {
            Staff staff = new Staff();

            string queryString = String.Format("select * from staff where id = {0}", staffToRetrieve.Id); //Staff detail in the database is obtained by restricting conditions and stored in data reader

            MySqlConnection conn = GetConnection(); //call conn to make connection
            MySqlDataReader rdr = null; //set a data reader

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, conn); //set cmd to get query string 
                rdr = cmd.ExecuteReader(); //use data reader to read the information

                while (rdr.Read())
                {
                    staff = new Staff
                    {
                        Id = rdr.GetInt32(0), //use GetInt read the ID that stored in data reader
                        //use GetString read the Given Name that stored in data reader
                        GivenName = rdr.GetString(1),
                        FamilyName = rdr.GetString(2),
                        Title = rdr.GetString(3),
                        PhoneNumber = rdr.GetString(5),
                        RoomLocation = rdr.GetString(6),
                        EmailAddress = rdr.GetString(7),
                        Photo = rdr.GetString(8),
                        //call function parseEnum to get the value of category from datareader
                        Campus = ParseEnum<Campus>(rdr.GetString(4)),
                        Category = ParseEnum<Category>(rdr.GetString(9))
                    };
                }

                rdr.Close(); // close data reader. 
                queryString = String.Format("select distinct unit.code, unit.title from unit, class where class.staff = '" + staff.Id + "' and unit.code = class.unit_code"); //Unit information in the database is obtained by restricting conditions and stored in data reader
                cmd = new MySqlCommand(queryString, conn); //set cmd to get query string 
                rdr = cmd.ExecuteReader();// set a new data reader

                List<Unit> units = new List<Unit>(); // Define a new class
                //call data reader for get unit value
                while (rdr.Read())
                {
                    units.Add(new Unit
                    { UnitCode = rdr.GetString(0), UnitTitle = rdr.GetString(1) });
                }

                staff.TeachesUnit = units;

                rdr.Close(); //close data reader
                queryString = String.Format("select room, campus, type, day, start, end from class where staff = {0}", staff.Id); //unit classes information in the database is obtained by restricting conditions and stored in data reader
                cmd = new MySqlCommand(queryString, conn); //set cmd to get query string 
                rdr = cmd.ExecuteReader(); // set a data reader

                List<UnitClass> unitClasses = new List<UnitClass>();/*list*/
                // call data reader to get value from it
                while (rdr.Read())
                {
                    //call data reader for get unitclass value
                    unitClasses.Add(new UnitClass
                    {
                        Room = rdr.GetString(0),
                        Campus = ParseEnum<Campus>(rdr.GetString(1)),
                        Type = ParseEnum<Entity.Type>(rdr.GetString(2)),

                        DayAndTime = new Event
                        {
                            Day = ParseEnum<DayOfWeek>(rdr.GetString(3)),
                            Start = rdr.GetTimeSpan(4),
                            End = rdr.GetTimeSpan(5)
                        }
                    });
                }

                staff.TeachesClass = unitClasses;

                rdr.Close(); //close data reader
                queryString = String.Format("select day, start, end from consultation where staff_id = {0}", staff.Id); //consultion time in the database is obtained by restricting conditions and stored in data reader
                cmd = new MySqlCommand(queryString, conn);
                rdr = cmd.ExecuteReader(); //set data reader


                List<Event> consultationInfo = new List<Event>();
                //call data reader for get cnsultation time value
                while (rdr.Read())
                {
                    consultationInfo.Add(new Event
                    {
                        Day = ParseEnum<DayOfWeek>(rdr.GetString(0)),
                        Start = rdr.GetTimeSpan(1),
                        End = rdr.GetTimeSpan(2)
                    });
                }

                staff.ConsultationTimes = consultationInfo;

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return staff;
        }

        // This function will fetch units information by data reader.
        public List<Unit> FetchUnits()
        {
            List<Unit> units = new List<Unit>(); // Define a new class
            //call data reader for get cnsultation time value
            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select code, title from unit", conn);  // Filter specific units by code and title from the database
                rdr = cmd.ExecuteReader();
                // call data reader for unit information
                while (rdr.Read())
                {
                    units.Add(new Unit
                    {
                        UnitCode = rdr.GetString(0),
                        UnitTitle = rdr.GetString(1)
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return units;
        }

        // This function will fetch class information by data reader.
        public List<UnitClass> FetchClasses(Unit unit)
        {
            List<UnitClass> classes = new List<UnitClass>(); // Define a new class
            MySqlDataReader rdr = null;

            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT class.campus, class.type, class.room, class.day, class.start, class.end, staff.given_name, staff.family_name, staff.title FROM class, staff, unit WHERE class.unit_code = '" + unit.UnitCode + "' AND unit.code = '" + unit.UnitCode + "' AND staff.id = unit.coordinator", conn); // Filter specific units by  limiting condition from the database
                rdr = cmd.ExecuteReader();

                while (rdr.Read())// call data reader for unitclass , event and staff by Get
                {
                    classes.Add(new UnitClass
                    {
                        Campus = ParseEnum<Campus>(rdr.GetString(0)),
                        Type = ParseEnum<Entity.Type>(rdr.GetString(1)),
                        Room = rdr.GetString(2),

                        DayAndTime = new Event
                        {
                            Day = ParseEnum<DayOfWeek>(rdr.GetString(3)),
                            Start = rdr.GetTimeSpan(4),
                            End = rdr.GetTimeSpan(5)
                        },

                        Coordinator = new Staff
                        {
                            GivenName = rdr.GetString(6),
                            FamilyName = rdr.GetString(7),
                            Title = rdr.GetString(8)
                        }
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return classes;
        }

        //Set private type for Event, call the list
        //Use Tuple represents a 2-tuple or the pair
        //the value in 'Event' and 'Campus' will be read by data reader
        private List<Tuple<Event, Campus>> ObtainEvents(MySqlCommand command)
        {
            //Set two data reader for tuple function
            MySqlDataReader reader = null;
            var events = new List<Tuple<Event, Campus>>();
            MySqlDataReader rdr = null;

            conn = GetConnection();

            try
            {
                reader = command.ExecuteReader(); // call and set the 'reader' as Execute Reader
                // call the reader to get value
                while (reader.Read())
                {
                    var eventObject = new Event
                    {
                        Start = reader.GetTimeSpan("start"),
                        End = reader.GetTimeSpan("end"),
                        Day = ParseEnum<DayOfWeek>(reader.GetString("day")),
                    };

                    var campus = ParseEnum<Campus>(reader.GetString("campus"));

                    events.Add(Tuple.Create(eventObject, campus));
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return events;
        }

        //Use Tuple represents a 2-tuple or the pair
        //The value in 'Event' and 'Campus' will be read by data reader
        public List<Tuple<Event, Campus>> GetAllUnitClasses()
        {

            conn = GetConnection();
            try
            {
                conn.Open();
                var command = new MySqlCommand("SELECT start, end, day, campus FROM class", conn);
                return ObtainEvents(command);
            }
            finally
            {
                conn?.Close();
            }
        }


    }
}


