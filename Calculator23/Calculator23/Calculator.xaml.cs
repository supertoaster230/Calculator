using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator23
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        public double GlobalBitch = 0;
        public double Solver = 0;

        public bool GMul = false;
        public bool GDiv = false;
        public bool GPlus = false;
        public bool GMinus = false;
        public bool GDot = false;
        public bool State = false;

        public Calculator()
        {
            InitializeComponent();
            displayLabel.Text = "0";
            displayLabel2.Text = "";

            backspaceButton.IsEnabled = displayLabel.Text != null && displayLabel.Text.Length > 0;
        }
        void OnDigitButtonClicked(object sender, EventArgs args)
        {
            try
            {
                if ((displayLabel.Text[0] == '0') || (State == true))
                {
                    displayLabel.Text = "";
                }
                Button button = (Button)sender;
                displayLabel.Text += (string)button.StyleId;
                backspaceButton.IsEnabled = true;
                State = false;
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка нуля" + ex.Message;
            }
        }
        void DotButtonClicked(object sender, EventArgs args)
        {
            int Mydot = 0;
            foreach (char c in displayLabel.Text)
            {
                if (c == '.')
                {
                    Mydot++;
                }
                if ((c == '/') || (c == '*') || (c == '-') || (c == '+'))
                {
                    Mydot--;
                }

            }
            if (Mydot == 1)
            {

                displayLabel.Text = displayLabel.Text;
            }
            else
            {
                GDot = true;
                displayLabel.Text += ".";
            }
           
        }
        void EqualButtonClicked(object sender, EventArgs args)
        {
            try
            {
                if (GDiv == true)
                {
                    if (GDot == true)
                    {
                        displayLabel.Text = (GlobalBitch / DotToDouble(displayLabel.Text.Split(new char[] { '/' })[1])).ToString();
                    }
                    else
                    {
                        displayLabel.Text = (GlobalBitch / (Int32.Parse(displayLabel.Text.Split(new char[] { '/' })[1]))).ToString();
                    }
                    GlobalBitch = 0;
                    displayLabel2.Text = displayLabel.Text;
                }

                if (GMul == true)
                {
                    if (GDot == true)
                    {
                        displayLabel.Text = (GlobalBitch * DotToDouble(displayLabel.Text.Split(new char[] { '*' })[1])).ToString();
                    }
                    else
                    {
                        displayLabel.Text = (GlobalBitch * (Int32.Parse(displayLabel.Text.Split(new char[] { '*' })[1]))).ToString();
                    }
                    GlobalBitch = 0;
                    displayLabel2.Text = displayLabel.Text;
                }

                if (GMinus == true)
                {
                    if (GDot == true)
                    {
                        displayLabel.Text = (GlobalBitch - DotToDouble(displayLabel.Text.Split(new char[] { '-' })[1])).ToString();
                    }
                    else
                    {
                        displayLabel.Text = (GlobalBitch - (Int32.Parse(displayLabel.Text.Split(new char[] { '-' })[1]))).ToString();
                    }
                    GlobalBitch = 0;
                    displayLabel2.Text = displayLabel.Text;
                }

                if (GPlus == true)
                {
                    if (GDot == true)
                    {
                        displayLabel.Text = (GlobalBitch + DotToDouble(displayLabel.Text.Split(new char[] { '+' })[1])).ToString();
                    }
                    else
                    {
                        displayLabel.Text = (GlobalBitch + (Int32.Parse(displayLabel.Text.Split(new char[] { '+' })[1]))).ToString();
                    }
                    GlobalBitch = 0;
                    displayLabel2.Text = displayLabel.Text;
                }
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка вывода" + ex.Message;
            }
            GMul = false;
             GDiv = false;
             GPlus = false;
             GMinus = false;
             GDot = false;

            PoM.IsEnabled = true;
            Sqrt.IsEnabled = true;
            Clear.IsEnabled = true;
            Div.IsEnabled = true;
            Mul.IsEnabled = true;
            Min.IsEnabled = true;
            Plus.IsEnabled = true;
            State = true;
        }
        void PoMButtonClicked(object sender, EventArgs args)
        {
            try
            {
                FindDot(displayLabel.Text);
                if (GDot == true)
                {
                    displayLabel.Text = (DotToDouble(displayLabel.Text) * (-1)).ToString();
                }
                else
                {
                    displayLabel.Text = ((Int32.Parse(displayLabel.Text)) * (-1)).ToString();
                }
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка знака " + ex.Message;
            }
        }
        void SqrtButtonClicked(object sender, EventArgs args)
        {
            try
            {
                if (DotToDouble(displayLabel.Text) < 0)
                {
                    displayLabel.Text = DotToDouble(displayLabel.Text).ToString();
                }
                else
                {
                    displayLabel.Text = Math.Sqrt(DotToDouble(displayLabel.Text)).ToString();
                }
                 State = true;
                displayLabel2.Text = displayLabel.Text;
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка корня " + ex.Message;
            }
        }
        void ClearButtonClicked(object sender, EventArgs args)
        {
            try
            {
                string text = displayLabel.Text;
                displayLabel.Text = "0";
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка очистки " + ex.Message;
            }
        }
        void DivButtonClicked(object sender, EventArgs args)
        {
            try
            {
                GDiv = true;
                EnableAll();
                FindDot(displayLabel.Text);
                if (GDot == true)
                {
                    GlobalBitch = DotToDouble(displayLabel.Text);
                }
                else
                {
                    GlobalBitch = Int32.Parse(displayLabel.Text);
                }
                displayLabel.Text = displayLabel.Text + "/";
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка деления " + ex.Message;
            }
        }
        void MulButtonClicked(object sender, EventArgs args)
        {
            try
            {      
                GMul = true;
                EnableAll();
                FindDot(displayLabel.Text);
                if (GDot == true)
                {
                    GlobalBitch = DotToDouble(displayLabel.Text);
                }
                else
                {
                    GlobalBitch = Int32.Parse(displayLabel.Text);
                }
                displayLabel.Text = displayLabel.Text + "*";
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка умножения " + ex.Message;
            }
        }
        void MinusButtonClicked(object sender, EventArgs args)
        {
            try
            {
                GMinus = true;
                EnableAll();

                FindDot(displayLabel.Text);
                if (GDot == true)
                {
                    GlobalBitch = DotToDouble(displayLabel.Text);
                }
                else
                {
                    GlobalBitch = Int32.Parse(displayLabel.Text);
                }
                displayLabel.Text = displayLabel.Text + "-";
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка минуса " + ex.Message;
            }
        }
        void PlusButtonClicked(object sender, EventArgs args)
        {
            try
            {
                GPlus = true;
                EnableAll();
                FindDot(displayLabel.Text);
                if (GDot == true)
                {
                    GlobalBitch = DotToDouble(displayLabel.Text);
                }
                else
                {
                    GlobalBitch = Int32.Parse(displayLabel.Text);
                }
                displayLabel.Text = displayLabel.Text + "+";
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка плюса " + ex.Message;
            }
        }
        void OnBackspaceButtonClicked(object sender, EventArgs args)
        {
            string text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            if (displayLabel.Text == "") displayLabel.Text = "0";
        }
        double DotToDouble(string str)
        {
            try
            {
                bool Mydot = false;
                foreach (char c in str)
                {
                    if (c == '.')
                    {
                        Mydot = true;
                        break;

                    }
                }
                if (Mydot == true)
                {
                    if (Int32.Parse(str.Split(new char[] { '.' })[0]) < 0)
                    {
                        return Int32.Parse(str.Split(new char[] { '.' })[0]) + (Int32.Parse(str.Split(new char[] { '.' })[1]) / Math.Pow(10, (str.Split(new char[] { '.' })[1].Length))) * (-1);
                    }
                    else
                    {
                        return Int32.Parse(str.Split(new char[] { '.' })[0]) + (Int32.Parse(str.Split(new char[] { '.' })[1]) / Math.Pow(10, (str.Split(new char[] { '.' })[1].Length)));
                    }
                }
                if (Mydot == false)
                {
                    return Int32.Parse(str);
                }
            }
            catch (Exception ex)
            {
                displayLabel.Text = "Ошибка точки в число " + ex.Message;
                return 0;
            }
            return 0;
        }

        void EnableAll()
        {
            State = false;
            PoM.IsEnabled = false;
            Sqrt.IsEnabled = false;
            Clear.IsEnabled = false;
            Div.IsEnabled = false;
            Mul.IsEnabled = false;
            Min.IsEnabled = false;
            Plus.IsEnabled = false;
        }
        void FindDot(string str)
        {
            foreach(char c in str)
            {
                if (c == '.')
                {
                    GDot = true;
                    break;
                }
            }
        }
    }
}