using System;
using System.Windows.Forms;
using Calculator.Properties;


namespace Calculator
{
    public partial class Form1 : Form
    {
        // sign_flag отвечает за знак числа
        private bool sign_flag = false;
        // point_flag отвечает за наличие дробной части в числе
        private bool point_flag = false;
        // operation_flag равен true после нажатия на кнопку опреаций : "+", "-", "*", "/"
        private bool operation_flag = false;
        // bracket_flag равен true, если введённое выражение оканчивается скобкой ")"
        private bool bracket_flag = false; 
        // считает, чтобы количество открывающихся скобок было равно количеству закрывающихся
        private short bracket_counter = 0; 
        public Form1()
        { 
            InitializeComponent();
            _Form1 = this;
        }
        
        public static Form1 _Form1;
        
        public void update(string message)
        {
            MessageBox.Show(message);
        }

        private void Form1_Load(object sender, EventArgs e) {}

        // button5_Click - "0"
        private void button5_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "0";   
                operation_flag = false;
            }
            else
                if (textBox1.Text != "0") textBox1.Text += 0;
        }

        // button6_Click - "1"
        private void button6_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "1";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "1";
                else textBox1.Text += 1;
            } 
        }
        
        // button7_Click - "2"
        private void button7_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "2";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "2";
                else textBox1.Text += 2;
            } 
        }
        // button9_Click - "3"
        private void button9_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "3";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "3";
                else textBox1.Text += 3;
            } 
        }
        // button10_Click - "4"
        private void button10_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "4";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "4";
                else textBox1.Text += 4;
            } 
        }
        // button11_Click - "5"
        private void button11_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "5";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "5";
                else textBox1.Text += 5;
            } 
        }
        // button13_Click - "6"
        private void button13_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "6";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "6";
                else textBox1.Text += 6;
            } 
        }
        
        // button14_Click - "7"

        private void button14_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "7";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "7";
                else textBox1.Text += 7;
            } 
        }

        // button15_Click - "8"
        private void button15_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            if (operation_flag == true) {
                textBox1.Text = "8";
                operation_flag = false;
            } else {
                if (textBox1.Text == "0") textBox1.Text = "8";
                else textBox1.Text += 8;
            }
        }
        
        // button16_Click - ","
        private void button19_Click(object sender, EventArgs e)
        {
            if (point_flag != false) return;
            textBox1.Text += ",";
            point_flag = true;
            operation_flag = false;
        }

        //button4_Click - "+"
        private void button4_Click(object sender, EventArgs e)
        {
            // разбор случая, когда выражение заканчивается ")" и мы хотим поставить дальше "+"
            if (bracket_flag == true) {
                bracket_flag = false;
                label1.Text += " + ";
                return;
            }
            // разбор случая, когда выражение уже заканчивается какой-то операцией
            // тогда при нажатии "+" произойдёт замена операции на "+"
            if (operation_flag == true) {
                var lastChar = label1.Text[label1.Text.Length - 2];
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 3) + " + ";
            } else {
                label1.Text += textBox1.Text + " + ";
                sign_flag = false;
                point_flag = false;
                textBox1.Text = "0";
                operation_flag = true;
            }
        }

        // button8_Click - "-"
        private void button8_Click(object sender, EventArgs e)
        {
            // разбор случая, когда выражение заканчивается ")" и мы хотим поставить дальше "-"
            if (bracket_flag == true) {
                bracket_flag = false;
                label1.Text += " - ";
                return;
            }
            // разбор случая, когда выражение уже заканчивается какой-то операцией
            // тогда при нажатии "-" произойдёт замена операции на "-"
            if (operation_flag == true) {
                var lastChar = label1.Text[label1.Text.Length - 2];
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 3) + " - ";
            } else {
                label1.Text += textBox1.Text + " - ";
                sign_flag = false;
                point_flag = false;
                textBox1.Text = "0";
                operation_flag = true;
            }
        }
        
        // button12_Click - "*"
        private void button12_Click(object sender, EventArgs e)
        {
            // разбор случая, когда выражение заканчивается ")" и мы хотим поставить дальше "*"
            if (bracket_flag == true) {
                bracket_flag = false;
                label1.Text += " * ";
                return;
            }
            // разбор случая, когда выражение уже заканчивается какой-то операцией
            // тогда при нажатии "*" произойдёт замена операции на "*"
            if (operation_flag == true) {
                var lastChar = label1.Text[label1.Text.Length - 2];
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 3) + " * ";
            } else {
                label1.Text += textBox1.Text + " * ";
                sign_flag = false;
                point_flag = false;
                textBox1.Text = "0";
                operation_flag = true;
            }
        }
        
        // button16_Click - "/"
        private void button16_Click(object sender, EventArgs e)
        {
            // разбор случая, когда выражение заканчивается ")" и мы хотим поставить дальше "/"
            if (bracket_flag == true) {
                bracket_flag = false;
                label1.Text += " / ";
                return;
            }
            // разбор случая, когда выражение уже заканчивается какой-то операцией
            // тогда при нажатии "/" произойдёт замена операции на "/"
            if (operation_flag == true) {
                var lastChar = label1.Text[label1.Text.Length - 2];
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 3) + " / ";
            } else {
                label1.Text += textBox1.Text + " / ";
                sign_flag = false;
                point_flag = false;
                textBox1.Text = "0";
                operation_flag = true;
            }
        }
        
        // button1_Click - "C"
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Text = "0";
            sign_flag = false;
            point_flag = false;
            bracket_flag = false;
            operation_flag = false;
            bracket_counter = 0;
            foreach (Control c in Controls) c.Enabled = true;
        }

        // button2_Click - "<-"
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 1)
            {
                var lastChar = textBox1.Text[textBox1.Text.Length - 1];
                if (lastChar == ',') point_flag = false;
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
                sign_flag = false;
            }
        }

        // button3_Click - "+/-"
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                return;
            if (sign_flag == false) {
                textBox1.Text = "-" + textBox1.Text;
                sign_flag = true;
            }
            else {
                textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                sign_flag = false;
            }
        }

        // button17_Click - "("
        private void button17_Click(object sender, EventArgs e)
        {
            if (bracket_flag == true) return;
            label1.Text += "( ";
            operation_flag = false;
            bracket_counter++;
        }
        
        // button18_Click - ")"
        private void button18_Click(object sender, EventArgs e)
        {
            if (bracket_counter <= 0) return;
            bracket_counter--;
            if (bracket_flag == true)
            {
                label1.Text += " )";
                return;
            }
            label1.Text += textBox1.Text + " )";
            textBox1.Text = "0";
            sign_flag = false;
            point_flag = false;
            bracket_flag = true;
        }
        
        private double calculate()
        {
            var expr = label1.Text;
            var symbols = expr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var to_pol = ReversePolish.reverse_polish(symbols);
            var my_res = ReversePolish.calculation(to_pol);
            return my_res;
        }
         
        // button20_Click - "="
        private void button20_Click(object sender, EventArgs e)
        {
            if (bracket_counter > 0)
            {
                update("Количество открывающихся скобок больше количества закрывающихся!");
                return;
            }
            
            if (bracket_flag != true) 
                label1.Text += textBox1.Text;
            
            textBox1.Text = calculate().ToString();
            label1.Text += " = ";
            
            foreach (Control c in Controls)
            {
                //Button b = c as Button;
                if (c.Name != "button1")
                {
                    c.Enabled = false;
                }
            }
        }
    }
}
