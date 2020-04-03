using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;


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

        public async void CreateSelectFolder()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                Windows.Storage.StorageFolder sampleFile = await storageFolder.CreateFolderAsync("Music223");
            }
            catch (Exception e) {
                Console.WriteLine("error {0}",e);
            }
           
            
            
        }

    }
}
