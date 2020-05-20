using System;
using System.Threading;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;

namespace MusicMixer.musicexplorer
{
    class MusicPlayer
    {
        readonly MediaPlayer mPlayer; // the mediaplayer
        bool playing;   // bool to check if mediaplayer is playing
        String currentMusic; // currentsong being played

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
            
            if(currentMusic == null) // Check if a song is selected
            {
                return; 
            }
            Windows.Storage.StorageFile file = await StorageFile.GetFileFromPathAsync(currentMusic); // Select Windows Music folder as selected folder

            mPlayer.AutoPlay = false; // disables autoplay from mPlayer
            mPlayer.Source = MediaSource.CreateFromStorageFile(file); // creates a mediasource for mPlayer
            mPlayer.Play(); // plays the mPlayer

            playing = true;
        }

        /// <summary>
        /// Pauses or resumes the track
        /// </summary>
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
        /// <summary>
        /// Change the channel of music. -1 is left 0 is middle 1 is right.
        /// </summary>
        public void ChangeChannel(int channel)
        {
            mPlayer.AudioBalance = channel;
        }

        /// <summary>
        /// Toggle mute between mute and unmute
        /// </summary>
        public void ToggleMute()
        {
            
            if (mPlayer.IsMuted == false) //mute if unmuted
            {
                mPlayer.IsMuted = true;
            }
            else if (mPlayer.IsMuted == true) //unmute if muted
            {
                mPlayer.IsMuted = false;
            }
        }

        /// <summary>
        /// Set music player to mute.
        /// </summary>
        /// <param name="value">True is mute false is not muted</param>
        public void Mute(Boolean value)
        {
            mPlayer.IsMuted = value;
        }
        /// <summary>
        /// Lower the volume of music player
        /// </summary>
        public void VolumeDown()
        {
            mPlayer.Volume -= 0.1;
        }
        /// <summary>
        /// Raise the volume of music player
        /// </summary>
        public void VolumeUp()
        {
            mPlayer.Volume += 0.1;
        }
    }
}
