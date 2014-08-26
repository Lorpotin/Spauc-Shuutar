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
    public class IntroVideo
    {
        Texture2D introTexture;
        Vector2 screen;
        Rectangle screenRectangle;
        //GraphicsDevice graphics = new GraphicsDevice();
        Color colour, creditsColour;
        int level = 0, creditsLevel = 0;
        public bool down;
        SpriteFont font;
        public float nameCounter = 0;

        public IntroVideo(Texture2D text, SpriteFont font)
        {
            introTexture = text;
            colour = new Color(0, 0, 0);
            creditsColour = new Color(255, 255, 255, 0);
            screen = new Vector2(1920, 1080);
            this.font = font;
        }
        public int Level
        {
            get { return level; }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState State = Keyboard.GetState();
            screenRectangle = new Rectangle(0, 0, 1920, 1080);
            switch (level)
            {
                case 0:
                    if (State.IsKeyDown(Keys.Escape))
                        level = 1;
                    //colour.R++;
                    if (colour.R == 255)
                        down = false;
                    if (colour.R == 0)
                        down = true;
                    if (down) colour.R++;
                    else
                    {
                        colour.R--;
                        if (colour.R == 0)
                            level = 1;

                    }

                    break;
                case 1:
                    break;

            }

        }
        public void UpdateCredits()
        {
            KeyboardState State = Keyboard.GetState();
            screenRectangle = new Rectangle(0, 0, 1920, 1080);
            switch (creditsLevel)
            {
                case 0:

                    //colour.R++;
                    if (creditsColour.A == 255)
                        down = false;
                    if (creditsColour.A == 0)
                        down = true;
                    if (down) creditsColour.A++;
                    else
                    {
                        creditsColour.A--;
                        if (creditsColour.A == 0)
                            creditsLevel = 1;

                    }

                    break;
                case 1:

                    //colour.R++;
                    if (creditsColour.A == 255)
                        down = false;
                    if (creditsColour.A == 0)
                        down = true;
                    if (down) creditsColour.A++;
                    else
                    {
                        creditsColour.A--;
                        if (creditsColour.A == 0)
                            creditsLevel = 2;

                    }
                    break;

                case 2:

                    //colour.R++;
                    if (creditsColour.A == 255)
                        down = false;
                    if (creditsColour.A == 0)
                        down = true;
                    if (down) creditsColour.A++;
                    else
                    {
                        creditsColour.A--;
                        if (creditsColour.A == 0)
                            creditsLevel = 3;

                    }
                    break;

                case 3:

                    //colour.R++;
                    if (creditsColour.A == 255)
                        down = false;
                    if (creditsColour.A == 0)
                        down = true;
                    if (down) creditsColour.A++;
                    else
                    {
                        creditsColour.A--;
                        if (creditsColour.A == 0)
                            creditsLevel = 4;

                    }
                    break;

                case 4:

                    //colour.R++;
                    if (creditsColour.A == 255)
                        down = false;
                    if (creditsColour.A == 0)
                        down = true;
                    if (down) creditsColour.A++;
                    else
                    {
                        creditsColour.A--;
                        if (creditsColour.A == 0)
                            creditsLevel = 0;

                    }
                    break;

                case 5:
                    break;

            }

        }

        public void DrawCredits(SpriteBatch spriteBatch)
        {
            
            if (creditsLevel == 0)
            {
                spriteBatch.DrawString(font, "- Tatu Virta", new Vector2(400, 600), creditsColour);
                spriteBatch.DrawString(font, "Project Manager", new Vector2(400, 450), Color.White);
            }
            else if (creditsLevel == 1)
            {
                spriteBatch.DrawString(font, "- Otto Laitinen", new Vector2(400, 600), creditsColour);

                spriteBatch.DrawString(font, "Lead Programmer", new Vector2(400, 450), Color.White);

            }
            else if (creditsLevel == 2)
            {
                spriteBatch.DrawString(font, "- Kasper Halme", new Vector2(400, 600), creditsColour);

                spriteBatch.DrawString(font, "Graphics", new Vector2(400, 450), Color.White);

            }
            else if (creditsLevel == 3)
            {
                spriteBatch.DrawString(font, "- Lauri Rapo", new Vector2(400, 600), creditsColour);

                spriteBatch.DrawString(font, "Music & SFX", new Vector2(400, 450), Color.White);

            }
            else if (creditsLevel == 4)
            {
                spriteBatch.DrawString(font, "- Teemu Hokkanen", new Vector2(400, 600), creditsColour);


                spriteBatch.DrawString(font, "Programmer", new Vector2(400, 450), Color.White);

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(introTexture, screenRectangle, Color.White);
            spriteBatch.Draw(introTexture, screenRectangle, colour);
        }

    }
}
