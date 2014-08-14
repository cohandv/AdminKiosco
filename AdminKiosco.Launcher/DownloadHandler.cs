using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CefSharp;

namespace AdminKiosco.Launcher
{
    public class DownloadHandler : IDownloadHandler
    {
        public bool OnBeforeDownload(DownloadItem downloadItem, out string downloadPath, out bool showDialog)
        {
            downloadPath = downloadItem.SuggestedFileName;
            showDialog = true;

            return true;
        }

        public bool OnDownloadUpdated(DownloadItem downloadItem)
        {
            return false;
        }
    }

}
