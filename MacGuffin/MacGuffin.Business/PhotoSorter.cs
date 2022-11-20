using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MacGuffin.Business.Providers;
using MacGuffin.Models;

namespace MacGuffin.Business
{
    public interface IPhotoSorter
    {
        void SortPhotos(string filesPath, string categoriesPath);
    }

    public class PhotoSorter : IPhotoSorter
    {
        private readonly IPhotoProvider _photoProvider;
        private readonly IFileProvider _fileProvider;

        private string _filesPath;
        private string _categoriesPath;

        public PhotoSorter(IPhotoProvider photoProvider, IFileProvider fileProvider)
        {
            _photoProvider = photoProvider;
            _fileProvider = fileProvider;
        }

        public void SortPhotos(string filesPath, string categoriesPath)
        {
            _filesPath = filesPath;
            _categoriesPath = categoriesPath;

            var fileNames = _fileProvider.GetFileNames(_filesPath);
            var categoryNames = _fileProvider.GetFolderNames(_categoriesPath);

            var photos = _photoProvider.GetPhotos(fileNames);

            foreach (var photo in photos)
            {
                var categoryName = categoryNames.FirstOrDefault(x => x.ToLower() == photo.FullName);
                if (categoryName != null)
                {
                    CopyPhoto(photo, categoryName);
                    continue;
                }

                categoryName = categoryNames.FirstOrDefault(x => x.ToLower() == photo.SizeName);
                if (categoryName != null)
                {
                    CopyPhoto(photo, categoryName);
                    continue;
                }

                categoryName = categoryNames.FirstOrDefault(x => x.ToLower() == photo.ColorName);
                if (categoryName != null)
                {
                    CopyPhoto(photo, categoryName);
                    continue;
                }

                categoryName = categoryNames.FirstOrDefault(x => x.ToLower() == photo.ColorName);
                if (categoryName != null)
                {
                    CopyPhoto(photo, categoryName);
                    continue;
                }

                categoryName = categoryNames.FirstOrDefault(x => x.ToLower() == photo.ProductNumber);
                if (categoryName != null)
                {
                    CopyPhoto(photo, categoryName);
                }
            }
        }

        #region Private

        private void CopyPhoto(Photo file, string categoryName)
        {
            var originalPath = Path.Combine(_filesPath, file.FileName);
            var newPath = Path.Combine(_categoriesPath, categoryName);
            _fileProvider.CopyToFolder(originalPath, newPath);
        }

        #endregion

    }


}
