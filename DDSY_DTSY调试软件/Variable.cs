using System.Runtime.InteropServices;

namespace DDSY_DTSY调试软件;

internal class Variable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PortSet
	{
		public static string PortNumber = "COM1";

		public static string PortBaud = "9600";

		public static string PortData = "8";

		public static string PortStop = "1";

		public static string PortCheck = "N";
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MessageSet
	{
		public static string func = "03";

		public static string Reg = "512";

		public static string Reg1 = "256";

		public static string RegCount = "48";

		public static string RegCount1 = "07";
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct InitPara
	{
		public static short Un;

		public static short Ib;

		public static short Ec;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ReadInCorrect
	{
		public static byte func = 19;

		public static byte RegH = 1;

		public static byte RegL = 0;

		public static byte RegCountH = 0;

		public static byte RegCountL = 9;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ChangePortSet
	{
		public static byte func = 16;

		public static byte RegH = 0;

		public static byte RegL = 154;

		public static byte RegCountH = 0;

		public static byte RegCountL = 1;

		public static byte ByteCount = 2;

		public static byte Addr;

		public static byte Baud;

		public static byte CheckType;

		public static byte StopBits;

		public static byte MeterID = 153;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CorrectTime
	{
		public static byte func = 6;

		public static byte RegH = 0;

		public static byte RegL = 60;

		public static byte RegCountH = 0;

		public static byte RegCountL = 3;

		public static byte ByteCount = 6;

		public static byte Second;

		public static byte Minute;

		public static byte Hour;

		public static byte Day;

		public static byte Month;

		public static byte Year;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DIState
	{
		public static byte DI1State;

		public static byte DI1Program;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DOState
	{
		public static byte DO1State;

		public static byte DO1Program;

		public static byte DO1Pulse;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CTSet
	{
		public static int PT;

		public static int CT1;

		public static int LCD;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct AlarmSet
	{
		public static int VoltageHigh;

		public static int VoltageHighDelay;

		public static int CurentHigh;

		public static int CurentHighDelay;

		public static int VoltageLow;

		public static int VoltageLowDelay;

		public static int CurentLow;

		public static int CurentLowDelay;

		public static ushort AlarmEN;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TimeZone
	{
		public static byte Schedule1;

		public static byte Schedule2;

		public static byte Schedule3;

		public static byte Schedule4;

		public static byte Day1;

		public static byte Day2;

		public static byte Day3;

		public static byte Day4;

		public static byte Month1;

		public static byte Month2;

		public static byte Month3;

		public static byte Month4;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TimeSchedule
	{
		public static byte Price1;

		public static byte Price2;

		public static byte Price3;

		public static byte Price4;

		public static byte Price5;

		public static byte Price6;

		public static byte Price7;

		public static byte Price8;

		public static byte Price9;

		public static byte Price10;

		public static byte Price11;

		public static byte Price12;

		public static byte Price13;

		public static byte Price14;

		public static byte Minute1;

		public static byte Minute2;

		public static byte Minute3;

		public static byte Minute4;

		public static byte Minute5;

		public static byte Minute6;

		public static byte Minute7;

		public static byte Minute8;

		public static byte Minute9;

		public static byte Minute10;

		public static byte Minute11;

		public static byte Minute12;

		public static byte Minute13;

		public static byte Minute14;

		public static byte Hour1;

		public static byte Hour2;

		public static byte Hour3;

		public static byte Hour4;

		public static byte Hour5;

		public static byte Hour6;

		public static byte Hour7;

		public static byte Hour8;

		public static byte Hour9;

		public static byte Hour10;

		public static byte Hour11;

		public static byte Hour12;

		public static byte Hour13;

		public static byte Hour14;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct THD
	{
		public static int THDNum;

		public static int THDUa;

		public static int THDUb;

		public static int THDUc;

		public static int THDIa;

		public static int THDIb;

		public static int THDIc;
	}

	public static int IsRightAddr = 0;

	public static int IsPortOpen = 0;

	public static int MessageType = 0;

	public static string Address = "1";

	public static string TempAddress = "";

	public static byte AddrInADF = 0;

	public static byte[] AllSetResult = new byte[12];

	public static bool IsContinue = false;

	public static bool IsGiveUp = false;

	public static bool AutoCorrectFlag = false;

	public static bool Form2IsOpen = false;

	public static bool CorrectIsResponse = false;

	public static bool CorrectIsOver = false;

	public static bool Is485_2 = false;

	public static byte[] MeterIDToSet = new byte[6];

	public static byte[] UserIDToSet = new byte[6];

	public static byte RunCtrl_High;

	public static byte RunCtrl_Low;

	public static int ResLength;

	public static bool LenWrong = false;

	public static int FreezeDayTime;

	public static int FreezeMonthDay;

	public static int FreezeMonthTime;

	public static string Type = "商业版";
}
