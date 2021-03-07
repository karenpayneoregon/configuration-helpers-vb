using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            textBox1.Text = @"

8   9     11     12    13   14    15   33   37   38   39  24

";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var line = textBox1.Text.Trim();
            if (!string.IsNullOrWhiteSpace(line))
            {
                var cleanUpData = line.RemoveDoubleSpacesToArray();

                if (cleanUpData.AllInt())
                {
                    var integers = cleanUpData.ToIntegerArray();

                    for (int index = 0; index < integers.Length; index++)
                    {
                        Debug.WriteLine($"{index}\t{integers[index]}");
                    }
                }
            }
        }
    }

    public static class StringExtensions
    {
        public static string[] RemoveDoubleSpacesToArray(this string sender)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(sender, " ").Split(' ');
        }
    }
    public static class NumericArrayExtensions
    {
        public static bool AllInt(this string[] sender) =>
            sender.SelectMany(item => item.ToCharArray()).All(char.IsNumber);

        public static int[] ToIntegerArray(this string[] sender)
        {
            var intArray = Array
                .ConvertAll(sender,
                    (input) => new
                    {
                        IsInteger = int.TryParse(input, out var integerValue),
                        Value = integerValue
                    })
                .Where(result => result.IsInteger)
                .Select(result => result.Value)
                .ToArray();

            return intArray;
        }
    }
}
