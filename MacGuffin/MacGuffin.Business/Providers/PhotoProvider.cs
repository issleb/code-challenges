using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MacGuffin.Models;

namespace MacGuffin.Business.Providers
{
    public interface IPhotoProvider
    {
        List<Photo> GetPhotos(IEnumerable<string> fileNames);
    }

    public class PhotoProvider : IPhotoProvider
    {
        public List<Photo> GetPhotos(IEnumerable<string> fileNames)
        {
            var photos = fileNames.Select(GetPhoto).ToList();

            return photos;
        }

        #region Private

        private Photo GetPhoto(string fileName)
        {
            var photo = new Photo()
            {
                FileName = fileName
            };
            if (string.IsNullOrEmpty(fileName)) return photo;


            var name = Path.GetFileNameWithoutExtension(fileName).ToLower();           
            
            var firstIndex = name.IndexOf("-");

            if (firstIndex == -1)
            {
                photo.ProductNumber = name;
                return photo;
            }

            photo.ProductNumber = name.Remove(firstIndex);

            var sizes = Constants.Sizes.Where(name.ToLower().Contains).ToList();
            if (sizes.Count > 0) photo.Size = sizes.Count == 1 ? sizes.Single() : sizes.Single(x => x.Contains("x-"));

            if (photo.Size != null)
            {
                if (name.Length > photo.ProductNumber.Length + photo.Size.Length + 1)
                {
                    var sizeIndex = name.IndexOf(photo.Size);
                    photo.Color = name.Substring(sizeIndex + photo.Size.Length + 1);
                }
            }
            else
            {
                photo.Color = name.Substring(photo.ProductNumber.Length + 1);
            }

            return photo;
        }

        #endregion
    }
  
}
