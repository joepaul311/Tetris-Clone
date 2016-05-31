using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace XNA_Tetris
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
         // 1 is static, 2 is moving, 0 is empty
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        public int score;
        public int stage; //0 = menu; 1 = game; 2 = highscore
        menu menu1;
        Random rn = new Random();
        //HighScoreData hs2;
        highScore hs;
        KeyboardState kbs;
        SpriteFont Ronaldino;
        KeyboardState prevKeyPress;
        Vector2 Victor = new Vector2(0.0f, 0.0f);
        Texture2D Block;
        public Song Korobeiniki;
        public Song September;
        public Song prayer;
        public Song Zarathustra;
        SoundEffect Sf;
        public Song TIL;
        public Song BONITO;
        public Song blank;
        Texture2D Tlogo;
        public Song plumfairy;
        public Song selectedsong;
        int[,] board = new int[22, 12];
        int[,] prevBoard = new int[22, 12];
        int[,] staticbricks = new int[22, 12];
        Color[,] colorarray = new Color[20, 10];
        double intervalTime = 0;
        double prevIntervalTime = 0;
        int a;
        Color c0;
        Color c1;
        Color c2;
        Color c3;
        Color c4;
        Color c5;
        Color c6;
        int[,] fboard = new int[20, 10];
        public string[] names = new string[5];
        public int[] scores = new int[5];
        public string highScoreName;
        int vontaleach = 0;
        int mode = 0;
        int speed = 1000;
        int gscore = 0;
        int movespeed = 0;
        public bool isflickering = true;
        bool weredonehereok = false;
        int pscore;
        int pa;
        int prevspeed;
        Song teris;
        bool skiprest = false;
        bool moving = false;
        bool redraw = false;
        bool done = false;
        int timerlike = 0;
        public int level = 0;
        //bool skipover = false;
        int counttilldestroy = 0;
        bool loaded = false;
        Color[,] bc = new Color[20, 10];
        int[] blocklocx = new int[4];
        int[] blocklocy = new int[4];
        bool puuuuuush = false;
        int[] prevblocklocx = new int[4];
        int[] prevblocklocy = new int[4];
        Color color = new Color(0, 0, 0);


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            menu1 = new menu(this);
            score = 0;
            stage = 0;


            this.graphics.PreferredBackBufferHeight = 440;
            this.graphics.PreferredBackBufferWidth = 600;

            Components.Add(menu1);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            Block = Content.Load<Texture2D>("tetris block");
            Ronaldino = Content.Load<SpriteFont>("SpriteFont3");
            Tlogo = Content.Load<Texture2D>("Tetris");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = 0;
                }
            }
            Korobeiniki = Content.Load<Song>("Original_Tetris_theme_Tetris_Soundtrack");  // Put the name of your song in instead of "song_title"
            September = Content.Load<Song>("Earth_Wind_Fire_-_September_With_Lyrics");
            blank = Content.Load<Song>("blank");
            plumfairy = Content.Load<Song>("sugarplum");
            prayer = Content.Load<Song>("prayer3");
            teris = Content.Load<Song>("TetrisAudio");
            BONITO = Content.Load<Song>("Bonito");
            TIL = Content.Load<Song>("TIL");
            Zarathustra = Content.Load<Song>("ZARATHUSTRACUT");
            //selectedsong = September;
            // MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            // TODO: use this.Content to load your game content here
        }
        void SpawnBricks()
        {
            // resetbrick();
            moving = true;

            a = pa;
            pa = rn.Next(0, 7);
            //if (a >= 4)
            //{
            //    a = 3;
            //}
            ////else if (a < 2)
            ////{
            ////    a = 1;
            ////}
            //else
            //{
            //    a = 0;
            //}
            //a = 5;
            //a = 1;
            //1 and 5 should be watched
            //a = 4;\
            //a = 3;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    colorarray[i, j] = Color.Black;
                }
            }
            //if (a < 4)
            //{
            //    a = 6;
            //}
            //else
            //{
            //    a = 6;
            //}
            if (a == 0)
            {
                //board[0, 0] = 2;
                //board[0, 1] = 2;
                //board[1, 1] = 2;
                //board[1, 0] = 2;

                blocklocx[0] = 0;
                blocklocy[0] = 0;

                blocklocx[1] = 0;
                blocklocy[1] = 1;

                blocklocx[2] = 1;
                blocklocy[2] = 0;

                blocklocx[3] = 1;
                blocklocy[3] = 1;


                //[][]NN
                //[][]NN
            }
            if (a == 1)
            {
                board[0, 0] = 0;
                blocklocx[0] = 0;
                blocklocy[0] = 1;

                blocklocx[2] = 1;
                blocklocy[2] = 1;

                blocklocx[1] = 1;
                blocklocy[1] = 0;

                blocklocx[3] = 0;
                blocklocy[3] = 2;

                //N [][] N
                //[][] N N
                //blocklocx[0] = 0;
                //blocklocy[0] = 0;

                //blocklocx[1] = 1;
                //blocklocy[1] = 0;

                //blocklocx[2] = 1;
                //blocklocy[2] = 1;

                //blocklocx[3] = 2;
                //blocklocy[3] = 1; a rotation of it
            }

            if (a == 2)
            {


                blocklocx[0] = 0;
                blocklocy[0] = 0;

                blocklocx[1] = 0;
                blocklocy[1] = 1;

                blocklocx[2] = 1;
                blocklocy[2] = 1;

                blocklocx[3] = 1;
                blocklocy[3] = 2;

                //[][] N N
                //N [][] N

            }
            if (a == 3)
            {

                blocklocx[0] = 0;
                blocklocy[0] = 0;

                blocklocx[1] = 0;
                blocklocy[1] = 1;

                blocklocx[2] = 0;
                blocklocy[2] = 2;

                blocklocx[3] = 0;
                blocklocy[3] = 3;

                //[][][][]
                //N N N N
            }
            if (a == 4)
            {


                blocklocx[0] = 0;
                blocklocy[0] = 0;

                blocklocx[1] = 0;
                blocklocy[1] = 1;

                blocklocx[2] = 0;
                blocklocy[2] = 2;

                blocklocx[3] = 1;
                blocklocy[3] = 2;

                //[][][] N
                //N N [] N
            }
            if (a == 5)
            {
                blocklocx[0] = 0;
                blocklocy[0] = 0;

                blocklocx[1] = 1;
                blocklocy[1] = 0;

                blocklocx[2] = 0;
                blocklocy[2] = 1;

                blocklocx[3] = 0;
                blocklocy[3] = 2;

                //[][][] N
                //[] N N N
            }
            if (a == 6)
            {

                blocklocx[0] = 0;
                blocklocy[0] = 0;

                blocklocx[1] = 0;
                blocklocy[1] = 1;

                blocklocx[3] = 0;
                blocklocy[3] = 2;

                blocklocx[2] = 1;
                blocklocy[2] = 1;

                //[][][] N
                //N [] N N
            }
            board[0, 0] = 0;
            blocklocy[0] += 3;
            blocklocy[1] += 3;
            blocklocy[3] += 3;

            blocklocy[2] += 3;
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (board[j, i] == 1 )//|| board[j,i] == 2)
            //        {
            //            endgame();
            //        }
            //    }
            //}
            if (board[blocklocx[0], blocklocy[0]] == 1)
            {
                endgame();
            }
            if (board[blocklocx[1], blocklocy[1]] == 1)
            {
                endgame();
            }
            if (board[blocklocx[2], blocklocy[2]] == 1)
            {
                endgame();
            }
            if (board[blocklocx[3], blocklocy[3]] == 1)
            {
                endgame();
            }
            blocklocx[0]++;
            blocklocx[1]++;
            blocklocx[2]++;
            blocklocx[3]++;
            if (a == 4)
            {
                mode = 2;
            }
            else
            {
                mode = 0;
            }
            //switch (a)
            //{
            //    case 0:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.Yellow;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.Yellow;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.Yellow;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.Yellow;
            //    break;
            //    case 1:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.Green;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.Green;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.Green;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.Green;
            //    break;
            //    case 2:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.Red;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.Red;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.Red;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.Red;
            //    break;
            //    case 3:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.Cyan;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.Cyan;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.Cyan;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.Cyan;
            //    break;
            //    case 4:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.DarkBlue;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.DarkBlue;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.DarkBlue;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.DarkBlue;
            //    break;
            //    case 5:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.Orange;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.Orange;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.Orange;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.Orange;
            //    break;
            //    case 6:
            //    colorarray[blocklocx[0], blocklocy[0]] = Color.Purple;
            //    colorarray[blocklocx[1], blocklocy[1]] = Color.Purple;
            //    colorarray[blocklocx[2], blocklocy[2]] = Color.Purple;
            //    colorarray[blocklocx[3], blocklocy[3]] = Color.Purple;
            //    break;

            //}
        }
        protected override void UnloadContent()
        {

        }
        private bool Timer(GameTime gt, int pause)  //pause in milliseconds
        {
            bool resetInterval = false;

            intervalTime += (double)gt.ElapsedGameTime.Milliseconds;
            intervalTime = intervalTime % pause;
            if (intervalTime < prevIntervalTime) { resetInterval = true; }
            prevIntervalTime = intervalTime;
            return resetInterval;
        }
        bool checkifhit(bool x)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (x == false)
                    {
                        if (board[blocklocx[i] + 1, blocklocy[i]] == 1 || blocklocx[i] == 19 || board[blocklocx[i] + 1, blocklocy[i]] == 5)
                        {

                            //they stay at the top some reason
                            // Console.WriteLine(board[blocklocx[i] + 1, blocklocy[i]]);


                            for (int k = 0; k < 4; k++)
                            {
                                board[blocklocx[k], blocklocy[k]] = 1;

                                if (a == 0)
                                {
                                    bc[blocklocx[k], blocklocy[k]] = c0;
                                    fboard[blocklocx[k], blocklocy[k]] = 0;
                                }
                                else if (a == 1)
                                {
                                    bc[blocklocx[k], blocklocy[k]] = c1;
                                    fboard[blocklocx[k], blocklocy[k]] = 1;
                                    //colorusumbridge = new Color(0, 255, 0);
                                }
                                else if (a == 2)
                                {
                                    bc[blocklocx[k], blocklocy[k]] = c2;
                                    fboard[blocklocx[k], blocklocy[k]] = 2;
                                    //colorusumbridge = new Color(0, 0, 255);
                                }
                                else if (a == 3)
                                {
                                    bc[blocklocx[k], blocklocy[k]] = c3;
                                    fboard[blocklocx[k], blocklocy[k]] = 3;
                                    //colorusumbridge = new Color(255, 255, 0);
                                }
                                else if (a == 4)
                                {
                                    bc[blocklocx[k], blocklocy[k]] = c4;
                                    fboard[blocklocx[k], blocklocy[k]] = 4;
                                    //colorusumbridge = new Color(255, 0, 255);
                                }
                                else if (a == 5)
                                {
                                    bc[blocklocx[k], blocklocy[k]] = c5;
                                    fboard[blocklocx[k], blocklocy[k]] = 5;
                                    //colorusumbridge = new Color(0, 255, 255);
                                }
                                else if (a == 6)
                                {

                                    bc[blocklocx[k], blocklocy[k]] = c6;
                                    fboard[blocklocx[k], blocklocy[k]] = 6;
                                    //colorusumbridge = new Color(100, 100, 100);
                                }
                                if (k == 3)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                for (int i = 3; i >= 0; i--)
                {

                    board[blocklocx[i], blocklocy[i]] = 0;
                    blocklocx[i]++;
                    board[blocklocx[i], blocklocy[i]] = 2;


                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        void movebricksright()
        {


            if (kbs.IsKeyDown(Keys.Right)) //&& !prevKeyPress.IsKeyDown(Keys.Right) )
            {

                // 
                //else if ((a == 1 || a == 0) && blocklocy[3] == 8)
                //  {

                // }
                //  if (a == 1 && blocklocy[3] == 8)
                // {


                //               }
                if (board[blocklocx[0], blocklocy[0] + 1] == 1)
                {

                }
                else if (board[blocklocx[1], blocklocy[1] + 1] == 1)
                {

                }
                else if (board[blocklocx[2], blocklocy[2] + 1] == 1)
                {

                }
                else if (board[blocklocx[3], blocklocy[3] + 1] == 1)
                {

                }
                else if (blocklocy[0] == 9 || blocklocy[1] == 9 || blocklocy[2] == 9 || blocklocy[3] == 9)
                {

                }
                else
                {
                    for (int i = 3; i >= 0; i--)
                    {
                        board[blocklocx[i], blocklocy[i]] = 0;
                        blocklocy[i]++;
                        board[blocklocx[i], blocklocy[i]] = 2;

                    }
                }

            }



        }
        void movebricks()
        {
            kbs = Keyboard.GetState();
            bool done = false;
            try
            {
                //if (kbs.IsKeyDown(Keys.Right) && !prevKeyPress.IsKeyDown(Keys.Right) && done == false)
                //{
                //    movebricksright();
                //    done = true;
                //}
                //else if (kbs.IsKeyDown(Keys.Left) && !prevKeyPress.IsKeyDown(Keys.Left) && done == false)
                //{
                //    movebricksleft();
                //    done = true;
                //}

                if (kbs.IsKeyDown(Keys.Left) && !prevKeyPress.IsKeyDown(Keys.Left))
                {
                    movebricksright();
                    movebricksleft();
                    done = true;
                    movespeed = 0;
                }
                else if (kbs.IsKeyDown(Keys.Right) && !prevKeyPress.IsKeyDown(Keys.Right))
                {
                    movebricksright();
                    movebricksleft();
                    done = true;
                    movespeed = 0;
                }
                else if (movespeed % 6 == 0 && done == false)
                {

                    movebricksright();
                    movebricksleft();
                    done = true;
                }

                rotatebricks();
                prevKeyPress = kbs;
            }

            catch
            {
                board = prevBoard;
            }
        }
        void countstatic()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == 1)
                    {
                        staticbricks[i, j] = 1;
                    }
                    else
                    {
                        staticbricks[i, j] = 0;
                    }

                }
            }
        }
        void countmoving()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {


                }
            }
        }
        void movebricksleft()
        {
            if (kbs.IsKeyDown(Keys.Left))// && !prevKeyPress.IsKeyDown(Keys.Left))
            {
                // Console.WriteLine(a);
                if (blocklocy[0] == 0 || blocklocy[1] == 0 || blocklocy[2] == 0 || blocklocy[3] == 0)
                {
                }
                else if (board[blocklocx[0], blocklocy[0] - 1] == 1)
                {

                }
                else if (board[blocklocx[1], blocklocy[1] - 1] == 1)
                {

                }
                else if (board[blocklocx[2], blocklocy[2] - 1] == 1)
                {

                }
                else if (board[blocklocx[3], blocklocy[3] - 1] == 1)
                {

                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        board[blocklocx[i], blocklocy[i]] = 0;
                        blocklocy[i]--;
                        board[blocklocx[i], blocklocy[i]] = 2;
                    }

                }
            }
        }
        void rotatebricks()
        {
            try
            {



                //no 2x2 a = 0
                if (a == 3)
                {
                    rotatebricks1x4(); // a = 3
                }
                else if (a == 1)
                {
                    rotatebricks2shift2a(); //a = 1 

                }
                else if (a == 2)
                {

                    rotatebricks2shift2b(); // a = 2
                }
                else if (a == 4)
                {
                    rotateoooL(); // a = 4

                }
                else if (a == 5)
                {

                    rotateLooo(); // a = 
                }
                else if (a == 6)
                {
                    rotatePyramid(); // a = 6
                }

                if (board[blocklocx[0], blocklocy[0]] == 1 || board[blocklocx[1], blocklocy[1]] == 1 || board[blocklocx[2], blocklocy[2]] == 1 || board[blocklocx[3], blocklocy[3]] == 1)
                {
                    //Console.WriteLine("IXIAN SCUMBAGS!");
                    if (board[blocklocx[0], blocklocy[0] + 1] != 1 && board[blocklocx[1], blocklocy[1] + 1] != 1 && board[blocklocx[2], blocklocy[2] + 1] != 1 && board[blocklocx[3], blocklocy[3] + 1] != 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            blocklocy[i]++;
                        }

                    }
                    else if (board[blocklocx[0], blocklocy[0] - 1] != 1 && board[blocklocx[1], blocklocy[1] - 1] != 1 && board[blocklocx[2], blocklocy[2] - 1] != 1 && board[blocklocx[3], blocklocy[3] - 1] != 1)
                    {

                        for (int i = 0; i < 4; i++)
                        {

                            blocklocy[i]--;
                        }
                    }
                }
            }
            catch
            {
            
            }
        }
        void rotatebricks1x4()
        {

            // add so you cant rotate into bricks; thatd be silly
            if (kbs.IsKeyDown(Keys.Up) && !prevKeyPress.IsKeyDown(Keys.Up))
            {
                if (a == 3)
                {
                    //int storage;
                    //storage = blocklocx[0];
                    //blocklocx[0] = blocklocy[0];
                    //blocklocy[0] = storage;
                    //storage = blocklocx[1];
                    //blocklocx[1] = blocklocy[1];
                    //blocklocy[1] = storage;
                    //storage = blocklocx[2];
                    //blocklocx[2] = blocklocy[2];
                    //blocklocy[2] = storage;
                    //storage = blocklocx[3];
                    //blocklocx[3] = blocklocy[3];
                    //blocklocy[3] = storage; switcharoo
                    //[][][][]
                   // Console.WriteLine(mode);
                    if (mode == 0) //- - - - to |
                    {
                        //if (blocklocx[0] < 4)
                        //{
                        //    board[blocklocx[1], blocklocy[1]] = 0;
                        //    board[blocklocx[2], blocklocy[2]] = 0;
                        //    board[blocklocx[3], blocklocy[3]] = 0;
                        //    board[blocklocx[0], blocklocy[0]] = 0;

                        //    blocklocx[0] = 4;
                        //    blocklocx[1] = 3;
                        //    blocklocx[2] = 2;
                        //    blocklocx[3] = 1;

                        //    board[blocklocx[0], blocklocy[0]] = 2;
                        //    board[blocklocx[1], blocklocy[1]] = 2;
                        //    board[blocklocx[2], blocklocy[2]] = 2;
                        //    board[blocklocx[3], blocklocy[3]] = 2;

                        //    board[blocklocx[1], blocklocy[1]] = 0;
                        //    board[blocklocx[2], blocklocy[2]] = 0;
                        //    board[blocklocx[3], blocklocy[3]] = 0;
                        //    blocklocx[1] = blocklocx[0] - 1;
                        //    blocklocx[2] = blocklocx[0] - 2;
                        //    blocklocx[3] = blocklocx[0] - 3;
                        //    blocklocy[1] = blocklocy[0];
                        //    blocklocy[2] = blocklocy[0];
                        //    blocklocy[3] = blocklocy[0];
                        //    board[blocklocx[0], blocklocy[0]] = 2;
                        //    board[blocklocx[1], blocklocy[1]] = 2;
                        //    board[blocklocx[2], blocklocy[2]] = 2;
                        //    board[blocklocx[3], blocklocy[3]] = 2;
                        //    mode = 1;
                        //}




                        //else
                        //{
                        int y1 = blocklocy[0];
                        int y2 = blocklocy[1];
                        int y3 = blocklocy[2];
                        int y4 = blocklocy[3];
                        while (blocklocx[0] < 3)
                        {
                            blocklocx[0]++;
                            blocklocx[1]++;
                            blocklocx[2]++;
                            blocklocx[3]++;
                        }
                        board[blocklocx[1], blocklocy[1]] = 0;
                        board[blocklocx[2], blocklocy[2]] = 0;
                        board[blocklocx[3], blocklocy[3]] = 0;
                        blocklocx[1] = blocklocx[0] - 1;
                        blocklocx[2] = blocklocx[0] - 2;
                        blocklocx[3] = blocklocx[0] - 3;
                        blocklocy[1] = blocklocy[0];
                        blocklocy[2] = blocklocy[0];
                        blocklocy[3] = blocklocy[0];
                        board[blocklocx[0], blocklocy[0]] = 2;
                        board[blocklocx[1], blocklocy[1]] = 2;
                        board[blocklocx[2], blocklocy[2]] = 2;
                        board[blocklocx[3], blocklocy[3]] = 2;
                        mode = 1;



                    }
                    else if (mode == 1)
                    {
                        int c1, c2, c3, c4;

                        c1 = board[blocklocx[0], blocklocy[0]];
                        c2 = board[blocklocx[0], blocklocy[0] + 1];
                        c3 = board[blocklocx[0], blocklocy[0] + 2];
                        c4 = board[blocklocx[0], blocklocy[0] + 3];
                        if (c1 == 1)
                        {
                            Console.WriteLine("1");
                        }
                        else if (c2 == 1)
                        {
                            Console.WriteLine("2");
                        }
                        else if (c3 == 1)
                        {
                            Console.WriteLine("3");
                        }
                        else if (c4 == 1)
                        {
                            Console.WriteLine("4");
                        }
                        else if (board[blocklocx[0], blocklocy[0]] == 1)
                        {

                        }
                        else if (board[blocklocx[1], blocklocy[1]] == 1)
                        {

                        }
                        else if (board[blocklocx[2], blocklocy[2]] == 1)
                        {

                        }
                        else if (board[blocklocx[3], blocklocy[3]] == 1)
                        {

                        }
                        else
                        {
                            board[blocklocx[1], blocklocy[1]] = 0;
                            board[blocklocx[2], blocklocy[2]] = 0;
                            board[blocklocx[3], blocklocy[3]] = 0;
                            blocklocy[1] = blocklocy[0] + 1;
                            blocklocy[2] = blocklocy[0] + 2;
                            blocklocy[3] = blocklocy[0] + 3;
                            blocklocx[1] = blocklocx[0];
                            blocklocx[2] = blocklocx[0];
                            blocklocx[3] = blocklocx[0];
                            if (blocklocy[3] > 9)
                            {
                                blocklocy[3] = 9;
                                blocklocy[2] = 8;
                                blocklocy[1] = 7;
                                blocklocy[0] = 6;
                            }
                            board[blocklocx[0], blocklocy[0]] = 2;
                            board[blocklocx[1], blocklocy[1]] = 2;
                            board[blocklocx[2], blocklocy[2]] = 2;
                            board[blocklocx[3], blocklocy[3]] = 2;
                            //}
                            mode = 0;
                        }
                    }
                }
            }
        } //check
        void deleteem()
        {
            board[blocklocx[1], blocklocy[1]] = 0;
            board[blocklocx[2], blocklocy[2]] = 0;
            board[blocklocx[3], blocklocy[3]] = 0;
            board[blocklocx[0], blocklocy[0]] = 0;


        }
        void redraweem()
        {
            board[blocklocx[0], blocklocy[0]] = 2;
            board[blocklocx[1], blocklocy[1]] = 2;
            board[blocklocx[2], blocklocy[2]] = 2;
            board[blocklocx[3], blocklocy[3]] = 2;
        }
        void rotatebricks2shift2a()
        {
            //N [][] N
            //[][] N N
            if (kbs.IsKeyDown(Keys.Up) && !prevKeyPress.IsKeyDown(Keys.Up))
            {
                if (a == 1)
                {
                    if (mode == 0) // 00 is empty, lieing on the side
                    {
                        //aqua/[0] is fulcrum
                        //brown= [3]
                        //red = [2]
                        //pink is [1]
                        board[blocklocx[1], blocklocy[1]] = 0;
                        board[blocklocx[2], blocklocy[2]] = 0;
                        board[blocklocx[3], blocklocy[3]] = 0;
                        board[blocklocx[0], blocklocy[0]] = 0;



                        blocklocx[3] = blocklocx[0] - 1;
                        blocklocy[3] = blocklocy[0];
                        blocklocx[2] = blocklocx[0];
                        blocklocy[2] = blocklocy[0] + 1;
                        blocklocy[1] = blocklocy[0] + 1;


                        board[blocklocx[0], blocklocy[0]] = 2;
                        board[blocklocx[1], blocklocy[1]] = 2;
                        board[blocklocx[2], blocklocy[2]] = 2;
                        board[blocklocx[3], blocklocy[3]] = 2;
                        mode = 1;
                    }
                    else if (mode == 1) //up and down
                    {
                     
                            if (board[blocklocx[0] + 1, blocklocy[0] + 1] == 1)
                            {

                            }
                            else if (board[blocklocx[1] + 1, blocklocy[1] + 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2] + 1, blocklocy[2] + 1] == 1)
                            {

                            }
                            else if (board[blocklocx[3] + 1, blocklocy[3] + 1] == 1)
                            {

                            }
                            else if (board[blocklocx[0], blocklocy[0] + 1] == 1)
                            {

                            }

                            else if (board[blocklocx[1], blocklocy[1] + 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2], blocklocy[2] + 1] == 1)
                            {

                            }
                            else if (board[blocklocx[3], blocklocy[3] + 1] == 1)
                            {

                            }
                            else if (blocklocx[0] == 0)
                            {

                            }
                            else if (blocklocx[3] == 0)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[3] - 1, blocklocy[3] - 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2] - 1, blocklocy[2] - 1] == 1 && blocklocy[2] != 0)
                            {

                            }
                            else if (board[blocklocx[1] - 1, blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                            {

                            }
                            else if (blocklocy[0] != 0 && board[blocklocx[0] - 1, blocklocy[0] - 1] == 1)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[3], blocklocy[3] - 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2], blocklocy[2] - 1] == 1 && blocklocy[2] != 0)
                            {

                            }
                            else if (board[blocklocx[1], blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[0], blocklocy[0] - 1] == 1 && blocklocy[0] != 0)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[3] - 1, blocklocy[3] - 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2] - 1, blocklocy[2] - 1] == 1 && blocklocy[2] != 0)
                            {

                            }
                            else if (board[blocklocx[1] - 1, blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                            {

                            }
                            else if (blocklocy[0] != 0 && board[blocklocx[0] - 1, blocklocy[0] - 1] == 1)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[3], blocklocy[3] - 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2], blocklocy[2] - 1] == 1 && blocklocy[2] != 0)
                            {

                            }
                            else if (board[blocklocx[1], blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[0], blocklocy[0] - 1] == 1 && blocklocy[0] != 0)
                            {

                            }




                            else if (blocklocy[3] != 0 && board[blocklocx[3] + 1, blocklocy[3] - 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2] - 1, blocklocy[2] - 1] == 1 && blocklocy[2] != 0)
                            {

                            }
                            else if (board[blocklocx[1] - 1, blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                            {

                            }
                            else if (blocklocy[0] != 0 && board[blocklocx[0] + 1, blocklocy[0] - 1] == 1)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[3], blocklocy[3] - 1] == 1)
                            {

                            }
                            else if (board[blocklocx[2], blocklocy[2] - 1] == 1 && blocklocy[2] != 0)
                            {

                            }
                            else if (board[blocklocx[1], blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                            {

                            }
                            else if (blocklocy[3] != 0 && board[blocklocx[0], blocklocy[0] - 1] == 1 && blocklocy[0] != 0)
                            {

                            }


                            else
                            {

                                if (blocklocy[0] == 0)
                                {
                                    for (int i = 0; i < 4; i++)
                                    {

                                        board[blocklocx[1], blocklocy[1]] = 0;
                                        board[blocklocx[2], blocklocy[2]] = 0;
                                        board[blocklocx[3], blocklocy[3]] = 0;
                                        board[blocklocx[0], blocklocy[0]] = 0;
                                        blocklocy[i]++;
                                        board[blocklocx[0], blocklocy[0]] = 2;
                                        board[blocklocx[1], blocklocy[1]] = 2;
                                        board[blocklocx[2], blocklocy[2]] = 2;
                                        board[blocklocx[3], blocklocy[3]] = 2;

                                    }


                                }
                                board[blocklocx[1], blocklocy[1]] = 0;
                                board[blocklocx[2], blocklocy[2]] = 0;
                                board[blocklocx[3], blocklocy[3]] = 0;
                                board[blocklocx[0], blocklocy[0]] = 0;
                                //<code here for switch>
                                blocklocy[3] = blocklocy[0] + 1;
                                blocklocx[3] = blocklocx[0];
                                //blocklocx[2] = blocklocx[1];
                                //blocklocy[2] = blocklocy[1];
                                blocklocx[2] = blocklocx[0] + 1;
                                blocklocy[2] = blocklocy[0];
                                blocklocx[1] = blocklocx[0] + 1;
                                blocklocy[1] = blocklocy[0] - 1;
                                //</code here for switch>
                                board[blocklocx[0], blocklocy[0]] = 2;
                                board[blocklocx[1], blocklocy[1]] = 2;
                                board[blocklocx[2], blocklocy[2]] = 2;
                                board[blocklocx[3], blocklocy[3]] = 2;
                                mode = 0;
                            }
                            //mode = 0? maybe not
                        }
                    
                 


                }
                                  
            }
        }
        void rotatebricks2shift2b()
        {
            if (kbs.IsKeyDown(Keys.Up) && !prevKeyPress.IsKeyDown(Keys.Up))
            {
                //aqua/[0] 
                //brown= [3]
                //red = [2]
                //pink is [1] is fulcrum

                //[][] N N
                //N [][] N
                if (a == 2)
                {
                    if (mode == 0) // 00 is empty, lieing on the side
                    {
                        //aqua/[0] 
                        //brown= [3]
                        //red = [2]
                        //pink is [1] is fulcrum
                        board[blocklocx[1], blocklocy[1]] = 0;
                        board[blocklocx[2], blocklocy[2]] = 0;
                        board[blocklocx[3], blocklocy[3]] = 0;
                        board[blocklocx[0], blocklocy[0]] = 0;



                        blocklocx[0] = blocklocx[1] - 1;
                        blocklocy[0] = blocklocy[1];
                        blocklocy[2] = blocklocy[1] - 1;
                        blocklocx[2] = blocklocx[1];
                        blocklocy[3] = blocklocy[1] - 1;
                        blocklocx[3] = blocklocx[1] + 1;
                        //red left of pink
                        //brown below red (down 1 left 1 of pink)

                        board[blocklocx[0], blocklocy[0]] = 2;
                        board[blocklocx[1], blocklocy[1]] = 2;
                        board[blocklocx[2], blocklocy[2]] = 2;
                        board[blocklocx[3], blocklocy[3]] = 2;
                        mode = 1;
                    }
                    else if (mode == 1) //up and down
                    {

                        if (board[blocklocx[0] + 1, blocklocy[0] + 1] == 1)
                        {

                        }
                        else if (blocklocx[0] == 0)
                        {

                        }
                        else if (blocklocx[3] == 0)
                        {

                        }
                        else if (board[blocklocx[1] + 1, blocklocy[1] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[2] + 1, blocklocy[2] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[3] + 1, blocklocy[3] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[0], blocklocy[0] + 1] == 1)
                        {

                        }

                        else if (board[blocklocx[1], blocklocy[1] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[2], blocklocy[2] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[3], blocklocy[3] + 1] == 1)
                        {

                        }
                        else if (blocklocy[3] != 0 && board[blocklocx[3] - 1, blocklocy[3] - 1] == 1)
                        {

                        }
                        else if (blocklocy[2] != 0 && board[blocklocx[2] - 1, blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[1] - 1, blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                        {

                        }
                        else if (blocklocy[0] != 0 && board[blocklocx[0] - 1, blocklocy[0] - 1] == 1)
                        {

                        }
                        else if (blocklocy[3] != 0 && board[blocklocx[3], blocklocy[3] - 1] == 1)
                        {

                        }
                        else if (blocklocy[2] != 0 && board[blocklocx[2], blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[1], blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                        {

                        }
                        else if (blocklocy[0] != 0 && blocklocy[3] != 0 && board[blocklocx[0], blocklocy[0] - 1] == 1)
                        {

                        }
                        else if (blocklocy[3] != 0 && board[blocklocx[3] - 1, blocklocy[3] - 1] == 1)
                        {

                        }
                        else if (blocklocy[2] != 0 && board[blocklocx[2] - 1, blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[1] - 1, blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                        {

                        }
                        else if (blocklocy[0] != 0 && board[blocklocx[0] - 1, blocklocy[0] - 1] == 1)
                        {

                        }
                        else if (blocklocy[3] != 0 && board[blocklocx[3], blocklocy[3] - 1] == 1)
                        {

                        }
                        else if (blocklocy[2] != 0 && board[blocklocx[2], blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (blocklocy[1] != 0 && board[blocklocx[1], blocklocy[1] - 1] == 1)
                        {

                        }
                        else if (blocklocy[3] != 0 && board[blocklocx[0], blocklocy[0] - 1] == 1 && blocklocy[0] != 0)
                        {

                        }




                        else if (blocklocy[3] != 0 && board[blocklocx[3] + 1, blocklocy[3] - 1] == 1)
                        {

                        }
                        else if (blocklocy[2] != 0 && board[blocklocx[2] - 1, blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[1] - 1, blocklocy[1] - 1] == 1 && blocklocy[1] != 0)
                        {

                        }
                        else if (blocklocy[0] != 0 && board[blocklocx[0] + 1, blocklocy[0] - 1] == 1)
                        {

                        }
                        else if (blocklocy[3] != 0 && board[blocklocx[3], blocklocy[3] - 1] == 1)
                        {

                        }
                        else if (blocklocy[2] != 0 && board[blocklocx[2], blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (blocklocy[1] != 0 && board[blocklocx[1], blocklocy[1] - 1] == 1)
                        {

                        }
                        else if (blocklocy[0] != 0 && blocklocy[3] != 0 && board[blocklocx[0], blocklocy[0] - 1] == 1)
                        {

                        }


                        else
                        {

                            if (blocklocy[0] == 0)
                            {
                                for (int i = 0; i < 4; i++)
                                {

                                    board[blocklocx[1], blocklocy[1]] = 0;
                                    board[blocklocx[2], blocklocy[2]] = 0;
                                    board[blocklocx[3], blocklocy[3]] = 0;
                                    board[blocklocx[0], blocklocy[0]] = 0;
                                    blocklocy[i]++;
                                    board[blocklocx[0], blocklocy[0]] = 2;
                                    board[blocklocx[1], blocklocy[1]] = 2;
                                    board[blocklocx[2], blocklocy[2]] = 2;
                                    board[blocklocx[3], blocklocy[3]] = 2;

                                }

                            }
                            else if (blocklocy[3] == 9 || blocklocy[2] == 9 || blocklocy[1] == 9 || blocklocy[0] == 9)
                            {
                                deleteem();
                                if (board[blocklocx[3], blocklocy[3] - 1] == 1 || board[blocklocx[2], blocklocy[2] - 1] == 1 || board[blocklocx[1], blocklocy[1] - 1] == 1 || board[blocklocx[0], blocklocy[0] - 1] == 1)
                                {



                                }
                                else
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        blocklocy[i]--;
                                    }


                                }
                                redraweem();
                            }
                            //aqua/[0] 
                            //brown= [3]
                            //red = [2]
                            //pink is [1] is fulcrum
                            board[blocklocx[1], blocklocy[1]] = 0;
                            board[blocklocx[2], blocklocy[2]] = 0;
                            board[blocklocx[3], blocklocy[3]] = 0;
                            board[blocklocx[0], blocklocy[0]] = 0;
                            //<code here for switch>
                            blocklocy[0] = blocklocy[1] - 1;
                            blocklocx[0] = blocklocx[1];
                            blocklocx[2] = blocklocx[1] + 1;
                            blocklocy[2] = blocklocy[1] + 1;
                            blocklocy[3] = blocklocy[1];

                            //</code here for switch>
                            board[blocklocx[0], blocklocy[0]] = 2;
                            board[blocklocx[1], blocklocy[1]] = 2;
                            board[blocklocx[2], blocklocy[2]] = 2;
                            board[blocklocx[3], blocklocy[3]] = 2;
                            mode = 0;
                        }

                    }

                }
            }
        }
        void rotateoooL()
        {
            if (a == 4)
            {
                if (kbs.IsKeyDown(Keys.Up) && !prevKeyPress.IsKeyDown(Keys.Up))
                {
                    //red is [0]
                    //orange is [1] fulcrum
                    //yelow is [2];
                    //green is [3]
                  //  Console.WriteLine(mode);
                    if (blocklocy[1] == 0)
                    {
                        if (board[blocklocx[0], blocklocy[0] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[1], blocklocy[1] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[2], blocklocy[2] + 1] == 1)
                        {

                        }
                        else if (board[blocklocx[3], blocklocy[3] + 1] == 1)
                        {

                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                blocklocy[i]++;
                            }
                        }
                    }
                    if (blocklocy[1] == 9)
                    {
                        if (board[blocklocx[0], blocklocy[0] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[1], blocklocy[1] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[2], blocklocy[2] - 1] == 1)
                        {

                        }
                        else if (board[blocklocx[3], blocklocy[3] - 1] == 1)
                        {

                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                blocklocy[i]--;
                            }
                        }
                    }
                    if (blocklocy[1] == 0)
                    {

                    }

                    else if (blocklocy[1] == 9)
                    {

                    }
                    else if (mode == 0) //across, down at right end --L
                    {
                        if (blocklocx[1] == 19)
                        {
         

                        }
                        else
                        {
                            deleteem();
                            blocklocy[0] = blocklocy[1];
                            blocklocx[0] = blocklocx[1] - 1;
                            blocklocy[2] = blocklocy[1];
                            blocklocx[2] = blocklocx[1] + 1;
                            blocklocy[3] = blocklocy[1] - 1;
                            blocklocx[3] = blocklocx[1] + 1;
                            redraweem();
                            mode = 1;
                        }

                    }
                    else if (mode == 1)//J
                    {

                        if (board[blocklocx[1], blocklocy[1] - 1] != 1)
                        {
                            deleteem();
                           
                            blocklocy[0] = blocklocy[1] - 1;
                            blocklocx[0] = blocklocx[1];
                            blocklocy[2] = blocklocy[1] + 1;
                            blocklocx[2] = blocklocx[1];
                            blocklocy[3] = blocklocy[1] + 1;
                            blocklocx[3] = blocklocx[1] + 1;
                            redraweem();
                            mode = 2;
                        }
                        else
                        {
                            mode--;
                        }
                    }
                    else if (mode == 2)//L---
                    {
                        
                        deleteem();
                        blocklocy[0] = blocklocy[1];
                        blocklocx[0] = blocklocx[1] + 1;
                        blocklocy[2] = blocklocy[1];
                        blocklocx[2] = blocklocx[1] - 1;
                        blocklocy[3] = blocklocy[1] + 1;
                        blocklocx[3] = blocklocx[1] - 1;
                        redraweem();
                        mode = 3;
                    }
                    else if (mode == 3)//Up 3 right 1 at top (upside down L)
                    {
                        deleteem();

                        blocklocy[0] = blocklocy[1] + 1;
                        blocklocx[0] = blocklocx[1];
                        blocklocy[2] = blocklocy[1] - 1;
                        blocklocx[2] = blocklocx[1];
                        blocklocy[3] = blocklocy[1] - 1;
                        blocklocx[3] = blocklocx[1] - 1;
                        mode = 0;

                        redraweem();

                    }
                }
            }
        }
        void rotateLooo()
        {
            if (kbs.IsKeyDown(Keys.Up) && !prevKeyPress.IsKeyDown(Keys.Up))
            {
                if (blocklocy[2] == 9)
                {
                    blocklocy[0]--;
                    blocklocy[1]--;
                    blocklocy[2]--;
                    blocklocy[3]--;
                }
                else if (blocklocy[2] == 0)
                {
                    blocklocy[0]++;
                    blocklocy[1]++;
                    blocklocy[2]++;
                    blocklocy[3]++;
                }
                if (mode == 0)
                {
                    deleteem();
                    blocklocy[0] = blocklocy[2];
                    blocklocx[0] = blocklocx[2] - 1;
                    blocklocy[1] = blocklocy[2] - 1;
                    blocklocx[1] = blocklocx[2] - 1;
                    blocklocy[3] = blocklocy[2];
                    blocklocx[3] = blocklocx[2] + 1;
                    redraweem();
                    mode = 1;
                }
                else if (mode == 1)
                {
                    deleteem();
                    blocklocy[0] = blocklocy[2] + 1;
                    blocklocx[0] = blocklocx[2];
                    blocklocy[1] = blocklocy[2] + 1;
                    blocklocx[1] = blocklocx[2] - 1;
                    blocklocy[3] = blocklocy[2] - 1;
                    blocklocx[3] = blocklocx[2];
                    redraweem();
                    mode = 2;
                    
                }
                else if (mode == 2)
                {
                    if (blocklocx[2] == 19)
                    {
                       
                    }
                    else
                    {
                        deleteem();
                        blocklocy[0] = blocklocy[2];
                        blocklocx[0] = blocklocx[2] + 1;
                        blocklocy[1] = blocklocy[2] + 1;
                        blocklocx[1] = blocklocx[2] + 1;
                        blocklocy[3] = blocklocy[2];
                        blocklocx[3] = blocklocx[2] - 1;
                        redraweem();
                  
                        mode = 3;
                    }
                }
                else if (mode == 3)
                {
                    deleteem();
                    blocklocy[0] = blocklocy[2] - 1;
                    blocklocx[0] = blocklocx[2];
                    blocklocy[1] = blocklocy[2] - 1;
                    blocklocx[1] = blocklocx[2] + 1;
                    blocklocy[3] = blocklocy[2] + 1;
                    blocklocx[3] = blocklocx[2];
                    redraweem();
                    mode = 0;
                }
              //  Console.WriteLine(mode);
            }
        }
        void rotatePyramid()
        {
            if (kbs.IsKeyDown(Keys.Up) && !prevKeyPress.IsKeyDown(Keys.Up))
            {
                if (blocklocy[1] == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        blocklocy[i]++;
                    }
                }
                if (blocklocy[1] == 9)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        blocklocy[i]--;
                    }
                }
                if (mode == 0)
                {
                    deleteem();
                    blocklocy[0] = blocklocy[1];
                    blocklocx[0] = blocklocx[1] - 1;
                    blocklocy[2] = blocklocy[1] - 1;
                    blocklocx[2] = blocklocx[1];
                    blocklocy[3] = blocklocy[1];
                    blocklocx[3] = blocklocx[1] + 1;
                    redraweem();
                    mode = 1;
                }
                else if (mode == 1)
                {
                    deleteem();
                    blocklocy[0] = blocklocy[1] + 1;
                    blocklocx[0] = blocklocx[1];
                    blocklocy[2] = blocklocy[1];
                    blocklocx[2] = blocklocx[1] - 1;
                    blocklocy[3] = blocklocy[1] - 1;
                    blocklocx[3] = blocklocx[1];
                    redraweem();
                    mode = 2;
                }
                else if (mode == 2)
                {
                    deleteem();
                    if (blocklocx[1] == 19)
                    {
                        //Console.WriteLine("HI");
                    }
                    else
                    {


                        blocklocy[0] = blocklocy[1];
                        blocklocx[0] = blocklocx[1] + 1;
                        blocklocy[2] = blocklocy[1] + 1;
                        blocklocx[2] = blocklocx[1];
                        blocklocy[3] = blocklocy[1];
                        blocklocx[3] = blocklocx[1] - 1;
                        redraweem();
                        mode = 3;
                    }
                 
                }
                else if (mode == 3)
                {
                    deleteem();
                    blocklocy[0] = blocklocy[1] - 1;
                    blocklocx[0] = blocklocx[1];
                    blocklocy[2] = blocklocy[1];
                    blocklocx[2] = blocklocx[1] + 1;
                    blocklocy[3] = blocklocy[1] + 1;
                    blocklocx[3] = blocklocx[1];
                    redraweem();
                    mode = 0;
                   
                }
            }
        }
        void checkrows()
        {

            int startat = 19;
            if (moving == false)
            {
                int count = 0;
                for (int j = 0; j < 20; j++)
                {
                    bool nextphase = true;
                    for (int i = 0; i < 10; i++)
                    {
                        if (board[j, i] != 1 && board[j, i] != 2 && board[j, i] != 5)
                        {

                            nextphase = false;
                        }
                        if (i == 9)
                        {

                            if (nextphase == true)
                            {
                                counttilldestroy++;

                                count++;




                                for (int k = 0; k < 10; k++)
                                {
                                    startat++;
                                    board[j, k] = 5;
                                    startat = j;





                                }

                                for (int m = startat; m >= 1; m--)
                                {
                                    for (int n = 9; n >= 0; n--)
                                    {
                                        bc[m, n] = bc[m - 1, n];
                                        board[m, n] = board[m - 1, n];
                                        fboard[m, n] = fboard[m - 1, n];
                                        skiprest = true;

                                    }

                                }



                            }
                        }

                    }

                }
                if (count == 1)
                {
                    gscore += 100;
                }
                else if (count == 2)
                {
                    gscore += 200;
                }
                else if (count == 3)
                {
                    gscore += 400;
                }
                else if (count == 4)
                {
                    gscore += 800;

                }
            }

        }
        void pushdown()
        {
            kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Down) && moving)
            {
                speed = 10;
                done = true;
                puuuuuush = true;
            }
            else
            {
                puuuuuush = false;
                done = false;
                speed = prevspeed;
            }
        }
        void deleteboard()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = 0;
                    fboard[i, j] = 99;
                }
            }
        }
        void checkscore()
        {
            //level = gscore/1000
            if (gscore / 1000 > level)
            {
                level = gscore / 1000;
            }

            if (puuuuuush == false)
            {
                speed = ((11 - (level + 1)) * 50);
                if (speed <= 0)
                {
                    speed = 10;
                }
            }
            if (level == 0)
            {
                c0 = Color.LightSalmon;
                c1 = Color.Red;
                c2 = Color.Salmon;
                c3 = Color.Crimson;
                c4 = Color.DarkRed;
                c5 = Color.Firebrick;
                c6 = Color.LightCoral;
            }
            else if (level == 1)
            {
                c0 = Color.Orange;
                c1 = Color.DarkOrange;
                c2 = Color.OrangeRed;
                c3 = new Color(255, 153, 0);
                c4 = new Color(255, 102, 51);
                c5 = new Color(255, 51, 0);
                c6 = new Color(255, 204, 51);
            }
            else if (level == 2)
            {
                c0 = Color.Yellow;
                c1 = Color.Gold;
                c2 = Color.Goldenrod;
                c3 = new Color(150, 150, 0);
                c4 = Color.Moccasin;
                c5 = new Color(200, 200, 0);
                c6 = Color.LemonChiffon;
            }
            else if (level == 3)
            {
                c0 = Color.GreenYellow;
                c1 = Color.Green;
                c2 = Color.Lime;
                c3 = Color.ForestGreen;
                c4 = Color.SeaGreen;
                c5 = Color.SpringGreen;
                c6 = Color.LightGreen;
            }
            else if (level == 4)
            {
                c0 = Color.DarkCyan;
                c1 = Color.MidnightBlue;
                c2 = Color.DodgerBlue;
                c3 = Color.Cyan;
                c4 = Color.Blue;
                c5 = Color.DarkTurquoise;
                c6 = Color.DeepSkyBlue;
            }
            else if (level == 5)
            {
                c0 = Color.Orchid;
                c1 = Color.SlateBlue;
                c2 = Color.BlueViolet;
                c3 = Color.Indigo;
                c4 = Color.Violet;
                c5 = Color.Purple;
                c6 = Color.Magenta;
            }
            else if (level == 6)
            {
                c0 = Color.Red;
                c1 = Color.OrangeRed;
                c2 = Color.Yellow;
                c3 = Color.Orange;
                c4 = Color.DeepPink;
                c5 = Color.Gold;
                c6 = Color.Coral;
            }
            else if (level == 7)
            {
                c0 = Color.Teal;
                c1 = Color.Purple;
                c2 = Color.Blue;
                c3 = Color.Indigo;
                c4 = Color.DodgerBlue;
                c5 = Color.DarkOrchid;
                c6 = Color.LightSeaGreen;
            }
            else if (level == 8)
            {
                c0 = Color.LightGray;
                c1 = Color.Gray;
                c2 = Color.DarkGray;
                c3 = Color.White;
                c4 = Color.Silver;
                c5 = Color.White;
                c6 = Color.LightSlateGray;
            }
            else if (level >= 9)
            {
                c0 = Color.Red;
                c1 = Color.Purple;
                c2 = Color.OrangeRed;
                c3 = Color.Yellow;
                c4 = Color.Lime;
                c5 = Color.Aqua;
                c6 = Color.Blue;
                //grays
            }
            else
            {
                //raibnow
                c0 = Color.Red;
                c1 = Color.DeepPink;
                c2 = Color.OrangeRed;
                c3 = Color.Yellow;
                c4 = Color.Lime;
                c5 = Color.Aqua;
                c6 = Color.Blue;
            }
            //Console.WriteLine(gscore);
            //Console.WriteLine(speed);
        }
        void screenshot()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    prevBoard[i, j] = board[i, j];


                }
            }
            for (int i = 0; i < 4; i++)
            {
                prevblocklocx[i] = blocklocx[i];
                prevblocklocy[i] = blocklocy[i];
            }
        }
        void inversescreenshot()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = prevBoard[i, j];


                }
            }

            for (int i = 0; i < 4; i++)
            {
                blocklocx[i] = prevblocklocx[i] + 1;
                blocklocy[i] = prevblocklocy[i];
            }

            //deleteem();
            //redraweem();
        }
        bool compareBoard()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == 2 && prevBoard[i, j] == 1)
                    {

                       Console.WriteLine("Shpoopster");
                        return true;
                    }

                }
            }

            return false;
        }
        void increasespeed()
        {
            if (gscore % 1000 == 0)
            {
                if (speed > 100)
                {
                    speed -= 100;
                }
                else if (speed > 10)
                {
                    speed -= 10;
                }
                else
                {
                    speed -= 1;
                }
            }
        }
        void endgame()
        {
            deleteboard();
            deleteem();

            weredonehereok = true;
            moving = false;
        }
        void drawwithflicker()
        {
            vontaleach++;
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(100.0f, 100.0f), Color.Yellow);
            //spriteBatch.DrawString(spriteFont, "Press Spacebar to End", new Vector2(100.0f, 200.0f), Color.Yellow);
            spriteBatch.End();
            spriteBatch.Begin();
            board[0, 0] = 0;
            deleteem();
            Color neongreen = new Color(0, 255, 0);
            timerlike++;
            redraweem();
            board[0, 0] = 0;
            Color gray = new Color(105, 105, 105);

            for (int i = 0; i < 20; i++)
            {
                Vector2 ricardo = new Vector2(0.0f, i * 21.0f);
                //ricardo.Y++;
                //ricardo.X++;
                spriteBatch.Draw(Block, ricardo, gray);
            }
            for (int i = 0; i < 20; i++)
            {
                Vector2 ricardo = new Vector2(231.0f, i * 21.0f);
                //ricardo.Y++;
                //ricardo.X++;
                spriteBatch.Draw(Block, ricardo, gray);

                //420
            }
            for (int i = 0; i < 12; i++)
            {
                Vector2 ricardo = new Vector2(21.0f * i, 420.0f);
                //ricardo.Y++;
                //ricardo.X++;
                spriteBatch.Draw(Block, ricardo, gray);
            }


            for (int i = 0; i < 20; i++)
            {

                for (int j = 0; j < 10; j++)
                {

                    //if (timerlike % 50 == 0)
                    //{
                    if (timerlike % 10 != 0)
                    {

                        color = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                        //}

                    }


                    //Console.WriteLine("SHPOOP the wanker");
                    if (timerlike % 4 == 0)
                    {
                        colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                    }
                    if (board[i, j] == 2)
                    {

                        if (i == blocklocx[0] && j == blocklocy[0])
                        {
                            colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);

                        }
                        else if (i == blocklocx[1] && j == blocklocy[1])
                        {
                            colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);
                        }
                        else if (i == blocklocx[2] && j == blocklocy[2])
                        {
                            colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            //ricardo.Y--;
                            ricardo.X += 21;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);
                        }
                        else if (i == blocklocx[3] && j == blocklocy[3])
                        {
                            colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);
                        }
                        else
                        {
                            colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, Color.Black);

                        }

                    }


                    else if (board[i, j] == 1)
                    {
                        colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                        Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                        ricardo.X += 21;
                        //ricardo.Y++;
                        spriteBatch.Draw(Block, ricardo, colorusumbridge);
                    }
                    else if (board[i, j] == 5)
                    {
                        Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                        ricardo.X += 21;
                        spriteBatch.Draw(Block, ricardo, Color.Red);
                    }
                    else
                    {

                        Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                        ricardo.X += 21;
                        spriteBatch.Draw(Block, ricardo, Color.Black);
                    }

                }
            }
            //Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
            //                    ricardo.X += 21;
            //                   //ricardo.Y--;
            //                    spriteBatch.Draw(Block, ricardo, colorarray[i,j]);




            Vector2 Scoobydoo = new Vector2(260.0f, 10.0f);
            spriteBatch.DrawString(spriteFont, "Score:", Scoobydoo, neongreen);
            Scoobydoo.X += 65;
            spriteBatch.DrawString(spriteFont, gscore.ToString(), Scoobydoo, neongreen);
            Scoobydoo.X -= 65;
            Scoobydoo.Y += 20;
            spriteBatch.DrawString(spriteFont, "Level:", Scoobydoo, neongreen);
            Scoobydoo.X += 65;
            spriteBatch.DrawString(spriteFont, level.ToString(), Scoobydoo, neongreen);
            redraw = false;
            Scoobydoo.Y += 20;
            Scoobydoo.X -= 65;
            spriteBatch.DrawString(spriteFont, "Next Up:", Scoobydoo, neongreen);

            //color = new Color(rn.Next(0, 255), rn.Next(0, 255), rn.Next(0, 255));
            //}


            int lbound = 150;
            int upbound = 255;
            if (pa == 0)
            {

                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0)); ;
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0)); ;
                ricardo.X -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0)); ;
                //Console.WriteLine("SHPOOOOOOOO");
            }
            if (pa == 1)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                ricardo.X -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 2)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 3)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 4)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 5)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 6)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                ricardo.Y -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            for (int i = 0; i < 5; i++)
            {
                spriteBatch.DrawString(spriteFont, names[i], new Vector2(400.0f, 10 + i * 30.0f), new Color(0, 255, 0));
                spriteBatch.DrawString(spriteFont, scores[i].ToString(), new Vector2(525.0f, 10 + i * 30.0f), new Color(0, 255, 0));
                //spriteBatch.DrawString(spriteFont, ((menu)menu1).scores[i].ToString(), new Vector2(525.0f, 90 + i * 30.0f), Color.BlueViolet);
            }
            spriteBatch.Draw(Tlogo, new Rectangle(275, 170, 300, 250), Color.White);
            spriteBatch.End();


        }
        void drawwithoutflicker()
        {

            vontaleach++;
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            spriteBatch.End();
            spriteBatch.Begin();
            board[0, 0] = 0;
            deleteem();
            Color neongreen = new Color(0, 255, 0);
            timerlike++;
            redraweem();
            board[0, 0] = 0;
            Color gray = new Color(105, 105, 105);

            for (int i = 0; i < 20; i++)
            {
                Vector2 ricardo = new Vector2(0.0f, i * 21.0f);
                //ricardo.Y++;
                //ricardo.X++;
                spriteBatch.Draw(Block, ricardo, gray);
            }
            for (int i = 0; i < 20; i++)
            {
                Vector2 ricardo = new Vector2(231.0f, i * 21.0f);
                //ricardo.Y++;
                //ricardo.X++;
                spriteBatch.Draw(Block, ricardo, gray);

                //420
            }
            for (int i = 0; i < 12; i++)
            {
                Vector2 ricardo = new Vector2(21.0f * i, 420.0f);
                //ricardo.Y++;
                //ricardo.X++;
                spriteBatch.Draw(Block, ricardo, gray);
            }


            for (int i = 0; i < 20; i++)
            {

                for (int j = 0; j < 10; j++)
                {

                    //if (timerlike % 50 == 0)
                    //{
                    if (timerlike % 10 != 0)
                    {

                        color = new Color(0, 255, 0);
                        //}

                    }


                    if (a == 0)
                    {
                        colorusumbridge = c0;
                    }
                    else if (a == 1)
                    {
                        colorusumbridge = c1;
                    }
                    else if (a == 2)
                    {
                        colorusumbridge = c2;
                    }
                    else if (a == 3)
                    {
                        colorusumbridge = c3;
                    }
                    else if (a == 4)
                    {
                        colorusumbridge = c4;
                    }
                    else if (a == 5)
                    {
                        colorusumbridge = c5;
                    }
                    else if (a == 6)
                    {
                        colorusumbridge = c6;
                    }
                    if (board[i, j] == 2)
                    {

                        if (i == blocklocx[0] && j == blocklocy[0])
                        {
                            //  colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;

                            spriteBatch.Draw(Block, ricardo, colorusumbridge);

                        }
                        else if (i == blocklocx[1] && j == blocklocy[1])
                        {
                            // colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);
                        }
                        else if (i == blocklocx[2] && j == blocklocy[2])
                        {
                            // colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            //ricardo.Y--;
                            ricardo.X += 21;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);
                        }
                        else if (i == blocklocx[3] && j == blocklocy[3])
                        {
                            // colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, colorusumbridge);
                        }
                        else
                        {
                            //colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                            Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                            ricardo.X += 21;
                            //ricardo.Y--;
                            spriteBatch.Draw(Block, ricardo, Color.Black);

                        }

                    }


                    else if (board[i, j] == 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (fboard[i, j] == 0)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c0;
                            }
                            else if (fboard[i, j] == 1)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c1;
                            }
                            else if (fboard[i, j] == 2)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c2;
                            }
                            else if (fboard[i, j] == 3)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c3;
                            }
                            else if (fboard[i, j] == 4)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c4;
                            }
                            else if (fboard[i, j] == 5)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c5;

                            }
                            else if (fboard[i, j] == 6)
                            {
                                bc[blocklocx[k], blocklocy[k]] = c6;
                            }
                            //keep these comments for the alternative if colors dont work!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            //if (a == 0)
                            //{
                            //    bc[blocklocx[k], blocklocy[k]] = c0;
                            //    fboard[blocklocx[k], blocklocy[k]] = 0;
                            //}
                            //else if (a == 1)
                            //{
                            //    bc[blocklocx[k], blocklocy[k]] = c1;
                            //    fboard[blocklocx[k], blocklocy[k]] = 1;
                            //    //colorusumbridge = new Color(0, 255, 0);
                            //}
                            //else if (a == 2)
                            //{
                            //    bc[blocklocx[k], blocklocy[k]] = c2;
                            //    fboard[blocklocx[k], blocklocy[k]] = 2;
                            //    //colorusumbridge = new Color(0, 0, 255);
                            //}
                            //else if (a == 3)
                            //{
                            //    bc[blocklocx[k], blocklocy[k]] = c3; 
                            //    fboard[blocklocx[k], blocklocy[k]] = 3;
                            //    //colorusumbridge = new Color(255, 255, 0);
                            //}
                            //else if (a == 4)
                            //{
                            //    bc[blocklocx[k], blocklocy[k]] = c4;
                            //    fboard[blocklocx[k], blocklocy[k]] = 4;
                            //    //colorusumbridge = new Color(255, 0, 255);
                            //}
                            //else if (a == 5)
                            //{
                            //    bc[blocklocx[k], blocklocy[k]] = c5;
                            //    fboard[blocklocx[k], blocklocy[k]] = 5;
                            //    //colorusumbridge = new Color(0, 255, 255);
                            //}
                            //else if (a == 6)
                            //{
                            //    //Console.WriteLine("a");
                            //    bc[blocklocx[k], blocklocy[k]] = c6;
                            //    fboard[blocklocx[k], blocklocy[k]] = 6;
                            //    //Console.WriteLine(a);
                            //    //colorusumbridge = new Color(100, 100, 100);
                            //}
                        }
                        //  colorusumbridge = new Color(rn.Next(150, 255), rn.Next(150, 255), rn.Next(150, 255));
                        Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                        ricardo.X += 21;
                        //ricardo.Y++;
                        spriteBatch.Draw(Block, ricardo, bc[i, j]);
                    }
                    else if (board[i, j] == 5)
                    {
                        Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                        ricardo.X += 21;
                        spriteBatch.Draw(Block, ricardo, Color.Red);
                    }
                    else
                    {

                        Vector2 ricardo = new Vector2(j * 21.0f, i * 21.0f);
                        ricardo.X += 21;
                        spriteBatch.Draw(Block, ricardo, Color.Black);
                    }

                }
            }



            Vector2 Scoobydoo = new Vector2(260.0f, 10.0f);
            spriteBatch.DrawString(spriteFont, "Score:", Scoobydoo, neongreen);
            Scoobydoo.X += 65;
            spriteBatch.DrawString(spriteFont, gscore.ToString(), Scoobydoo, neongreen);
            Scoobydoo.X -= 65;
            Scoobydoo.Y += 20;
            spriteBatch.DrawString(spriteFont, "Level:", Scoobydoo, neongreen);
            Scoobydoo.X += 65;
            spriteBatch.DrawString(spriteFont, level.ToString(), Scoobydoo, neongreen);
            redraw = false;
            Scoobydoo.Y += 20;
            Scoobydoo.X -= 65;
            spriteBatch.DrawString(spriteFont, "Next Up:", Scoobydoo, neongreen);

            //color = new Color(rn.Next(0, 255), rn.Next(0, 255), rn.Next(0, 255));
            //}



            if (pa == 0)
            {

                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0)); ;
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0)); ;
                ricardo.X -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0)); ;
            }
            if (pa == 1)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                ricardo.X -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 2)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 3)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 4)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 5)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            if (pa == 6)
            {
                Vector2 ricardo = new Vector2(260.0f, 80.0f);
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.Y += 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
                ricardo.X += 21;
                ricardo.Y -= 21;
                spriteBatch.Draw(Block, ricardo, new Color(0, 255, 0));
            }
            for (int i = 0; i < 5; i++)
            {
                spriteBatch.DrawString(spriteFont, names[i], new Vector2(400.0f, 10 + i * 30.0f), new Color(0, 255, 0));
                spriteBatch.DrawString(spriteFont, scores[i].ToString(), new Vector2(525.0f, 10 + i * 30.0f), new Color(0, 255, 0));
                //spriteBatch.DrawString(spriteFont, ((menu)menu1).scores[i].ToString(), new Vector2(525.0f, 90 + i * 30.0f), Color.BlueViolet);
            }
            spriteBatch.Draw(Tlogo, new Rectangle(275, 170, 300, 250), Color.White);
            spriteBatch.End();

        }
        protected override void Update(GameTime gameTime)
        {
            //propper version!
            this.graphics.PreferredBackBufferHeight = 440;
            this.graphics.PreferredBackBufferWidth = 700;

            //4, 3

            if (stage == 1)
            {
                //prevBoard = board;
             
                
                    if (board[2, 5] == 1 || board[2, 4] == 1 || board[2, 3] == 1 || board[2, 6] == 1)
                    {
                        endgame();
                    }
                    movespeed++;
                    if (loaded == false)
                    {

                        pa = rn.Next(0, 7);
                        MediaPlayer.IsMuted = false;
                        try
                        {
                            MediaPlayer.Play(selectedsong);
                        }
                        catch
                        {
                            MediaPlayer.Play(Korobeiniki);
                        }
                        deleteboard();
                        deleteem();
                        loaded = true;

                        mode = 0;
                        speed = 1000;
                        gscore = 0;
                        weredonehereok = false;


                        skiprest = false;
                        moving = false;
                        redraw = false;
                        done = false;
                        timerlike = 0;

                        for (int kk = 0; kk < 4; kk++)
                        {
                            blocklocx[kk] = 0;
                            blocklocy[kk] = 0;
                            prevblocklocx[kk] = 0;
                            prevblocklocy[kk] = 0;
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                board[i, j] = 0;
                                prevBoard[i, j] = 0;
                                staticbricks[i, j] = 0;
                                deleteem();
                                deleteboard();

                                gscore = 0;
                            }
                        }
                    }
                    if (weredonehereok == true)
                    {
                        weredonehereok = false;
                        loaded = false;
                        score = gscore;
                        gscore = 0;
                        //score = 110066;
                        stage = 2;
                        MediaPlayer.IsMuted = true;
                        MediaPlayer.Stop();
                        deleteboard();
                        deleteem();
                        hs = new highScore(this);
                        deleteboard();
                        deleteem();
                        Components.Add(hs);

                    }
                    // increasespeed();
                    // pscore = gscore;

                    if (done == false)
                    {
                        prevspeed = speed;
                    }

                    //for (int ab = 0; ab < 4; ab++)
                    //{
                    //    colorarray[blocklocx[ab], blocklocy[ab]] = Color.Black;
                    //}

                    pushdown();
                    countstatic();
                    movebricks();
                    checkscore();

                    // checkifhit();

                    if (Timer(gameTime, speed+ 100))
                    {

                        redraw = true;


                        //Console.WriteLine(gameTime);
                        if (skiprest == false)
                        {

                            screenshot();
                            if (moving)
                            {

                                if (checkifhit(false) == true)
                                {
                                    moving = false;
                                };
                            }
                            //prevboard = board;

                            //score++;
                            prevKeyPress = kbs;
                            kbs = Keyboard.GetState();
                            if (!moving)
                            {

                                board[blocklocx[0], blocklocy[0]] = 1;
                                board[blocklocx[1], blocklocy[1]] = 1;
                                board[blocklocx[2], blocklocy[2]] = 1;
                                board[blocklocx[3], blocklocy[3]] = 1;
                                checkrows();
                                SpawnBricks();
                            }


                            board[blocklocx[0], blocklocy[0]] = 2;
                            board[blocklocx[1], blocklocy[1]] = 2;
                            board[blocklocx[2], blocklocy[2]] = 2;
                            board[blocklocx[3], blocklocy[3]] = 2;



                        }

                    }
                    //staticbricks blocklocx,blocklocy
                    for (int i = 0; i < 4; i++)
                    {
                        if (staticbricks[blocklocx[i], blocklocy[i]] == 1)
                        {
                            inversescreenshot();
                        }
                    }
                    // if (moving) { checkifhit(); }
                }

                skiprest = false;
                //if (blocklocx[0] == 19 || blocklocx[3] == 19 || blocklocx[1] == 19 | blocklocx[2] == 19)
                //{
                //    Update(gameTime);
                //}
                //switch (a)
                //{
                //    //case 0:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.Yellow;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.Yellow;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.Yellow;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.Yellow;
                //    //    break;
                //    //case 1:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.Green;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.Green;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.Green;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.Green;
                //    //    break;
                //    //case 2:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.Red;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.Red;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.Red;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.Red;
                //    //    break;
                //    //case 3:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.Cyan;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.Cyan;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.Cyan;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.Cyan;
                //    //    break;
                //    //case 4:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.DarkBlue;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.DarkBlue;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.DarkBlue;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.DarkBlue;
                //    //    break;
                //    //case 5:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.Orange;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.Orange;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.Orange;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.Orange;
                //    //    break;
                //    //case 6:
                //    //    colorarray[blocklocx[0], blocklocy[0]] = Color.Purple;
                //    //    colorarray[blocklocx[1], blocklocy[1]] = Color.Purple;
                //    //    colorarray[blocklocx[2], blocklocy[2]] = Color.Purple;
                //    //    colorarray[blocklocx[3], blocklocy[3]] = Color.Purple;
                //    //    break;

                //}
                //if (compareBoard())
                //{

                //}
                base.Update(gameTime);
           
        }
        Color colorusumbridge = new Color(0, 255, 0);
        protected override void Draw(GameTime gameTime)
        {
            //if (isflickering == true)
            //{
            //    drawwithflicker();
            //    base.Draw(gameTime);
            //}
            //else
            //{

            try
            {
                drawwithoutflicker();
            }
            catch
            {
                board = prevBoard;
            }
         
            //for (int i = 0; i < 20; i++) //attempt at tracking the Pyramid
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (j == blocklocx[1] && i == blocklocy[1])
            //        {
            //            {
            //                spriteBatch.Draw(Block, new Vector2(i * 21, j * 21), Color.White);
            //            }
            //        }
            //    }
            //}
                
                base.Draw(gameTime);
                //}
            }
        }
    }

