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

namespace QRCode
{
	public partial class Codify : Form
	{
		public Codify()
		{
			InitializeComponent();
		}
		PictureBox qrCode = new PictureBox();
		RichTextBox txtBoxCodify = new RichTextBox();
		Button btnLoadImage = new Button();
		Button btnBarCodeTransform = new Button();
		private void Codify_Load(object sender, EventArgs e)
		{
			Width = 800;
			Height = 600;
			MinimizeBox = false;
			MaximizeBox = false;
			//Set the components into screen
			//Picturebox
			
			qrCode.Height = 180;
			qrCode.Width = 180;
			qrCode.Location = new Point(320, 60);
			qrCode.BackColor = Color.Blue;
			qrCode.Visible = true;
			qrCode.SizeMode = PictureBoxSizeMode.StretchImage;
			
			Controls.Add(qrCode);

		
			//TextBox Codify
			
			txtBoxCodify.Width = 730;
			txtBoxCodify.Height = 250;
			txtBoxCodify.Location = new Point(0, 300);
			txtBoxCodify.BackColor = Color.Black;
			txtBoxCodify.Font = new Font("Times New Roman", 12, FontStyle.Bold);
			txtBoxCodify.ForeColor = Color.White;
			txtBoxCodify.TextChanged += delegate
			{
				CreateQRCode(txtBoxCodify.Text);
			};
			Controls.Add(txtBoxCodify);
			//Button Load Image
			
			btnLoadImage.Width = 50;
			btnLoadImage.Height = 30;
			btnLoadImage.AutoSize = true;
			btnLoadImage.Location = new Point(120, 60);
			/*Color*/
			/*Font*/
			/*Forecolor*/
			btnLoadImage.Text = "Carregar a Partir de Uma Imagem";
			Controls.Add(btnLoadImage);

			//Button Save Image
			Button buttonSaveImage = new Button();

			buttonSaveImage.Width = 50;
			buttonSaveImage.Height = 30;
			buttonSaveImage.AutoSize = true;
			buttonSaveImage.Location = new Point(120, 90);
			/*Color*/
			/*Font*/
			/*Forecolor*/
			buttonSaveImage.Text = "Salvar QR code";
			Controls.Add(buttonSaveImage);
			buttonSaveImage.Click += delegate
			{
				SaveFileDialog saveQRCode = new SaveFileDialog();
				saveQRCode.DefaultExt = ".jpg";
				saveQRCode.AddExtension = true;
				//Saves the file
				if(saveQRCode.ShowDialog() == DialogResult.OK)
				{
					qrCode.Image.Save(saveQRCode.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

				}
				
			};

			//Transforms the qr code into a barcode
			btnBarCodeTransform.Width = 50;
			btnBarCodeTransform.Height = 30;
			btnBarCodeTransform.AutoSize = true;
			btnBarCodeTransform.Location = new Point(590, 60);
			/*Color*/
			/*Font*/
			/*Forecolor*/
			btnBarCodeTransform.Text = "Transformar em Código de Barras";
			Controls.Add(btnBarCodeTransform);
			btnBarCodeTransform.Click += delegate
			{
				BarcodeWriter createBarcode = new BarcodeWriter();
				createBarcode.Format = BarcodeFormat.MAXICODE;
				try
				{
					qrCode.Image = createBarcode.Write(txtBoxCodify.Text);
				}
				catch
				{

				}
				
			};

			
		}
		
		private void CreateQRCode(string value1)
		{
			try
			{
				MessagingToolkit.QRCode.Codec.QRCodeEncoder qrCodeCodify = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
			//	qrCodeCodify.QRCodeForegroundColor = Color.Azure;
		//		qrCodeCodify.QRCodeBackgroundColor = Color.Black;
				qrCode.Image = qrCodeCodify.Encode(value1);
			
			}
			catch
			{

			}
		
		}
	}
}
