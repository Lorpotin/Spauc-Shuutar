using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace SpacuShuutar
{
    class EpicHealthBar
    {

        Texture2D foreGround, borders;
        Rectangle rectangle;
        Vector2 position, position2;
        Player player;
        public int Width;

      
        public EpicHealthBar(Texture2D fg, Texture2D border, Player player)
        {
            Width = 211;
            foreGround = fg;
            borders = border;
            position = new Vector2(50, 30);
            position2 = new Vector2(46, 26);
            this.player = player;
            
        }

        public void Update()
        {
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = new Rectangle(0, 0, Width, foreGround.Height);
            spriteBatch.Draw(borders, position2, Color.White);
            spriteBatch.Draw(foreGround, position, rectangle, Color.White);
        }

    }
}
