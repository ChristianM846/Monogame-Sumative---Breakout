using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sumative___Breakout
{
    public class Paddle
    {
        private Texture2D _paddleTexture;
        private Rectangle _paddleLocation;
        private Rectangle _windowBounds;
        private Vector2 _paddleSpeed;

        public Paddle (Texture2D texture, Rectangle locaton, Rectangle window)
        {
            _paddleTexture = texture;
            _paddleLocation = locaton;
            _windowBounds = window;
            _paddleSpeed = Vector2.Zero;
        }







    }
}
