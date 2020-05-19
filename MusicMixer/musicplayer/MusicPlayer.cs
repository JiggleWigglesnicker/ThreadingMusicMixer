using System;
using System.Diagnostics;
using System.Threading;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace MusicMixer.musicexplorer
{
    class MusicPlayer
    {
        MediaPlayer mPlayer;
        bool playing;

        public MusicPlayer()
        {
            mPlayer = new MediaPlayer();        // initialize new mediaplayer
            playing = false;                    // set playing bool to false
        }

        public void playTrack()
        {
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(play));
        }

        private async void play(Object ThreadObj)
        {
            Thread thread = Thread.CurrentThread;
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("klaxon_beat.mp3");

            mPlayer.AutoPlay = false;
            mPlayer.Source = MediaSource.CreateFromStorageFile(file);
            mPlayer.Play();

            playing = true;
        }

        public void pauseTrack()
        {
            if (playing)
            {
                mPlayer.Pause();
                playing = false;
                Debug.WriteLine("pausing {0}", playing);
            }
            else
            {
                mPlayer.Play();
                playing = true;
                Debug.WriteLine("resuming {0}", playing);
            }
        }

        public void changeChannel(int channel)
        {
            mPlayer.AudioBalance = channel;
        }

        public void toggleMute()
        {
            if (mPlayer.IsMuted == false)
            {
                mPlayer.IsMuted = true;
            }
            else if (mPlayer.IsMuted == true)
            {
                mPlayer.IsMuted = false;
            }
        }
    }
}
