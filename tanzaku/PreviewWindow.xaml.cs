/*
 * SharpDevelopによって生成
 * 日付: 07/05/2018
 * 時刻: 21:59
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using System.Windows.Interop;

namespace tanzaku
{
	/// <summary>
	/// Interaction logic for PreviewWindow.xaml
	/// </summary>
	public partial class PreviewWindow : Window
	{
		public PreviewWindow()
		{
			InitializeComponent();
			//グローバル変数に格納
			nagaigoto.Text = GrovalData.Grovaltext;
			canvas.Background = GrovalData.GrovalColor;
		}
		void save_Click(object sender, RoutedEventArgs e)
		{			
			//保存する
			SaveImageFromWindow saved = new SaveImageFromWindow();
			// キャプチャ対象のXY座標を取得
			System.Windows.Point targetPoint = this.canvas.PointToScreen(new System.Windows.Point(0.0d, 0.0d));
			saved.CaptureStart(targetPoint);
		}
	}
	
	class SaveImageFromWindow : PreviewWindow
	{
		public void CaptureStart(System.Windows.Point targetPoint)
		{
			// キャプチャ対象のXY座標を取得
			// System.Windows.Point targetPoint = this.PointToScreen(new System.Windows.Point(0.0d, 0.0d));


			// キャプチャ領域の生成
			Rect targetRect = new Rect(targetPoint.X, targetPoint.Y, 200, 490);


			// 画面のキャプチャ
			BitmapSource bitmap = this.CaptureScreen(targetRect);
			
			//一番あたらしいファイルを検索
			FileNameCreate filenamecreate = new FileNameCreate();
			string newfilename = filenamecreate.NewFileName() + ".jpg";
			
			// ビットマップをPNGで保存
			using (Stream stream = new FileStream(newfilename, FileMode.Create)) {
				JpegBitmapEncoder encoder = new JpegBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(bitmap));
				encoder.Save(stream);
			}
			
			//messageを出す
			MessageBox.Show("ほぞんしました！");
			//閉じる
			Environment.Exit(0);
		}

		public BitmapSource CaptureScreen(Rect rect)
		{
			// 引数rectの領域をキャプチャする
			using (var screenBmp = new Bitmap((int)rect.Width, (int)rect.Height,
				                       System.Drawing.Imaging.PixelFormat.Format32bppArgb)) {
				using (var bmpGraphics = Graphics.FromImage(screenBmp)) {
					// キャプチャ結果をBitmapSourceで返す
					bmpGraphics.CopyFromScreen((int)rect.X, (int)rect.Y, 0, 0, screenBmp.Size);
					return Imaging.CreateBitmapSourceFromHBitmap(screenBmp.GetHbitmap(),
						IntPtr.Zero, Int32Rect.Empty,
						BitmapSizeOptions.FromEmptyOptions());
				}
			}
		}
	}
		
	class FileNameCreate
	{
		private int GetLastFiles()
		{
			
			string[] files = Directory.GetFiles(
				                 @"Z:\パソコン部\文化祭発表用\tanzakuimages", "*.jpg", SearchOption.AllDirectories);
			//とりあえずファイルの数字を列挙する
			int[] filenumbers = new int[files.Length];
			for (int i = 0; i < files.Length; i++) {
				filenumbers[i] = int.Parse(Path.GetFileNameWithoutExtension(files[i]));
			}
			return Max(filenumbers);
		}
		
		//最大値を出す
		public int Max(params int[] nums)
		{
			// 引数が渡されない場合
			if (nums.Length == 0)
				return 0;

			int max = nums[0];
			for (int i = 1; i < nums.Length; i++) {
				max = max > nums[i] ? max : nums[i];
				// Minの場合は不等号を逆にすればOK
			}
			return max;
		}
		public int NewFileName()
		{
			Console.WriteLine(GetLastFiles() + 1);
			return GetLastFiles() + 1;
		}
	}
}