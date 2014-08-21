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
    public class Boss
    {

        public Texture2D bossTexture, bulletTexture, turretTexture;
        public Vector2 velocity, direction, origin, shootingDirection, center, turretOrigin, position, turretPosition;
        public bool active = false;
        public int health, a;
        public int damage, bulletDamage;
        private float speed, timer;
        public float bossRotation, turretRotation;
        public Color bossColor, hitColor;
        public bool hit;
        public bool victory, canTakeDamage;
        Random random = new Random();
        public Player target;
        public Bullet bullet;
        public List<Bullet> bulletList = new List<Bullet>();
        public GraphicsDeviceManager graphics;
        private float shootCounter;
        private float keissitimer1;
        public int level = 0, number = 0;
        public bool down, teleportPossible, ramming, shooting;



        public Boss(Texture2D texture, Player player, Texture2D bulletTexture, Texture2D turret)
        {
            bossTexture = texture;
            turretTexture = turret;
            health = 20000;
            damage = 1;
            bossColor = new Color(255, 255, 255, 255);
            speed = 4f;
            hit = false;
            bulletDamage = 25;
            victory = false;
            position = new Vector2(900, 0);
            origin = new Vector2(bossTexture.Width / 2, bossTexture.Height / 2);
            turretOrigin = new Vector2(turretTexture.Width / 2, turretTexture.Height / 2);
            target = player;
            this.bulletTexture = bulletTexture;
            center = new Vector2(position.X + turretTexture.Width / 2, position.Y + turretTexture.Height / 2);
            turretPosition = new Vector2(position.X - 135, position.Y - 55);
            teleportPossible = true;
            ramming = false;
            shooting = true;
            canTakeDamage = false;

        }

        public int Width
        {
            get { return bossTexture.Width; }
        }
        public int Height
        {
            get { return bossTexture.Height; }
        }
        public int FadeLevel
        {
            get { return level; }
        }
        public void ShootPlayer()
        {
                if (shootCounter > 7)
                {
                    shootCounter = 0;
                    Bullet bullet = new Bullet(new Vector2(turretPosition.X + 60, turretPosition.Y - 10), GetPlayerPosition(), bulletTexture, target, graphics);
                    bulletList.Add(bullet);
                }
                else
                    shootCounter++;
        }

        public void TeleportToAnotherLocation()
        {
            switch (level)
            {
                case 0:

                    if (bossColor.A == 255)
                        down = false;
                    if (bossColor.A == 0)
                    {
                        down = true;
                        position = Evade();
                    }
                    if (down) bossColor.A++;
                    else
                    {
                        bossColor.A--;
                        if (bossColor.A == 0)
                        {
                            level = 1;
                            
                        }
                    }
                    break;
                case 1:
                    level = 0;
                    break;
            }
        }
        public bool SpinAroundAndRamPlayer()
        {
            ramming = true;
            bossRotation += 0.1f;
            direction = Vector2.Normalize(target.arrowPosition - position);
            position += direction * speed;
            return ramming;
        }
        public Vector2 GetPlayerPosition()
        {
            shootingDirection = Vector2.Normalize(target.arrowPosition - position);
            return shootingDirection;
        }
        public Vector2 Evade()
        {
            int number = random.Next(1, 4);
            Vector2 evadePoint = new Vector2();

            switch (number)
            {
                case 1:
                    evadePoint = new Vector2(random.Next(100, 1800), 100);
                    break;

                case 2:
                    evadePoint = new Vector2(1800, random.Next(100, 1000));
                    break;

                case 3:
                    evadePoint = new Vector2(random.Next(100, 1080), 1000);
                    break;

                case 4:
                    evadePoint = new Vector2(100, random.Next(100, 1000));
                    break;
            }

            return evadePoint;
        }
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 18)
                position.Y += 0.4f;
            if (timer >= 18.5)
            {
                canTakeDamage = true;
                keissitimer1 += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (keissitimer1 >= 10)
                {
                    SpinAroundAndRamPlayer();
                    if (keissitimer1 >= 20)
                        keissitimer1 = 0;
                }
                else if (keissitimer1 < 10)
                {

                    ShootPlayer();
                    TeleportToAnotherLocation();
                }
            }
            UpdateBullets();
            UpdateCollisions();
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
                    target.health -= bulletDamage;
                }
            }
        }
        public void Shot(GameTime gameTime)
        {
            if (health <= 0)
            {
                active = false;
                victory = true;
            }

        }
      
        public void TurnTurret()
        {
            Vector2 direction = turretPosition - target.arrowPosition;
            direction.Normalize();
            turretRotation = (float)Math.Atan2(-direction.X, direction.Y);
        }


        public void UpdateTurret(GameTime gameTime)
        {
            turretPosition = position;
            if (target != null)
            {
                TurnTurret();
            }

        }
        public void DrawTurret(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(turretTexture, turretPosition, null, bossColor,
                turretRotation, turretOrigin, 1.0f, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (bulletList.Count > 0)
            {
                foreach (Bullet bullet in bulletList)
                    bullet.Draw(spriteBatch);
            }
            spriteBatch.Draw(bossTexture, position, null, bossColor, bossRotation, origin, 1.0f, SpriteEffects.None, 0);
            
            
        }

    }
}
