using MusicMixer.musicexplorer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;
using System.Diagnostics;
using Windows.ApplicationModel.Store.Preview.InstallControl;

namespace MusicMixer.musicexplorer
{
    class MusicExplorer
    {

        //BIND Track to buttons in view
        public List<MusicFile> MusicList { get; set; }
        public MusicExplorer()
        {
            MusicList = new List<MusicFile>();
        }

        public String RetrieveMusicNameFromPath(String path)
        {
            return path.Split("/")[0];
        }


        public async Task FindNewMusic()
        {
            QueryOptions queryOption = new QueryOptions(CommonFileQuery.OrderByTitle, new string[] { ".mp3" });

            queryOption.FolderDepth = FolderDepth.Deep;

            Queue<IStorageFolder> folders = new Queue<IStorageFolder>();


            var files = await KnownFolders.MusicLibrary.CreateFileQueryWithOptions
                (queryOption).GetFilesAsync();


            foreach (var musictrack in files)
            {
                MusicFile musicfile = new MusicFile(musictrack.Path, RetrieveMusicNameFromPath(musictrack.Path));
                MusicList.Add(musicfile);

            }

        }

    }
}
