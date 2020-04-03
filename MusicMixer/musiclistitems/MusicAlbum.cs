using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MusicMixer.musiclistitems
{
    class MusicAlbum : MusicList
    {
        private String bandName;

        private String artistName;

        public MusicAlbum()
        {

        }

        public String getBandName()
        {
            return bandName;
        }

        public void setBandName(String bandName)
        {
            this.bandName = bandName;
        }


        public String getArtistName()
        {
            return artistName;
        }

        public void setArtistName(String artistName)
        {
            this.artistName = artistName;
        }

        public void CreateSelectFolder()
        {
            // Specify the directory you want to manipulate.
            String existingPath = @"D:/0Icons/Documents/music";
            String path = @"D:/0Icons/Documents/";
            
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(existingPath))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

    }
}
