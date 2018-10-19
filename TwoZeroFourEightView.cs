﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
        bool isFull2;
        int score;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            //TwoZeroFourEightView_KeyPress(sender,e);



        }

        public void Notify(Model m)
        {
            
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
            isFull2 = ((TwoZeroFourEightModel)m).GetIsFull();
            score = ((TwoZeroFourEightModel)m).GetScore();
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }
        }
        private void UpdateScore(int score)
        {

        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
            label1.Text = score.ToString();
        }

        private void TwoZeroFourEightView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:
                case Keys.Up:
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    label1.Visible = isFull2;
                    label2.Visible = isFull2;
                    break;
                case Keys.S:
                case Keys.Down:
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    label1.Visible = isFull2;
                    label2.Visible = isFull2;

                    break;
                case Keys.D:
                case Keys.Right:
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    label1.Visible = isFull2;
                    label2.Visible = isFull2;

                    break;
                case Keys.A:
                case Keys.Left:
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    label1.Visible = isFull2;
                    label2.Visible = isFull2;

                    break;
            }
        }
    }
}
