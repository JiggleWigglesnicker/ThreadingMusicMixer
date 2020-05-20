using MusicMixer.metronome;
using MusicMixer.musicexplorer;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
// This page is the mainpage for the application.
namespace MusicMixer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Thread metroThread; // Thread to beused in mainpage
        public Boolean bpmStop; // Bool to check if metronome has stopped


        private String musicLibraryPath; // Path of the musiclibrary when clicked as a listview item
        private MusicPlayer musicPlayer1 = new MusicPlayer(); // Creates instance of First musicplayer
        private MusicPlayer musicPlayer2 = new MusicPlayer(); // Creates instance of Second musicplayer 
        private MusicExplorer explorer; // Creates instance of MusicExplorer to gather and explore the Windows MusicLibrary folder


        public MainPage()
        {

            explorer = new MusicExplorer();
            // Creates takes to check and gather new musictracks multithreaded
            Task findMusic = new Task(async () =>
            {

                await explorer.FindNewMusic();  // Waits for the gathering of new musicfiles
                CreateDynamicListItems(); // Creates the listview items 

            });

            findMusic.RunSynchronously(); // Runs the task multithreaded

            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(1920, 1080); // Sets the application window to 1920 x 1080
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize; // Sets the prefered viewing mode of the app in windows.
            InitializeComponent();
            bpmStop = false; // Metronome stop flag set to false, since the metronoom isn't started yet.

        }

        /// <summary>
        /// Creates the listview and items based on the musictracks gathered in the MusicExplorer class
        /// </summary>
        public void CreateDynamicListItems()
        {

            ListView Musicfiles = new ListView // Creates the list view
            {
                // Sets the properties for the listview ands its items
                IsItemClickEnabled = true,
                IsEnabled = true,

                Background = new SolidColorBrush(Windows.UI.Color.FromArgb(160, 160, 160, 160)),
                Margin = new Thickness(50.0, 50.0, 50.0, 50.0)
            };


            if (explorer.MusicList.Count != 0)
            {
                foreach (var musicfile in explorer.MusicList) // Loops through the MusicList to obtain musictracks
                {
                    Musicfiles.Items.Add(musicfile.FileName); // Adds the musictrack as a listview item to the listview
                    Musicfiles.ItemClick += Musicfiles_ItemClick; // Binds the itemClick event to the Musicfiles_ItemClick method
                }
                MusicItemList.Children.Add(Musicfiles); // Adds the listview to the stackpanel in XAML
            }
            else
            {

                Musicfiles.Items.Add("NO MUSIC TRACKS FOUND"); //Adds warning message as a listview item
                MusicItemList.Children.Add(Musicfiles); // Adds the listview to the stackpanel in XAML
            }

        }

        /// <summary>
        /// When item is clicked in the listview, 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Musicfiles_ItemClick(object sender, ItemClickEventArgs e)
        {
            musicLibraryPath = Windows.Storage.KnownFolders.MusicLibrary.Path + e.ClickedItem.ToString();
        }

        /// <summary>
        /// When Metronoom is clicked start the metronome in a new thread
        /// When clicked again stop metronome
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BpmClick(object sender, RoutedEventArgs e)
        {
            playBtn.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
            Metronome metronome = new Metronome();
            if (metroThread == null)
            {
                double bpmval = bpmNumber.Value;
                metroThread = new Thread(() => metronome.Beep(bpmval, this));
                metroThread.Start();
            }
            else
            {
                bpmStop = true;
                metroThread = null;
            }
        }

        /// <summary>
        /// Stops the Metronome.
        /// </summary>
        public void SetBpmStop()
        {
            bpmStop = false;
        }


        /// <summary>
        /// Plays a track on the musicplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.PlayTrack(musicLibraryPath);

        }

        /// <summary>
        /// Pause or resume track button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.PauseTrack();
        }

        /// <summary>
        /// Set audio to left channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ChangeChannel(-1);
        }

        /// <summary>
        /// Set audio to middle channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiddleChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ChangeChannel(0);
        }

        /// <summary>
        /// Set audio to right channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ChangeChannel(+1);
        }

        /// <summary>
        /// Mutes the musicplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleMute1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ToggleMute();
        }

        /// <summary>
        /// Plays a track on the musicplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ply2_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.PlayTrack(musicLibraryPath);
        }

        /// <summary>
        /// Pause or resume track button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pz2_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.PauseTrack();
        }

        /// <summary>
        /// Set audio to left channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftChannel2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ChangeChannel(-1);
        }

        /// <summary>
        /// Set audio to middle channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiddleChannel2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ChangeChannel(0);
        }

        /// <summary>
        /// Sets the audio to the right channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightChannel2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ChangeChannel(+1);
        }

        /// <summary>
        /// Mutes the musicplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleMute2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ToggleMute();
        }

        /// <summary>
        /// Mutes all Musicplayers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuteAll_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.Mute(true);
            musicPlayer2.Mute(true);
        }

        /// <summary>
        /// Unmutes all musicplayers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnmuteAll_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.Mute(false);
            musicPlayer2.Mute(false);
        }

        /// <summary>
        /// Reduces the volume of the music player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeDown1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.VolumeDown();
        }

        /// <summary>
        /// Increases the volume of the musicplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeUp1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.VolumeUp();
        }

        /// <summary>
        /// Reduces the volume of the music player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeDown2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.VolumeDown();
        }

        /// <summary>
        /// Increases the volume of the musicplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeUp2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.VolumeUp();
        }

    }
}
