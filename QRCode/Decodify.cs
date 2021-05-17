using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace QRCode
{
	public partial class Decodify : Form
	{
		public Decodify()
		{
			InitializeComponent();
		}

		private void Decodify_Load(object sender, EventArgs e)
		{
			//
			RichTextBox txtBoxDecodify = new RichTextBox();
			txtBoxDecodify.Width = 730;
			txtBoxDecodify.Height = 250;
			txtBoxDecodify.Location = new Point(0, 300);
			txtBoxDecodify.BackColor = Color.Black;
			txtBoxDecodify.Font = new Font("Times New Roman", 12, FontStyle.Bold);
			txtBoxDecodify.ForeColor = Color.White;
			Controls.Add(txtBoxDecodify);
			//
			//
			Width = 800;
			Height = 600;
			//Picturebox Decode
			PictureBox ptBoxDecode = new PictureBox();
			ptBoxDecode.Height = 180;
			ptBoxDecode.Width = 180;
			ptBoxDecode.Location = new Point(320, 60);
			ptBoxDecode.BackColor = Color.Navy;
			Controls.Add(ptBoxDecode);
			string imagePath = null;
			ptBoxDecode.SizeMode = PictureBoxSizeMode.StretchImage;
			//
			ptBoxDecode.Click += delegate
			{
				OpenFileDialog opFlDlg = new OpenFileDialog();
				//opFlDlg.Filter =
				if(opFlDlg.ShowDialog() == DialogResult.OK)
				{
					try
					{
						ptBoxDecode.Load(opFlDlg.FileName);
						BarcodeReader qrcodeDecode = new BarcodeReader();
						//Binarizer bin = new Binarizer();
						
						Bitmap bmpQR = new Bitmap(opFlDlg.FileName); 
						try
						{
							var result = qrcodeDecode.Decode(bmpQR);
						txtBoxDecodify.Text =	result.Text;
						}
						catch
						{

						}
					}
					catch
					{

					}
				} 
			};
			//

		

			
		}
	}
}
