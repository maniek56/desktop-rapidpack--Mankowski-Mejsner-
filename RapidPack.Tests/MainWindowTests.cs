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
   [Fact]
   public void FragilePackage_AddsExtraCost()
   {
      var calc = new ParcelCalculator();

      double result = calc.CalculatorPrice(10, 10, 10, 5, false, "ostroznie");

      Assert.Equal(30, result); // 10 + 10 + (5*2)
   }
   [Fact]
   public void ExpressOption_Adds15()
   {
      var calc = new ParcelCalculator();

      double result = calc.CalculatorPrice(10, 10, 10, 5, true, "standard");

      Assert.Equal(35, result); // 10 + (5*2) + 15
   }
   [Fact]
   public void LargeDimensions_IncreasePriceBy50Percent()
   {
      var calc = new ParcelCalculator();

      double result = calc.CalculatorPrice(100, 60, 10, 5, false, "standard");

      Assert.Equal(30, result); // (10 + 10) * 1.5 = 30
   }
}