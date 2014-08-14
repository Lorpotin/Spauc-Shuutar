using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Audio;
using System.Collections;



namespace SpacuShuutar
{

    public class Highscore
    {
        //public StorageFolder localFolder = KnownFolders.DocumentsLibrary;
        SpriteFont font;
        //StreamReader reader;
        public string playerName { get; set; }
        public int score { get; set; }
        public List<string> scores = new List<string>();
        public int scoreCounter;




        
        public Highscore(SpriteFont fontz)
        {
            font = fontz;
            
        }
        public void ReadFile()    //Toimii tämäkin
        {
           
                using (StreamReader reader = new StreamReader("C:\\test.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        scores.Add(line);
                    }
                }
            
        }
        public void SortTextFileAndWrite(string score)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\test.txt", true))
            {
                file.WriteLine(score);
            }
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            
            int max = Convert.ToInt32(scores.Max());
            spriteBatch.DrawString(font, "HIGHSCORES", new Vector2(600, 50), Color.White);
            spriteBatch.DrawString(font, "1. " + max, new Vector2(600, 300), Color.White);
            
        }
        public int HighestScore()
        {
            int max = Convert.ToInt32(scores.Max());
            return max;
        }
    }
}
