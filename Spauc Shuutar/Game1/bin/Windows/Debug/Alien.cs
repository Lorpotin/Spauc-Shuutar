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
    public class Alien
    {
        public Texture2D ufoTexture;
        public Texture2D  bulletTexture;
        public Vector2 alienPosition, shootingDirection, origin;
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
        Bullet bullet;
        private int timeUntilStart = 60;
        public List<Bullet> bulletList = new List<Bullet>();
        private float shootCounter;
        private float rotation;
        GraphicsDeviceManager graphics;

        public Alien(Texture2D texture, Player player, Texture2D bulletTexture)
        {
            active = true;
            health = 200;
            damage = 10;
            score = 5;
            speed = 6f;
            this.Player = player;
            this.target = player;
            ufoTexture = texture;
            alienPosition = CreateSpawnPoint();
            randY = random.Next(2, 6);
            randX = random.Next(-4, 4);
            alienColor = Color.Transparent;
            this.bulletTexture = bulletTexture;
            origin = new Vector2(ufoTexture.Width / 2, ufoTexture.Height / 2);

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
        public void TurnAlien()
        {
            Vector2 direction = alienPosition - target.arrowPosition;
            direction.Normalize();
            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }

        public Vector2 GetPlayerPosition()
        {
            shootingDirection = Vector2.Normalize(target.arrowPosition - alienPosition);
            return shootingDirection;
        }
        public void ShootPlayer()
        {
            if (shootCounter > 25)
            {
                shootCounter = 0;
                Bullet bullet = new Bullet(new Vector2(alienPosition.X + 60, alienPosition.Y - 10), GetPlayerPosition(), bulletTexture, target, graphics);
                bulletList.Add(bullet);
            }
            else
                shootCounter++;
        }
        public void UpdateBullets()
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.position += bullet.direction * 7f;
            }
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].position.Y > 1080 | bulletList[i].position.Y < 0 | bulletList[i].position.X > 1920
                | bulletList[i].position.X < 0 | bulletList[i].Dead == true)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }
        public void UpdateCollisions()
        {
            Rectangle playerRectangle;
            Rectangle bulletRectangle;
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletRectangle = new Rectangle((int)bulletList[i].position.X, (int)bulletList[i].position.Y, bulletList[i].Width, bulletList[i].Height);
                playerRectangle = new Rectangle((int)target.Position.X, (int)target.Position.Y, target.Width, target.Height);
                if (bulletRectangle.Intersects(playerRectangle))
                {
                    bulletList[i].Dead = true;
                    target.health -= damage;
                }
            }
        }
       
        public void UpdateAlien()
        {
           
            if (timeUntilStart <= 0)
            {
                if (target != null)
                {
                    TurnAlien();
                }
                UpdateBullets();
                UpdateCollisions();
                ShootPlayer();
            }
            else
            {
                timeUntilStart--;
                alienColor = Color.White * (1 - timeUntilStart / 60f);
            }

            if (health <= 0)
            {
                active = false;
            }
          

        }
        public void DrawAlien(SpriteBatch spriteBatch)
        {
            if (bulletList.Count > 0)
            {
                foreach (Bullet bullet in bulletList)
                    bullet.Draw(spriteBatch);
            }
            spriteBatch.Draw(ufoTexture, alienPosition, null, alienColor, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
