using System;
using System.Collections.Generic;
using System.Linq;

namespace MacGuffin.Models
{
    public class Photo
    {
        public string FileName      { get; set; }
        public string ProductNumber { get; set; }
        public string Size          { get; set; }
        public string Color         { get; set; }

        public string FullName
        {
            get
            {
                var name = GetName(Size);
                if (!string.IsNullOrEmpty(Color)) name = name + "-" + Color;

                return name;
            }
        }

        public string SizeName
        {
            get { return string.IsNullOrEmpty(Size) ? string.Empty : GetName(Size); }
        }

        public string ColorName
        {
            get { return string.IsNullOrEmpty(Color) ? string.Empty : GetName(Color); }
        }

        #region Private

        private string GetName(string descriptor)
        {
            var name = ProductNumber ?? string.Empty;
            if (!string.IsNullOrEmpty(descriptor)) name = name + "-" + descriptor;

            return name;
        }

        #endregion
    }
}
