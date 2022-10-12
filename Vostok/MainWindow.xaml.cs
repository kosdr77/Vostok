using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Shapes;
using Vostok.Models;

namespace Vostok
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

        private void ComboBoxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BrigadeLabel.Content = Brigade.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var employee = new
            {
                Employee = ComboBoxEmployees.SelectedItem as Employee,
                City = ComboBoxCities.SelectedItem as City,
                Workshop = ComboBoxWorkshops.SelectedItem as Workshop,
                Brigade = BrigadeLabel.Content,
                Change = ComboBoxChange.SelectedItem as Change
            };

            SaveJsonToFile(JsonSerializer.Serialize(employee));
        }

        private static void SaveJsonToFile(string json)
        {
            var path = "select_data.json";

            File.WriteAllText(path, string.Empty);
            using (FileStream fileStream2 = File.OpenWrite(path))
            {                
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                fileStream2.Write(bytes, 0, bytes.Length);
            }

            MessageBox.Show("Success!");
        }
    }
}
