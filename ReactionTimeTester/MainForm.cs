using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ReactionTimeTester
{
    public partial class MainForm : Form
    {
        private bool testActive = false;
        private int testNumber = 0;
        private int reactionTime = 0;
        Random randomTimeGenerator = new Random();
        Stopwatch stopwatch = new Stopwatch();
        int timeCalc1;
        int timeCalc2;
        int timeLeft;

        public MainForm()
        {
            InitializeComponent();
            ResetForm();
            button1.BackColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!testActive)
                StartTest();
            else
                EndTest();

        }

        public void ResetForm()
        {
            button1.Text = "CLICK TO START TEST";
            testActive = false;
            testNumber = 0;
            reactionTime = 0;

            button1.BackColor = Color.Blue;
        }

        public void StartTest()
        {
            timeLeft = randomTimeGenerator.Next(1, 25);
            testActive = true;
            button1.BackColor = Color.Red;
            ButtomCountdownTimer.Start();
        }

        public void EndTest()
        {
            testActive = false;
            testNumber++;
            ButtomCountdownTimer.Stop();
            button1.BackColor = Color.Yellow;
            button1.Text = "";
        }

        private void ButtomCountdownTimer_Tick(object sender, EventArgs e)
        {
            if(timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }
            else
            {
                ButtomCountdownTimer.Stop();
                button1.BackColor = Color.Green;
                //sum.Value = timeCalc1 + timeCalc2;

                stopwatch.Start();
                timeLeft = 0;
            }
        } 
    }
}
