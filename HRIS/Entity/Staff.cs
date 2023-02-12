//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//Set some variable for staff, define 3 enum value for campus , category and availability

using System;
using System.Collections.Generic;
using System.Linq;


namespace HRIS.Entity
{
    public enum Campus { All, Hobart, Launceston } //set enmu value for campus 
    public enum Category { All, Academic, Technical, Admin, Casual } //set enmu value for category
    public enum Availability { Free, Consulting, Teaching } //set enmu value for Availability

    class Staff
    {
        //Complete information for the staff
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string RoomLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        
        public Campus Campus { get; set; }
        public Category Category { get; set; }
        public List<Unit> TeachesUnit { get; set; }
        public List<UnitClass> TeachesClass { get; set; }
        public List<Event> ConsultationTimes { get; set; }


        //Get availability value
        //Free , consulting , teaching
        public Availability GetAvailability()
        {
            Availability currAvailablity = Availability.Free;
            DateTime now = DateTime.Now;

            var overlap = from Event consult in ConsultationTimes
                          where consult.OverlapOfEvent(now)
                          select consult;
            var classOverlap = from UnitClass unitClass in TeachesClass
                               where unitClass.DayAndTime.OverlapOfEvent(now)
                               select unitClass;
            if (overlap.Count() > 0)
            {
                currAvailablity = Availability.Consulting;
            }
            if (classOverlap.Count() > 0)
            {
                currAvailablity = Availability.Teaching;
            }

            return currAvailablity;
        }


        public override string ToString()
        {
            return String.Format("In {0}, {1} {2}, the full name is {1} {2}, works as a {4} in Room {5}. If you have any question, please make a phone call or send an e-mail, Phone number is {6}, E-mail dress is {7}",
                Campus, Title, FamilyName, GivenName, Category, RoomLocation, PhoneNumber, EmailAddress);
        }

    }
}
