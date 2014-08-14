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
    //Basic crap machinagun
    public class Bullet
    {
        public Vector2 position;
        public Vector2 direction;
        public Vector2 origin;
        public Player player;
        public Texture2D bulletTexture;
        public GraphicsDeviceManager gManager;
        public bool Dead;
        public float angle;
        public int damage;
        public float speed;
        
        public Bullet(Vector2 spawn, Vector2 direction, Texture2D tex, Player player, GraphicsDeviceManager graphics)
        {
            this.direction = direction;
            this.player = player;
            position = spawn;
            bulletTexture = tex;
            speed = 10f;
            damage = 150;
            Dead = false;
            origin = new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2);
            gManager = graphics;
            
        }

        public int Width
        {
            get { return bulletTexture.Width; }
        }
        public int Height
        {
            get { return bulletTexture.Height; }
        }
        
        public void Update()
        {

            direction.Normalize();
            position += direction * speed;

            if (position.Y > gManager.GraphicsDevice.Viewport.Height + 100 | position.Y < -100 | position.X > gManager.GraphicsDevice.Viewport.Width + 100
                | position.X < -100)
            {
                Dead = true;
            }
            
               
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTexture, position, null, Color.White,
                player.Vector2ToRadian(direction), origin, 1.0f, SpriteEffects.None, 0);
        }

    }
}
