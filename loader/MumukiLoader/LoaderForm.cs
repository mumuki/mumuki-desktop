using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using MumukiLoader.Core;
using MumukiLoader.Core.Steps;

namespace MumukiLoader {
	public partial class LoaderForm : Form {
		private bool loaded;

		public LoaderForm() {
			InitializeComponent();
		}

		private async void LoaderForm_Shown(object sender, EventArgs e)
		{
			lblPleaseWait.Text = Locales.ValueFor("PreparingThings");
			lblState.Text = Locales.ValueFor("Loading");

			this.createSelfShortcutOnDesktop();
			var result = await new Loader(new TextBoxLogger(this.txtShell)).LoadAll();
			tweakUiFor(result);
			if (result == Result.Success) Application.Exit();
		}

		private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (!this.loaded) e.Cancel = true;
		}

		private void txtShell_TextChanged(object sender, EventArgs e) {
			txtShell.SelectionStart = txtShell.Text.Length;
			txtShell.ScrollToCaret();
		}

		private void tmrFakeProgress_Tick(object sender, EventArgs e) {
			prgProgress.Value += 1;
			if (prgProgress.Value >= prgProgress.Maximum)
				prgProgress.Value = 0;
		}

		private void tweakUiFor(Result result)
		{
			lblState.Text = Locales.ValueFor(result.ToStatusString());
			this.loaded = true;
			prgProgress.Value = 100;
			tmrFakeProgress.Enabled = false;
		}

		private void createSelfShortcutOnDesktop() {
			const string DESCRIPTION = "Mumuki";
			var shortcutLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{DESCRIPTION}.lnk");
			var shortcutTarget = Assembly.GetExecutingAssembly().Location;
			var shortcutFolder = Path.GetDirectoryName(shortcutTarget);
			var shell = new WshShell();

			var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
			shortcut.TargetPath = shortcutTarget;
			shortcut.WorkingDirectory = shortcutFolder;
			shortcut.Description = DESCRIPTION;
			shortcut.IconLocation = $@"{shortcutFolder}\logo.ico";
			shortcut.Save();
		}
	}
}
