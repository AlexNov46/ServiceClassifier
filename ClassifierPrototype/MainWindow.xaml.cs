using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.ML;
using ClassifierPrototypeML.Model;

namespace ClassifierPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Prepare(ref string input)
        {
            input = input.Replace("ё", "е");
            input = System.Text.RegularExpressions.Regex.Replace(input, @"[^a-zA-Zа-яА-Я1-9]+", " ");
            input = System.Text.RegularExpressions.Regex.Replace(input, @"[ ]+", " ");
            input = input.Trim();
        }
        private void Processing()
        {
            string input = Input.Text;
            Prepare(ref input);
            ModelInput inputText = new ModelInput()
            {
                Col0 = input,
            };
            var result = ConsumeModel.Predict(inputText);
            if (Math.Abs(result.Score[0] - result.Score[1]) <= 0.15)
            {
                Output.Content = "Нейтральный!";
            }
            else if (result.Prediction == "-1 ")
            {
                Output.Content = "Отрицательный!";
            }
            else if (result.Prediction == "1 ")
            {
                Output.Content = "Положительный!";
            }
            Output.Visibility = Visibility.Visible;
        }

        
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Output.Visibility = Visibility.Hidden;
            Processing();
        }
    }
}
