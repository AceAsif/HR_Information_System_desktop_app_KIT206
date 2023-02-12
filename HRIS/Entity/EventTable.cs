//Author: Jiajun He 469858 , Md Asif Iqbal 554280, Weixia Dai 477420
//Set some variable for event table

using System;
using System.Collections.Generic;


namespace HRIS.Entity
{
	public class EventTable
	{
		// Number of days during a week
		private const int DaysCount = 7;


		// Number of hours during a day
		private const int HoursCount = 24;


		// Multidimensional array for storing frequencies
		private int[,] Freq { get; } = new int[DaysCount, HoursCount];


		// Retrieve the number of events occuring during a given hour and day of the week
		public int this[DayOfWeek day, int hour] => Freq[(int)day, hour];


		/// Retrieve the number of events occuring during a given hour and day of the week
		public int this[int day, int hour] => Freq[day, hour];


		internal EventTable(IEnumerable<Event> events)
		{
			foreach (var i in events)
			{
				for (var hour = Math.Floor(i.Start.TotalHours); hour < Math.Ceiling(i.End.TotalHours); hour++)
				{
					Freq[(int)i.Day, (int)hour]++;
				}
			}
		}


		// Find the maximum frequency in the table
		public int Max()
		{
			var max = 0;

			for (var hour = 0; hour < HoursCount; hour++)
			{
				for (var day = 0; day < DaysCount; day++)
				{
					var val = this[day, hour];

					if (val > max)
					{
						max = val;
					}
				}
			}

			return max;
		}
	}
}
