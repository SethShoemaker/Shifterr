namespace mauiclient.Services.Dashboard.Shifts.GetShifts
{
    public interface IGetShiftsService
    {
        Task<GetShiftsResponse> GetShiftsAsync(CancellationToken cancellationToken);
    }
}