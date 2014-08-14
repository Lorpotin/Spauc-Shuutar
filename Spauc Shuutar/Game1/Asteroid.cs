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
    public class Asteroid
    {
        public Vector2 position, deathPosition;
        public Vector2 direction;
        //public Texture2D asteroidTexture;
        //public Texture2D bigAsteroidTexture;
        public Color color;
        public bool active;
        public int health;
        public int health2;
        public int damage;
        public int score;
        float speed;
        Player Player;
        Random random = new Random();
        private int timeUntilStart = 60;
        public SpriteAnimation animation;
        
        
        public Asteroid(Player player, SpriteAnimation Animation)
        {
           
            position = CreateSpawnPoint();
            active = true;
            health = 100;
            health2 = 500;
            damage = 10;
            speed = randomizeSpeed();
            score = 5;
            Player = player;
            color = Color.Transparent;
            animation = Animation;
            
        }
        

        public int Width
        {
            get { return animation.FrameWidth; }
        }
        public int Height
        {
            get { return animation.FrameHeight; }
        }

        public Vector2 CreateSpawnPoint()
        {
            

            //Tehdään sittenkin semmonen spawni, että vihut tulee joka puolelta
            //Ja alkaa seuraamaan sua.

            int number = random.Next(1, 4);
            Vector2 spawnPoint = new Vector2();
            
            switch (number)
            {
                case 1:
                    spawnPoint = new Vector2(random.Next(100, 1800), 0);
                    break;

                case 2:
                    spawnPoint = new Vector2(1800, random.Next(50, 1030));
                    break;

                case 3:
                    spawnPoint = new Vector2(random.Next(100,1080), 1000);
                    break;

                case 4:
                    spawnPoint = new Vector2(0, random.Next(50, 1030));
                    break;
            }

            return spawnPoint;
        }
        public float randomizeSpeed()
        {
            int number = random.Next(1, 4);
            float speed = 0f;
            switch (number)
            {
                case 1:
                    speed = 2f;
                    break;

                case 2:
                    speed = 5f;
                    break;

                case 3:
                    speed = 8f;
                    break;

                case 4:
                    speed = 11f;
                    break;

            }
            return speed;
        }
      
     

        public void Update(GameTime gameTime)
        {
                if ((position - Player.Position).Length() > 3f)
                {
                    direction = Vector2.Normalize(Player.Position - position) * speed;
                    position += direction;
                }
                animation.Position = position;
                animation.Update(gameTime);   
          
            if (health <= 0)
            {
                active = false;

            } 
            
                
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(asteroidTexture, position, color);
            animation.Draw(spriteBatch);
        }
    }
}
