using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualStudio.WebHost;
using System.Configuration;
using CefSharp.WinForms;
using CefSharp;
using System.Threading;
using System.Threading.Tasks;
using AdminKiosco.Launcher.Controls;

namespace AdminKiosco.Launcher
{
    public partial class MainForm : Form
    {
        private readonly ChromiumWebBrowser _browser;
        private string _sitePath { get; set; }
        private string _virtualDirPath { get; set; }
        private int _port { get; set; }
        private Server _server { get; set; }

        private string _defaultURL
        {
            get
            {
                return "http://localhost:" + _port + _virtualDirPath + "index.html";
            }
        }

        public MainForm()
        {
            InitializeComponent();

            Load += _browserFormLoad;

            Text = "Cooperativa de Paradas";
            WindowState = FormWindowState.Maximized;

            _sitePath = System.Configuration.ConfigurationManager.AppSettings["SitePath"];
            _virtualDirPath = System.Configuration.ConfigurationManager.AppSettings["VirtualPath"];
            var port = System.Configuration.ConfigurationManager.AppSettings["Port"];
            if (string.IsNullOrEmpty(port))
            {
                _port = 80;
            }
            else
            {
                _port = Convert.ToInt16(port);
            }

            try
            {
                Thread th = new Thread(new ParameterizedThreadStart(StartServer));
                th.Start();



                _browser = new ChromiumWebBrowser(_defaultURL)
                {
                    Dock = DockStyle.Fill,
                };
                toolStripContainer.ContentPanel.Controls.Add(_browser);

                _browser.DownloadHandler = new DownloadHandler();
                _browser.MenuHandler = new MenuHandler();
                _browser.NavStateChanged += On_browserNavStateChanged;
                _browser.ConsoleMessage += On_browserConsoleMessage;
                _browser.TitleChanged += On_browserTitleChanged;

                var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);
                DisplayOutput(version);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error intentando abrir la aplicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitMenuItemClick(null, null);
            }

        }

        private void StartServer(object obj)
        {
            _server = new Server(_port, _virtualDirPath, _sitePath);
            _server.Start();
        }


        private void _browserFormLoad(object sender, EventArgs e)
        {
            ToggleBottomToolStrip();
        }

        private void On_browserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void On_browserNavStateChanged(object sender, NavStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }

        private void On_browserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }

        private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => backButton.Enabled = canGoBack);
        }

        private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => forwardButton.Enabled = canGoForward);
        }

        private void SetIsLoading(bool isLoading)
        {
            goButton.Text = isLoading ?
                "Stop" :
                "Go";

            HandleToolStripLayout();
        }

        public void ExecuteScript(string script)
        {
            _browser.ExecuteScriptAsync(script);
        }

        public object EvaluateScript(string script)
        {
            return _browser.EvaluateScript(script);
        }

        public void DisplayOutput(string output)
        {
            this.InvokeOnUiThreadIfRequired(() => outputLabel.Text = output);
        }

        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }

        private void HandleToolStripLayout()
        {
            var width = toolStrip1.Width;
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            _server.Stop();
            _browser.Dispose();
            Cef.Shutdown();
            Close();
        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            LoadUrl(_defaultURL);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            _browser.Back();
        }

        private void ForwardButtonClick(object sender, EventArgs e)
        {
            _browser.Forward();
        }

        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                _browser.Load(url);
            }
        }

        private void FindCloseButtonClick(object sender, EventArgs e)
        {
            ToggleBottomToolStrip();
        }

        private void FindMenuItemClick(object sender, EventArgs e)
        {
            ToggleBottomToolStrip();
        }

        private void ToggleBottomToolStrip()
        {
            if (toolStripContainer.BottomToolStripPanelVisible)
            {
                _browser.StopFinding(true);
                toolStripContainer.BottomToolStripPanelVisible = false;
            }
            else
            {
                toolStripContainer.BottomToolStripPanelVisible = true;
                findTextBox.Focus();
            }
        }

        private void FindNextButtonClick(object sender, EventArgs e)
        {
            Find(true);
        }

        private void FindPreviousButtonClick(object sender, EventArgs e)
        {
            Find(false);
        }

        private void Find(bool next)
        {
            if (!string.IsNullOrEmpty(findTextBox.Text))
            {
                _browser.Find(0, findTextBox.Text, next, false, false);
            }
        }

        private void FindTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            Find(true);
        }

        private void CopySourceToClipBoardAsyncClick(object sender, EventArgs e)
        {
            var task = _browser.GetSourceAsync();

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    Clipboard.SetText(t.Result);
                    DisplayOutput("HTML Source copied to clipboard");
                }
            },
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.Stop();
            _browser.Dispose();
            Cef.Shutdown();
        }
    }
}