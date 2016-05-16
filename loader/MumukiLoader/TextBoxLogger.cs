using System.Windows.Forms;
using MumukiLoader.Core;

namespace MumukiLoader
{
	public class TextBoxLogger : Logger
	{
		private readonly TextBox textBox;

		public TextBoxLogger(TextBox textBox)
		{
			this.textBox = textBox;
		}

		public string Text
		{
			get { return this.textBox.Text; }
			set { this.textBox.Text = value; }
		}
	}
}
