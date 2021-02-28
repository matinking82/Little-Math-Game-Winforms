using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleGame
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private static int Score = 0;
        private static int Answer;
        private static List<Button> btns;
        private static int Timer = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
            btns = new List<Button>() { btn1, btn2, btn3, btn4 };
            NewGame();
            timer1.Enabled = true;
        }

        private void NewGame()
        {
            int num1 = random.Next(1, 50);
            int num2 = random.Next(1, 50);
            if (random.Next(1, 2) == 2)
            {
                SetlblGame(num1, num2, "+");
                Answer = num1 + num2;
            }
            else
            {
                SetlblGame(num1, num2, "-");
                Answer = num1 - num2;
            }
            SetBtns();
            Timer = 15;
        }


        public void SetBtns()
        {
            btns[random.Next(0, 3)].Text = Answer.ToString();

            foreach (var btn in btns)
            {
                if (btn.Text == "")
                {
                    if (random.Next(1, 2) == 2)
                    {
                        btn.Text = (random.Next(1, 50) + random.Next(1, 50)).ToString();
                    }
                    else
                    {
                        btn.Text = (random.Next(1, 50) - random.Next(1, 50)).ToString();
                    }
                }
            }
        }


        public void SetlblGame(int num1, int num2, string opr)
        {
            lblGame.Text = num1.ToString() + $" {opr} " + num2.ToString() + " = ?";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CheckButton(btn1);
            NewGame();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            CheckButton(btn2);
            NewGame();

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CheckButton(btn3);
            NewGame();

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            CheckButton(btn4);
            NewGame();
        }

        private void CheckButton(Button btn)
        {
            if (btn.Text == Answer.ToString())
            {
                Win();
            }
            else
            {
                Lost();
            }
        }

        private void Win()
        {
            Score += 10;
            SetlblScore();
        }

        private void Lost()
        {
            if (MessageBox.Show("شما باختید!! آیا دوباره بازی میکنید؟", "بازی تمام", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void RestartGame()
        {
            NewGame();
            Score = 0;
            SetlblScore();
        }

        private void SetlblScore()
        {
            lblScore.Text = $"امتیاز : {Score}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Timer >= 0)
            {
                lblTimer.Text = Timer.ToString();
            }
            Timer--;
            if (Timer == -1)
            {
                Lost();
            }
        }
    }
}
