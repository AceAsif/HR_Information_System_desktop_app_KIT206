//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//As a supporting file for SchoolDBAdapter

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HRIS.Entity;

namespace HRIS.Database
{
    //While Connecting the controller with the database, the interface is used
    interface ISchoolDBAdapter
    {
        //For setting the connection with the databse
        MySqlConnection GetConnection();
        //Getting the basic Staff information
        List<Staff> FetchBasicStaffInformation();
        //Getting the complete Staff information
        Staff CompleteStaffDetails(Staff staffToRetrieve);
        //Getting the unit classes information
        List<UnitClass> FetchClasses(Unit unit);
        //Getting the unit information
        List<Unit> FetchUnits();
        
        public List<Tuple<Event, Campus>> GetAllUnitClasses();

    }
}
