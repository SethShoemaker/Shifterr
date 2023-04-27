namespace mauiclient.Pages.Dashboard.Calendar;

public partial class CalendarView : ContentPage
{
	public CalendarView(CalendarViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
