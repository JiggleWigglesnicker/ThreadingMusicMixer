using MusicMixer.musicplayer;
using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Threading;
using MusicMixer.metronome;

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
        public  Boolean bpmStop;
        private MusicPlayer musicPlayer = new MusicPlayer();

        public MainPage()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            this.InitializeComponent();
            bpmStop = false;
        }
        void bpmClick(object sender, RoutedEventArgs e)
        {
            playBtn.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
            Metronome patatje = new Metronome();
            if (metroThread == null)
            {
                double bpmval = bpmNumber.Value;
                metroThread = new Thread(() => patatje.Beep(bpmval, this));
                metroThread.Start();
            } else
            {
                bpmStop = true;
                metroThread = null;
            }
        }

        public void setBpmStop ()
        {
            this.bpmStop = false;
        }

        private async void ply1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.playTrack();
        }

        private void pz1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.pauzeTrack();
        }

        private void stp1_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.stopTrack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}