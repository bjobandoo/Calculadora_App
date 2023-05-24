using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraApp
{
    public partial class MainPage : ContentPage
    {
        private Button[] numberButtons;
        public MainPage()
        {
            InitializeComponent();
        }

        public void CalculatorPage()
        {
            numberButtons = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                numberButtons[i] = new Button
                {
                    Text = i.ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    WidthRequest = 80,
                    HeightRequest = 80
                };
                numberButtons[i].Clicked += NumberButton_Clicked;
            }

            addButton = CreateOperationButton("+");
            subtractButton = CreateOperationButton("-");
            multiplyButton = CreateOperationButton("*");
            divideButton = CreateOperationButton("/");
            equalsButton = CreateOperationButton("=");

            addButton.Clicked += OperationButton_Clicked;
            subtractButton.Clicked += OperationButton_Clicked;
            multiplyButton.Clicked += OperationButton_Clicked;
            divideButton.Clicked += OperationButton_Clicked;
            equalsButton.Clicked += EqualsButton_Clicked;

        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            resultEntry.Text += buttonText;
        }



        private Button CreateOperationButton(string text)
        {
            return new Button
            {
                Text = text,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                WidthRequest = 80,
                HeightRequest = 80
            };
        }

        private void OperationButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;
            lblNumero1.Text = resultEntry.Text;
            lblOperacion.Text = button.Text;
            resultEntry.Text = "";
        }

        private void EqualsButton_Clicked(object sender, EventArgs e)
        {
            lblNumero2.Text = resultEntry.Text;
            double number1 = double.Parse(lblNumero1.Text);
            double number2 = double.Parse(resultEntry.Text); 
            string operation = lblOperacion.Text; 


            double result = 0;

            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
            }

            resultEntry.Text = result.ToString();
        }
    }
}
