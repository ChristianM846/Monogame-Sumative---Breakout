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
            ball = new Ball(ballTexture, ballSpawn, new Vector2(0, 0), window, ballSpawn, 2);

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
                paddle.Update(keyboardState);
                ball.Update(keyboardState, paddle);

                if (ball.Lives <= 0)
                {
                    screen = Screen.Lose;
                }

                if (ball.BallSpeedX - 2 > paddle.PaddleSpeedX)
                {
                    paddle.PaddleSpeedX = (int)ball.BallSpeedX - 2;
                }

                if (paddle.PaddleSpeedX > ball.BallSpeedX)
                {
                    paddle.PaddleSpeedX = 3;
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
