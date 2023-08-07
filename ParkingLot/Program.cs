namespace ParkingLot;

internal class Program
{
    static async Task Main(string[] args)
    {
        //FeesCalculator feesCalculator = new FeesCalculator();
        ////feesCalculator.Initialize();
        //Console.WriteLine(feesCalculator.GetParkingFee("09:01", "10:00"));

        // https://visitcount.itsvg.in/api?id=jamshid-net&label=Profile%20Views&icon=5&pretty=true

        //string apiUrl = "https://visitcount.itsvg.in/api?id=MurodovDeveloper&icon=0&color=0";
        string baseUrl = "https://visitcount.itsvg.in/api";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                int views = 0; // Set the view count to 0

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}?id=jamshid-net&label=Profile%20Views&icon=5&pretty=true&Views={views}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request successful: {responseBody}");
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

    }
}
