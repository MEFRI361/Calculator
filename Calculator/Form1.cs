using System.Diagnostics;

namespace Calculator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string _activeNum = null;
        private string _secondaryNum = null;
        private bool _pointEntered = false;
        private bool _zeroBeforeDot = false;
        private int _wasAnOperation = 0;
        private int _lastOperator = 0;

        private void ChangeOfNumber()
        {
            string tempNum = _activeNum;
            _activeNum = _secondaryNum;
            _secondaryNum = tempNum;
        }

        private void PrintNum()
        {
            output.Text = _activeNum;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyValue)
            {
                case '0':
                    button_0_Click(button_0, null);
                    break;
                case '1':
                    button_1_Click(button_1, null);
                    break;
                case '2':
                    button_2_Click(button_2, null);
                    break;
                case '3':
                    button_3_Click(button_3, null);
                    break;
                case '4':
                    button_4_Click(button_4, null);
                    break;
                case '5':
                    button_5_Click(button_5, null);
                    break;
                case '6':
                    button_6_Click(button_6, null);
                    break;
                case '7':
                    button_7_Click(button_7, null);
                    break;
                case '8':
                    button_8_Click(button_8, null);
                    break;
                case '9':
                    button_9_Click(button_9, null);
                    break;
                case 65:
                    button_dot_Click(button_dot, null);
                    break;
                case '+':
                    button_sum_Click(button_sum, null);
                    break;
            }
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            _activeNum += "1";
            PrintNum();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            _activeNum += "2";
            PrintNum();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            _activeNum += "3";
            PrintNum();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            _activeNum += "4";
            PrintNum();
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            _activeNum += "5";
            PrintNum();
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            _activeNum += "6";
            PrintNum();
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            _activeNum += "7";
            PrintNum();
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            _activeNum += "8";
            PrintNum();
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            _activeNum += "9";
            PrintNum();
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (_pointEntered)
            {
                _activeNum += "0";
            }
            else if (!_zeroBeforeDot) 
            {
                _activeNum += "0";
                _zeroBeforeDot = true;
            }
            else if (_activeNum != "0")
            {
                _activeNum += "0";
            }
            PrintNum();
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (!_pointEntered)
            {
                _pointEntered = true;
                if (_activeNum == "")
                {
                    _activeNum = "0,";
                }
                else
                    _activeNum += ",";
            }
            PrintNum();
        }

        private void button_sum_Click(object sender, EventArgs e)
        {
            _activeNum = (double.Parse(_activeNum ?? "0") + double.Parse(_secondaryNum ?? "0")).ToString();
            Debug.WriteLine("act " + _activeNum);
            Debug.WriteLine("sec " + _secondaryNum);
            PrintNum();
            ChangeOfNumber();
            if (_wasAnOperation > 0)
            {
                _activeNum = null;
            }
            _wasAnOperation++;
            _lastOperator = 0;
        }

        private void button_sub_Click(object sender, EventArgs e)
        {
            _activeNum = (double.Parse(_activeNum ?? "0") - double.Parse(_secondaryNum ?? "0")).ToString();
            Debug.WriteLine("act " + _activeNum);
            Debug.WriteLine("sec " + _secondaryNum);
            PrintNum();
            ChangeOfNumber();
            if (_wasAnOperation > 0)
            {
                _activeNum = null;
            }
            _wasAnOperation++;
            _lastOperator = 1;
        }

        private void button_multi_Click(object sender, EventArgs e)
        {
            _activeNum = (double.Parse(_activeNum ?? "0") * double.Parse(_secondaryNum ?? "1")).ToString();
            Debug.WriteLine("act " + _activeNum);
            Debug.WriteLine("sec " + _secondaryNum);
            PrintNum();
            ChangeOfNumber();
            if (_wasAnOperation > 0)
            {
                _activeNum = null;
            }
            _wasAnOperation++;
            _lastOperator = 2;
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            _activeNum = (double.Parse(_activeNum ?? "0") / double.Parse(_secondaryNum ?? "1")).ToString();
            Debug.WriteLine("act " + _activeNum);
            Debug.WriteLine("sec " + _secondaryNum);
            PrintNum();
            ChangeOfNumber();
            if (_wasAnOperation > 0)
            {
                _activeNum = null;
            }
            _wasAnOperation++;
            _lastOperator = 3;
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            switch (_lastOperator) 
            {
                case 0:
                    button_sum_Click(button_sum, null);
                    break;
                case 1:
                    button_sub_Click(button_sum, null);
                    break;
                case 2:
                    button_multi_Click(button_sum, null);
                    break;
                case 3:
                    button_div_Click(button_sum, null);
                    break;
            }
            _lastOperator = -1;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            _activeNum = null;
            _secondaryNum = null;
            _pointEntered = false;
            _zeroBeforeDot = false;
            _wasAnOperation = 0;
            _lastOperator = -1;
            PrintNum();
        }

        private void button_mod_Click(object sender, EventArgs e)
        {
            _activeNum = Math.Abs(double.Parse(_activeNum)).ToString();
            PrintNum();
        }

        private void button_neg_Click(object sender, EventArgs e)
        {
            _activeNum = (double.Parse(_activeNum) * -1).ToString();
            PrintNum();
        }

        private void button_pi_Click(object sender, EventArgs e)
        {
            _activeNum = Math.PI.ToString();
            PrintNum();
        }

        private void button_exp_Click(object sender, EventArgs e)
        {
            _activeNum = Math.E.ToString();
            PrintNum();
        }
    }
}