using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame_Sumative___Breakout
{
    //Christian
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        bool bounced;

        KeyboardState keyboardState;
        MouseState mouseState;

        Random generator = new Random();

        Texture2D paddleTexture;
        Texture2D ballTexture;
        Texture2D brickTexture;

        Rectangle window;
        Rectangle ballSpawn;

        Color brickColor;

        Paddle paddle;
        Ball ball;
        List<Brick> bricks;


        Screen screen;

        enum Screen
        {
            Title,
            Game,
            Win,
            Lose
        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 700;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            screen = Screen.Game;
            generator = new Random();

            bricks = new List<Brick>();
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            ballSpawn = new Rectangle(335, 350, 30, 30);

            base.Initialize();

            paddle = new Paddle(paddleTexture, new Rectangle(300, 400, 70, 10), window);
            ball = new Ball(ballTexture, ballSpawn, new Vector2(0, 0), window, ballSpawn, 5);


            for (int y = 0; y < 6; y++)
            {
                switch (y)
                {
                    case 0:
                        brickColor = Color.Red;
                        break;
                    case 1:
                        brickColor = Color.Orange;
                        break;
                    case 2:
                        brickColor = Color.Yellow;
                        break;
                    case 3:
                        brickColor = Color.Green;
                        break;
                    case 4:
                        brickColor = Color.Blue;
                        break;
                    case 5:
                        brickColor = Color.Purple;
                        break;
                }

                for (int x = 0; x < 10; x++)
                {
                    bricks.Add(new Brick(brickTexture, new Rectangle(70 * x + 1, 30 * y, 68, 30), 1, brickColor));
                }
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            ballTexture = Content.Load<Texture2D>("Images/circle");
            brickTexture = Content.Load<Texture2D>("Images/rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            if (screen == Screen.Title)
            {

            }
            else if (screen == Screen.Game)
            {
                bounced = false;
                paddle.Update(keyboardState);
                ball.Update(keyboardState, paddle);

                for (int i = 0; i < bricks.Count; i++)
                {
                    //upwards collision
                    if (ball.BallSpeedY < 0 && ball.BallRect.Top <= bricks[i].BrickRect.Bottom && ball.BallRect.Top >= bricks[i].BrickRect.Bottom + (ball.BallSpeedY - 1) && ball.BallRect.Left <= bricks[i].BrickRect.Right && ball.BallRect.Right >= bricks[i].BrickRect.Left)
                    {
                        ball.BallSpeedY *= -1;
                        ball.BallRectY += (int)ball.BallSpeedY;
                        bricks[i].BrickHealth--;

                        if (bricks[i].BrickHealth == 0)
                        {
                            bricks.RemoveAt(i);
                            i--;
                        }
                    }
                    //downwards collision
                    else if (ball.BallSpeedY > 0 && ball.BallRect.Bottom >= bricks[i].BrickRect.Top && ball.BallRect.Bottom <= bricks[i].BrickRect.Top + (ball.BallSpeedY + 1) && ball.BallRect.Left <= bricks[i].BrickRect.Right && ball.BallRect.Right >= bricks[i].BrickRect.Left)
                    {
                        ball.BallSpeedY *= -1;
                        ball.BallRectY += (int)ball.BallSpeedY;
                        bricks[i].BrickHealth--;

                        if (bricks[i].BrickHealth == 0)
                        {
                            bricks.RemoveAt(i);
                            i--;
                        }
                    }
                    //rightwards collision
                    else if (ball.BallSpeedX > 0 && ball.BallRect.Right >= bricks[i].BrickRect.Left && ball.BallRect.Right <= bricks[i].BrickRect.Left + ball.BallSpeedX && ball.BallRect.Top <= bricks[i].BrickRect.Bottom && ball.BallRect.Bottom >= bricks[i].BrickRect.Top)
                    {
                        ball.BallSpeedX *= -1;
                        ball.BallRectX += (int)ball.BallSpeedX;
                        bricks[i].BrickHealth--;

                        if (bricks[i].BrickHealth == 0)
                        {
                            bricks.RemoveAt(i);
                            i--;
                        }
                    }
                    //leftward collision
                    else if (ball.BallSpeedX < 0 && ball.BallRect.Left <= bricks[i].BrickRect.Right && ball.BallRect.Left >= bricks[i].BrickRect.Right + ball.BallSpeedX && ball.BallRect.Top <= bricks[i].BrickRect.Bottom && ball.BallRect.Bottom >= bricks[i].BrickRect.Top)
                    {
                        ball.BallSpeedX *= -1;
                        ball.BallRectX += (int)ball.BallSpeedX;
                        bricks[i].BrickHealth--;

                        if (bricks[i].BrickHealth == 0)
                        {
                            bricks.RemoveAt(i);
                            i--;
                        }
                    }
                }

                if (bricks.Count == 0)
                {
                    screen = Screen.Win;
                }

                if (ball.Lives <= 0)
                {
                    screen = Screen.Lose;
                }

                if (ball.BallSpeedMod  >= paddle.SpeedMod)
                {
                    paddle.SpeedMod = (int)ball.BallSpeedMod + 1;
                }

                if (paddle.SpeedMod - 1 > ball.BallSpeedMod)
                {
                    paddle.SpeedMod = 3;
                }

            }
            else if (screen == Screen.Win)
            {

            }
            else if (screen == Screen.Lose)
            {

            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if (screen == Screen.Title)
            {

            }
            else if (screen == Screen.Game)
            {
                paddle.Draw(_spriteBatch);
                ball.Draw(_spriteBatch);

                foreach (Brick brick in bricks)
                {
                    brick.Draw(_spriteBatch);
                }

            }
            else if (screen == Screen.Win)
            {

            }
            else if (screen == Screen.Lose)
            {

            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
