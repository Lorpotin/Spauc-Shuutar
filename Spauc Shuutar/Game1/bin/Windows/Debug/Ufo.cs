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
    public class Ufo
    {
        public Texture2D ufoTexture;
        public Texture2D ufoTexture2, bulletTexture;
        public Vector2 position, wavePosition, alienPosition, shootingDirection, origin;
        public Vector2 direction, alienDirection;
        public Color color, alienColor;
        public bool active;
        public int health, alienHealth;
        public float speed;
        public int damage, alienDamage;
        public int score;
        int randX, randY;
        Random random = new Random();
        Player Player;
        Player target;
        private int timeUntilStart = 60;
        public List<Bullet> bulletList = new List<Bullet>();

        public Ufo(Texture2D texture, Texture2D texture2, Player player, Texture2D bulletTexture)
        {
            active = true;
            health = 200;
            damage = 10;
            score = 5;
            speed = 6f;
            this.Player = player;
            this.target = player;
            ufoTexture = texture;
            ufoTexture2 = texture2;
            position = CreateSpawnPoint();
            alienPosition = CreateSpawnPoint();
            randY = random.Next(2, 6);
            randX = random.Next(-4, 4);
            color = Color.Transparent;
            alienColor = Color.Transparent;
            this.bulletTexture = bulletTexture;
            origin = new Vector2(ufoTexture2.Width / 2, ufoTexture2.Height / 2);

        }

        public int Width
        {
            get { return ufoTexture.Width; }
        }
        public int Height
        {
            get { return ufoTexture.Height; }
        }

        public Vector2 CreateSpawnPoint()
        {

            //Tehdään sittenkin semmonen spawni, että vihut tulee joka puolelta ja alkaa seuraamaan pellaajaa.


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
                    spawnPoint = new Vector2(random.Next(100, 1080), 1000);
                    break;

                case 4:
                    spawnPoint = new Vector2(0, random.Next(50, 1030));
                    break;
            }

            return spawnPoint;
        }
       
       
        public void Update()
        {

            int number = random.Next(1, 2);
            if (timeUntilStart <= 0)
            {
                switch (number)
                {
                    case 1:
                        if ((position - Player.Position).Length() > 3f)
                        {
                            direction = Vector2.Normalize(Player.Position - position) * speed;
                            position += direction;
                        }
                        break;
                }
            }
            else
            {
                timeUntilStart--;
                color = Color.White * (1 - timeUntilStart / 60f);
            }
            if (health <= 0)
            {
                active = false;
            }
        }
        
        
        public void Draw(SpriteBatch spriteBatch)
        {
            int number = random.Next(1, 2);
            switch (number)
            {
                case 1:
                    spriteBatch.Draw(ufoTexture, position, color);
                    break;

                case 2:
                    spriteBatch.Draw(ufoTexture2, position, color);
                    break;

            }
        }

    }
}
