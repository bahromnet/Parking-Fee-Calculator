using System.Configuration;

namespace ParkingLot.Tests;

public class UnitTest1
{
    FeesCalculator calc;

    public UnitTest1()
    {
        ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap
        {
            ExeConfigFilename = @"C:\Users\Akramov_Dev\source\repos\ParkingLot\ParkingLot.Tests\App.config" // Update with the correct path
        };
        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

        calc = new FeesCalculator();
        calc.Initialize(configuration);
    }

    [Fact]
    public void PositiveTest()
    {
        int actualReasult = calc.GetParkingFee("09:01", "10:00");
        int expectedResult = 5;
        Assert.Equal(expectedResult, actualReasult);
    }
}