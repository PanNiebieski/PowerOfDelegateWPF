using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PowerOfDelegateWPF
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



private void Button_AddOperaction_Click(object sender, RoutedEventArgs e)
{
    Button b = (Button)e.Source;
    string s = "";
    if (b.Tag.ToString() == "Plus")
    {
            s = "Dodawanie :" + txtNumber.Text;
    }
    if (b.Tag.ToString() == "Minus")
    {
        s = "Odejmowanie :" + txtNumber.Text;
    }
    if (b.Tag.ToString() == "Dzie")
    {
        s = "Dzielenie :" + txtNumber.Text;
    }
    if (b.Tag.ToString() == "Mno")
    {
        s = "Mnożenie :" + txtNumber.Text;
    }

    AddToListBox(s);
}

public void AddToListBox(string text)
{
    lbOperations.Items.Add(text);
}

        public void AddToTheLast(string text)
        {
            if (lbOperations.Items.Count > 0)
            {
                string t = lbOperations.Items[lbOperations.Items.Count - 1].ToString();

                t = t + ":" + text;

                lbOperations.Items[lbOperations.Items.Count - 1] = t;
            }
            else
            {
                AddToTheLast(text);
            }

                
        }

private void Button_Run_Click(object sender, RoutedEventArgs e)
{
    OneOperationRunner runner = new OneOperationRunner();
    OperationsRunner r = new OperationsRunner();

    int a = 0; //Startowa wartość

    foreach (string item in lbOperations.Items)
    {
        var tab = item.Split(':');

        int b = int.Parse(tab[1]);

        DelegateOneOperationRunner del = runner.Run(Operation.Add);

        if (item.Contains("Dodawanie"))
        {
            del = runner.Run(Operation.Add);

            r.AddOperation(Operation.Add);
        }

        if (item.Contains("Odejmowanie"))
        {
            del = runner.Run(Operation.Substrack);

            r.AddOperation(Operation.Substrack);
        }

        if (item.Contains("Mnożenie"))
        {
            del = runner.Run(Operation.Mutyply);

            r.AddOperation(Operation.Mutyply);
        }

        if (item.Contains("Dzielenie"))
        {
            del = runner.Run(Operation.Supply);

            r.AddOperation(Operation.Supply);
        }

        //Wykoanie operacji pojedyńczo
        a = del.Invoke(a, b);
    }

    //Wykonanie operacji na raz
    r.Run(0, int.Parse(txtNumber.Text));
    int many = r.Result;
    //Wyświetlenie wyników
    lblResult.Content = "Po kolei: " + a.ToString();
    lblResult_2.Content = "Wszystkie operacje na raz na zmiennej w polu tekstowym: " + many.ToString();
}



        private void Button_Run_Many_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
