using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Sumative___Breakout
{
    public class Ball
    {
        private Texture2D _ballTexture;
        private Rectangle _ballLocation;
        private Rectangle _windowBounds;
        private Vector2 _ballSpeed;

        public Ball(Texture2D texture, Rectangle location, Rectangle window)
        {
            _ballTexture = texture;
            _ballLocation = location;
            _windowBounds = window;
            _ballSpeed = Vector2.Zero;
        }

        public void Update()
        {






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
