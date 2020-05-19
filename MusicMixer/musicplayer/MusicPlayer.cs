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
        readonly MediaPlayer mPlayer;
        bool playing;
        String currentMusic;

        public MusicPlayer()
        {
            mPlayer = new MediaPlayer();        // initialize new mediaplayer
            playing = false;                    // set playing bool to false
        }

        public void PlayTrack(String musicFile)
        {
            currentMusic = musicFile; // path and filename of music file to be played
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(Play));
        }

        private async void Play(Object ThreadObj)
        {
            // Check if a song is selected
            if(currentMusic == null)
            {
                return; 
            }
            Windows.Storage.StorageFile file = await StorageFile.GetFileFromPathAsync(currentMusic); // Select Windows Music folder as selected folder

            mPlayer.AutoPlay = false;
            mPlayer.Source = MediaSource.CreateFromStorageFile(file);
            mPlayer.Play();

            playing = true;
        }

        // Pauses or resumes the track
        public void PauseTrack()
        {
            if (playing)
            {
                mPlayer.Pause();
                playing = false;
            }
            else
            {
                mPlayer.Play();
                playing = true;
            }
        }
        // Change the channel of music. -1 is left 0 is middle 1 is right.
        public void ChangeChannel(int channel)
        {
            mPlayer.AudioBalance = channel;
        }

        // Toggle mute between mute and unmute
        public void ToggleMute()
        {
            //mute if unmuted
            if (mPlayer.IsMuted == false)
            {
                mPlayer.IsMuted = true;
            }
            //unmute if muted
            else if (mPlayer.IsMuted == true)
            {
                mPlayer.IsMuted = false;
            }
        }

        // Set music player to mute. True is mute false is unmute
        public void Mute(Boolean value)
        {
            mPlayer.IsMuted = value;
        }
        // Lower the volume of music player
        public void VolumeDown()
        {
            mPlayer.Volume -= 0.1;
        }
        // Higher the volume of music player
        public void VolumeUp()
        {
            mPlayer.Volume += 0.1;
        }
    }
}
