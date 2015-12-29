using System;
using System.Windows.Forms;
using MjpegStreamProcessor;

namespace MjpegProcessorTestWinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
            this.image.SizeMode = PictureBoxSizeMode.Zoom;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
            MjpegStreamDecoder mjpeg = new MjpegStreamDecoder();
			mjpeg.FrameReady += mjpeg_FrameReady;
			mjpeg.Error += mjpeg_Error;
            mjpeg.ParseStream(new Uri("http://10.1.16.48:10086/?action=stream"));
		}

		private void mjpeg_FrameReady(object sender, FrameReadyEventArgs e)
		{
			image.Image = e.Bitmap;
		}

		void mjpeg_Error(object sender, ErrorEventArgs e)
		{
			MessageBox.Show(e.Message);
		}
	}
}
