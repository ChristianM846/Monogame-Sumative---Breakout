using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Sumative___Breakout
{
    public class Ball
    {
        private Texture2D _ballTexture;
        private Rectangle _ballLocation;
        private Rectangle _windowBounds;
        private Vector2 _ballSpeed;

        public Ball(Texture2D texture, Rectangle location, Vector2 speed, Rectangle window)
        {
            _ballTexture = texture;
            _ballLocation = location;
            _windowBounds = window;
            _ballSpeed = speed;
        }

        public void Update(KeyboardState keyboardState)
        {
            if (_ballSpeed == Vector2.Zero && keyboardState.IsKeyDown(Keys.Space))
            {
                _ballSpeed.X = 2f;
                _ballSpeed.Y = 0f;
            }

            _ballLocation.Offset(_ballSpeed);

            if (_ballLocation.X < 0 || _ballLocation.Right > _windowBounds.Right)
            {
                _ballSpeed.X *= -1;
            }



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ballTexture, _ballLocation, Color.White);
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

    }
}
