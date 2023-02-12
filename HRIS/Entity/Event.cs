//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//Set some variable for event

using System;

namespace HRIS.Entity
{
    class Event
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }


        // Define days and weeks by the time things happen 
        private DateTime DayThisWeek => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)Day);

        // Define days and weeks by the time things start
        public DateTime StartDate => DayThisWeek + Start;

        // Define days and weeks by the time things end
        public DateTime EndDate => DayThisWeek + End;

        public bool OverlapOfEvent(DateTime now)
        {
            return now.DayOfWeek == Day && now.TimeOfDay >= Start && now.TimeOfDay < End;
        }

        public override string ToString()
        {
            return Day + "--" + Start + "--" + End;
        }

    }
}
