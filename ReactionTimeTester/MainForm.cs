using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactionTimeTester
{
    public partial class MainForm : Form
    {
        private bool testActive = false;
        private int testNumber = 0;
        private int reactionTime = 0;

        public MainForm()
        {
            InitializeComponent();
            ResetForm();
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
        }

        public void StartTest()
        {
            testActive = true;
            button1.BackColor = Color.Green;

        }

        public void EndTest()
        {
            testActive = false;
            testNumber++;
        }

        public void RandomGenerator()
        {

        }
    }
}
