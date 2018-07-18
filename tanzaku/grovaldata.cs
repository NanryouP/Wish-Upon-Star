/*
 * SharpDevelopによって生成
 * 日付: 07/05/2018
 * 時刻: 21:29
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Media;
namespace tanzaku
{
	/// <summary>
	///グローバル変数
	/// </summary>
	public static class GrovalData
	{
		private static SolidColorBrush _GrovalColor;
		
		//共有カラー
		public static SolidColorBrush GrovalColor {
			get{ return _GrovalColor; }
			set{ _GrovalColor = value; }
		}
		
		//共有文字
		private static string _Grovaltext;
		public static string Grovaltext {
			get{ return _Grovaltext; }
			set {
				ChengeTategaki changetategaki = new ChengeTategaki();
				_Grovaltext = changetategaki.textbox_tategaki(value);
			}
		}
	}
	
	/// <summary>
	/// 縦書きへ変換
	/// </summary>
	public class ChengeTategaki
	{
		public string textbox_tategaki(String str)
		{
			string resulttext = "";
			for (int i = 0; i < str.Length; i++) {
				resulttext += str[i];
				resulttext += '\n';
			}
			return resulttext;
		}
	}
}
