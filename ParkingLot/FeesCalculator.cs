using System.Configuration;
using System.Globalization;

namespace ParkingLot;
public class FeesCalculator
{
    public int EnteranceFee { get; set; }
    public int FirstHourFee { get; set; }
    public int SubsiquentHourFee { get; set; }
    public string TimeFormat { get; set; }

    public DateTime EnteredTime { get; set; }
    public DateTime LeftTime { get; set; }


    public void Initialize()
    {
        int enteranceFee = -1;
        int firstHourFee = -1;
        int subsiquentHourFee = -1;

        if (int.TryParse(ConfigurationManager.AppSettings["EnteranceFee"], out enteranceFee))
        {
            EnteranceFee = enteranceFee;
        }

        if (int.TryParse(ConfigurationManager.AppSettings["FirstHourFee"], out firstHourFee))
        {
            FirstHourFee = firstHourFee;
        }

        if (int.TryParse(ConfigurationManager.AppSettings["SubsiquentHourFee"], out subsiquentHourFee))
        {
            SubsiquentHourFee = subsiquentHourFee;
        }

        TimeFormat = ConfigurationManager.AppSettings["TimeFormat"]!;
    }

    public int GetParkingFee(string timeEntered, string timeLeft)
    {
        int cost = EnteranceFee;

        EnteredTime = DateTime.ParseExact(timeEntered, TimeFormat, CultureInfo.InvariantCulture);
        LeftTime = DateTime.ParseExact(timeLeft, TimeFormat, CultureInfo.InvariantCulture);
        var totalHours = (LeftTime - EnteredTime).TotalHours;
        if (totalHours > 0)
            cost += FirstHourFee;

        if (totalHours > 1)
        {
            var hoursAfterFirst = totalHours - 1;
            hoursAfterFirst = Math.Ceiling(hoursAfterFirst);
            cost += (int)hoursAfterFirst * SubsiquentHourFee;
        }

        return cost;
    }
}
