using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CefSharp;

namespace AdminKiosco.Launcher
{
    internal class MenuHandler : IMenuHandler
    {
        public bool OnBeforeContextMenu(IWebBrowser browser)
        {
            // Return false if you want to disable the context menu.
            return true;
        }
    }
}
