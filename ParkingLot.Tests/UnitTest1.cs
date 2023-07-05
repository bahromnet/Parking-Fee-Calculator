namespace ParkingLot.Tests;

public class UnitTest1
{
    FeesCalculator calc = new FeesCalculator();

    [Fact]
    public void PositiveTest()
    {
        calc.Initialize();
        int actualReasult = calc.GetParkingFee("09:01", "10:00");
        int expectedResult = 5;
        Assert.Equal(expectedResult, actualReasult);
    }
}