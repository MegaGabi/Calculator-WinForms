using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        char Operator;
        double? first = null, last = null, result;
        public Form1()
        {
            InitializeComponent();
            HistoryBox.ReadOnly = EnterBox.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var btnText = (sender as Button).Text;

            if (EnterBox.Text.Length == 1 && EnterBox.Text[0] == '0')
                EnterBox.Text = "";

            EnterBox.Text = EnterBox.Text + btnText;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (EnterBox.Text.Length - 1 >= 0)
                EnterBox.Text = EnterBox.Text.Remove(EnterBox.Text.Length - 1);

            if (EnterBox.Text.Length == 0)
                EnterBox.Text = "0";
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if (EnterBox.Text.Length - 1 >= 0)
                EnterBox.Text = "0";

            if (HistoryBox.Text.Length - 1 >= 0)
                HistoryBox.Text = "";

            last = first = null;
            Operator = ' ';
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            if (first != null)
                last = double.Parse(EnterBox.Text);
            else
                result = first = double.Parse(EnterBox.Text);

            var btnText = (sender as Button).Text;
            
            switch (Operator)
            {
                case '+':
                    if (last != null)
                    {
                        result = first + last;
                    }
                    break;
                case '-':
                    if (last != null)
                    {
                        result = first - last;
                    }
                    break;
                case '/':
                    if (last != null && last != 0)
                    {
                        result = first / last;
                    }
                    break;
                case '*':
                    if (last != null)
                    {
                        result = first * last;
                    }
                    break;
            }

            Operator = char.Parse(btnText);

            if (Operator == '=')
            {
                first = result;
                HistoryBox.Text = " = " + result;
            }
            else
            {
                first = result;
                HistoryBox.Text = result + " " + Operator;
            }
            EnterBox.Text   = "0";
            last = null;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (EnterBox.Text.Length > 1 && EnterBox.Text[0] == '-')
                EnterBox.Text = EnterBox.Text.Remove(0, 1);
            else
                EnterBox.Text = "-" + EnterBox.Text;
        }

    }
}
