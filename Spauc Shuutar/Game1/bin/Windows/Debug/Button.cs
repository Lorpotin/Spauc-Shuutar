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
using SpacuShuutar;
namespace SpacuShuutar
{
    public class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        Color colour = new Color(255, 255, 255, 255);
        public Vector2 size;
        public bool down, showInfo;
        public bool isClicked;
        public bool ship1active, ship2active, ship3active;

        public Button(Texture2D texture, Vector2 position, Vector2 size)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
        }

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            showInfo = false;
            if (mouseRectangle.Intersects(rectangle))
            {
                showInfo = true;
                if (colour.R == 255) down = false;
                if (colour.R == 0) down = true;
                if (down)
                    colour.R += 10;
                else
                    colour.R -= 10;

                if (mouse.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            }

            else if (colour.R < 255)
            {
                colour.R += 10;
                isClicked = false;
            }

        }
        public void UpdateShipChoose(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            showInfo = false;
            if (mouseRectangle.Intersects(rectangle))
            {
                showInfo = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
