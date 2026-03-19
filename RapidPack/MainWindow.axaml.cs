using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RapidPack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ResultButton.Click += ResultButton_Click;
    }

    private void ResultButton_Click(object? sender, RoutedEventArgs e)
    {
        // sprawdzenie czy pola są puste
        if (string.IsNullOrWhiteSpace(HeightTextBox.Text) ||
            string.IsNullOrWhiteSpace(WidthTextBox.Text) ||
            string.IsNullOrWhiteSpace(DepthTextBox.Text) ||
            string.IsNullOrWhiteSpace(WeightTextBox.Text))
        {
            SummaryTextBlock.Text = "Wpisz wszystkie dane!";
            return;
        }

        try
        {
            double height = double.Parse(HeightTextBox.Text);
            double width = double.Parse(WidthTextBox.Text);
            double depth = double.Parse(DepthTextBox.Text);
            double weight = double.Parse(WeightTextBox.Text);

            bool express = ExpressCheckBox.IsChecked == true;

            string type = "standard";
            if (PackageTypeComboBox.SelectedIndex == 1) type = "ostroznie";
            if (PackageTypeComboBox.SelectedIndex == 2) type = "paleta";

            ParcelCalculator calc = new ParcelCalculator();

            double price = calc.CalculatorPrice(height, width, depth, weight, express, type);

            SummaryTextBlock.Text = "Cena: " + price + " zł";
        }
        catch
        {
            SummaryTextBlock.Text = "Wpisz poprawne liczby!";
        }
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

        if (type == "ostroznie")
            price += 10;

        price += weight * 2;

        if (height + width + length > 150)
            price *= 1.5;

        if (express)
            price += 15;
        
        if (type == "paleta")
            price = 100;
        return price;
    }
}