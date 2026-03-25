using Avalonia.Headless.XUnit;
using Xunit;
using RapidPack;

namespace RapidPack.Tests;

public class MainWindowTests
{
   [AvaloniaFact]
   public void CreateWindow_ShouldCreateANewWindow()
   {
      var window = new MainWindow();
      Assert.NotNull(window);
   }
   [Fact]
   public void StandardPackage_BasicPrice_CalculatedCorrectly()
   {
      var calc = new ParcelCalculator();

      double result = calc.CalculatorPrice(10, 10, 10, 5, false, "standard");

      Assert.Equal(20, result); // 10 + (5*2)
   }
}