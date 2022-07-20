﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        //variables del juego
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeBottom.Left < -150) 
            {
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -180) 
            {
                pipeTop.Left = 950;
                score++; 
            }

            //este if chequea si el pajaro choca con las tuverias o el piso y el techo
            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
               flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
               flappyBird.Top < -25) 
            {
                endGame();
            }

            //este if chequea cuando el marcador sea mayor a 5 aumente la velocidad 
            if(score > 5) 
            {
                pipeSpeed = 15;
            }
            
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void endGame() //funcion que termina el juego
        {
            gameTimer.Stop();
            scoreText.Text += " Game  Over!!! ";
        }
    }
}