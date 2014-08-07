using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using SpacuShuutar;

namespace SpacuShuutar
{
    public class StarField
    {
        //Lista tähdistä
        public List<Star> stars = new List<Star>();
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public Random rand = new Random();
        public Color[] colors = { Color.White, Color.Yellow, Color.Red };
        public StarField(int screenWidth, int screenHeight, int starCount, Vector2 starVelocity, Texture2D texture, Rectangle initialFrame)
            {
                ScreenWidth = screenWidth;
                ScreenHeight = screenHeight;

                for (int x = 0; x < starCount; x++)
                {
                    stars.Add(new Star(new Vector2(rand.Next(0, screenWidth),rand.Next(0, screenHeight)),texture,initialFrame,starVelocity));
                }
                foreach (Star star in stars)
                {
                    star.TintColor = colors[rand.Next(0, colors.Length)];
                    star.TintColor *= (float)(rand.Next(30, 80) / 100f);
                }
            }
        public void Update(GameTime gameTime)
        {
            foreach (Star star in stars)
            {
                star.Update(gameTime);
                if (star.Location.Y > ScreenHeight)
                {
                    star.Location = new Vector2(rand.Next(0, ScreenWidth), 0);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Star star in stars)
            {
                star.Draw(spriteBatch);
            }
        } 
    }
}
