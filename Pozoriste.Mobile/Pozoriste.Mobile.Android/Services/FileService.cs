using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Pozoriste.Mobile.Services;

namespace PlesnaSkola.Mobile.Droid.Services
{
    public class FileService : IFileService
    {
        public string GetStorageFolderPath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
    }
}