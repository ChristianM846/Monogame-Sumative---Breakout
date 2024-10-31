using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Sumative___Breakout
{
    public class Paddle
    {
        private Texture2D _paddleTexture;
        private Rectangle _paddleLocation;
        private Rectangle _windowBounds;
        private Vector2 _paddleSpeed;
        private int _speedMod;

        public Paddle(Texture2D texture, Rectangle locaton, Rectangle window)
        {
            _paddleTexture = texture;
            _paddleLocation = locaton;
            _windowBounds = window;
            _paddleSpeed = Vector2.Zero;
            _speedMod = 3;
        }

        public void Update(KeyboardState keyboardState)
        {
            _paddleSpeed = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _paddleSpeed.X -= _speedMod;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _paddleSpeed.X += _speedMod;
            }

            _paddleLocation.Offset(_paddleSpeed);

            if (!_windowBounds.Contains(_paddleLocation))
            {
                _paddleLocation.Offset(-_paddleSpeed);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_paddleTexture, _paddleLocation, Color.White);
        }

        public Rectangle PaddleRect
        {
            get { return _paddleLocation; }
        }

        public float PaddleSpeedX
        {
            get { return _paddleSpeed.X; }
            set { _paddleSpeed.X = value; }
        }

        public int SpeedMod
        {
            get { return _speedMod; }
            set { _speedMod = value; }
        }
    }
}
