namespace mauiclient.Pages.Dashboard.Shifts;

public partial class ShiftsView : ContentPage
{
	public ShiftsView(ShiftsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
