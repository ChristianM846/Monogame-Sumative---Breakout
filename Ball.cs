using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Sumative___Breakout
{
    public class Ball
    {
        private Texture2D _ballTexture;
        private Rectangle _ballLocation;
        private Rectangle _ballSpawn;
        private Rectangle _windowBounds;
        private Vector2 _ballSpeed;
        private int _lives;

        public Ball(Texture2D texture, Rectangle location, Vector2 speed, Rectangle window, Rectangle spawn, int lives)
        {
            _ballTexture = texture;
            _ballLocation = location;
            _ballSpawn = spawn;
            _windowBounds = window;
            _ballSpeed = speed;
            _lives = lives;
        }

        public void Update(KeyboardState keyboardState, Paddle paddle)
        {
            if (_ballSpeed == Vector2.Zero && keyboardState.IsKeyDown(Keys.Space))
            {
                _ballSpeed.X = 2f;
                _ballSpeed.Y = -3f;
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
            }

            if (_ballLocation.Bottom >= _windowBounds.Bottom)
            {
                _ballSpeed.X = 0;
                _ballSpeed.Y = 0;
                _ballLocation = _ballSpawn;
                _lives--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ballTexture, _ballLocation, Color.Black);
        }

        public Rectangle BallRect
        {
            get { return _ballLocation; }
        }

        public Vector2 BallSpeed
        {
            get { return _ballSpeed; }
            set { _ballSpeed = value; }
        }

        public int Lives
        {
            get { return _lives; }
        }


    }
}
