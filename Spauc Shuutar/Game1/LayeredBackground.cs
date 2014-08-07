using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpacuShuutar
{
    class LayeredBackground
    {
        Texture2D texture;
        Vector2[] positions;
        int speed;
        int screenWidth;
        int screenHeight;

        public LayeredBackground(Texture2D texture, int screenWidth, int screenHeight, int speed)
        {
            this.texture = texture;
            this.speed = speed;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            positions = new Vector2[screenWidth / texture.Width + 1];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector2(i * texture.Width, 0);
            }
        }

        public void Update()
        {

        }
        public void Draw()
        {

        }


    }
}
