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
    public class Star
    {
        private Texture2D Texture;
        public Color TintColor { get; set; } //stores color of each star that will be used when the star is drawn.
        public Vector2 Location { get; set; } //the location of the star will be tracked via the Location vector
        private Vector2 Velocity { get; set; } //the speed and direction at which the star is moving is stored in Velocity
        private Rectangle InitialFrame { get; set; }

        public Star(Vector2 location, Texture2D texture, Rectangle initialFrame, Vector2 velocity)
        {
            //sets the members to the passed parameter values
            Location = location;
            Texture = texture;
            InitialFrame = initialFrame;
            Velocity = velocity;
        }
        public Rectangle Destination
        {
            //Getteri jolla palautetaan tähden määränpää
            get { return new Rectangle((int)Location.X, (int)Location.Y, InitialFrame.Width, InitialFrame.Height); }
                 
        }
        public void Update(GameTime gameTime)
        {
            //kulunut aika pelissä
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Muutetaan tähden sijaintia nopeuden mukaan
            Location += (Velocity * elapsed);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Destination, InitialFrame, TintColor);
        }

    }
}
