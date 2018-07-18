/*
 * SharpDevelopによって生成
 * 日付: 07/05/2018
 * 時刻: 21:41
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
using System.Runtime.InteropServices;
namespace tanzaku
{
	/// <summary>
	/// Interaction logic for inputwindow.xaml
	/// </summary>
	public partial class inputwindow : Window
	{
		public inputwindow()
		{
			InitializeComponent();
			
			textbox.Text= "ねがいごとをにゅうりょくしてね!";
		}
		void OK_Click(object sender, RoutedEventArgs e)
		{
			GrovalData.Grovaltext = textbox.Text;
			Window preview = new PreviewWindow();
			preview.Show();
		}
		void Textbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			hankakuzenkaku zenkaku = new hankakuzenkaku();
			zenkaku.change();
			textbox.Clear();
		}

	}
	/// <summary>
	/// 半角全角切り替え
	/// </summary>
	class hankakuzenkaku
	{
		[DllImport("user32.dll")]
        public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public void change()
        {
        	keybd_event(0xF3,0,0,(UIntPtr)0);
        }
	}
}