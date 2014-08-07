using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;


namespace SpacuShuutar
{
    public class HomingMinigunPowarUp
    {

        public Texture2D gunTexture;
        public Vector2 position;
        public Color colour = new Color(0, 0, 0);
        public bool active;
        public bool down;
        public bool pickedUp;
        public int plusAmmo;


        public HomingMinigunPowarUp(Texture2D text, Vector2 pos)
        {
            gunTexture = text;
            position = pos;
            active = true;
            pickedUp = false;
            plusAmmo = 100;

        }

        public int Width
        {
            get { return gunTexture.Width; }
        }
        public int Height
        {
            get { return gunTexture.Height; }
        }

        public void Update()
        {
            if (colour.B == 255)
                down = false;
            if (colour.B == 50)
                down = true;
            if (down) colour.B += 5;
            else
            {
                colour.B -= 5;

            }
                    
            if (pickedUp == true)
                active = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gunTexture, position, colour);
        }


    }

    
    
}
