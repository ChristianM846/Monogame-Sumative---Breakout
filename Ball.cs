using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Sumative___Breakout
{
    public class Ball
    {
        private Random generator = new Random();
        private Texture2D _ballTexture;
        private Rectangle _ballLocation;
        private Rectangle _ballSpawn;
        private Rectangle _windowBounds;
        private Vector2 _ballSpeed;
        private int _lives;
        private int _bounces;
        private int _speedIncrease;

        public Ball(Texture2D texture, Rectangle location, Vector2 speed, Rectangle window, Rectangle spawn, int lives)
        {
            _ballTexture = texture;
            _ballLocation = location;
            _ballSpawn = spawn;
            _windowBounds = window;
            _ballSpeed = speed;
            _lives = lives;
            _bounces = 0;
        }

        public void Update(KeyboardState keyboardState, Paddle paddle)
        {
            if (_ballSpeed == Vector2.Zero && keyboardState.IsKeyDown(Keys.Space))
            {
                _ballSpeed.X = generator.Next(-2, 3);
                _ballSpeed.Y = generator.Next(-4, -2);
            }

            _ballLocation.X += (int)_ballSpeed.X;

            if (_ballLocation.X < 0 || _ballLocation.Right > _windowBounds.Right)
            {
                _ballSpeed.X *= -1;
            }

            _ballLocation.Y += (int)_ballSpeed.Y;

            if (_ballLocation.Y <= 0)
            {
                _ballSpeed.Y *= -1;
            }

            if (_ballLocation.Bottom >= paddle.PaddleRect.Top && _ballLocation.Bottom - 15 < paddle.PaddleRect.Top && _ballLocation.X < paddle.PaddleRect.Right && _ballLocation.Right > paddle.PaddleRect.Left)
            {
                _ballSpeed.Y *= -1;
                _ballLocation.Y -= (int)paddle.PaddleRect.Height;
                _bounces++;

                if (_ballSpeed.X > 0)
                {
                    if (paddle.PaddleSpeedX > 0)
                    {
                        _ballSpeed.X += 1;
                    }
                    else if (paddle.PaddleSpeedX < 0)
                    {
                        _ballSpeed.X -= 1;
                    }
                }
                else if (_ballSpeed.X < 0)
                {
                    if (paddle.PaddleSpeedX > 0)
                    {
                        _ballSpeed.X += 1;
                    }
                    else if (paddle.PaddleSpeedX < 0)
                    {
                        _ballSpeed.X -= 1;
                    }
                }
                else if (_ballSpeed.X == 0)
                {
                    if (paddle.PaddleSpeedX > 0)
                    {
                        _ballSpeed.X += 1;
                    }
                    else if (paddle.PaddleSpeedX < 0)
                    {
                        _ballSpeed.X -= 1;
                    }
                }


                if (_bounces % 5 == 0)
                {
                    _speedIncrease = generator.Next(1, 3);

                    if (_speedIncrease == 1)
                    {
                        _ballSpeed.Y -= 1;
                    }
                    else if (_speedIncrease == 2)
                    {
                        if (_ballSpeed.X > 0)
                        {
                            _ballSpeed.X += 1;
                        }
                        else if (_ballSpeed.X < 0)
                        {
                            _ballSpeed.X -= 1;
                        }
                    }
                }

            }

            if (_ballLocation.Bottom >= _windowBounds.Bottom)
            {
                _ballSpeed.X = 0;
                _ballSpeed.Y = 0;
                _ballLocation = _ballSpawn;
                _lives--;
                _bounces = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ballTexture, _ballLocation, Color.Black);
        }

        public Rectangle BallRect
        {
            get { return _ballLocation; }
            set { _ballLocation = value; }
        }

        public int BallRectX
        {
            get { return _ballLocation.X; }
            set { _ballLocation.X = value; }
        }

        public int BallRectY
        {
            get { return _ballLocation.Y; }
            set { _ballLocation.Y = value; }
        }

        public float BallSpeedMod
        {
            get { return Math.Abs(_ballSpeed.X); }
            set { _ballSpeed.X = value; }
        }

        public float BallSpeedX
        {
            get { return _ballSpeed.X; }
            set { _ballSpeed.X = value; }
        }

        public float BallSpeedY
        {
            get { return _ballSpeed.Y; }
            set { _ballSpeed.Y = value; }
        }

        public int Lives
        {
            get { return _lives; }
        }


    }
}
