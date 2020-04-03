using MusicMixer.musiclistitems;
using MusicMixer.musicplayer;
using MusicMixer.socialmedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MUXC = Microsoft.UI.Xaml.Controls;
using System.Threading;
using MusicMixer.metronome;
using System.Diagnostics;
using ThreadState = System.Threading.ThreadState;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicMixer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private TwinPlayer twinPlayer;
        private MusicAlbum musicAL = new MusicAlbum();
        private SocialMediaHandler socialHand;
        private Thread metroThread;


        public MainPage()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            this.InitializeComponent();
            musicAL.CreateSelectFolder();
        }
        void bpmClick(object sender, RoutedEventArgs e)
        {
            playBtn.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
            Metronome patatje = new Metronome();
            if (metroThread == null)
            {
                double bpmval = bpmNumber.Value;
                metroThread = new Thread(() => patatje.Beep(bpmval));
                metroThread.Start();
            }
            
        }
    }
}