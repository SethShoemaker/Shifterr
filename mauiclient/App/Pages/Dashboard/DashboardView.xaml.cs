using mauiclient.Pages.Dashboard.Calendar;
using mauiclient.Pages.Dashboard.Shifts;

namespace mauiclient.Pages.Dashboard;

public partial class DashboardView : TabbedPage
{
	public DashboardView(ShiftsView shiftsView, CalendarView calendarView)
	{
		Children.Add(shiftsView);
        Children.Add(calendarView);
    }
}