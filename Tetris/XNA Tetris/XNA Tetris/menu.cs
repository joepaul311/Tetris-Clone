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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class menu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        int pauseTime = 0;
        SpriteFont tiny;
        //HIGH SCORE STUFF
        HighScoreData hsInfo;
       public string[] names;
       public int[] scores;
        string highScoreName;
        Texture2D TetrisImage;
        KeyboardState kbs;
        KeyboardState prevKeyPress;
        Game mainGame;

        public menu(Game game)
            : base(game)
        {
            mainGame = game;
            pauseTime = 0;
           
            
            //HIGH SCORE STUFF
            names = new string[5];
            scores = new int[5];
            //  scoresStr = new string[5];
            hsInfo = new HighScoreData("XNA Tetris");  //put your game name here
            names = hsInfo.getNames();
            scores = hsInfo.getScores();
            highScoreName = "";


            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Game.Content.Load<SpriteFont>("SpriteFont1");
            TetrisImage = Game.Content.Load<Texture2D>("Tetris");
            tiny = Game.Content.Load<SpriteFont>("SpriteFont5");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected override void UnloadContent()
        {
            //MediaPlayer.Stop();
        }
        public override void Update(GameTime gameTime)
        {
            pauseTime++;
            // TODO: Add your update code here
            prevKeyPress = kbs;
            kbs = Keyboard.GetState();
            for (int i = 0; i < 5; i++)
            {
                ((Game1)Game).names[i] = names[i];
                ((Game1)Game).scores[i] = scores[i];

                //spriteBatch.DrawString(spriteFont, names[i], new Vector2(380.0f, 90 + i * 30.0f), Color.BlueViolet);
                //spriteBatch.DrawString(spriteFont, scores[i].ToString(), new Vector2(525.0f, 90 + i * 30.0f), Color.BlueViolet);
            }
            if (((Game1)mainGame).stage == 0)// && pauseTime > 100)
            {

                if (kbs.IsKeyDown(Keys.A))
                {
                    Console.WriteLine("A");
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).Korobeiniki;
                    MediaPlayer.IsMuted = false;
                    MediaPlayer.Play(((Game1)mainGame).Korobeiniki);
                   
                }
                if (kbs.IsKeyDown(Keys.D)) //!NOTICE KEYS!
                {

                    MediaPlayer.IsMuted = false;
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).September;
                    MediaPlayer.Play(((Game1)mainGame).September);
                }
                if (kbs.IsKeyDown(Keys.B)) //!NOTICE KEYS
                {

                    MediaPlayer.IsMuted = false;
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).plumfairy;
                    MediaPlayer.Play(((Game1)mainGame).plumfairy);
                }
                if (kbs.IsKeyDown(Keys.G))
                {

                    MediaPlayer.IsMuted = false;
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).prayer;
                    MediaPlayer.Play(((Game1)mainGame).prayer);
                }
                if (kbs.IsKeyDown(Keys.E)) //!NOTICE KEYS
                {

                    MediaPlayer.IsMuted = false;
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).TIL;
                    MediaPlayer.Play(((Game1)mainGame).TIL);
                }
                if (kbs.IsKeyDown(Keys.F))
                {

                    MediaPlayer.IsMuted = false;
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).BONITO;
                    MediaPlayer.Play(((Game1)mainGame).BONITO);
                }
                if (kbs.IsKeyDown(Keys.C))
                {

                    MediaPlayer.IsMuted = false;
                    ((Game1)mainGame).selectedsong = ((Game1)mainGame).Zarathustra;
                    MediaPlayer.Play(((Game1)mainGame).Zarathustra);
                }
                if (kbs.IsKeyDown(Keys.NumPad0) && !prevKeyPress.IsKeyDown(Keys.NumPad0))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 0;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D0) && !prevKeyPress.IsKeyDown(Keys.D0))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 0;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad1) && !prevKeyPress.IsKeyDown(Keys.NumPad1))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 1;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D1) && !prevKeyPress.IsKeyDown(Keys.D1))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 1;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad2) && !prevKeyPress.IsKeyDown(Keys.NumPad2))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 2;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D2) && !prevKeyPress.IsKeyDown(Keys.D2))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 2;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad3) && !prevKeyPress.IsKeyDown(Keys.NumPad3))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 3;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D3) && !prevKeyPress.IsKeyDown(Keys.D3))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 3;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad4) && !prevKeyPress.IsKeyDown(Keys.NumPad4))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 4;
                    
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D4) && !prevKeyPress.IsKeyDown(Keys.D4))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 4;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad5) && !prevKeyPress.IsKeyDown(Keys.NumPad5))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 5;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D5) && !prevKeyPress.IsKeyDown(Keys.D5))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 5;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad6) && !prevKeyPress.IsKeyDown(Keys.NumPad6))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 6;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D6) && !prevKeyPress.IsKeyDown(Keys.D6))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 6;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad7) && !prevKeyPress.IsKeyDown(Keys.NumPad7))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 7;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D7) && !prevKeyPress.IsKeyDown(Keys.D7))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 7;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad8) && !prevKeyPress.IsKeyDown(Keys.NumPad8))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 8;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D8) && !prevKeyPress.IsKeyDown(Keys.D8))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 8;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.NumPad9) && !prevKeyPress.IsKeyDown(Keys.NumPad9))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 9;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                else if (kbs.IsKeyDown(Keys.D9) && !prevKeyPress.IsKeyDown(Keys.D9))
                {
                    //set level to 0
                    ((Game1)mainGame).stage = 1;
                    ((Game1)mainGame).score = 0;
                    ((Game1)mainGame).level = 9;
                    mainGame.Components.RemoveAt(0);

                    this.Dispose();
                }
                if (kbs.IsKeyDown(Keys.S) && !prevKeyPress.IsKeyDown(Keys.S))
                {
                    if (((Game1)mainGame).isflickering == true)
                    {
                        ((Game1)mainGame).isflickering = false;
                    }
                    else
                    {
                        ((Game1)mainGame).isflickering = true;
                    }
                }
                if (pauseTime > 2000) pauseTime = 0;
                
                base.Update(gameTime);
            }
                //if (kbs.IsKeyDown(Keys.NumPad0) && !prevKeyPress.IsKeyDown(Keys.NumPad0))
                //{
                //    //set level to 0
                //    ((Game1)mainGame).stage = 1;
                //    ((Game1)mainGame).score = 0;
                //    mainGame.Components.RemoveAt(0);
                    
                //    this.Dispose();
                //}
                //if (pauseTime > 2000) pauseTime = 0;
                //base.Update(gameTime);
           
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();     
            spriteBatch.DrawString(spriteFont, "PRESS 0 TO 9 TO SELECT YOUR LEVEL.", new Vector2(25.0f, 10.0f), Color.BlueViolet);

            //HIGH SCORE STUFF
            spriteBatch.DrawString(spriteFont, "HIGH SCORES:", new Vector2(380.0f, 60.0f), Color.BlueViolet);
            for (int i = 0; i < 5; i++)
            {
                spriteBatch.DrawString(spriteFont, names[i], new Vector2(380.0f, 90 + i * 30.0f), Color.BlueViolet);
                spriteBatch.DrawString(spriteFont, scores[i].ToString(), new Vector2(525.0f, 90 + i * 30.0f), Color.BlueViolet);
            }
            spriteBatch.DrawString(spriteFont, "INSTRUCTIONS:", new Vector2(380, 240), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "UP: ROTATE", new Vector2(380, 260), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "LEFT: MOVE LEFT", new Vector2(380, 280), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "RIGHT: MOVE RIGHT", new Vector2(380, 300), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "DOWN: PUSH DOWN", new Vector2(380, 320), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "CREATE FULL ROWS", new Vector2(380, 340), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "TO WIN. SPEED OF", new Vector2(380, 360), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "DESCENT GOES UP", new Vector2(380, 380), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "EVERY 1000 POINTS", new Vector2(380, 400), Color.BlueViolet);
           // spriteBatch.DrawString(spriteFont, "S TO TOGGLE FLICKERING COLORS", new Vector2(25, 415), Color.Red);
            if (((Game1)mainGame).isflickering == true)
            {
            //    spriteBatch.DrawString(spriteFont, "(ON)", new Vector2(350, 415), Color.Red);
            }
            else
            {
              //  spriteBatch.DrawString(spriteFont, "(OFF)", new Vector2(350, 415), Color.Red);
            }
            //Vector2 Victor = new Vector2(25.0f, 130.0f);
            Rectangle Ricky = new Rectangle(25, 60, 350, 250);
            spriteBatch.DrawString(spriteFont, "MUSIC:", new Vector2(25, 310), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "A - KOROBEINIKI - THEME", new Vector2(25, 330), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "B - ALT. THEME", new Vector2(25, 350), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "E - ???", new Vector2(290, 330), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "F - ???", new Vector2(290, 350), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "G - ???", new Vector2(290, 370), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "C - Zarathustra", new Vector2(25, 370), Color.BlueViolet);
            spriteBatch.DrawString(spriteFont, "D - September", new Vector2(25, 390), Color.BlueViolet);
            spriteBatch.DrawString(tiny, "By: Joe Bernstein", new Vector2(25, 415), Color.Red);
            //spriteBatch.Draw(TetrisImage, Victor,Color.White);
            spriteBatch.Draw(TetrisImage, Ricky, Color.White);
            
            spriteBatch.End();

 
            base.Draw(gameTime);
        }
    }
}