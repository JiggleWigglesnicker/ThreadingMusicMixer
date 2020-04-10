using MusicMixer.musiclistitems;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Diagnostics;

namespace MusicMixer.musicplayer
{
    class MusicPlayer
    {
        MediaPlayer mPlayer;
        bool playing;

        public MusicPlayer()
        {
            mPlayer = new MediaPlayer();
            playing = false;
        }

        public async void playTrack()
        {
            Debug.WriteLine("Playing Music File");
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("klaxon_beat.mp3");

            mPlayer.AutoPlay = false;
            mPlayer.Source = MediaSource.CreateFromStorageFile(file);

            mPlayer.Play();
            playing = true;
        }





        static void test()
        {
            Debug.WriteLine("testing thread");
        }

        public void Player()
        {
            Thread newthread = new Thread(test);

            newthread.Start();
        } 
    }
}
