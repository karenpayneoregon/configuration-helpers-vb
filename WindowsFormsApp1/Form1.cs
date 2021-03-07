using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Shown += (sender, args) => ActiveControl = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var line = textBox1.Lines.FirstOrDefault(data => !string.IsNullOrWhiteSpace(data));
            
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
