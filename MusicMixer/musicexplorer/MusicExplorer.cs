using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;

namespace MusicMixer.musicexplorer
{
    class MusicExplorer
    {
        /// <summary>
        /// List that will contain all of the musicfiles retrieved from the Windows MusicLibrary.
        /// </summary>
        public List<MusicFile> MusicList { get; set; }

        /// <summary>
        /// List that will store the file extension filters for filtering the desired files from the Windows MusicLibrary
        /// </summary>
        List<string> fileTypeFilter = new List<string>();
        public MusicExplorer()
        {
            
            MusicList = new List<MusicFile>(); // MusicList is instanciated.
            fileTypeFilter.Add(".mp3"); // only these types of extensions types are played and filters are added to filter list.
            fileTypeFilter.Add(".m4a");
            fileTypeFilter.Add(".flac");
        }

        /// <summary>
        /// Takes filename out of the path name.
        /// </summary>
        /// <param name="path">Complete path of song</param>
        /// <returns>Filename</returns>
        public String RetrieveMusicNameFromPath(String path)
        {
            return path.Split("/")[0];
        }

        /// <summary>
        /// Searches for music in Windows music folder.
        /// </summary>
        /// <returns>List of found songs</returns>
        public async Task FindNewMusic()
        {
            
            QueryOptions queryOption = new QueryOptions(CommonFileQuery.OrderByTitle, fileTypeFilter) //Adds the filtertypes from the filterlist to the queryOption object
            {
                FolderDepth = FolderDepth.Deep //Folderdepth is also set to deep, therefore all folders and subfolders are searched and filtered on their file extension.
            };

            Queue<IStorageFolder> folders = new Queue<IStorageFolder>(); // Collection of all folders to be searched

            
            var files = await KnownFolders.MusicLibrary.CreateFileQueryWithOptions
                (queryOption).GetFilesAsync(); //Aplies filters to all of the folders in the Windows Music Library, and gets the files that were filtered.

            foreach (var musictrack in files) //Retrieves the obtained files from the MusicLibrary
            {
                MusicFile musicfile = new MusicFile(musictrack.Path, RetrieveMusicNameFromPath(musictrack.Path)); //wraps the files into the MusicFile class
                MusicList.Add(musicfile); // adds the MusicFile to the MusicList;
            }
        }
    }
}
