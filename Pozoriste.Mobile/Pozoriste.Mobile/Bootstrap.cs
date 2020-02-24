using GalaSoft.MvvmLight.Ioc;
using Pozoriste.Mobile.Services;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste.Mobile
{
    public class Bootstrap
    {
        private static Bootstrap instance;
        /// <summary>
        /// This is a singleton instance for bootstraping the application.
        /// </summary>
        /// <value>The instance.</value>
        public static Bootstrap Instance
        {
            get
            {
                if (instance == null)
                    instance = new Bootstrap();

                return instance;
            }
        }

        /// <summary>
        /// Setup all injections
        /// </summary>
        public void Setup()
        {
            SimpleIoc.Default.Register<IDownloadService, DownloadService>();
            SimpleIoc.Default.Register<DownloadViewModel>();
        }
    }
}
