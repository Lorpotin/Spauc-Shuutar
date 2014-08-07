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
    public class MiniGunBullet
    {

        public Texture2D bulletTexture;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 center;
        public Vector2 origin;
        public Player player;
        public Asteroid asteroid;
        public float rotation;
        public int damage;
        public int speed;
        public bool dead;

        public MiniGunBullet(Texture2D texture, Vector2 position, float rotation, Player player)
        {
            //this.rotation = rotation;
            this.position = player.arrowPosition;
            this.rotation = rotation;
            this.player = player;
            bulletTexture = texture;
            speed = 20;
            damage = 150;
            center = new Vector2(position.X + bulletTexture.Width / 2, position.Y + bulletTexture.Height / 2);
            origin = new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2);
            dead = false;

        }
        public int Width
        {
            get { return bulletTexture.Width; }
        }
        public int Height
        {
            get { return bulletTexture.Height; }
        }
        public bool Destroy()
        {
            dead = true;
            return dead;
        }

        public void SetRotation()
        {
            velocity = Vector2.Transform(new Vector2(0, -speed),
                Matrix.CreateRotationZ(rotation));
        }
        
        public void Update(GameTime gameTime)
        {

            position += velocity + new Vector2(4, 4);
            
            if (position.Y < (-Width - 50) || position.X < (-Height-50))
            {
                dead = true;
            }    
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTexture, position, null, Color.White,
                rotation, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
