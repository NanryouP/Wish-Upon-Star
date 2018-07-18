/*
 * SharpDevelopによって生成
 * 日付: 2018/07/05
 * 時刻: 21:09
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

namespace tanzaku
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			GrovalData.GrovalColor = (SolidColorBrush)button.Background;
			Window window = new inputwindow();
			window.Show();
		}
	}
}