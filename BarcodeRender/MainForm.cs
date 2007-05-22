using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Zen.Barcode;

namespace BarcodeRender
{
	/// <summary>
	/// <c>MainForm</c> implements the barcode test form.
	/// </summary>
	public partial class MainForm : Form
	{
		private Image _current;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		public MainForm ()
		{
			InitializeComponent ();
		}

		private void refreshButton_Click (object sender, EventArgs e)
		{
			try
			{
				switch (symbology.SelectedIndex)
				{
					case 0:
						_current = BarcodeDrawFactory.Code39WithoutChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 1:
						_current = BarcodeDrawFactory.Code39WithChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 2:
						_current = BarcodeDrawFactory.Code93WithChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 3:
						_current = BarcodeDrawFactory.Code128WithChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 4:
						_current = BarcodeDrawFactory.Code11WithoutChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 5:
						_current = BarcodeDrawFactory.Code11WithChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 6:
						_current = BarcodeDrawFactory.CodeEan13WithChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					case 7:
						_current = BarcodeDrawFactory.CodeEan8WithChecksum.Draw (
							barcodeText.Text,
							(int) minHeight.Value, (int) maxHeight.Value,
							(int) minWidth.Value, (int) maxWidth.Value);
						break;
					default:
						return;
				}
			}
			catch (Exception error)
			{
				MessageBox.Show (this, string.Format (
					"Failed to regenerate bar-code\n{0}\nStack Trace:\n{1}",
					error.Message, error.StackTrace), "Barcode Render Error");
				return;
			}
			barcodePanel.Invalidate ();
		}

		private void barcodePanel_Paint (object sender, PaintEventArgs e)
		{
			if (_current != null)
			{
				Graphics dc = e.Graphics;
				dc.DrawImage (_current, new Point (0, 0));
			}
		}

		private void Form1_Load (object sender, EventArgs e)
		{

		}
	}
}