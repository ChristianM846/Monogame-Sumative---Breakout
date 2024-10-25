using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sumative___Breakout
{
    internal class Brick
    {
        private Texture2D _brickTexture;
        private Rectangle _brickLocation;
        private Color _brickColor;

        public Brick(Texture2D texture, Rectangle location, Color color)
        {
            _brickTexture = texture;
            _brickLocation = location;
            _brickColor = color;
        }



    }
}
