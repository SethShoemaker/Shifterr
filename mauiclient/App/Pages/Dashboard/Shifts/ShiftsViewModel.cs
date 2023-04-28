using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mauiclient.Pages.Login;
using mauiclient.Services.Dashboard.Shifts.GetShifts;

namespace mauiclient.Pages.Dashboard.Shifts
{
	public partial class ShiftsViewModel : ObservableObject
	{
        private readonly IGetShiftsService _getShiftsService;
        private readonly IServiceProvider _services;

        public ShiftsViewModel(IGetShiftsService getShiftsService, IServiceProvider services)
		{
            _getShiftsService = getShiftsService;
            _services = services;

            Task.Run(GetShiftsAsync);
        }

		[ObservableProperty]
        ObservableCollection<ShiftDto> shifts;

        [RelayCommand]
		async Task GetShiftsAsync()
		{
            GetShiftsResponse response = await _getShiftsService.GetShiftsAsync(default);

			if(response.Error is not null)
				App.Current.MainPage = _services.GetService<LoginView>();
			else
				Shifts = (ObservableCollection<ShiftDto>)response.Shifts;
        }
    }
}