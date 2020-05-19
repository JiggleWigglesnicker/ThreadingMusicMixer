using MusicMixer.metronome;
using MusicMixer.musicexplorer;
using MusicMixer.musicexplorer;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.Threading;
using Windows.Foundation;
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
        private Thread metroThread;
        public Boolean bpmStop;
        private MusicPlayer musicPlayer = new MusicPlayer();
        private MusicExplorer explorer;
        private FolderExplorer folder;

        public MainPage()
        {
            folder = new FolderExplorer();
            explorer = new MusicExplorer();
            int nn = explorer.MusicList.Count;
            ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            InitializeComponent();
            bpmStop = false;

            
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

        private async void Ply1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.playTrack();
        }

        private void Pz1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.pauzeTrack();
        }

        private void stp1_Click(object sender, RoutedEventArgs e)
        {
            //musicPlayer.stopTrack();
        }

        private void LeftChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer.changeChannel(-1);
        }

        private void MiddleChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer.changeChannel(0);
        }

        private void RightChannel1_click(object sender, RoutedEventArgs e)
        {
            musicPlayer.changeChannel(+1);
        }

        private void ToggleMute_click(object sender, RoutedEventArgs e)
        {
            musicPlayer.toggleMute();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MetronomeBoxTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}