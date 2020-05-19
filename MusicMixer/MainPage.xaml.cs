using MusicMixer.metronome;
using MusicMixer.musicexplorer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Diagnostics;
using System.Reflection;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
// This page is the mainpage for the application.
namespace MusicMixer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Thread metroThread;
        public Boolean bpmStop;
        private MusicPlayer musicPlayer1 = new MusicPlayer();
        private MusicPlayer musicPlayer2 = new MusicPlayer();
        private MusicExplorer explorer;


        public MainPage()
        {

            explorer = new MusicExplorer();
            Task findMusic = new Task(async () =>
            {

                await explorer.FindNewMusic();
                //moet wachten tot task is uitgevoerd boven. anders null
                CreateDynamicListItems();

            });

            findMusic.RunSynchronously();

            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            InitializeComponent();
            bpmStop = false;

        }

        public void CreateDynamicListItems()
        {
            ListView Musicfiles = new ListView();
            Musicfiles.IsItemClickEnabled = true;
            Musicfiles.IsEnabled = true;

            //Musicfiles.ItemClick += Musicfiles_ItemClick;
            Musicfiles.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(160, 160, 160, 160));
            Musicfiles.Margin = new Thickness(50.0, 50.0, 50.0, 50.0);
            // array for testen of het werkt 
            //String[] ll = new String[] { "wdw", "aaa", "cxc", "xzx", "plo", "qwe" };
            if (explorer.MusicList.Count != 0)
            {
                foreach (var musicfile in explorer.MusicList)
                {
                    Musicfiles.Items.Add(musicfile.FileName);
                    Musicfiles.ItemClick += Musicfiles_ItemClick;
                }
                MusicItemList.Children.Add(Musicfiles);
            }
            else
            {
                for (int x = 0; x <= 20; x++)
                {
                    Musicfiles.Items.Add("NO MUSIC TRACKS FOUND");
                    Musicfiles.ItemClick += Musicfiles_ItemClick;
                }
                //Musicfiles.Items.Add("NO MUSIC TRACKS FOUND");
                MusicItemList.Children.Add(Musicfiles);
            }

        }

        private void Musicfiles_ItemClick(object sender, ItemClickEventArgs e)
        {

            String musicLibraryPath = Windows.Storage.KnownFolders.MusicLibrary.Path + e.ClickedItem.ToString();
            Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.WriteLine(musicLibraryPath);
            Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        }

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

        public void SetBpmStop()
        {
            bpmStop = false;
        }


        // Music Player 1
        private void Ply1_Click(object sender, RoutedEventArgs e)
        {
             musicPlayer1.playTrack();
        }

        private void Pz1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.PauseTrack();
        }


        private void LeftChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ChangeChannel(-1);
        }

        private void MiddleChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ChangeChannel(0);
        }

        private void RightChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ChangeChannel(+1);
        }

        private void ToggleMute1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.ToggleMute();
        }



        // Music Player 2
        private void Ply2_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.playTrack();
        }

        private void Pz2_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.PauseTrack();
        }

        private void LeftChannel2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ChangeChannel(-1);
        }

        private void MiddleChannel2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ChangeChannel(0);
        }

        private void RightChannel2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ChangeChannel(+1);
        }

        private void ToggleMute2_click(object sender, RoutedEventArgs e)
        {
            musicPlayer2.ToggleMute();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MetronomeBoxTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        
        private void MuteAll_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.Mute(true);
            musicPlayer2.Mute(true);
        }

        private void UnmuteAll_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer1.Mute(false);
            musicPlayer2.Mute(false);
        }
    }
}
