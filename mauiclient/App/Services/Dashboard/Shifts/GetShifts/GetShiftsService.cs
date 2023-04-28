using System.Net.Http.Json;
using mauiclient.Services.StorageService;

namespace mauiclient.Services.Dashboard.Shifts.GetShifts
{
    public class GetShiftsService : IGetShiftsService
    {
        private readonly HttpClient _http;
        private readonly IStorageService _storage;

        public GetShiftsService(HttpClient http, IStorageService storage)
        {
            _http = http;
            _storage = storage;
        }

        public async Task<GetShiftsResponse> GetShiftsAsync(CancellationToken cancellationToken)
        {
            GetShiftsResponse r = new();

            HttpResponseMessage httpResponse = new();
            try
            {
                httpResponse = await _http.GetAsync(App.RestApiUrl + "shifts/index");
            }
            catch(HttpRequestException e)
            {
                r.Error = GetShiftsError.CouldNotConnectToServer;
                return r;
            }

            if(!httpResponse.IsSuccessStatusCode){
                r.Error = GetShiftsError.Unauthorized;
                await _storage.DeleteAllAsync();
                return r;
            }

            r.Shifts = await httpResponse.Content.ReadFromJsonAsync<List<ShiftDto>>(cancellationToken: cancellationToken);

            return r;
        }
    }
}