using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace irobot
{
    public partial class Form1 : Form
    {
        SerialPort robot;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                robot.Close();
            }
            catch (Exception ex)
            {
            }
            robot = new SerialPort(textBox1.Text);
            robot.BaudRate = 57600;
            robot.StopBits = StopBits.One;
            robot.DataBits = 8;
            robot.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                robot.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] line = {128,131};
            robot.Write(line, 0, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] line = { 137,0,100,128,0};
            robot.Write(line, 0, 5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] line = { 137, 0, 0, 0, 0 };
            robot.Write(line, 0, 5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            int index = 0;
            byte val = 0;
            byte[] line = new byte[10];
            
            while (count < textBox2.Text.Length){
                val = 0;
                while (textBox2.Text.ElementAt(count) != ',' && count < textBox2.Text.Length)
                {
                    val = (byte)(val * 10 + ((int)textBox2.Text.ElementAt(count) - (int)'0'));
                    count++;
                }
                line[index] = val;
                index++;
            }
            robot.Write(line, 0, index);
        }
    }
}
