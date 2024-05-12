﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool t = true;
        int t_count = 0;
        static string player_name1, player2_name;
        public bool mode;
       
       
        private void btns_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            try
            {
                if (t == true)
                    b.Text = "X";
                else
                    b.Text = "O";
                t = !t;
                b.Enabled = false;
                t_count++;
                checkwinner();
                if (mode == true && !t)
                {
                    Button move = null;
                    move = win_or_block("O");
                    if (move == null)
                        move = win_or_block("X");
                    if (move == null)
                    move.PerformClick();


                }
            }
            catch (Exception p)
            { MessageBox.Show(p.ToString()); }




        }
        private void checkwinner()
        {
            bool i = false;
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
            {
                i = true;
            }
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
            {
                i = true;
            }
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
            {
                i = true;
            }


            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
            {
                i = true;
            }
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
            {
                i = true;
            }
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
            {
                i = true;
            }


            else if((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
            {
                i = true;
            }
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!c1.Enabled))
            {
                i = true;
            }

            if (i)
            {
                string s;
                if (t)
                {
                    int a = Convert.ToInt32(O.Text);
                    a++;
                    O.Text =a.ToString();
                    s = player_name2.Text;
                    enabledbuttons();
                }
                else
                {
                    int a = Convert.ToInt32(X.Text);
                    a++;
                    X.Text =a.ToString();
                    s = player1.Text;
                    enabledbuttons();
                }
                MessageBox.Show(s + " wins !", "congratulations!");
                t_count = 0;
            }
            if (t_count == 9)
            {
                MessageBox.Show("Draw !", "Bunner !");
                t_count = 0;
                enabledbuttons();
                int a = Convert.ToInt32(d.Text);
                a++;
                d.Text =a.ToString();
            }
        }

        private void enabledbuttons()
        {
            foreach(Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void c3_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((t) && (b.Enabled))
            {
                b.Text = "X";
            }
            if ((t==false) && (b.Enabled))
            {
                b.Text = "O";
            }
        }

        private void c3_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledbuttons();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sorry but we don't support this project any more","Tic Tac Toe About");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player1.Text = player_name1;
            player_name2.Text = player2_name;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            X.Text = "0";
            O.Text = "0";
            d.Text = "0";
            t_count = 0;
        }

        public static void playernames(string n1,string n2)
        {
            player_name1 = n1;
            player2_name = n2;
        }
        private Button win_or_block(string s)
        {
            if (a1.Text == s && a2.Text == s && a3.Text == "")
                return a3;
            if (a1.Text == s && a2.Text == "" && a3.Text == s)
                return a2;
            if (a1.Text == "" && a2.Text == s && a3.Text == s)
                return a1;

            if (b1.Text == s && b2.Text == s && b3.Text == "")
                return b3;
            if (b1.Text == s && b2.Text == "" && b3.Text == s)
                return b2;
            if (b1.Text == "" && b2.Text == s && b3.Text == s)
                return b1;

            if (c1.Text == s && c2.Text == s && c3.Text == "")
                return c3;
            if (c1.Text == s && c2.Text == "" && c3.Text == s)
                return c2;
            if (c1.Text == "" && c2.Text == s && c3.Text == s)
                return c1;

            if (a1.Text == s && b1.Text == s && c1.Text == "")
                return c1;
            if (a1.Text == s && b1.Text == "" && c1.Text == s)
                return b1;
            if (a1.Text == "" && b1.Text == s && c1.Text == s)
                return a1;

            if (a2.Text == s && b2.Text == s && c2.Text == "")
                return c2;
            if (a2.Text == s && b2.Text == "" && c2.Text == s)
                return b2;
            if (a2.Text == "" && b2.Text == s && c2.Text == s)
                return a2;

            if (a3.Text == s && b3.Text == s && c3.Text == "")
                return c3;
            if (a3.Text == s && b3.Text == "" && c3.Text == s)
                return b3;
            if (a3.Text == "" && b3.Text == s && c3.Text == s)
                return a3;

            if (a1.Text == s && b2.Text == "" && c3.Text == s)
                return b2;
            if (a1.Text == "" && b2.Text == s && c3.Text == s)
                return a1;
            if (a1.Text == s && b2.Text == s && c3.Text == "")
                return c3;

            if (a3.Text == s && b2.Text == "" && c1.Text == s)
                return b2;
            if (a3.Text == "" && b2.Text == s && c1.Text == s)
                return a3;
            if (a3.Text == s && b2.Text == s && c1.Text == "")
                return c1;

            return null;







        }
    }
}