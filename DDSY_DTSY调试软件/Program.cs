using System;
using System.Windows.Forms;

namespace DDSY_DTSY调试软件;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run((Form)(object)new ADF400读取DIDO());
	}
}
