using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;

namespace MusicMixer.musicexplorer
{
    class MusicExplorer
    {
        //BIND Track to buttons in view
        public List<MusicFile> MusicList { get; set; }
        List<string> fileTypeFilter = new List<string>();
        public MusicExplorer()
        {
            MusicList = new List<MusicFile>();
            // only these types of sound types are played 
            fileTypeFilter.Add(".mp3");
            fileTypeFilter.Add(".m4a");
            fileTypeFilter.Add(".flac");
        }

        /// <summary>
        /// Takes filename out of the path name
        /// </summary>
        /// <param name="path">Complete path of song</param>
        /// <returns>Filename</returns>
        public String RetrieveMusicNameFromPath(String path)
        {
            return path.Split("/")[0];
        }

        /// <summary>
        /// Searches for music in Windows music folder
        /// </summary>
        /// <returns>List of found songs</returns>
        public async Task FindNewMusic()
        {
            QueryOptions queryOption = new QueryOptions(CommonFileQuery.OrderByTitle, fileTypeFilter)
            {
                FolderDepth = FolderDepth.Deep
            };

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
