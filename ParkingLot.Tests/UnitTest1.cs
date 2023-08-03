using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace ParkingLot.Tests;

public class UnitTest1
{

    [Fact]
    public static void PositiveTest()
    {
        Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["EnteranceFee"]).Returns("5");
        mockConfig.Setup(c => c["FirstHourFee"]).Returns("3");
        mockConfig.Setup(c => c["SubsiquentHourFee"]).Returns("2");
        mockConfig.Setup(c => c["TimeFormat"]).Returns("HH:mm");

        FeesCalculator calc = new();
        calc.Initialize();

        int actualReasult = calc.GetParkingFee("09:01", "10:00");
        int expectedResult = 5;
        Assert.Equal(expectedResult, actualReasult);
    }
}