using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Sumative___Breakout
{
    internal class Brick
    {
        private Texture2D _brickTexture;
        private Rectangle _brickLocation;
        private int _brickHealth;
        private Color _brickColor;

        public Brick(Texture2D texture, Rectangle location, int Health, Color color)
        {
            _brickTexture = texture;
            _brickLocation = location;
            _brickHealth = Health;
            _brickColor = color;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_brickTexture, _brickLocation, _brickColor);
        }




    }
}
