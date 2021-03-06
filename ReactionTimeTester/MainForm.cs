﻿using System;
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
        private bool tooSoon = false;
        private int testNumber = 0;
        private int reactionTime = 0;
        Random randomTimeGenerator = new Random();
        Stopwatch stopwatch = new Stopwatch();
        int timeCalc1;
        int timeCalc2;
        int timeLeft;
        int totalReactionTime = 0;
        private string attempts = "";

        public MainForm()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            ResetForm();
            button1.BackColor = Color.Cyan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!testActive)
                StartTest();
            else
                if(!tooSoon)
                    EndTest();

        }

        public void ResetForm()
        {
            ButtomCountdownTimer.Interval = 1;
            button1.Text = "CLICK TO START TEST";
            testActive = false;
            testNumber = 0;
            reactionTime = 0;

            button1.BackColor = Color.Cyan;
            button1.Enabled = true;
            button2.Text = "Reset Stats";
            button2.Enabled = false;
            label1.Text = "NO RECENT ATTMEPTS:" + Environment.NewLine;
            label2.Text = "";
        }

        public void StartTest()
        {
            timeLeft = randomTimeGenerator.Next(100, 500);
            testActive = true;
            button1.BackColor = Color.Violet;
            ButtomCountdownTimer.Interval = 1;
            ButtomCountdownTimer.Start();
            button1.Text = "Click when the button turns green ";
        }

        public void EndTest()
        {
            testActive = false;
            testNumber++;
            ButtomCountdownTimer.Stop();
            button1.BackColor = Color.Yellow;
            button1.Text = "";
            stopwatch.Stop();
            //int elapsedTime = (int));
            decimal reactionTime = stopwatch.ElapsedMilliseconds - 100;
            button1.Text = reactionTime + "ms" + Environment.NewLine + "Press any key to try again";
            totalReactionTime += (int)reactionTime;
            label1.Text = testNumber + " RECENT ATTMEPTS (AVERAGE: " + (totalReactionTime / testNumber) + "ms)" + Environment.NewLine;
            label2.Text += reactionTime + Environment.NewLine;
            stopwatch.Reset();
            //button1.Enabled = true;
            button2.Enabled = true;
        }

        private void ButtomCountdownTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {

                timeLeft = timeLeft - 1;
                tooSoon = true;
            }
            else
            {
                tooSoon = false;
                //button1.Enabled = true;
                ButtomCountdownTimer.Stop();
                button1.BackColor = Color.Green;
                //sum.Value = timeCalc1 + timeCalc2;

                timeLeft = 0;
                stopwatch.Start();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();
        } 
    }
}
