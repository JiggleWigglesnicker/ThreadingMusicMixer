using System;

namespace MusicMixer.musicexplorer
{
    class MusicFile
    {
        /// <summary>
        /// This class allows for the name and path of the song to be accessed. 
        /// It functions similarly to a model.
        /// </summary>
        public String FilePath { get; set; }
        public String FileName { get; set; }
        public MusicFile(String filepath, String filename)
        {
            FilePath = filepath;
            FileName = filename;
        }
    }
}
