using System;
using System.Diagnostics;
using System.Threading;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;

namespace MusicMixer.musicexplorer
{
    class MusicPlayer
    {
        MediaPlayer mPlayer;
        bool playing;
        String currentMusic;

        public MusicPlayer()
        {
            mPlayer = new MediaPlayer();        // initialize new mediaplayer
            playing = false;                    // set playing bool to false
        }

        public void playTrack(String mp3File)
        {
            currentMusic = mp3File;
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(play));
        }

        private async void play(Object ThreadObj)
        {
            Thread thread = Thread.CurrentThread;
            Windows.Storage.StorageFile file = await StorageFile.GetFileFromPathAsync(currentMusic);

            mPlayer.AutoPlay = false;
            mPlayer.Source = MediaSource.CreateFromStorageFile(file);
            mPlayer.Play();

            playing = true;
        }

        public void PauseTrack()
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
        // Change the channel of music. -1 is left 0 is middle 1 is right.
        public void ChangeChannel(int channel)
        {
            mPlayer.AudioBalance = channel;
        }

        public void ToggleMute()
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

        // set music player to mute. True is mute false is unmute
        public void Mute(Boolean value)
        {
            mPlayer.IsMuted = value;
        }
    }
}
