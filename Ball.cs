using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




    }
}
