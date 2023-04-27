using System;
namespace mauiclient.Pages.Dashboard.Calendar
{
	public class CalendarViewModel
	{
		public CalendarViewModel()
		{
		}

		public DateTime CurrentWeekStart { get; set; } = DateTime.Now;
	}
}

