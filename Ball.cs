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
        private Vector2 _ballSpeed;

        public Ball(Texture2D texture, Rectangle location)
        {
            _ballTexture = texture;
            _ballLocation = location;
            _ballSpeed = Vector2.Zero;
        }




    }
}
