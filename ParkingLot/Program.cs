namespace ParkingLot;

internal class Program
{
    static void Main(string[] args)
    {
        FeesCalculator feesCalculator = new FeesCalculator();
        //feesCalculator.Initialize();
        Console.WriteLine(feesCalculator.GetParkingFee("09:01", "10:00"));
    }
}
