//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//Set some variable for UnitClass, define the Unitclass type

namespace HRIS.Entity
{
    public enum Type { Lecture, Tutorial, Practical, Workshop }

    class UnitClass
    {
        public string Room { get; set; }
        
        public Type Type { get; set; }
        public Event DayAndTime { get; set; }
        public Campus Campus { get; set; }
        public Staff Coordinator { get; set; }
        public object Unit { get; internal set; }

    }
}
