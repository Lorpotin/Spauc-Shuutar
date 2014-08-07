using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Microsoft.Xna.Framework.Audio;

namespace SpacuShuutar
{
    public class SpriteAnimation
    {

        Texture2D spriteStrip;

      
        float scale;
        int elapsedTime;
        int frameTime;
        int frameCount;
        int currentFrame;
        Color color;
        
        public int FrameWidth;
        public int FrameHeight;
        public bool Active;
        public bool Looping;
        public Vector2 Position;
 
        public SpriteAnimation(Texture2D texture, int frameWidth, int frameHeight, int frameCount, int frametime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            Looping = looping;
            spriteStrip = texture;

            elapsedTime = 0;
            currentFrame = 0;

            Active = true;
        }
        public void Initialize(Vector2 position)
        {
            Position = position;
        }
 
        public void Update(GameTime gameTime)
        {
            if (Active == false)
                return;
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsedTime > frameTime)
                {
                    currentFrame++;
                    

                    if (currentFrame == frameCount)
                    {
                        currentFrame = 0;
                        if (Looping == false)
                            Active = false;
                        
                    }
                    elapsedTime = 0;
                }
                
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
            Rectangle destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2, (int)Position.Y - (int)(FrameHeight * scale) / 2, (int)(FrameWidth * scale), (int)(FrameHeight * scale));
            if (Active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, Color.White);
            }
        }
        
    }
}


