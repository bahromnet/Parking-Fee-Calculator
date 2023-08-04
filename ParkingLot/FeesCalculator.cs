using System.Configuration;
using System.Globalization;

namespace ParkingLot;
public class FeesCalculator
{
    public int EnteranceFee { get; set; } = 2;
    public int FirstHourFee { get; set; } = 3;
    public int SubsiquentHourFee { get; set; } = 4;
    public string TimeFormat { get; set; } = "HH:mm";

    public DateTime EnteredTime { get; set; }
    public DateTime LeftTime { get; set; }


    public void Initialize(Configuration configuration)
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

        TimeFormat = configuration.AppSettings.Settings["TimeFormat"].Value;
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
