using System;
using Microsoft.Maui.Controls;

namespace IMCCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HeightEntry.Text) || string.IsNullOrWhiteSpace(WeightEntry.Text))
            {
                DisplayAlert("Error", "Por favor, ingrese su altura y peso.", "OK");
                return;
            }

            if (!double.TryParse(HeightEntry.Text, out double height) || !double.TryParse(WeightEntry.Text, out double weight))
            {
                DisplayAlert("Error", "Por favor, ingrese valores numéricos válidos.", "OK");
                return;
            }

            double bmi = CalculateBMI(height, weight);
            string category = DetermineCategory(bmi);

            BMIResultLabel.Text = $"Su IMC es: {bmi:F2}\nCategoría: {category}";
        }

        private double CalculateBMI(double height, double weight)
        {
            return weight / Math.Pow(height / 100, 2);
        }

        private string DetermineCategory(double bmi)
        {
            if (bmi < 18.5)
                return "Por debajo del peso";
            else if (bmi >= 18.5 && bmi <= 24.9)
                return "Saludable";
            else if (bmi >= 25.0 && bmi <= 29.9)
                return "Con sobrepeso";
            else if (bmi >= 30.0 && bmi <= 39.9)
                return "Obeso";
            else
                return "Obesidad extrema o de alto riesgo";
        }
    }
}