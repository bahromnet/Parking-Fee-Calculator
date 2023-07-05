namespace ParkingLot;

internal class Program
{
    static void Main(string[] args)
    {
        FeesCalculator feesCalculator = new FeesCalculator();
        feesCalculator.Initialize();
        Console.WriteLine(feesCalculator.GetParkingFee($"{DateTime.Now.AddMinutes(-85).ToString("HH:mm")}", $"{DateTime.Now.ToString("HH:mm")}"));
    }
}
