using System;
using Avalonia.Controls;

namespace RapidPack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}

public class ParcelCalculator
{
    public double CalculatorPrice(
        double height,
        double width,
        double length,
        double weight,
        bool express,
        string type)
    {
        if (weight > 30)
        {
            throw new Exception("Paczka jest zbyt ciężka");
        }

        double price = type == "paleta" ? 100 : 10;

        price += type == "ostroznie" ? 10 : 0;

        price += weight * 2;

        price *= (height + width + length > 150) ? 1.5 : 1;

        price += express ? 15 : 0;

        return price;
    }
}