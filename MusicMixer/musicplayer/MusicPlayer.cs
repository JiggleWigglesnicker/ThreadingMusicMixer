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
            currentMusic = musicFile;
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(Play));
        }
        
        private async void Play(Object ThreadObj)
        {
            if(currentMusic == null)
            {
                return;
            }
            Windows.Storage.StorageFile file = await StorageFile.GetFileFromPathAsync(currentMusic);

            mPlayer.AutoPlay = false;
            mPlayer.Source = MediaSource.CreateFromStorageFile(file);
            mPlayer.Play();

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

        /// <summary>
        /// Set music player to mute.
        /// </summary>
        /// <param name="value">True is mute false is unmute</param>
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
