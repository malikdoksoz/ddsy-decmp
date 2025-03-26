using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DDSY_DTSY调试软件;

public class ADF400读取DIDO : Form
{
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
	public struct CorrectTime
	{
		public static byte Second;

		public static byte Minute;

		public static byte Hour;

		public static byte Day;

		public static byte Month;

		public static byte Year;

		public static byte DayOfWeek;
	}

	private byte[] MeterIDToSet = new byte[8];

	private byte MeterType;

	private byte MeterType2;

	private byte IS3P;

	private byte[] AllSetResult = new byte[12];

	private Modbus m = new Modbus();

	private DateTime dh = default(DateTime);

	public static uint[] SysKey = new uint[4] { 24931u, 29285u, 27699u, 12849u };

	private bool PortIsAvailable = false;

	private ushort Num;

	private ushort Num1;

	private ushort Num2;

	private ushort Zt;

	private ushort Zt1;

	private ushort Zt2;

	private ushort Zt3;

	private ushort Num123;

	private ushort Num456;

	private IContainer components = null;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem toolStripMenuItem3;

	private ToolStripMenuItem toolStripMenuItem2;

	private GroupBox groupBox新增版;

	private TextBox 平电能;

	private Label label21;

	private TextBox 购电次数;

	private Label label19;

	private TextBox 峰电能;

	private Label label18;

	private TextBox 电流变比;

	private Label label15;

	private TextBox 电压变比;

	private Label label16;

	private TextBox PFt;

	private Label label11;

	private TextBox PFc;

	private Label label13;

	private TextBox PFb;

	private Label label10;

	private TextBox Qc;

	private Label label84;

	private TextBox Qb;

	private Label label80;

	private TextBox Qa;

	private Label label76;

	private TextBox Pc;

	private Label label69;

	private TextBox Pb;

	private Label label65;

	private TextBox Pa;

	private Label label61;

	private TextBox 剩余金额;

	private Label label35;

	private TextBox 尖电能;

	private Label label34;

	private TextBox Ic;

	private Label label72;

	private TextBox Ib;

	private Label label71;

	private TextBox Uc;

	private Label label70;

	private TextBox Ub;

	private Label label59;

	private TextBox PFa;

	private Label label9;

	private TextBox Qt;

	private TextBox Pt;

	private TextBox Ia;

	private TextBox Ua;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label12;

	private TextBox 基础电量;

	private Label label8;

	private TextBox 允许次数;

	private Label label2;

	private TextBox 负控次数;

	private Label label7;

	private TextBox 总用电量;

	private Label label6;

	private TextBox 谷电能;

	private Label label1;

	private GroupBox groupBox1;

	private Label ps3;

	private GroupBox groupBox6;

	private Label ps2;

	private Label ps1;

	private Label ps;

	private Label label40;

	private Label label41;

	private Label label42;

	private Label label43;

	private GroupBox groupBox5;

	private Label ms2;

	private Label ms1;

	private Label ms3;

	private Label ms;

	private Label label32;

	private Label label33;

	private Label label14;

	private Label label17;

	private Label ts3;

	private GroupBox groupBox4;

	private Label ts2;

	private Label ts1;

	private Label ts;

	private Label label24;

	private Label label25;

	private Label label26;

	private Label label27;

	private Label fs3;

	private GroupBox groupBox3;

	private Label fs2;

	private Label fs1;

	private Label fs;

	private Label label20;

	private Label label23;

	private Label label28;

	private Label label29;

	private Label label22;

	private GroupBox groupBox8;

	private Label 越限;

	private Label label62;

	private Label 欠费;

	private Label label58;

	private Label ALM2;

	private Label label56;

	private Label ALM1;

	private Label label54;

	private Label label46;

	private Label label47;

	private Label 故障;

	private Label label49;

	private Label label50;

	private Label label51;

	private Label label52;

	private Label L3;

	private GroupBox groupBox7;

	private Label L2;

	private Label L1;

	private Label label38;

	private Label label39;

	private Label label44;

	private Label label45;

	private TabPage tabPage6;

	private TabPage tabPage5;

	private TabPage tabPage4;

	private GroupBox groupBox14;

	private Button button7;

	private CheckBox checkBoxForceEN3;

	private CheckBox checkBoxForceEN2;

	private CheckBox checkBoxForceEN1;

	private GroupBox groupBoxFL3;

	private RadioButton L3Close;

	private RadioButton L3Open;

	private GroupBox groupBoxFL2;

	private RadioButton L2Close;

	private RadioButton L2Open;

	private GroupBox groupBoxFL1;

	private RadioButton L1Close;

	private RadioButton L1Open;

	private Button ForceControl;

	private TabPage tabPage3;

	private GroupBox groupBox13;

	private Button ReadTimeControl;

	private Label label89;

	private CheckBox checkBoxTimeEN1;

	private Button AllTimeControl;

	private GroupBox groupBoxL1;

	private Label label103;

	private Label label104;

	private Label label105;

	private TextBox textBoxL1WorkH3;

	private TextBox textBoxL1WorkM3;

	private ComboBox comboBoxL1Work3;

	private TextBox textBoxL1WorkH2;

	private TextBox textBoxL1WorkM2;

	private ComboBox comboBoxL1Work2;

	private TextBox textBoxL1WorkH1;

	private TextBox textBoxL1WorkM1;

	private ComboBox comboBoxL1Work1;

	private Label label106;

	private Label label107;

	private Label label108;

	private TextBox textBoxL1FreeH3;

	private TextBox textBoxL1FreeM3;

	private ComboBox comboBoxL1Free3;

	private TextBox textBoxL1FreeH2;

	private TextBox textBoxL1FreeM2;

	private ComboBox comboBoxL1Free2;

	private TextBox textBoxL1FreeH1;

	private TextBox textBoxL1FreeM1;

	private ComboBox comboBoxL1Free1;

	private GroupBox groupBox15;

	private Label label109;

	private Label label110;

	private Label label111;

	private Label label112;

	private Label label113;

	private Label label114;

	private Label label115;

	private CheckBox checkBoxL1Mon;

	private CheckBox checkBoxL1Thu;

	private CheckBox checkBoxL1Wed;

	private CheckBox checkBoxL1Tue;

	private CheckBox checkBoxL1Fri;

	private CheckBox checkBoxL1Sat;

	private CheckBox checkBoxL1Sun;

	private Button TimeControl;

	private RadioButton CloseTime;

	private RadioButton OpenTime;

	private TabPage tabPage2;

	private GroupBox groupBox10;

	private CheckBox checkBoxPowerEN0;

	private TextBox textBoxMaxPF;

	private Label label88;

	private TextBox textBoxMaxPAdd;

	private Label label87;

	private Button ReadPowerControl;

	private CheckBox checkBoxPowerEN4;

	private CheckBox checkBoxPowerEN3;

	private CheckBox checkBoxPowerEN1;

	private Button AllPowerControl;

	private TextBox MaxOverCount;

	private Label label74;

	private TextBox RecoverTime;

	private Label label75;

	private TextBox MaxPower;

	private Label label77;

	private Button PowerControl;

	private RadioButton ClosePower;

	private RadioButton OpenPower;

	private GroupBox groupBox25;

	private TextBox OverCountALL;

	private Button ResetPC;

	private TabPage tabPage1;

	private GroupBox groupBox9;

	private TextBox textBoxPrice4;

	private Label label95;

	private TextBox textBoxPrice3;

	private Label label96;

	private CheckBox FKEN6;

	private TextBox textBoxPrice2;

	private Label label93;

	private TextBox textBoxPrice1;

	private Label label94;

	private CheckBox checkBox1;

	private Button ReadMoneyControl;

	private CheckBox FKEN3;

	private CheckBox FKEN2;

	private CheckBox FKEN5;

	private CheckBox FKEN4;

	private CheckBox FKEN1;

	private Button AllMoneyControl;

	private TextBox Alarm2;

	private Label label63;

	private TextBox Alarm1;

	private Label label64;

	private TextBox TotalE;

	private Label label66;

	private TextBox BaseE;

	private Label label67;

	private TextBox BuyTimes;

	private Label label68;

	private TextBox LeaveE;

	private Label label73;

	private Button MoneyControl;

	private RadioButton OFFFK;

	private RadioButton ONFK;

	private TabControl tabControl1;

	private CheckBox FKEN10;

	private TextBox textBox8;

	private Label label144;

	private CheckBox FKEN8;

	private TextBox textBox7;

	private Label FKEN9;

	private CheckBox FKEN7;

	private TextBox TouZhi;

	private Label label142;

	private Label label82;

	private CheckBox checkBox11;

	private TextBox textBoxL1WorkH8;

	private TextBox textBoxL1WorkM8;

	private ComboBox comboBoxL1Work8;

	private TextBox textBoxL1WorkH7;

	private TextBox textBoxL1WorkM7;

	private ComboBox comboBoxL1Work7;

	private TextBox textBoxL1FreeH8;

	private TextBox textBoxL1FreeM8;

	private ComboBox comboBoxL1Free8;

	private TextBox textBoxL1FreeH7;

	private TextBox textBoxL1FreeM7;

	private ComboBox comboBoxL1Free7;

	private TextBox textBoxL1WorkH6;

	private TextBox textBoxL1WorkM6;

	private ComboBox comboBoxL1Work6;

	private TextBox textBoxL1WorkH5;

	private TextBox textBoxL1WorkM5;

	private ComboBox comboBoxL1Work5;

	private TextBox textBoxL1WorkH4;

	private TextBox textBoxL1WorkM4;

	private ComboBox comboBoxL1Work4;

	private TextBox textBoxL1FreeH6;

	private TextBox textBoxL1FreeM6;

	private ComboBox comboBoxL1Free6;

	private TextBox textBoxL1FreeH5;

	private TextBox textBoxL1FreeM5;

	private ComboBox comboBoxL1Free5;

	private TextBox textBoxL1FreeH4;

	private TextBox textBoxL1FreeM4;

	private ComboBox comboBoxL1Free4;

	private CheckBox checkBox10;

	private TextBox textBox10;

	private Label label150;

	private CheckBox checkBox9;

	private TextBox textBox9;

	private Label label149;

	private TextBox 地址;

	private Label label86;

	private Button 关闭串口;

	private Button 读取数据;

	private Label labelGOOD;

	private Label labelERROR;

	private Timer 主轮抄定时器;

	private Timer 透传定时器;

	private Timer timer3;

	private TabPage tabPage7;

	private GroupBox groupBox2;

	private Label label30;

	private Label label31;

	private Label label36;

	private ComboBox comboBoxEc;

	private ComboBox comboBoxIb;

	private ComboBox comboBoxUn;

	private Button 增益;

	private Button 初始化;

	private GroupBox groupBox18;

	private Button 运行状态读取;

	private Button 运行状态设置;

	private GroupBox groupBox11;

	private TextBox PriceJ;

	private Label label37;

	private TextBox PriceF;

	private TextBox PriceP;

	private TextBox PriceG;

	private Label label98;

	private TextBox FKState;

	private TextBox BuyTime;

	private Label label97;

	private Button 设置预付费参数;

	private Button 读取预付费参数;

	private Label label92;

	private TextBox PMAX;

	private Label label90;

	private Label label91;

	private TextBox SQJE;

	private TextBox SYJE;

	private Label label57;

	private Label label60;

	private TextBox BJ1;

	private TextBox BJ2;

	private Label label55;

	private Label label53;

	private Label label48;

	private GroupBox groupBox12;

	private RadioButton 强控关;

	private RadioButton 强制合闸;

	private RadioButton 强制调制;

	private GroupBox groupBox23;

	private Button 强控设置;

	private GroupBox groupBox24;

	private Button 地址读取;

	private ComboBox 波特率comboBox;

	private TextBox 地址textBox;

	private Button 地址设置;

	private ComboBox 停止位comboBox;

	private TextBox 表号textBox;

	private GroupBox groupBox29;

	private Button 读取变比;

	private TextBox CTValue;

	private Label label120;

	private TextBox PTValue;

	private Label label121;

	private Button 设置变比;

	private Button button14;

	private GroupBox groupBox16;

	private Button buttonReadTimeZone;

	private Button buttonSetTimeZone;

	private Label label99;

	private Label label100;

	private Label label101;

	private Label label102;

	private Label label116;

	private Label label117;

	private Label label118;

	private TextBox textBoxMonth4;

	private TextBox textBoxDay4;

	private ComboBox comboBoxschedu4;

	private TextBox textBoxMonth3;

	private TextBox textBoxDay3;

	private ComboBox comboBoxschedu3;

	private TextBox textBoxMonth2;

	private TextBox textBoxDay2;

	private ComboBox comboBoxschedu2;

	private TextBox textBoxMonth1;

	private TextBox textBoxDay1;

	private ComboBox comboBoxschedu1;

	private GroupBox groupBox17;

	private Button buttonReadSched2;

	private Button buttonSetSched2;

	private Label label119;

	private Label label122;

	private Label label123;

	private Label label124;

	private Label label125;

	private Label label126;

	private ComboBox comboBoxCharge14_S2;

	private ComboBox comboBoxCharge13_S2;

	private ComboBox comboBoxCharge12_S2;

	private ComboBox comboBoxCharge11_S2;

	private ComboBox comboBoxCharge10_S2;

	private ComboBox comboBoxCharge9_S2;

	private TextBox textBoxMinute14_S2;

	private TextBox textBoxMinute13_S2;

	private TextBox textBoxMinute12_S2;

	private TextBox textBoxMinute11_S2;

	private TextBox textBoxMinute10_S2;

	private TextBox textBoxMinute9_S2;

	private TextBox textBoxHour14_S2;

	private TextBox textBoxHour13_S2;

	private TextBox textBoxHour12_S2;

	private TextBox textBoxHour11_S2;

	private TextBox textBoxHour10_S2;

	private TextBox textBoxHour9_S2;

	private Label label127;

	private Label label128;

	private Label label129;

	private Label label130;

	private Label label131;

	private Label label132;

	private Label label133;

	private Label label134;

	private Label label135;

	private Label label136;

	private Label label137;

	private TextBox textBoxHour8_S2;

	private TextBox textBoxMinute8_S2;

	private ComboBox comboBoxCharge8_S2;

	private TextBox textBoxHour7_S2;

	private TextBox textBoxMinute7_S2;

	private ComboBox comboBoxCharge7_S2;

	private TextBox textBoxHour6_S2;

	private TextBox textBoxMinute6_S2;

	private ComboBox comboBoxCharge6_S2;

	private TextBox textBoxHour5_S2;

	private TextBox textBoxMinute5_S2;

	private ComboBox comboBoxCharge5_S2;

	private TextBox textBoxHour4_S2;

	private TextBox textBoxMinute4_S2;

	private ComboBox comboBoxCharge4_S2;

	private TextBox textBoxHour3_S2;

	private TextBox textBoxMinute3_S2;

	private ComboBox comboBoxCharge3_S2;

	private TextBox textBoxHour2_S2;

	private TextBox textBoxMinute2_S2;

	private ComboBox comboBoxCharge2_S2;

	private TextBox textBoxHour1_S2;

	private TextBox textBoxMinute1_S2;

	private ComboBox comboBoxCharge1_S2;

	private GroupBox groupBox19;

	private Button buttonReadSched1;

	private Button buttonSetSched1;

	private Label label138;

	private Label label139;

	private Label label140;

	private Label label141;

	private Label label143;

	private Label label151;

	private ComboBox comboBoxCharge14_S1;

	private ComboBox comboBoxCharge13_S1;

	private ComboBox comboBoxCharge12_S1;

	private ComboBox comboBoxCharge11_S1;

	private ComboBox comboBoxCharge10_S1;

	private ComboBox comboBoxCharge9_S1;

	private TextBox textBoxMinute14_S1;

	private TextBox textBoxMinute13_S1;

	private TextBox textBoxMinute12_S1;

	private TextBox textBoxMinute11_S1;

	private TextBox textBoxMinute10_S1;

	private TextBox textBoxMinute9_S1;

	private TextBox textBoxHour14_S1;

	private TextBox textBoxHour13_S1;

	private TextBox textBoxHour12_S1;

	private TextBox textBoxHour11_S1;

	private TextBox textBoxHour10_S1;

	private TextBox textBoxHour9_S1;

	private Label label152;

	private Label label153;

	private Label label154;

	private Label label155;

	private Label label156;

	private Label label157;

	private Label label158;

	private Label label159;

	private Label label160;

	private Label label161;

	private Label label162;

	private TextBox textBoxHour8_S1;

	private TextBox textBoxMinute8_S1;

	private ComboBox comboBoxCharge8_S1;

	private TextBox textBoxHour7_S1;

	private TextBox textBoxMinute7_S1;

	private ComboBox comboBoxCharge7_S1;

	private TextBox textBoxHour6_S1;

	private TextBox textBoxMinute6_S1;

	private ComboBox comboBoxCharge6_S1;

	private TextBox textBoxHour5_S1;

	private TextBox textBoxMinute5_S1;

	private ComboBox comboBoxCharge5_S1;

	private TextBox textBoxHour4_S1;

	private TextBox textBoxMinute4_S1;

	private ComboBox comboBoxCharge4_S1;

	private TextBox textBoxHour3_S1;

	private TextBox textBoxMinute3_S1;

	private ComboBox comboBoxCharge3_S1;

	private TextBox textBoxHour2_S1;

	private TextBox textBoxMinute2_S1;

	private ComboBox comboBoxCharge2_S1;

	private TextBox textBoxHour1_S1;

	private TextBox textBoxMinute1_S1;

	private ComboBox comboBoxCharge1_S1;

	private ComboBox 校验位comboBox;

	private GroupBox groupBox21;

	private RadioButton 单费率;

	private RadioButton 复费率;

	private GroupBox groupBox30;

	private RadioButton 无射频;

	private RadioButton 有射频;

	private GroupBox groupBox27;

	private RadioButton 内控;

	private RadioButton 外控;

	private GroupBox groupBox22;

	private RadioButton 红外;

	private RadioButton 副通讯;

	private GroupBox groupBox20;

	private RadioButton 电能脉冲;

	private RadioButton 时钟脉冲;

	private Label 时间显示;

	private Button button1;

	private GroupBox groupBox32;

	private RadioButton SKL3;

	private RadioButton SKL2;

	private RadioButton SKL1;

	private GroupBox groupBox31;

	private RadioButton FKL3;

	private RadioButton FKL2;

	private RadioButton FKL1;

	private RadioButton FKALL;

	private Label label79;

	private GroupBox groupBox33;

	private Button 输出方式读取;

	private Button 输出方式设置;

	private RadioButton 脉冲;

	private RadioButton 电平;

	private Label label85;

	private Label label83;

	private Label label81;

	private RadioButton 第二路通讯;

	private RadioButton 主通讯;

	private Label label145;

	private GroupBox groupBox34;

	private Button CorrectMeter;

	private Button Init;

	private Button ADF300广播清零;

	private Button ADF300清零;

	private GroupBox groupBox28;

	private ComboBox ADF300波特率;

	private Button button2;

	private Button button3;

	private ComboBox ADF300地址;

	private Label label165;

	private GroupBox groupBoxChangePhaseType;

	private Button buttonReadPhase;

	private Button buttonChangePhase;

	private TextBox 三相数量;

	private TextBox 单相数量;

	private Label label146;

	private Label label147;

	private Label label166;

	private Label label163;

	private TextBox textBox2;

	private TextBox textBox1;

	private Label label148;

	private GroupBox groupBox35;

	private RadioButton 三相四线;

	private RadioButton 三相三线;

	private Label 单三相状态;

	private Label 最大回路数;

	private Label 版本号;

	private CheckBox FWL3;

	private CheckBox FWL2;

	private CheckBox FWL1;

	private CheckBox FWALL;

	private TextBox OverCount3;

	private TextBox OverCount2;

	private TextBox OverCount1;

	private Label label169;

	private Label label168;

	private Label label167;

	private Label label78;

	private Button button5;

	private GroupBox groupBox38;

	private RadioButton L3OFF;

	private RadioButton L3ON;

	private GroupBox groupBox37;

	private RadioButton L2OFF;

	private RadioButton L2ON;

	private GroupBox groupBox36;

	private RadioButton L1OFF;

	private RadioButton L1ON;

	private Button 表号读取;

	private CheckBox checkBox2;

	private RadioButton SKALL;

	private Button ADF300类型读取;

	private Button ADF300类型设置;

	private RadioButton II;

	private RadioButton III;

	private RadioButton I;

	private GroupBox ADF参数设置;

	private Button 读取ADF;

	private Button 设置ADF;

	private GroupBox groupBox41;

	private RadioButton ADF脉冲;

	private RadioButton ADF电平;

	private GroupBox groupBox42;

	private RadioButton ADF三相三线;

	private RadioButton ADF三相四线;

	private TextBox ADFCT4;

	private Label label174;

	private TextBox ADFCT2;

	private Label label173;

	private TextBox ADFCT3;

	private Label label172;

	private TextBox ADFCT1;

	private Label label171;

	private TextBox ADFPT;

	private Label label170;

	private Label label178;

	private Label label177;

	private TextBox ADF间隔;

	private Label label175;

	private TextBox ADF脉宽;

	private Label label176;

	private RadioButton ADF副通讯;

	private RadioButton ADF主通讯;

	private RadioButton 无IC;

	private RadioButton 使能IC;

	private Label label179;

	private TextBox ADF表号;

	private Label label164;

	private Label label180;

	private Label label181;

	private ComboBox ADF脉冲常数;

	private ComboBox ADF电流;

	private ComboBox ADF电压;

	private TabPage tabPage8;

	private TextBox 无线调制信息;

	private Label label182;

	private TextBox 数据上报间隔;

	private Label label183;

	private GroupBox groupBox26;

	private Label label185;

	private Label label184;

	private Label label186;

	private TextBox IP1;

	private TextBox 序列号;

	private TextBox 协议模式;

	private Label label187;

	private TextBox 端口号;

	private Label label190;

	private Label label189;

	private TextBox IP4;

	private TextBox IP3;

	private TextBox IP2;

	private Label label191;

	private Label labe端口l188;

	private TextBox ALMM4;

	private TextBox ALMM3;

	private TextBox ALMM2;

	private TextBox ALMM1;

	private Label label197;

	private TextBox LONG4;

	private TextBox LONG3;

	private TextBox LONG2;

	private TextBox LONG1;

	private Label label196;

	private TextBox Addr4;

	private TextBox Addr3;

	private TextBox Addr2;

	private TextBox Addr1;

	private Label label195;

	private TextBox TCP;

	private Label label193;

	private TextBox 告警段数量;

	private Label label194;

	private TextBox 数据段数量;

	private Label label192;

	private TextBox 设备数量;

	private Button button4;

	private Button button6;

	private GroupBox groupBox39;

	private Label 软件版本号;

	private Label 编号;

	private Label label199;

	private Label label198;

	private Label CCID卡号值;

	private Label label208;

	private Label 系统复位值;

	private Label label206;

	private Label 连接状态信号值;

	private Label label205;

	private Label 接受次数值;

	private Label label213;

	private Label 发送次数值;

	private Label label211;

	private Label IMEI号值;

	private Label label215;

	private Button button8;

	private GroupBox groupBox40;

	private RadioButton 无无线;

	private RadioButton 有无线;

	private Label 连接状态值;

	private Label label203;

	private Label label200;

	private Label label188;

	private CheckBox FKEN0;

	private TextBox 域名;

	private TextBox ALMM8;

	private TextBox ALMM7;

	private TextBox ALMM6;

	private TextBox ALMM5;

	private TextBox LONG8;

	private TextBox LONG7;

	private TextBox LONG6;

	private TextBox LONG5;

	private TextBox Addr8;

	private TextBox Addr7;

	private TextBox Addr6;

	private TextBox Addr5;

	private GroupBox groupBox45;

	private CheckBox checkBox3;

	private CheckBox checkBox4;

	private GroupBox groupBox44;

	private RadioButton radioButton3;

	private RadioButton radioButton4;

	private RadioButton radioButton5;

	private CheckBox dlt645xieyi;

	private RadioButton jiliangxing;

	private RadioButton yufufei;

	private GroupBox groupBox46;

	private GroupBox groupBox47;

	private GroupBox groupBox43;

	private RadioButton radioButton2;

	private RadioButton radioButton1;

	private Button 购电命令下发;

	private GroupBox groupBox49;

	private Button 设置密钥;

	private Button button9;

	private TextBox 密钥4;

	private TextBox 密钥3;

	private TextBox 密钥2;

	private TextBox 密钥1;

	private GroupBox groupBox50;

	private TextBox 新购电量;

	private Label label201;

	private TextBox new购电次数;

	private Label label202;

	private GroupBox groupBox51;

	private Button button10;

	private Button button11;

	private RadioButton 外置互感器;

	private RadioButton 内置互感器;

	private GroupBox groupBox48;

	private RadioButton 加密开;

	private RadioButton 加密关;

	private Button button12;

	private Button button13;

	private TabPage tabPage9;

	private GroupBox groupBox54;

	private Label label228;

	private Label label227;

	private TextBox ADF400PT;

	private TextBox ADF400CT12;

	private TextBox ADF400CT8;

	private TextBox ADF400CT4;

	private TextBox ADF400CT11;

	private TextBox ADF400CT7;

	private TextBox ADF400CT3;

	private TextBox ADF400CT10;

	private TextBox ADF400CT6;

	private TextBox ADF400CT2;

	private TextBox ADF400CT9;

	private TextBox ADF400CT5;

	private TextBox ADF400CT1;

	private Label label223;

	private Label label224;

	private Label label225;

	private Label label226;

	private Label label219;

	private Label label220;

	private Label label221;

	private Label label222;

	private Label label217;

	private Label label218;

	private Label label216;

	private Label label214;

	private Label label212;

	private GroupBox groupBox53;

	private Button button16;

	private Button button15;

	private RadioButton ADF400从机地址重排1;

	private Label label210;

	private TextBox ADF400互感器接入回路;

	private Label label209;

	private TextBox ADF400三相数量;

	private TextBox ADF400单相数量;

	private Label label207;

	private Label label204;

	private Button button18;

	private Button button17;

	private Label label230;

	private TextBox ADF400间隔;

	private Label label229;

	private TextBox ADF400脉宽;

	private GroupBox groupBox55;

	private Button button21;

	private Button button22;

	private GroupBox groupBox57;

	private GroupBox groupBox56;

	private RadioButton ADF400DI1分;

	private Label label232;

	private Label label231;

	private Button ADF400设置DO;

	private RadioButton ADF400DO2合;

	private RadioButton ADF400DO2分;

	private RadioButton ADF400DO1合;

	private RadioButton ADF400DO1分;

	private Label label234;

	private Label label233;

	private Button button19;

	private RadioButton ADF400DI2合;

	private RadioButton ADF400DI2分;

	private RadioButton ADF400DI1合;

	private GroupBox groupBox58;

	private Button ADF400广播清零;

	private Label label237;

	private Button ADF400电能清零;

	private Label label238;

	private Label label239;

	private ComboBox ADF400脉冲常数;

	private ComboBox ADF400电流;

	private ComboBox ADF400电压;

	private Button ADF400校准;

	private Button ADF400初始化;

	private RadioButton ADF400计量型;

	private RadioButton ADF400预付费型;

	private GroupBox groupBox59;

	private Label label240;

	private Label label243;

	private Label label242;

	private RadioButton ADF4003p4l;

	private RadioButton ADF400无线;

	private RadioButton ADF400脉冲;

	private RadioButton ADF400电平;

	private RadioButton ADF4003p3l;

	private RadioButton ADF400无无线;

	private GroupBox groupBox60;

	private Button button32;

	private Button button33;

	private RadioButton ADF4001通讯;

	private ComboBox ADF400波特率;

	private RadioButton ADF4002通讯;

	private Label label241;

	private ComboBox ADF400地址;

	private CheckBox ADF400dlt645协议;

	private RadioButton ADF400使能IC;

	private RadioButton ADF400无使能IC;

	private Label label245;

	private Label label246;

	private Label label247;

	private RadioButton ADF400使能CE以太网0;

	private RadioButton ADF400使能CE以太网1;

	private RadioButton ADF400从机地址重排2;

	private GroupBox groupBox73;

	private GroupBox groupBox71;

	private GroupBox groupBox70;

	private GroupBox groupBox69;

	private GroupBox groupBox68;

	private GroupBox groupBox67;

	private GroupBox groupBox66;

	private GroupBox groupBox63;

	private GroupBox groupBox61;

	private GroupBox groupBox65;

	private GroupBox groupBox64;

	private TabPage tabPage10;

	private GroupBox groupBox76;

	private GroupBox groupBox75;

	private Button ADF400L额定参数读取;

	private TextBox ADF400L从额定电压;

	private TextBox ADF400L从额定电流;

	private Label label251;

	private Label label250;

	private GroupBox groupBox74;

	private Button ADF400L从通讯W;

	private Label label248;

	private Label label249;

	private Button ADF400L从通讯R;

	private Button ADF400L从参数W;

	private Button ADF400L从参数R;

	private TextBox ADF400L从消抖时间;

	private Label label259;

	private TextBox ADF400L从脉冲常数;

	private Label label258;

	private GroupBox groupBox78;

	private RadioButton ADF400L从3p3l;

	private RadioButton ADF400L从3p4l;

	private Label label257;

	private GroupBox groupBox77;

	private RadioButton ADF400L从电平;

	private RadioButton ADF400L从脉冲;

	private Label label252;

	private Label label253;

	private TextBox ADF400L从脉冲间隔;

	private Label label254;

	private Label label255;

	private TextBox ADF400L从脉冲宽度;

	private Label label256;

	private GroupBox groupBox79;

	private GroupBox groupBox80;

	private GroupBox groupBox81;

	private RadioButton ADF400L从DO4分;

	private RadioButton ADF400L从DO4合;

	private GroupBox groupBox82;

	private RadioButton ADF400L从DO1分;

	private RadioButton ADF400L从DO1合;

	private GroupBox groupBox83;

	private RadioButton ADF400L从DO2分;

	private RadioButton ADF400L从DO2合;

	private Button ADF400L从DOW;

	private GroupBox groupBox84;

	private RadioButton ADF400L从DO3分;

	private RadioButton ADF400L从DO3合;

	private Button ADF400L从DOR;

	private Label label260;

	private Label label261;

	private Label label262;

	private Label label263;

	private GroupBox groupBox85;

	private GroupBox groupBox86;

	private RadioButton ADF400L从DI2分;

	private RadioButton ADF400L从DI2合;

	private GroupBox groupBox87;

	private RadioButton ADF400L从DI1分;

	private RadioButton ADF400L从DI1合;

	private Button ADF400L从DI;

	private Label label264;

	private Label label265;

	private Label label266;

	private TextBox ADF400L从地址;

	private GroupBox groupBox88;

	private Button button24;

	private Label label267;

	private Button button27;

	private Label label268;

	private Label label269;

	private ComboBox ADF400L从pulse;

	private ComboBox ADF400L从电流;

	private ComboBox ADF400L从电压;

	private Button button28;

	private Button button29;

	private TextBox ADF400L从波特率;

	private RadioButton ADF4003通讯;

	private TabPage tabPage11;

	private Button 设置DO;

	private Button 读取DIO;

	private GroupBox DO;

	private CheckBox DO4checkBox;

	private CheckBox DO3checkBox;

	private CheckBox DO2checkBox;

	private CheckBox DO1checkBox;

	private GroupBox groupBox89;

	private CheckBox DI8checkBox;

	private CheckBox DI4checkBox;

	private CheckBox DI7checkBox;

	private CheckBox DI3checkBox;

	private CheckBox DI6checkBox;

	private CheckBox DI2checkBox;

	private CheckBox DI5checkBox;

	private CheckBox DI1checkBox;

	private GroupBox groupBox90;

	private RadioButton ADF400主机;

	private RadioButton ADF400从机;

	private Label 需量时间;

	private Label label270;

	private TextBox 最大需量;

	private Button XuLieHao读取;

	private TextBox XuLieHao;

	private Button XuLieHao设置;

	private Label label271;

	private GroupBox groupBox52;

	private GroupBox groupBox62;

	private Button Read序列号;

	private Button Set序列号;

	private Label label235;

	private TextBox ADF400序列号;

	private GroupBox groupBox72;

	private Button Readxulihao;

	private Button Setxuliehao;

	private Label label236;

	private TextBox ADF300序列号;

	private TextBox ADF400表号;

	private RadioButton ADF300;

	private RadioButton DDSYDTSY;

	private Label 型号;

	private TabPage tabPage12;

	private Label label273;

	private Label label272;

	private Label label244;

	private Button ADF400无线读取;

	private Button ADF400无线设置;

	private TextBox ADF400端口号;

	private TextBox ADF400IP2;

	private TextBox ADF400IP3;

	private TextBox ADF400IP4;

	private TextBox ADF400IP1;

	private TextBox 子网掩码2;

	private TextBox 子网掩码3;

	private TextBox 子网掩码4;

	private TextBox 子网掩码1;

	private TextBox ADF400网关IP2;

	private TextBox ADF400网关IP3;

	private TextBox ADF400网关IP4;

	private TextBox ADF400网关IP1;

	private Label label274;

	private GroupBox groupBox91;

	private RadioButton DDSY;

	private RadioButton DDSF;

	private ComboBox ADF400校验位;

	private Label label275;

	private TabPage tabPage13;

	private GroupBox groupBox95;

	private TextBox 序列号1;

	private Label label339;

	private Button 无限信息设置;

	private Button 无线信息读取;

	private TextBox 域名1;

	private Label label335;

	private TextBox 协议模式1;

	private Label label336;

	private TextBox 端口号1;

	private Label label337;

	private TextBox IP44;

	private TextBox IP33;

	private TextBox IP22;

	private Label label338;

	private TextBox IP11;

	private GroupBox groupBox94;

	private Label label367;

	private Label label366;

	private Label label360;

	private TextBox cxzcycsj;

	private Label label341;

	private Label label340;

	private ComboBox comboBox2;

	private ComboBox comboBox1;

	private Button setWIFI;

	private Button readWIFI;

	private TextBox WIFIsignal;

	private TextBox MACaddress;

	private TextBox WIFIpassword;

	private TextBox WIFIname;

	private Label label334;

	private Label label333;

	private Label label332;

	private Label label331;

	private Label label330;

	private Label label329;

	private TabPage tabPage14;

	private GroupBox groupBox96;

	private ComboBox 仪表型号;

	private Button setZT2;

	private Button setZT1;

	private TextBox 自注册IP;

	private TextBox 调试网站ip;

	private Label label357;

	private Button setZhongtai;

	private Button readZhongtai;

	private TextBox zzcDKH;

	private TextBox tswzDKH;

	private TextBox ztXLH;

	private TextBox 密码;

	private TextBox 用户名;

	private Label label355;

	private TextBox ztSBZQ;

	private TextBox ztDKH;

	private TextBox 中台域名;

	private ComboBox 平台选择;

	private ComboBox 中台EIOT协议模式;

	private Label label354;

	private Label label353;

	private Label label352;

	private Label label351;

	private Label label350;

	private Label label349;

	private Label label348;

	private Label label347;

	private Label label346;

	private Label label345;

	private Label label344;

	private Label label343;

	private Label label342;

	private Label label688;

	private Button button80;

	private Label label689;

	private Label label690;

	private Label label691;

	private TextBox textBox199;

	private TextBox textBox201;

	private Button button82;

	private ComboBox comboBox5;

	private ComboBox comboBox6;

	private Label label692;

	private Label label693;

	private Label label694;

	private GroupBox groupBox92;

	private Button button71;

	private Button button70;

	private Label label276;

	private TextBox 心跳;

	private Label label277;

	private TextBox APN号;

	private RadioButton APNOFF;

	private Button button23;

	private Button button20;

	private RadioButton APNON;

	private Label label278;

	public ADF400读取DIDO()
	{
		InitializeComponent();
	}

	private void toolStripMenuItem3_Click(object sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Form val = (Form)(object)new PortConfig();
		val.ShowDialog();
	}

	private void miyao()
	{
		((Control)密钥1).Text = "6163";
		((Control)密钥2).Text = "7265";
		((Control)密钥3).Text = "6C33";
		((Control)密钥4).Text = "3231";
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		((Control)地址).Text = "1";
		PortFalshInit();
		ParaInit();
		miyao();
		((Control)groupBox68).Visible = false;
		Form val = (Form)(object)new PortConfig();
		if (!PortIsAvailable)
		{
			return;
		}
		if (!Modbus.sp.IsOpen)
		{
			bool flag = false;
			if (m.Open())
			{
				MessageBox.Show("串口" + Variable.PortSet.PortNumber.ToString() + "已打开！");
				Variable.IsPortOpen = 1;
			}
			else
			{
				MessageBox.Show("串口" + Variable.PortSet.PortNumber.ToString() + "打开失败！");
				Variable.IsPortOpen = 0;
			}
		}
		else
		{
			MessageBox.Show("串口" + Variable.PortSet.PortNumber.ToString() + "已打开！");
		}
	}

	private void PortFalshInit()
	{
		((Control)labelGOOD).Visible = false;
		((Control)labelERROR).Visible = false;
	}

	private void PortFalshGOOD()
	{
		((Control)labelGOOD).Visible = true;
		((Control)labelERROR).Visible = false;
	}

	private void PortFalshERROR()
	{
		((Control)labelGOOD).Visible = false;
		((Control)labelERROR).Visible = true;
	}

	private void ParaInit()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		string[] portNames = SerialPort.GetPortNames();
		if (portNames.Length != 0)
		{
			PortIsAvailable = true;
			Variable.PortSet.PortNumber = portNames[0];
		}
		else
		{
			PortIsAvailable = false;
			MessageBox.Show("没有可用的串口！");
		}
		((ListControl)comboBoxCharge1_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge2_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge3_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge4_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge5_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge6_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge7_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge8_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge9_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge10_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge11_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge12_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge13_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge14_S2).SelectedIndex = 0;
		((ListControl)comboBoxCharge1_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge2_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge3_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge4_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge5_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge6_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge7_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge8_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge9_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge10_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge11_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge12_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge13_S1).SelectedIndex = 0;
		((ListControl)comboBoxCharge14_S1).SelectedIndex = 0;
		((ListControl)comboBoxschedu1).SelectedIndex = 0;
		((ListControl)comboBoxschedu2).SelectedIndex = 0;
		((ListControl)comboBoxschedu3).SelectedIndex = 0;
		((ListControl)comboBoxschedu4).SelectedIndex = 0;
		((ListControl)comboBoxUn).SelectedIndex = 1;
		((ListControl)comboBoxIb).SelectedIndex = 1;
		((ListControl)comboBoxEc).SelectedIndex = 0;
		强制合闸.Checked = true;
		脉冲.Checked = true;
		((ListControl)comboBoxL1Free1).SelectedIndex = 0;
		((ListControl)comboBoxL1Free2).SelectedIndex = 0;
		((ListControl)comboBoxL1Free3).SelectedIndex = 0;
		((ListControl)comboBoxL1Free4).SelectedIndex = 0;
		((ListControl)comboBoxL1Free5).SelectedIndex = 0;
		((ListControl)comboBoxL1Free6).SelectedIndex = 0;
		((ListControl)comboBoxL1Free7).SelectedIndex = 0;
		((ListControl)comboBoxL1Free8).SelectedIndex = 0;
		((ListControl)comboBoxL1Work1).SelectedIndex = 0;
		((ListControl)comboBoxL1Work2).SelectedIndex = 0;
		((ListControl)comboBoxL1Work3).SelectedIndex = 0;
		((ListControl)comboBoxL1Work4).SelectedIndex = 0;
		((ListControl)comboBoxL1Work5).SelectedIndex = 0;
		((ListControl)comboBoxL1Work6).SelectedIndex = 0;
		((ListControl)comboBoxL1Work7).SelectedIndex = 0;
		((ListControl)comboBoxL1Work8).SelectedIndex = 0;
		((ListControl)波特率comboBox).SelectedIndex = 3;
		((ListControl)校验位comboBox).SelectedIndex = 0;
		((ListControl)停止位comboBox).SelectedIndex = 0;
		((ListControl)ADF电压).SelectedIndex = 1;
		((ListControl)ADF电流).SelectedIndex = 0;
		((ListControl)ADF脉冲常数).SelectedIndex = 0;
		((ListControl)ADF300地址).SelectedIndex = 0;
		((ListControl)ADF300波特率).SelectedIndex = 0;
		FKEN0.Checked = true;
		FKEN1.Checked = true;
		FKEN2.Checked = true;
		FKEN3.Checked = true;
		FKEN4.Checked = true;
		FKEN5.Checked = true;
		FKEN6.Checked = true;
		FKEN7.Checked = true;
		FKEN8.Checked = true;
		OFFFK.Checked = true;
		FKALL.Checked = true;
		checkBoxPowerEN0.Checked = true;
		ClosePower.Checked = true;
		SKALL.Checked = true;
		checkBox2.Checked = true;
		CloseTime.Checked = true;
		checkBoxForceEN1.Checked = true;
		checkBoxForceEN2.Checked = true;
		checkBoxForceEN3.Checked = true;
		L1ON.Checked = true;
		L1Open.Checked = true;
		L2ON.Checked = true;
		L2Open.Checked = true;
		L3ON.Checked = true;
		L3Open.Checked = true;
	}

	private void 读取数据_Click(object sender, EventArgs e)
	{
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		if (!Modbus.sp.IsOpen)
		{
			if (m.Open())
			{
				MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
			}
			else
			{
				MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "失败");
			}
		}
		if (!CheckAddr())
		{
			return;
		}
		if (!Modbus.sp.IsOpen)
		{
			MessageBox.Show("请先打开串口！");
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[12];
		byte[] response = new byte[15];
		byte[] CRC = new byte[15];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 17;
		array[2] = 254;
		array[3] = 220;
		array[4] = 186;
		array[5] = 152;
		array[6] = 118;
		array[7] = 84;
		array[8] = 50;
		array[9] = 16;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(30);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			int num = (response[3] << 8) | response[4];
			int num2 = (response[7] << 8) | response[8];
			if (num2 < 32768)
			{
				((Control)版本号).Text = "V" + num2;
			}
			else
			{
				((Control)版本号).Text = "T" + (num2 - 32768);
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
		if (Variable.PortSet.PortBaud == "9600")
		{
			主轮抄定时器.Interval = 500;
		}
		else if (Variable.PortSet.PortBaud == "4800")
		{
			主轮抄定时器.Interval = 1000;
		}
		else if (Variable.PortSet.PortBaud == "2400")
		{
			主轮抄定时器.Interval = 1500;
		}
		else if (Variable.PortSet.PortBaud == "1200")
		{
			主轮抄定时器.Interval = 2000;
		}
		else
		{
			主轮抄定时器.Interval = 500;
		}
		主轮抄定时器.Enabled = true;
	}

	private bool CheckAddr()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (Variable.IsRightAddr != 1)
		{
			MessageBox.Show("Please confirm that you have entered the correct address！");
			return false;
		}
		if (Variable.IsPortOpen > 0)
		{
			return true;
		}
		MessageBox.Show("Serial port not open！");
		return false;
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		switch (((Control)地址).Text.Trim().Length)
		{
			case 1:
				{
					string text3 = ((Control)地址).Text.Trim();
					foreach (char c3 in text3)
					{
						if (c3 < '0' || c3 > '9')
						{
							MessageBox.Show("确定输入的值为0到255的整数！");
							((Control)地址).Text = "";
							Variable.IsRightAddr = 0;
							return;
						}
					}
					if (Convert.ToByte(((Control)地址).Text.Trim()) != 0)
					{
						Variable.Address = ((Control)地址).Text.Trim();
						Variable.IsRightAddr = 1;
					}
					else
					{
						Variable.Address = ((Control)地址).Text.Trim();
						Variable.IsRightAddr = 1;
					}
					break;
				}
			case 2:
				{
					string text2 = ((Control)地址).Text.Trim();
					foreach (char c2 in text2)
					{
						if (c2 < '0' || c2 > '9')
						{
							MessageBox.Show("确定输入的值为0到255的整数！");
							((Control)地址).Text = "";
							Variable.IsRightAddr = 0;
							return;
						}
					}
					if (Convert.ToByte(((Control)地址).Text.Trim()) != 0)
					{
						Variable.Address = ((Control)地址).Text.Trim();
						Variable.IsRightAddr = 1;
					}
					else
					{
						Variable.Address = ((Control)地址).Text.Trim();
						Variable.IsRightAddr = 1;
					}
					break;
				}
			case 3:
				if (((Control)地址).Text.Trim()[0] >= '0' && ((Control)地址).Text.Trim()[0] < '3')
				{
					if (((Control)地址).Text.Trim()[0] == '2')
					{
						if (((Control)地址).Text.Trim()[1] >= '0' && ((Control)地址).Text.Trim()[1] <= '5')
						{
							if (((Control)地址).Text.Trim()[1] == '5' && ((Control)地址).Text.Trim()[2] > '5' && ((Control)地址).Text.Trim()[2] <= '9')
							{
								MessageBox.Show("确定输入的值为0到255的整数！");
								((Control)地址).Text = "";
								Variable.IsRightAddr = 0;
							}
							else if (Convert.ToByte(((Control)地址).Text.Trim()) != 0)
							{
								Variable.Address = ((Control)地址).Text.Trim();
								Variable.IsRightAddr = 1;
							}
							else
							{
								Variable.IsRightAddr = 1;
								Variable.Address = ((Control)地址).Text.Trim();
							}
						}
						else
						{
							MessageBox.Show("确定输入的值为0到255的整数！");
							((Control)地址).Text = "";
							Variable.IsRightAddr = 0;
						}
						break;
					}
					string text = ((Control)地址).Text.Trim();
					foreach (char c in text)
					{
						if (c < '0' || c > '9')
						{
							MessageBox.Show("确定输入的值为0到255的整数！");
							((Control)地址).Text = "";
							Variable.IsRightAddr = 0;
							return;
						}
					}
					if (Convert.ToByte(((Control)地址).Text.Trim()) != 0)
					{
						Variable.Address = ((Control)地址).Text.Trim();
						Variable.IsRightAddr = 1;
					}
					else
					{
						Variable.Address = ((Control)地址).Text.Trim();
						Variable.IsRightAddr = 1;
					}
				}
				else
				{
					MessageBox.Show("确定输入的值为0到255的整数！");
					((Control)地址).Text = "";
					Variable.IsRightAddr = 0;
				}
				break;
		}
	}

	private void 主轮抄_Tick(object sender, EventArgs e)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		PortFalshInit();
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] message = new byte[8];
		byte[] response = new byte[101];
		m.BuildMessage(ref message, 0);
		try
		{
			Modbus.sp.Write(message, 0, message.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = false;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			PortFalshGOOD();
			轮抄显示(response);
		}
		else
		{
			主轮抄定时器.Enabled = false;
			PortFalshInit();
			MessageBox.Show("Verification error！");
		}
	}

	private void 轮抄显示(byte[] bb)
	{
		byte[] array = new byte[7];
		double num = (bb[3] << 8) | bb[4];
		if (bb[97] == 0)
		{
			MeterType2 = 0;
		}
		else if (bb[97] == 1)
		{
			MeterType2 = 1;
		}
		else
		{
			MeterType2 = 2;
		}
		if (num == 7.0)
		{
			MeterType = 1;
			((ListControl)comboBoxEc).SelectedIndex = 1;
			DDSYDTSY.Checked = true;
			((Control)型号).Text = "DDSY1352";
		}
		else if (num == 5.0)
		{
			MeterType = 2;
			DDSYDTSY.Checked = true;
			((Control)型号).Text = "DTSY1352";
		}
		else if (num == 10.0)
		{
			((Control)型号).Text = "ADF300";
			MeterType = 3;
			if (bb[98] == 0)
			{
				IS3P = 1;
			}
			else
			{
				IS3P = 0;
			}
			if (MeterType2 == 0)
			{
				((Control)最大回路数).Text = "最大36路";
				if (bb[98] == 0)
				{
					((Control)单三相状态).Text = "三相回路";
				}
				else
				{
					((Control)单三相状态).Text = "单相回路";
				}
			}
			else if (MeterType2 == 1)
			{
				((Control)最大回路数).Text = "最大24路";
				if (bb[98] == 0)
				{
					((Control)单三相状态).Text = "三相回路";
				}
				else
				{
					((Control)单三相状态).Text = "单相回路";
				}
			}
			else
			{
				((Control)最大回路数).Text = "最大12路";
				if (bb[98] == 0)
				{
					((Control)单三相状态).Text = "三相回路";
				}
				else
				{
					((Control)单三相状态).Text = "单相回路";
				}
			}
		}
		num = (bb[5] << 8) | bb[6];
		num = Convert.ToDouble(num) / 10.0;
		((Control)Ua).Text = num.ToString("f1");
		num = (bb[7] << 8) | bb[8];
		num = Convert.ToDouble(num) / 10.0;
		((Control)Ub).Text = num.ToString("f1");
		num = (bb[9] << 8) | bb[10];
		num = Convert.ToDouble(num) / 10.0;
		((Control)Uc).Text = num.ToString("f1");
		num = (bb[11] << 8) | bb[12];
		num = Convert.ToDouble(num) / 100.0;
		((Control)Ia).Text = num.ToString("f2");
		num = (bb[13] << 8) | bb[14];
		num = Convert.ToDouble(num) / 100.0;
		((Control)Ib).Text = num.ToString("f2");
		num = (bb[15] << 8) | bb[16];
		num = Convert.ToDouble(num) / 100.0;
		((Control)Ic).Text = num.ToString("f2");
		int num2 = (bb[17] << 8) | bb[18];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Pa).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[19] << 8) | bb[20];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Pb).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[21] << 8) | bb[22];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Pc).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[23] << 8) | bb[24];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Pt).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[25] << 8) | bb[26];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Qa).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[27] << 8) | bb[28];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Qb).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[29] << 8) | bb[30];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Qc).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[31] << 8) | bb[32];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)Qt).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[33] << 8) | bb[34];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)PFa).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[35] << 8) | bb[36];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)PFb).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[37] << 8) | bb[38];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)PFc).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num2 = (bb[39] << 8) | bb[40];
		if (num2 > 32767)
		{
			num2 = -1 * (65536 - num2);
		}
		((Control)PFt).Text = (Convert.ToDouble(num2) / 1000.0).ToString("f3");
		num = (bb[41] << 8) | bb[42];
		num = Convert.ToDouble(num);
		((Control)电压变比).Text = num.ToString("f0");
		num = (bb[43] << 8) | bb[44];
		num = Convert.ToDouble(num);
		((Control)电流变比).Text = num.ToString("f0");
		num = (bb[45] << 24) | (bb[46] << 16) | (bb[47] << 8) | bb[48];
		num /= 100.0;
		((Control)总用电量).Text = num.ToString("f2");
		num = (bb[49] << 24) | (bb[50] << 16) | (bb[51] << 8) | bb[52];
		num /= 100.0;
		((Control)尖电能).Text = num.ToString("f2");
		num = (bb[53] << 24) | (bb[54] << 16) | (bb[55] << 8) | bb[56];
		num /= 100.0;
		((Control)峰电能).Text = num.ToString("f2");
		num = (bb[79] << 24) | (bb[80] << 16) | (bb[81] << 8) | bb[82];
		num /= 100.0;
		((Control)基础电量).Text = num.ToString("f2");
		num = (bb[57] << 24) | (bb[58] << 16) | (bb[59] << 8) | bb[60];
		num /= 100.0;
		((Control)平电能).Text = num.ToString("f2");
		num = (bb[61] << 24) | (bb[62] << 16) | (bb[63] << 8) | bb[64];
		num /= 100.0;
		((Control)谷电能).Text = num.ToString("f2");
		num = (bb[65] << 24) | (bb[66] << 16) | (bb[67] << 8) | bb[68];
		num /= 100.0;
		((Control)剩余金额).Text = num.ToString("f2");
		num = (bb[69] << 8) | bb[70];
		num = Convert.ToDouble(num);
		((Control)购电次数).Text = num.ToString("f0");
		num = (bb[71] << 8) | bb[72];
		num = Convert.ToDouble(num);
		((Control)负控次数).Text = num.ToString("f0");
		num = (bb[73] << 8) | bb[74];
		num = Convert.ToDouble(num);
		((Control)允许次数).Text = num.ToString("f0");
		if (((bb[76] >> 3) & 1) == 1)
		{
			((Control)fs).Text = "打开";
			if ((bb[76] & 1) == 1)
			{
				((Control)fs1).Text = "闭合";
			}
			else
			{
				((Control)fs1).Text = "断开";
			}
			if (((bb[76] >> 1) & 1) == 1)
			{
				((Control)fs2).Text = "闭合";
			}
			else
			{
				((Control)fs2).Text = "断开";
			}
			if (((bb[76] >> 2) & 1) == 1)
			{
				((Control)fs3).Text = "闭合";
			}
			else
			{
				((Control)fs3).Text = "断开";
			}
		}
		else
		{
			((Control)fs).Text = "**";
			((Control)fs1).Text = "**";
			((Control)fs2).Text = "**";
			((Control)fs3).Text = "**";
		}
		if (((bb[76] >> 4) & 1) == 1)
		{
			((Control)越限).Text = "是";
		}
		else
		{
			((Control)越限).Text = "否";
		}
		if (((bb[76] >> 5) & 1) == 1)
		{
			((Control)欠费).Text = "是";
		}
		else
		{
			((Control)欠费).Text = "否";
		}
		if (((bb[76] >> 6) & 1) == 1)
		{
			((Control)ALM1).Text = "是";
		}
		else
		{
			((Control)ALM1).Text = "否";
		}
		if (((bb[76] >> 7) & 1) == 1)
		{
			((Control)ALM2).Text = "是";
		}
		else
		{
			((Control)ALM2).Text = "否";
		}
		if ((bb[75] & 1) == 1)
		{
			((Control)故障).Text = "是";
		}
		else
		{
			((Control)故障).Text = "否";
		}
		if (((bb[75] >> 5) & 1) == 1)
		{
			((Control)L1).Text = "合闸";
		}
		else
		{
			((Control)L1).Text = "分闸";
		}
		if (((bb[75] >> 6) & 1) == 1)
		{
			((Control)L2).Text = "合闸";
		}
		else
		{
			((Control)L2).Text = "分闸";
		}
		if (((bb[75] >> 7) & 1) == 1)
		{
			((Control)L3).Text = "合闸";
		}
		else
		{
			((Control)L3).Text = "分闸";
		}
		if (((bb[77] >> 3) & 1) == 1)
		{
			((Control)ps).Text = "打开";
			if ((bb[77] & 1) == 1)
			{
				((Control)ps1).Text = "闭合";
			}
			else
			{
				((Control)ps1).Text = "断开";
			}
			if (((bb[77] >> 1) & 1) == 1)
			{
				((Control)ps2).Text = "闭合";
			}
			else
			{
				((Control)ps2).Text = "断开";
			}
			if (((bb[77] >> 2) & 1) == 1)
			{
				((Control)ps3).Text = "闭合";
			}
			else
			{
				((Control)ps3).Text = "断开";
			}
		}
		else
		{
			((Control)ps).Text = "**";
			((Control)ps1).Text = "**";
			((Control)ps2).Text = "**";
			((Control)ps3).Text = "**";
		}
		if (((bb[78] >> 3) & 1) == 1)
		{
			((Control)ms).Text = "打开";
			if ((bb[78] & 1) == 1)
			{
				((Control)ms1).Text = "闭合";
			}
			else
			{
				((Control)ms1).Text = "断开";
			}
			if (((bb[78] >> 1) & 1) == 1)
			{
				((Control)ms2).Text = "闭合";
			}
			else
			{
				((Control)ms2).Text = "断开";
			}
			if (((bb[78] >> 2) & 1) == 1)
			{
				((Control)ms3).Text = "闭合";
			}
			else
			{
				((Control)ms3).Text = "断开";
			}
		}
		else
		{
			((Control)ms).Text = "**";
			((Control)ms1).Text = "**";
			((Control)ms2).Text = "**";
			((Control)ms3).Text = "**";
		}
		if (((bb[78] >> 7) & 1) == 1)
		{
			((Control)ts).Text = "打开";
			if (((bb[78] >> 4) & 1) == 1)
			{
				((Control)ts1).Text = "闭合";
			}
			else
			{
				((Control)ts1).Text = "断开";
			}
			if (((bb[78] >> 5) & 1) == 1)
			{
				((Control)ts2).Text = "闭合";
			}
			else
			{
				((Control)ts2).Text = "断开";
			}
			if (((bb[78] >> 6) & 1) == 1)
			{
				((Control)ts3).Text = "闭合";
			}
			else
			{
				((Control)ts3).Text = "断开";
			}
		}
		else
		{
			((Control)ts).Text = "**";
			((Control)ts1).Text = "**";
			((Control)ts2).Text = "**";
			((Control)ts3).Text = "**";
		}
		num = (bb[90] << 8) | bb[91];
		num = Convert.ToDouble(num);
		((Control)最大需量).Text = num.ToString("f0");
		string text = bb[95].ToString("00") + "-" + bb[94].ToString("00") + "  " + bb[93].ToString("00") + ":" + bb[92].ToString("00");
		((Control)需量时间).Text = text;
		string text2 = bb[83].ToString("00") + "-" + bb[84].ToString("00") + "-" + bb[85].ToString("00") + "  " + bb[87].ToString("00") + ":" + bb[88].ToString("00") + ":" + bb[89].ToString("00") + "  星期" + bb[86].ToString("00");
		((Control)时间显示).Text = text2;
	}

	private void 关闭串口_Click(object sender, EventArgs e)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		if (m.close())
		{
			PortFalshInit();
			MessageBox.Show("The serial port is closed");
		}
		else
		{
			MessageBox.Show("Error closing, please check the connection");
		}
	}

	private void 强控设置_Click(object sender, EventArgs e)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 87;
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = 0;
		if (强控关.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		array[9] = 0;
		if (强制合闸.Checked)
		{
			array[10] = 0;
		}
		else
		{
			array[10] = 1;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 运行状态设置_Click(object sender, EventArgs e)
	{
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 34;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		if (单费率.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		if (电能脉冲.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 2;
		}
		if (红外.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 4;
		}
		if (内控.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 8;
		}
		if (无射频.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 16;
		}
		if (加密开.Checked)
		{
			array[8] |= 32;
		}
		else
		{
			array[8] |= 0;
		}
		if (DDSY.Checked)
		{
			array[8] |= 64;
		}
		else
		{
			array[8] |= 0;
		}
		if (三相四线.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 128;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 运行状态读取_Click(object sender, EventArgs e)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 34;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			运行状态显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 运行状态显示(byte[] bb)
	{
		if ((bb[4] & 1) == 1)
		{
			复费率.Checked = true;
		}
		else
		{
			单费率.Checked = true;
		}
		if ((bb[4] & 2) == 2)
		{
			时钟脉冲.Checked = true;
		}
		else
		{
			电能脉冲.Checked = true;
		}
		if ((bb[4] & 4) == 4)
		{
			副通讯.Checked = true;
		}
		else
		{
			红外.Checked = true;
		}
		if ((bb[4] & 8) == 8)
		{
			外控.Checked = true;
		}
		else
		{
			内控.Checked = true;
		}
		if ((bb[4] & 0x10) == 16)
		{
			有射频.Checked = true;
		}
		else
		{
			无射频.Checked = true;
		}
		if ((bb[4] & 0x20) == 32)
		{
			加密开.Checked = true;
		}
		else
		{
			加密关.Checked = true;
		}
		if ((bb[4] & 0x40) == 64)
		{
			DDSY.Checked = true;
		}
		else
		{
			DDSF.Checked = true;
		}
		if ((bb[4] & 0x80) == 128)
		{
			三相三线.Checked = true;
		}
		else
		{
			三相四线.Checked = true;
		}
	}

	private void 读取预付费参数_Click(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[61];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 70;
		array[4] = 0;
		array[5] = 28;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			预付费参数显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 预付费参数显示(byte[] bb)
	{
		double num = (bb[3] << 24) | (bb[4] << 16) | (bb[5] << 8) | bb[6];
		((Control)BJ1).Text = num.ToString("f0");
		num = (bb[7] << 24) | (bb[8] << 16) | (bb[9] << 8) | bb[10];
		((Control)BJ2).Text = num.ToString("f0");
		num = (bb[11] << 24) | (bb[12] << 16) | (bb[13] << 8) | bb[14];
		((Control)SQJE).Text = num.ToString("f0");
		int num2 = (bb[19] << 8) | bb[20];
		((Control)BuyTime).Text = num2.ToString("f0");
		num = (bb[21] << 24) | (bb[22] << 16) | (bb[23] << 8) | bb[24];
		((Control)SYJE).Text = num.ToString("f0");
		num2 = bb[33];
		((Control)FKState).Text = num2.ToString("f0");
		num = (bb[41] << 24) | (bb[42] << 16) | (bb[43] << 8) | bb[44];
		((Control)PriceJ).Text = num.ToString("f0");
		num = (bb[45] << 24) | (bb[46] << 16) | (bb[47] << 8) | bb[48];
		((Control)PriceF).Text = num.ToString("f0");
		num = (bb[49] << 24) | (bb[50] << 16) | (bb[51] << 8) | bb[52];
		((Control)PriceP).Text = num.ToString("f0");
		num = (bb[53] << 24) | (bb[54] << 16) | (bb[55] << 8) | bb[56];
		((Control)PriceG).Text = num.ToString("f0");
		num2 = (bb[57] << 8) | bb[58];
		((Control)PMAX).Text = num2.ToString("f0");
	}

	private void 设置预付费参数_Click(object sender, EventArgs e)
	{
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[65];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 170;
		array[2] = 0;
		array[3] = 70;
		array[4] = 0;
		array[5] = 28;
		array[6] = 56;
		array[7] = (byte)(Convert.ToInt32(((Control)BJ1).Text) >> 24);
		array[8] = (byte)(Convert.ToInt32(((Control)BJ1).Text) >> 16);
		array[9] = (byte)(Convert.ToInt32(((Control)BJ1).Text) >> 8);
		array[10] = (byte)Convert.ToInt32(((Control)BJ1).Text);
		array[11] = (byte)(Convert.ToInt32(((Control)BJ2).Text) >> 24);
		array[12] = (byte)(Convert.ToInt32(((Control)BJ2).Text) >> 16);
		array[13] = (byte)(Convert.ToInt32(((Control)BJ2).Text) >> 8);
		array[14] = (byte)Convert.ToInt32(((Control)BJ2).Text);
		array[15] = (byte)(Convert.ToInt32(((Control)SQJE).Text) >> 24);
		array[16] = (byte)(Convert.ToInt32(((Control)SQJE).Text) >> 16);
		array[17] = (byte)(Convert.ToInt32(((Control)SQJE).Text) >> 8);
		array[18] = (byte)Convert.ToInt32(((Control)SQJE).Text);
		array[19] = 0;
		array[20] = 0;
		array[21] = 0;
		array[22] = 0;
		array[23] = (byte)(Convert.ToInt16(((Control)BuyTime).Text) >> 8);
		array[24] = (byte)Convert.ToInt16(((Control)BuyTime).Text);
		array[25] = (byte)(Convert.ToInt32(((Control)SYJE).Text) >> 24);
		array[26] = (byte)(Convert.ToInt32(((Control)SYJE).Text) >> 16);
		array[27] = (byte)(Convert.ToInt32(((Control)SYJE).Text) >> 8);
		array[28] = (byte)Convert.ToInt32(((Control)SYJE).Text);
		array[29] = 0;
		array[30] = 0;
		array[31] = 0;
		array[32] = 0;
		array[33] = 0;
		array[34] = 0;
		array[35] = 0;
		array[36] = 0;
		array[37] = (byte)Convert.ToSByte(((Control)FKState).Text);
		array[38] = 0;
		array[39] = 0;
		array[40] = 0;
		array[41] = 0;
		array[42] = 0;
		array[43] = 0;
		array[44] = 0;
		array[45] = (byte)(Convert.ToInt32(((Control)PriceJ).Text) >> 24);
		array[46] = (byte)(Convert.ToInt32(((Control)PriceJ).Text) >> 16);
		array[47] = (byte)(Convert.ToInt32(((Control)PriceJ).Text) >> 8);
		array[48] = (byte)Convert.ToInt32(((Control)PriceJ).Text);
		array[49] = (byte)(Convert.ToInt32(((Control)PriceF).Text) >> 24);
		array[50] = (byte)(Convert.ToInt32(((Control)PriceF).Text) >> 16);
		array[51] = (byte)(Convert.ToInt32(((Control)PriceF).Text) >> 8);
		array[52] = (byte)Convert.ToInt32(((Control)PriceF).Text);
		array[53] = (byte)(Convert.ToInt32(((Control)PriceP).Text) >> 24);
		array[54] = (byte)(Convert.ToInt32(((Control)PriceP).Text) >> 16);
		array[55] = (byte)(Convert.ToInt32(((Control)PriceP).Text) >> 8);
		array[56] = (byte)Convert.ToInt32(((Control)PriceP).Text);
		array[57] = (byte)(Convert.ToInt32(((Control)PriceG).Text) >> 24);
		array[58] = (byte)(Convert.ToInt32(((Control)PriceG).Text) >> 16);
		array[59] = (byte)(Convert.ToInt32(((Control)PriceG).Text) >> 8);
		array[60] = (byte)Convert.ToInt32(((Control)PriceG).Text);
		array[61] = (byte)(Convert.ToUInt16(((Control)PMAX).Text) >> 8);
		array[62] = (byte)Convert.ToUInt16(((Control)PMAX).Text);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 地址设置_Click(object sender, EventArgs e)
	{
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[19];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 3;
		if (主通讯.Checked)
		{
			array[3] = 96;
		}
		else
		{
			array[3] = 101;
		}
		array[4] = 0;
		array[5] = 5;
		array[6] = 10;
		array[7] = Convert.ToByte(((Control)地址textBox).Text);
		array[8] = (byte)((ListControl)波特率comboBox).SelectedIndex;
		array[9] = (byte)((ListControl)校验位comboBox).SelectedIndex;
		array[10] = (byte)((ListControl)停止位comboBox).SelectedIndex;
		GetMeterID();
		array[11] = MeterIDToSet[0];
		array[12] = MeterIDToSet[1];
		array[13] = MeterIDToSet[2];
		array[14] = MeterIDToSet[3];
		array[15] = MeterIDToSet[4];
		array[16] = MeterIDToSet[5];
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 地址读取_Click(object sender, EventArgs e)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 3;
		if (主通讯.Checked)
		{
			array[3] = 96;
		}
		else
		{
			array[3] = 101;
		}
		array[4] = 0;
		array[5] = 5;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			地址显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 地址显示(byte[] bb)
	{
		((Control)地址textBox).Text = bb[3].ToString();
		((ListControl)波特率comboBox).SelectedIndex = bb[4];
		((ListControl)校验位comboBox).SelectedIndex = bb[5];
		((ListControl)停止位comboBox).SelectedIndex = bb[6];
		string text = "";
		int[] array = new int[6];
		for (int i = 0; i < 6; i++)
		{
			array[i] = bb[7 + i] / 16 * 10 + bb[7 + i] % 16;
		}
		for (int j = 0; j < 6; j++)
		{
			text = ((array[j] != 0) ? ((array[j] >= 10 || array[j] <= 0) ? (text + array[j]) : (text + "0" + array[j])) : (text + "00"));
		}
		((Control)表号textBox).Text = text;
	}

	private int CheckMeterIDSet()
	{
		int num = 0;
		int num2 = 0;
		if (((Control)表号textBox).Text.Trim() == "")
		{
			return 1;
		}
		string text = ((Control)表号textBox).Text.Trim();
		foreach (char c in text)
		{
			if (c < '0' || c > '9')
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			return 2;
		}
		return 0;
	}

	private void GetMeterID()
	{
		string text = "";
		int num = 12 - ((Control)表号textBox).Text.Length;
		for (int i = 0; i < num; i++)
		{
			text += "0";
		}
		((Control)表号textBox).Text = text + ((Control)表号textBox).Text;
		int num2 = 0;
		int num3 = 0;
		while (num2 < 6)
		{
			MeterIDToSet[num3] = (byte)(Convert.ToInt16(((Control)表号textBox).Text.Substring(num2 * 2, 2)) / 10 * 16 + Convert.ToInt16(((Control)表号textBox).Text.Substring(num2 * 2, 2)) % 10);
			num2++;
			num3++;
		}
	}

	private void GetMeterID3()
	{
		string text = "";
		int num = 10 - ((Control)ADF表号).Text.Length;
		for (int i = 0; i < num; i++)
		{
			text += "0";
		}
		((Control)ADF表号).Text = text + ((Control)ADF表号).Text;
		int num2 = 0;
		int num3 = 0;
		while (num2 < 5)
		{
			MeterIDToSet[num3] = (byte)(Convert.ToInt16(((Control)ADF表号).Text.Substring(num2 * 2, 2)) / 10 * 16 + Convert.ToInt16(((Control)ADF表号).Text.Substring(num2 * 2, 2)) % 10);
			num2++;
			num3++;
		}
	}

	private void GetMeterID4()
	{
		string text = "";
		int num = 16 - ((Control)序列号).Text.Length;
		for (int i = 0; i < num; i++)
		{
			text += "0";
		}
		((Control)序列号).Text = text + ((Control)序列号).Text;
		int num2 = 0;
		int num3 = 0;
		while (num2 < 8)
		{
			MeterIDToSet[num3] = (byte)(Convert.ToInt16(((Control)序列号).Text.Substring(num2 * 2, 2)) / 10 * 16 + Convert.ToInt16(((Control)序列号).Text.Substring(num2 * 2, 2)) % 10);
			num2++;
			num3++;
		}
	}

	private void GetMeterID5()
	{
		string text = "";
		int num = 10 - ((Control)ADF400表号).Text.Length;
		for (int i = 0; i < num; i++)
		{
			text += "0";
		}
		((Control)ADF400表号).Text = text + ((Control)ADF400表号).Text;
		int num2 = 0;
		int num3 = 0;
		while (num2 < 5)
		{
			MeterIDToSet[num3] = (byte)(Convert.ToInt16(((Control)ADF400表号).Text.Substring(num2 * 2, 2)) / 10 * 16 + Convert.ToInt16(((Control)ADF400表号).Text.Substring(num2 * 2, 2)) % 10);
			num2++;
			num3++;
		}
	}

	private void button11_Click(object sender, EventArgs e)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		num = CheckMeterIDSet();
		GetMeterID();
		switch (num)
		{
			case 2:
				MessageBox.Show("Please confirm that the input table number does not contain other characters！");
				return;
			case 1:
				MessageBox.Show("Please confirm that the account number or table number has been entered！");
				return;
		}
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[15];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 67;
		array[4] = 0;
		array[5] = 3;
		array[6] = 6;
		array[7] = MeterIDToSet[0];
		array[8] = MeterIDToSet[1];
		array[9] = MeterIDToSet[2];
		array[10] = MeterIDToSet[3];
		array[11] = MeterIDToSet[4];
		array[12] = MeterIDToSet[5];
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button10_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[11];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 67;
		array[4] = 0;
		array[5] = 3;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			表号显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 表号显示(byte[] bb)
	{
		string text = "";
		int[] array = new int[6];
		for (int i = 0; i < 6; i++)
		{
			array[i] = bb[3 + i] / 16 * 10 + bb[3 + i] % 16;
		}
		for (int j = 0; j < 6; j++)
		{
			text = ((array[j] != 0) ? ((array[j] >= 10 || array[j] <= 0) ? (text + array[j]) : (text + "0" + array[j])) : (text + "00"));
		}
		((Control)表号textBox).Text = text;
	}

	private void button13_Click(object sender, EventArgs e)
	{
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 55;
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = (byte)(Convert.ToInt16(((Control)CTValue).Text) / 256);
		array[8] = (byte)Convert.ToInt16(((Control)CTValue).Text);
		array[9] = (byte)(Convert.ToInt16(((Control)PTValue).Text) / 256);
		array[10] = (byte)Convert.ToInt16(((Control)PTValue).Text);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void GetTimeSche1()
	{
		TimeSchedule.Price1 = (byte)((ListControl)comboBoxCharge1_S1).SelectedIndex;
		if (TimeSchedule.Price1 == byte.MaxValue)
		{
			TimeSchedule.Price1 = 0;
		}
		TimeSchedule.Price2 = (byte)((ListControl)comboBoxCharge2_S1).SelectedIndex;
		if (TimeSchedule.Price2 == byte.MaxValue)
		{
			TimeSchedule.Price2 = 0;
		}
		TimeSchedule.Price3 = (byte)((ListControl)comboBoxCharge3_S1).SelectedIndex;
		if (TimeSchedule.Price3 == byte.MaxValue)
		{
			TimeSchedule.Price3 = 0;
		}
		TimeSchedule.Price4 = (byte)((ListControl)comboBoxCharge4_S1).SelectedIndex;
		if (TimeSchedule.Price4 == byte.MaxValue)
		{
			TimeSchedule.Price4 = 0;
		}
		TimeSchedule.Price5 = (byte)((ListControl)comboBoxCharge5_S1).SelectedIndex;
		if (TimeSchedule.Price5 == byte.MaxValue)
		{
			TimeSchedule.Price5 = 0;
		}
		TimeSchedule.Price6 = (byte)((ListControl)comboBoxCharge6_S1).SelectedIndex;
		if (TimeSchedule.Price6 == byte.MaxValue)
		{
			TimeSchedule.Price6 = 0;
		}
		TimeSchedule.Price7 = (byte)((ListControl)comboBoxCharge7_S1).SelectedIndex;
		if (TimeSchedule.Price7 == byte.MaxValue)
		{
			TimeSchedule.Price7 = 0;
		}
		TimeSchedule.Price8 = (byte)((ListControl)comboBoxCharge8_S1).SelectedIndex;
		if (TimeSchedule.Price8 == byte.MaxValue)
		{
			TimeSchedule.Price8 = 0;
		}
		TimeSchedule.Price9 = (byte)((ListControl)comboBoxCharge9_S1).SelectedIndex;
		if (TimeSchedule.Price9 == byte.MaxValue)
		{
			TimeSchedule.Price9 = 0;
		}
		TimeSchedule.Price10 = (byte)((ListControl)comboBoxCharge10_S1).SelectedIndex;
		if (TimeSchedule.Price10 == byte.MaxValue)
		{
			TimeSchedule.Price10 = 0;
		}
		TimeSchedule.Price11 = (byte)((ListControl)comboBoxCharge11_S1).SelectedIndex;
		if (TimeSchedule.Price11 == byte.MaxValue)
		{
			TimeSchedule.Price11 = 0;
		}
		TimeSchedule.Price12 = (byte)((ListControl)comboBoxCharge12_S1).SelectedIndex;
		if (TimeSchedule.Price12 == byte.MaxValue)
		{
			TimeSchedule.Price12 = 0;
		}
		TimeSchedule.Price13 = (byte)((ListControl)comboBoxCharge13_S1).SelectedIndex;
		if (TimeSchedule.Price13 == byte.MaxValue)
		{
			TimeSchedule.Price13 = 0;
		}
		TimeSchedule.Price14 = (byte)((ListControl)comboBoxCharge14_S1).SelectedIndex;
		if (TimeSchedule.Price14 == byte.MaxValue)
		{
			TimeSchedule.Price14 = 0;
		}
		TimeSchedule.Minute1 = Convert.ToByte(((Control)textBoxMinute1_S1).Text);
		TimeSchedule.Minute2 = Convert.ToByte(((Control)textBoxMinute2_S1).Text);
		TimeSchedule.Minute3 = Convert.ToByte(((Control)textBoxMinute3_S1).Text);
		TimeSchedule.Minute4 = Convert.ToByte(((Control)textBoxMinute4_S1).Text);
		TimeSchedule.Minute5 = Convert.ToByte(((Control)textBoxMinute5_S1).Text);
		TimeSchedule.Minute6 = Convert.ToByte(((Control)textBoxMinute6_S1).Text);
		TimeSchedule.Minute7 = Convert.ToByte(((Control)textBoxMinute7_S1).Text);
		TimeSchedule.Minute8 = Convert.ToByte(((Control)textBoxMinute8_S1).Text);
		TimeSchedule.Minute9 = Convert.ToByte(((Control)textBoxMinute9_S1).Text);
		TimeSchedule.Minute10 = Convert.ToByte(((Control)textBoxMinute10_S1).Text);
		TimeSchedule.Minute11 = Convert.ToByte(((Control)textBoxMinute11_S1).Text);
		TimeSchedule.Minute12 = Convert.ToByte(((Control)textBoxMinute12_S1).Text);
		TimeSchedule.Minute13 = Convert.ToByte(((Control)textBoxMinute13_S1).Text);
		TimeSchedule.Minute14 = Convert.ToByte(((Control)textBoxMinute14_S1).Text);
		TimeSchedule.Hour1 = Convert.ToByte(((Control)textBoxHour1_S1).Text);
		TimeSchedule.Hour2 = Convert.ToByte(((Control)textBoxHour2_S1).Text);
		TimeSchedule.Hour3 = Convert.ToByte(((Control)textBoxHour3_S1).Text);
		TimeSchedule.Hour4 = Convert.ToByte(((Control)textBoxHour4_S1).Text);
		TimeSchedule.Hour5 = Convert.ToByte(((Control)textBoxHour5_S1).Text);
		TimeSchedule.Hour6 = Convert.ToByte(((Control)textBoxHour6_S1).Text);
		TimeSchedule.Hour7 = Convert.ToByte(((Control)textBoxHour7_S1).Text);
		TimeSchedule.Hour8 = Convert.ToByte(((Control)textBoxHour8_S1).Text);
		TimeSchedule.Hour9 = Convert.ToByte(((Control)textBoxHour9_S1).Text);
		TimeSchedule.Hour10 = Convert.ToByte(((Control)textBoxHour10_S1).Text);
		TimeSchedule.Hour11 = Convert.ToByte(((Control)textBoxHour11_S1).Text);
		TimeSchedule.Hour12 = Convert.ToByte(((Control)textBoxHour12_S1).Text);
		TimeSchedule.Hour13 = Convert.ToByte(((Control)textBoxHour13_S1).Text);
		TimeSchedule.Hour14 = Convert.ToByte(((Control)textBoxHour14_S1).Text);
	}

	private int CheckTimeScheSet1()
	{
		int num = 0;
		int num2 = 0;
		int[] array = new int[28];
		if (((Control)textBoxMinute1_S1).Text.Trim() == "" || ((Control)textBoxHour1_S1).Text.Trim() == "" || ((Control)textBoxMinute2_S1).Text.Trim() == "" || ((Control)textBoxHour2_S1).Text.Trim() == "" || ((Control)textBoxMinute3_S1).Text.Trim() == "" || ((Control)textBoxHour3_S1).Text.Trim() == "" || ((Control)textBoxMinute4_S1).Text.Trim() == "" || ((Control)textBoxHour4_S1).Text.Trim() == "" || ((Control)textBoxMinute5_S1).Text.Trim() == "" || ((Control)textBoxHour5_S1).Text.Trim() == "" || ((Control)textBoxMinute6_S1).Text.Trim() == "" || ((Control)textBoxHour6_S1).Text.Trim() == "" || ((Control)textBoxMinute7_S1).Text.Trim() == "" || ((Control)textBoxHour7_S1).Text.Trim() == "" || ((Control)textBoxMinute8_S1).Text.Trim() == "" || ((Control)textBoxHour8_S1).Text.Trim() == "" || ((Control)textBoxMinute9_S1).Text.Trim() == "" || ((Control)textBoxHour9_S1).Text.Trim() == "" || ((Control)textBoxMinute10_S1).Text.Trim() == "" || ((Control)textBoxHour10_S1).Text.Trim() == "" || ((Control)textBoxMinute11_S1).Text.Trim() == "" || ((Control)textBoxHour11_S1).Text.Trim() == "" || ((Control)textBoxMinute12_S1).Text.Trim() == "" || ((Control)textBoxHour12_S1).Text.Trim() == "" || ((Control)textBoxMinute13_S1).Text.Trim() == "" || ((Control)textBoxHour13_S1).Text.Trim() == "" || ((Control)textBoxMinute14_S1).Text.Trim() == "" || ((Control)textBoxHour14_S1).Text.Trim() == "")
		{
			return 1;
		}
		string text = ((Control)textBoxMinute1_S1).Text.Trim();
		foreach (char c in text)
		{
			if (c < '0' || c > '9')
			{
				num2++;
			}
		}
		string text2 = ((Control)textBoxHour1_S1).Text.Trim();
		foreach (char c2 in text2)
		{
			if (c2 < '0' || c2 > '9')
			{
				num2++;
			}
		}
		string text3 = ((Control)textBoxMinute2_S1).Text.Trim();
		foreach (char c3 in text3)
		{
			if (c3 < '0' || c3 > '9')
			{
				num2++;
			}
		}
		string text4 = ((Control)textBoxHour2_S1).Text.Trim();
		foreach (char c4 in text4)
		{
			if (c4 < '0' || c4 > '9')
			{
				num2++;
			}
		}
		string text5 = ((Control)textBoxMinute3_S1).Text.Trim();
		foreach (char c5 in text5)
		{
			if (c5 < '0' || c5 > '9')
			{
				num2++;
			}
		}
		string text6 = ((Control)textBoxHour3_S1).Text.Trim();
		foreach (char c6 in text6)
		{
			if (c6 < '0' || c6 > '9')
			{
				num2++;
			}
		}
		string text7 = ((Control)textBoxMinute4_S1).Text.Trim();
		foreach (char c7 in text7)
		{
			if (c7 < '0' || c7 > '9')
			{
				num2++;
			}
		}
		string text8 = ((Control)textBoxHour4_S1).Text.Trim();
		foreach (char c8 in text8)
		{
			if (c8 < '0' || c8 > '9')
			{
				num2++;
			}
		}
		string text9 = ((Control)textBoxMinute5_S1).Text.Trim();
		foreach (char c9 in text9)
		{
			if (c9 < '0' || c9 > '9')
			{
				num2++;
			}
		}
		string text10 = ((Control)textBoxHour5_S1).Text.Trim();
		foreach (char c10 in text10)
		{
			if (c10 < '0' || c10 > '9')
			{
				num2++;
			}
		}
		string text11 = ((Control)textBoxMinute6_S1).Text.Trim();
		foreach (char c11 in text11)
		{
			if (c11 < '0' || c11 > '9')
			{
				num2++;
			}
		}
		string text12 = ((Control)textBoxHour6_S1).Text.Trim();
		foreach (char c12 in text12)
		{
			if (c12 < '0' || c12 > '9')
			{
				num2++;
			}
		}
		string text13 = ((Control)textBoxMinute7_S1).Text.Trim();
		foreach (char c13 in text13)
		{
			if (c13 < '0' || c13 > '9')
			{
				num2++;
			}
		}
		string text14 = ((Control)textBoxHour7_S1).Text.Trim();
		foreach (char c14 in text14)
		{
			if (c14 < '0' || c14 > '9')
			{
				num2++;
			}
		}
		string text15 = ((Control)textBoxMinute8_S1).Text.Trim();
		foreach (char c15 in text15)
		{
			if (c15 < '0' || c15 > '9')
			{
				num2++;
			}
		}
		string text16 = ((Control)textBoxHour8_S1).Text.Trim();
		foreach (char c16 in text16)
		{
			if (c16 < '0' || c16 > '9')
			{
				num2++;
			}
		}
		string text17 = ((Control)textBoxMinute9_S1).Text.Trim();
		foreach (char c17 in text17)
		{
			if (c17 < '0' || c17 > '9')
			{
				num2++;
			}
		}
		string text18 = ((Control)textBoxHour9_S1).Text.Trim();
		foreach (char c18 in text18)
		{
			if (c18 < '0' || c18 > '9')
			{
				num2++;
			}
		}
		string text19 = ((Control)textBoxMinute10_S1).Text.Trim();
		foreach (char c19 in text19)
		{
			if (c19 < '0' || c19 > '9')
			{
				num2++;
			}
		}
		string text20 = ((Control)textBoxHour10_S1).Text.Trim();
		foreach (char c20 in text20)
		{
			if (c20 < '0' || c20 > '9')
			{
				num2++;
			}
		}
		string text21 = ((Control)textBoxMinute11_S1).Text.Trim();
		foreach (char c21 in text21)
		{
			if (c21 < '0' || c21 > '9')
			{
				num2++;
			}
		}
		string text22 = ((Control)textBoxHour11_S1).Text.Trim();
		foreach (char c22 in text22)
		{
			if (c22 < '0' || c22 > '9')
			{
				num2++;
			}
		}
		string text23 = ((Control)textBoxMinute12_S1).Text.Trim();
		foreach (char c23 in text23)
		{
			if (c23 < '0' || c23 > '9')
			{
				num2++;
			}
		}
		string text24 = ((Control)textBoxHour12_S1).Text.Trim();
		foreach (char c24 in text24)
		{
			if (c24 < '0' || c24 > '9')
			{
				num2++;
			}
		}
		string text25 = ((Control)textBoxMinute13_S1).Text.Trim();
		foreach (char c25 in text25)
		{
			if (c25 < '0' || c25 > '9')
			{
				num2++;
			}
		}
		string text26 = ((Control)textBoxHour13_S1).Text.Trim();
		foreach (char c26 in text26)
		{
			if (c26 < '0' || c26 > '9')
			{
				num2++;
			}
		}
		string text27 = ((Control)textBoxMinute14_S1).Text.Trim();
		foreach (char c27 in text27)
		{
			if (c27 < '0' || c27 > '9')
			{
				num2++;
			}
		}
		string text28 = ((Control)textBoxHour14_S1).Text.Trim();
		foreach (char c28 in text28)
		{
			if (c28 < '0' || c28 > '9')
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			return 2;
		}
		array[0] = Convert.ToInt16(((Control)textBoxMinute1_S1).Text);
		array[1] = Convert.ToInt16(((Control)textBoxMinute2_S1).Text);
		array[2] = Convert.ToInt16(((Control)textBoxMinute3_S1).Text);
		array[3] = Convert.ToInt16(((Control)textBoxMinute4_S1).Text);
		array[4] = Convert.ToInt16(((Control)textBoxMinute5_S1).Text);
		array[5] = Convert.ToInt16(((Control)textBoxMinute6_S1).Text);
		array[6] = Convert.ToInt16(((Control)textBoxMinute7_S1).Text);
		array[7] = Convert.ToInt16(((Control)textBoxMinute8_S1).Text);
		array[8] = Convert.ToInt16(((Control)textBoxMinute9_S1).Text);
		array[9] = Convert.ToInt16(((Control)textBoxMinute10_S1).Text);
		array[10] = Convert.ToInt16(((Control)textBoxMinute11_S1).Text);
		array[11] = Convert.ToInt16(((Control)textBoxMinute12_S1).Text);
		array[12] = Convert.ToInt16(((Control)textBoxMinute13_S1).Text);
		array[13] = Convert.ToInt16(((Control)textBoxMinute14_S1).Text);
		array[14] = Convert.ToInt16(((Control)textBoxHour1_S1).Text);
		array[15] = Convert.ToInt16(((Control)textBoxHour2_S1).Text);
		array[16] = Convert.ToInt16(((Control)textBoxHour3_S1).Text);
		array[17] = Convert.ToInt16(((Control)textBoxHour4_S1).Text);
		array[18] = Convert.ToInt16(((Control)textBoxHour5_S1).Text);
		array[19] = Convert.ToInt16(((Control)textBoxHour6_S1).Text);
		array[20] = Convert.ToInt16(((Control)textBoxHour7_S1).Text);
		array[21] = Convert.ToInt16(((Control)textBoxHour8_S1).Text);
		array[22] = Convert.ToInt16(((Control)textBoxHour9_S1).Text);
		array[23] = Convert.ToInt16(((Control)textBoxHour10_S1).Text);
		array[24] = Convert.ToInt16(((Control)textBoxHour11_S1).Text);
		array[25] = Convert.ToInt16(((Control)textBoxHour12_S1).Text);
		array[26] = Convert.ToInt16(((Control)textBoxHour13_S1).Text);
		array[27] = Convert.ToInt16(((Control)textBoxHour14_S1).Text);
		for (int num25 = 0; num25 < 14; num25++)
		{
			if (array[num25] > 59)
			{
				return 3;
			}
		}
		for (int num26 = 0; num26 < 14; num26++)
		{
			if (array[num26 + 14] > 23)
			{
				return 4;
			}
		}
		return 0;
	}

	private void buttonSetSched1_Click(object sender, EventArgs e)
	{
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		if (!CheckAddr())
		{
			return;
		}
		switch (CheckTimeScheSet1())
		{
			case 2:
				MessageBox.Show("请确认输入的时段表不包含其他字符！");
				return;
			case 1:
				MessageBox.Show("请确认已输入时段表！");
				return;
			case 3:
				MessageBox.Show("请确认已输入正确的分钟！");
				return;
			case 4:
				MessageBox.Show("请确认已输入正确的时间！");
				return;
		}
		GetTimeSche1();
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[51];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		if (MeterType == 3)
		{
			array[2] = 9;
			array[3] = 20;
		}
		else if (MeterType == 1)
		{
			array[2] = 32;
			array[3] = 6;
		}
		else
		{
			array[2] = 32;
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 21;
		array[6] = 42;
		array[7] = TimeSchedule.Price1;
		array[8] = TimeSchedule.Minute1;
		array[9] = TimeSchedule.Hour1;
		array[10] = TimeSchedule.Price2;
		array[11] = TimeSchedule.Minute2;
		array[12] = TimeSchedule.Hour2;
		array[13] = TimeSchedule.Price3;
		array[14] = TimeSchedule.Minute3;
		array[15] = TimeSchedule.Hour3;
		array[16] = TimeSchedule.Price4;
		array[17] = TimeSchedule.Minute4;
		array[18] = TimeSchedule.Hour4;
		array[19] = TimeSchedule.Price5;
		array[20] = TimeSchedule.Minute5;
		array[21] = TimeSchedule.Hour5;
		array[22] = TimeSchedule.Price6;
		array[23] = TimeSchedule.Minute6;
		array[24] = TimeSchedule.Hour6;
		array[25] = TimeSchedule.Price7;
		array[26] = TimeSchedule.Minute7;
		array[27] = TimeSchedule.Hour7;
		array[28] = TimeSchedule.Price8;
		array[29] = TimeSchedule.Minute8;
		array[30] = TimeSchedule.Hour8;
		array[31] = TimeSchedule.Price9;
		array[32] = TimeSchedule.Minute9;
		array[33] = TimeSchedule.Hour9;
		array[34] = TimeSchedule.Price10;
		array[35] = TimeSchedule.Minute10;
		array[36] = TimeSchedule.Hour10;
		array[37] = TimeSchedule.Price11;
		array[38] = TimeSchedule.Minute11;
		array[39] = TimeSchedule.Hour11;
		array[40] = TimeSchedule.Price12;
		array[41] = TimeSchedule.Minute12;
		array[42] = TimeSchedule.Hour12;
		array[43] = TimeSchedule.Price13;
		array[44] = TimeSchedule.Minute13;
		array[45] = TimeSchedule.Hour13;
		array[46] = TimeSchedule.Price14;
		array[47] = TimeSchedule.Minute14;
		array[48] = TimeSchedule.Hour14;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void GetTimeSche2()
	{
		TimeSchedule.Price1 = (byte)((ListControl)comboBoxCharge1_S2).SelectedIndex;
		if (TimeSchedule.Price1 == byte.MaxValue)
		{
			TimeSchedule.Price1 = 0;
		}
		TimeSchedule.Price2 = (byte)((ListControl)comboBoxCharge2_S2).SelectedIndex;
		if (TimeSchedule.Price2 == byte.MaxValue)
		{
			TimeSchedule.Price2 = 0;
		}
		TimeSchedule.Price3 = (byte)((ListControl)comboBoxCharge3_S2).SelectedIndex;
		if (TimeSchedule.Price3 == byte.MaxValue)
		{
			TimeSchedule.Price3 = 0;
		}
		TimeSchedule.Price4 = (byte)((ListControl)comboBoxCharge4_S2).SelectedIndex;
		if (TimeSchedule.Price4 == byte.MaxValue)
		{
			TimeSchedule.Price4 = 0;
		}
		TimeSchedule.Price5 = (byte)((ListControl)comboBoxCharge5_S2).SelectedIndex;
		if (TimeSchedule.Price5 == byte.MaxValue)
		{
			TimeSchedule.Price5 = 0;
		}
		TimeSchedule.Price6 = (byte)((ListControl)comboBoxCharge6_S2).SelectedIndex;
		if (TimeSchedule.Price6 == byte.MaxValue)
		{
			TimeSchedule.Price6 = 0;
		}
		TimeSchedule.Price7 = (byte)((ListControl)comboBoxCharge7_S2).SelectedIndex;
		if (TimeSchedule.Price7 == byte.MaxValue)
		{
			TimeSchedule.Price7 = 0;
		}
		TimeSchedule.Price8 = (byte)((ListControl)comboBoxCharge8_S2).SelectedIndex;
		if (TimeSchedule.Price8 == byte.MaxValue)
		{
			TimeSchedule.Price8 = 0;
		}
		TimeSchedule.Price9 = (byte)((ListControl)comboBoxCharge9_S2).SelectedIndex;
		if (TimeSchedule.Price9 == byte.MaxValue)
		{
			TimeSchedule.Price9 = 0;
		}
		TimeSchedule.Price10 = (byte)((ListControl)comboBoxCharge10_S2).SelectedIndex;
		if (TimeSchedule.Price10 == byte.MaxValue)
		{
			TimeSchedule.Price10 = 0;
		}
		TimeSchedule.Price11 = (byte)((ListControl)comboBoxCharge11_S2).SelectedIndex;
		if (TimeSchedule.Price11 == byte.MaxValue)
		{
			TimeSchedule.Price11 = 0;
		}
		TimeSchedule.Price12 = (byte)((ListControl)comboBoxCharge12_S2).SelectedIndex;
		if (TimeSchedule.Price12 == byte.MaxValue)
		{
			TimeSchedule.Price12 = 0;
		}
		TimeSchedule.Price13 = (byte)((ListControl)comboBoxCharge13_S2).SelectedIndex;
		if (TimeSchedule.Price13 == byte.MaxValue)
		{
			TimeSchedule.Price13 = 0;
		}
		TimeSchedule.Price14 = (byte)((ListControl)comboBoxCharge14_S2).SelectedIndex;
		if (TimeSchedule.Price14 == byte.MaxValue)
		{
			TimeSchedule.Price14 = 0;
		}
		TimeSchedule.Minute1 = Convert.ToByte(((Control)textBoxMinute1_S2).Text);
		TimeSchedule.Minute2 = Convert.ToByte(((Control)textBoxMinute2_S2).Text);
		TimeSchedule.Minute3 = Convert.ToByte(((Control)textBoxMinute3_S2).Text);
		TimeSchedule.Minute4 = Convert.ToByte(((Control)textBoxMinute4_S2).Text);
		TimeSchedule.Minute5 = Convert.ToByte(((Control)textBoxMinute5_S2).Text);
		TimeSchedule.Minute6 = Convert.ToByte(((Control)textBoxMinute6_S2).Text);
		TimeSchedule.Minute7 = Convert.ToByte(((Control)textBoxMinute7_S2).Text);
		TimeSchedule.Minute8 = Convert.ToByte(((Control)textBoxMinute8_S2).Text);
		TimeSchedule.Minute9 = Convert.ToByte(((Control)textBoxMinute9_S2).Text);
		TimeSchedule.Minute10 = Convert.ToByte(((Control)textBoxMinute10_S2).Text);
		TimeSchedule.Minute11 = Convert.ToByte(((Control)textBoxMinute11_S2).Text);
		TimeSchedule.Minute12 = Convert.ToByte(((Control)textBoxMinute12_S2).Text);
		TimeSchedule.Minute13 = Convert.ToByte(((Control)textBoxMinute13_S2).Text);
		TimeSchedule.Minute14 = Convert.ToByte(((Control)textBoxMinute14_S2).Text);
		TimeSchedule.Hour1 = Convert.ToByte(((Control)textBoxHour1_S2).Text);
		TimeSchedule.Hour2 = Convert.ToByte(((Control)textBoxHour2_S2).Text);
		TimeSchedule.Hour3 = Convert.ToByte(((Control)textBoxHour3_S2).Text);
		TimeSchedule.Hour4 = Convert.ToByte(((Control)textBoxHour4_S2).Text);
		TimeSchedule.Hour5 = Convert.ToByte(((Control)textBoxHour5_S2).Text);
		TimeSchedule.Hour6 = Convert.ToByte(((Control)textBoxHour6_S2).Text);
		TimeSchedule.Hour7 = Convert.ToByte(((Control)textBoxHour7_S2).Text);
		TimeSchedule.Hour8 = Convert.ToByte(((Control)textBoxHour8_S2).Text);
		TimeSchedule.Hour9 = Convert.ToByte(((Control)textBoxHour9_S2).Text);
		TimeSchedule.Hour10 = Convert.ToByte(((Control)textBoxHour10_S2).Text);
		TimeSchedule.Hour11 = Convert.ToByte(((Control)textBoxHour11_S2).Text);
		TimeSchedule.Hour12 = Convert.ToByte(((Control)textBoxHour12_S2).Text);
		TimeSchedule.Hour13 = Convert.ToByte(((Control)textBoxHour13_S2).Text);
		TimeSchedule.Hour14 = Convert.ToByte(((Control)textBoxHour14_S2).Text);
	}

	private int CheckTimeScheSet2()
	{
		int num = 0;
		int num2 = 0;
		int[] array = new int[28];
		if (((Control)textBoxMinute1_S2).Text.Trim() == "" || ((Control)textBoxHour1_S2).Text.Trim() == "" || ((Control)textBoxMinute2_S2).Text.Trim() == "" || ((Control)textBoxHour2_S2).Text.Trim() == "" || ((Control)textBoxMinute3_S2).Text.Trim() == "" || ((Control)textBoxHour3_S2).Text.Trim() == "" || ((Control)textBoxMinute4_S2).Text.Trim() == "" || ((Control)textBoxHour4_S2).Text.Trim() == "" || ((Control)textBoxMinute5_S2).Text.Trim() == "" || ((Control)textBoxHour5_S2).Text.Trim() == "" || ((Control)textBoxMinute6_S2).Text.Trim() == "" || ((Control)textBoxHour6_S2).Text.Trim() == "" || ((Control)textBoxMinute7_S2).Text.Trim() == "" || ((Control)textBoxHour7_S2).Text.Trim() == "" || ((Control)textBoxMinute8_S2).Text.Trim() == "" || ((Control)textBoxHour8_S2).Text.Trim() == "" || ((Control)textBoxMinute9_S2).Text.Trim() == "" || ((Control)textBoxHour9_S2).Text.Trim() == "" || ((Control)textBoxMinute10_S2).Text.Trim() == "" || ((Control)textBoxHour10_S2).Text.Trim() == "" || ((Control)textBoxMinute11_S2).Text.Trim() == "" || ((Control)textBoxHour11_S2).Text.Trim() == "" || ((Control)textBoxMinute12_S2).Text.Trim() == "" || ((Control)textBoxHour12_S2).Text.Trim() == "" || ((Control)textBoxMinute13_S2).Text.Trim() == "" || ((Control)textBoxHour13_S2).Text.Trim() == "" || ((Control)textBoxMinute14_S2).Text.Trim() == "" || ((Control)textBoxHour14_S2).Text.Trim() == "")
		{
			return 1;
		}
		string text = ((Control)textBoxMinute1_S2).Text.Trim();
		foreach (char c in text)
		{
			if (c < '0' || c > '9')
			{
				num2++;
			}
		}
		string text2 = ((Control)textBoxHour1_S2).Text.Trim();
		foreach (char c2 in text2)
		{
			if (c2 < '0' || c2 > '9')
			{
				num2++;
			}
		}
		string text3 = ((Control)textBoxMinute2_S2).Text.Trim();
		foreach (char c3 in text3)
		{
			if (c3 < '0' || c3 > '9')
			{
				num2++;
			}
		}
		string text4 = ((Control)textBoxHour2_S2).Text.Trim();
		foreach (char c4 in text4)
		{
			if (c4 < '0' || c4 > '9')
			{
				num2++;
			}
		}
		string text5 = ((Control)textBoxMinute3_S2).Text.Trim();
		foreach (char c5 in text5)
		{
			if (c5 < '0' || c5 > '9')
			{
				num2++;
			}
		}
		string text6 = ((Control)textBoxHour3_S2).Text.Trim();
		foreach (char c6 in text6)
		{
			if (c6 < '0' || c6 > '9')
			{
				num2++;
			}
		}
		string text7 = ((Control)textBoxMinute4_S2).Text.Trim();
		foreach (char c7 in text7)
		{
			if (c7 < '0' || c7 > '9')
			{
				num2++;
			}
		}
		string text8 = ((Control)textBoxHour4_S2).Text.Trim();
		foreach (char c8 in text8)
		{
			if (c8 < '0' || c8 > '9')
			{
				num2++;
			}
		}
		string text9 = ((Control)textBoxMinute5_S2).Text.Trim();
		foreach (char c9 in text9)
		{
			if (c9 < '0' || c9 > '9')
			{
				num2++;
			}
		}
		string text10 = ((Control)textBoxHour5_S2).Text.Trim();
		foreach (char c10 in text10)
		{
			if (c10 < '0' || c10 > '9')
			{
				num2++;
			}
		}
		string text11 = ((Control)textBoxMinute6_S2).Text.Trim();
		foreach (char c11 in text11)
		{
			if (c11 < '0' || c11 > '9')
			{
				num2++;
			}
		}
		string text12 = ((Control)textBoxHour6_S2).Text.Trim();
		foreach (char c12 in text12)
		{
			if (c12 < '0' || c12 > '9')
			{
				num2++;
			}
		}
		string text13 = ((Control)textBoxMinute7_S2).Text.Trim();
		foreach (char c13 in text13)
		{
			if (c13 < '0' || c13 > '9')
			{
				num2++;
			}
		}
		string text14 = ((Control)textBoxHour7_S2).Text.Trim();
		foreach (char c14 in text14)
		{
			if (c14 < '0' || c14 > '9')
			{
				num2++;
			}
		}
		string text15 = ((Control)textBoxMinute8_S2).Text.Trim();
		foreach (char c15 in text15)
		{
			if (c15 < '0' || c15 > '9')
			{
				num2++;
			}
		}
		string text16 = ((Control)textBoxHour8_S2).Text.Trim();
		foreach (char c16 in text16)
		{
			if (c16 < '0' || c16 > '9')
			{
				num2++;
			}
		}
		string text17 = ((Control)textBoxMinute9_S2).Text.Trim();
		foreach (char c17 in text17)
		{
			if (c17 < '0' || c17 > '9')
			{
				num2++;
			}
		}
		string text18 = ((Control)textBoxHour9_S2).Text.Trim();
		foreach (char c18 in text18)
		{
			if (c18 < '0' || c18 > '9')
			{
				num2++;
			}
		}
		string text19 = ((Control)textBoxMinute10_S2).Text.Trim();
		foreach (char c19 in text19)
		{
			if (c19 < '0' || c19 > '9')
			{
				num2++;
			}
		}
		string text20 = ((Control)textBoxHour10_S2).Text.Trim();
		foreach (char c20 in text20)
		{
			if (c20 < '0' || c20 > '9')
			{
				num2++;
			}
		}
		string text21 = ((Control)textBoxMinute11_S2).Text.Trim();
		foreach (char c21 in text21)
		{
			if (c21 < '0' || c21 > '9')
			{
				num2++;
			}
		}
		string text22 = ((Control)textBoxHour11_S2).Text.Trim();
		foreach (char c22 in text22)
		{
			if (c22 < '0' || c22 > '9')
			{
				num2++;
			}
		}
		string text23 = ((Control)textBoxMinute12_S2).Text.Trim();
		foreach (char c23 in text23)
		{
			if (c23 < '0' || c23 > '9')
			{
				num2++;
			}
		}
		string text24 = ((Control)textBoxHour12_S2).Text.Trim();
		foreach (char c24 in text24)
		{
			if (c24 < '0' || c24 > '9')
			{
				num2++;
			}
		}
		string text25 = ((Control)textBoxMinute13_S2).Text.Trim();
		foreach (char c25 in text25)
		{
			if (c25 < '0' || c25 > '9')
			{
				num2++;
			}
		}
		string text26 = ((Control)textBoxHour13_S2).Text.Trim();
		foreach (char c26 in text26)
		{
			if (c26 < '0' || c26 > '9')
			{
				num2++;
			}
		}
		string text27 = ((Control)textBoxMinute14_S2).Text.Trim();
		foreach (char c27 in text27)
		{
			if (c27 < '0' || c27 > '9')
			{
				num2++;
			}
		}
		string text28 = ((Control)textBoxHour14_S2).Text.Trim();
		foreach (char c28 in text28)
		{
			if (c28 < '0' || c28 > '9')
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			return 2;
		}
		array[0] = Convert.ToInt16(((Control)textBoxMinute1_S2).Text);
		array[1] = Convert.ToInt16(((Control)textBoxMinute2_S2).Text);
		array[2] = Convert.ToInt16(((Control)textBoxMinute3_S2).Text);
		array[3] = Convert.ToInt16(((Control)textBoxMinute4_S2).Text);
		array[4] = Convert.ToInt16(((Control)textBoxMinute5_S2).Text);
		array[5] = Convert.ToInt16(((Control)textBoxMinute6_S2).Text);
		array[6] = Convert.ToInt16(((Control)textBoxMinute7_S2).Text);
		array[7] = Convert.ToInt16(((Control)textBoxMinute8_S2).Text);
		array[8] = Convert.ToInt16(((Control)textBoxMinute9_S2).Text);
		array[9] = Convert.ToInt16(((Control)textBoxMinute10_S2).Text);
		array[10] = Convert.ToInt16(((Control)textBoxMinute11_S2).Text);
		array[11] = Convert.ToInt16(((Control)textBoxMinute12_S2).Text);
		array[12] = Convert.ToInt16(((Control)textBoxMinute13_S2).Text);
		array[13] = Convert.ToInt16(((Control)textBoxMinute14_S2).Text);
		array[14] = Convert.ToInt16(((Control)textBoxHour1_S2).Text);
		array[15] = Convert.ToInt16(((Control)textBoxHour2_S2).Text);
		array[16] = Convert.ToInt16(((Control)textBoxHour3_S2).Text);
		array[17] = Convert.ToInt16(((Control)textBoxHour4_S2).Text);
		array[18] = Convert.ToInt16(((Control)textBoxHour5_S2).Text);
		array[19] = Convert.ToInt16(((Control)textBoxHour6_S2).Text);
		array[20] = Convert.ToInt16(((Control)textBoxHour7_S2).Text);
		array[21] = Convert.ToInt16(((Control)textBoxHour8_S2).Text);
		array[22] = Convert.ToInt16(((Control)textBoxHour9_S2).Text);
		array[23] = Convert.ToInt16(((Control)textBoxHour10_S2).Text);
		array[24] = Convert.ToInt16(((Control)textBoxHour11_S2).Text);
		array[25] = Convert.ToInt16(((Control)textBoxHour12_S1).Text);
		array[26] = Convert.ToInt16(((Control)textBoxHour13_S1).Text);
		array[27] = Convert.ToInt16(((Control)textBoxHour14_S1).Text);
		for (int num25 = 0; num25 < 14; num25++)
		{
			if (array[num25] > 59)
			{
				return 3;
			}
		}
		for (int num26 = 0; num26 < 14; num26++)
		{
			if (array[num26 + 14] > 23)
			{
				return 4;
			}
		}
		return 0;
	}

	private void buttonSetSched2_Click(object sender, EventArgs e)
	{
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		if (!CheckAddr())
		{
			return;
		}
		switch (CheckTimeScheSet2())
		{
			case 2:
				MessageBox.Show("请确认输入的时段表不包含其他字符！");
				return;
			case 1:
				MessageBox.Show("请确认已输入时段表！");
				return;
			case 3:
				MessageBox.Show("请确认已输入正确的分钟！");
				return;
			case 4:
				MessageBox.Show("请确认已输入正确的时间！");
				return;
		}
		GetTimeSche2();
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[51];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 32;
		if (MeterType == 3)
		{
			array[2] = 9;
			array[3] = 41;
		}
		else if (MeterType == 1)
		{
			array[2] = 32;
			array[3] = 27;
		}
		else
		{
			array[2] = 32;
			array[3] = 21;
		}
		array[4] = 0;
		array[5] = 21;
		array[6] = 42;
		array[7] = TimeSchedule.Price1;
		array[8] = TimeSchedule.Minute1;
		array[9] = TimeSchedule.Hour1;
		array[10] = TimeSchedule.Price2;
		array[11] = TimeSchedule.Minute2;
		array[12] = TimeSchedule.Hour2;
		array[13] = TimeSchedule.Price3;
		array[14] = TimeSchedule.Minute3;
		array[15] = TimeSchedule.Hour3;
		array[16] = TimeSchedule.Price4;
		array[17] = TimeSchedule.Minute4;
		array[18] = TimeSchedule.Hour4;
		array[19] = TimeSchedule.Price5;
		array[20] = TimeSchedule.Minute5;
		array[21] = TimeSchedule.Hour5;
		array[22] = TimeSchedule.Price6;
		array[23] = TimeSchedule.Minute6;
		array[24] = TimeSchedule.Hour6;
		array[25] = TimeSchedule.Price7;
		array[26] = TimeSchedule.Minute7;
		array[27] = TimeSchedule.Hour7;
		array[28] = TimeSchedule.Price8;
		array[29] = TimeSchedule.Minute8;
		array[30] = TimeSchedule.Hour8;
		array[31] = TimeSchedule.Price9;
		array[32] = TimeSchedule.Minute9;
		array[33] = TimeSchedule.Hour9;
		array[34] = TimeSchedule.Price10;
		array[35] = TimeSchedule.Minute10;
		array[36] = TimeSchedule.Hour10;
		array[37] = TimeSchedule.Price11;
		array[38] = TimeSchedule.Minute11;
		array[39] = TimeSchedule.Hour11;
		array[40] = TimeSchedule.Price12;
		array[41] = TimeSchedule.Minute12;
		array[42] = TimeSchedule.Hour12;
		array[43] = TimeSchedule.Price13;
		array[44] = TimeSchedule.Minute13;
		array[45] = TimeSchedule.Hour13;
		array[46] = TimeSchedule.Price14;
		array[47] = TimeSchedule.Minute14;
		array[48] = TimeSchedule.Hour14;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private int CheckTimeZoneSet()
	{
		int num = 0;
		int num2 = 0;
		int[] array = new int[8];
		if (((Control)textBoxDay1).Text.Trim() == "" || ((Control)textBoxDay2).Text.Trim() == "" || ((Control)textBoxDay3).Text.Trim() == "" || ((Control)textBoxDay4).Text.Trim() == "" || ((Control)textBoxMonth1).Text.Trim() == "" || ((Control)textBoxMonth2).Text.Trim() == "" || ((Control)textBoxMonth3).Text.Trim() == "" || ((Control)textBoxMonth4).Text.Trim() == "")
		{
			return 1;
		}
		string text = ((Control)textBoxDay1).Text.Trim();
		foreach (char c in text)
		{
			if (c < '0' || c > '9')
			{
				num2++;
			}
		}
		string text2 = ((Control)textBoxDay2).Text.Trim();
		foreach (char c2 in text2)
		{
			if (c2 < '0' || c2 > '9')
			{
				num2++;
			}
		}
		string text3 = ((Control)textBoxDay3).Text.Trim();
		foreach (char c3 in text3)
		{
			if (c3 < '0' || c3 > '9')
			{
				num2++;
			}
		}
		string text4 = ((Control)textBoxDay4).Text.Trim();
		foreach (char c4 in text4)
		{
			if (c4 < '0' || c4 > '9')
			{
				num2++;
			}
		}
		string text5 = ((Control)textBoxMonth1).Text.Trim();
		foreach (char c5 in text5)
		{
			if (c5 < '0' || c5 > '9')
			{
				num2++;
			}
		}
		string text6 = ((Control)textBoxMonth2).Text.Trim();
		foreach (char c6 in text6)
		{
			if (c6 < '0' || c6 > '9')
			{
				num2++;
			}
		}
		string text7 = ((Control)textBoxMonth3).Text.Trim();
		foreach (char c7 in text7)
		{
			if (c7 < '0' || c7 > '9')
			{
				num2++;
			}
		}
		string text8 = ((Control)textBoxMonth4).Text.Trim();
		foreach (char c8 in text8)
		{
			if (c8 < '0' || c8 > '9')
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			return 2;
		}
		array[0] = Convert.ToInt16(((Control)textBoxDay1).Text);
		array[1] = Convert.ToInt16(((Control)textBoxDay2).Text);
		array[2] = Convert.ToInt16(((Control)textBoxDay3).Text);
		array[3] = Convert.ToInt16(((Control)textBoxDay4).Text);
		array[4] = Convert.ToInt16(((Control)textBoxMonth1).Text);
		array[5] = Convert.ToInt16(((Control)textBoxMonth2).Text);
		array[6] = Convert.ToInt16(((Control)textBoxMonth3).Text);
		array[7] = Convert.ToInt16(((Control)textBoxMonth4).Text);
		for (int num5 = 0; num5 < 4; num5++)
		{
			if (array[num5] > 31)
			{
				return 3;
			}
		}
		for (int num6 = 0; num6 < 4; num6++)
		{
			if (array[num6 + 4] > 12)
			{
				return 4;
			}
		}
		return 0;
	}

	private void GetTimeZone()
	{
		TimeZone.Schedule1 = (byte)((ListControl)comboBoxschedu1).SelectedIndex;
		TimeZone.Schedule2 = (byte)((ListControl)comboBoxschedu2).SelectedIndex;
		TimeZone.Schedule3 = (byte)((ListControl)comboBoxschedu3).SelectedIndex;
		TimeZone.Schedule4 = (byte)((ListControl)comboBoxschedu4).SelectedIndex;
		TimeZone.Day1 = Convert.ToByte(((Control)textBoxDay1).Text);
		TimeZone.Day2 = Convert.ToByte(((Control)textBoxDay2).Text);
		TimeZone.Day3 = Convert.ToByte(((Control)textBoxDay3).Text);
		TimeZone.Day4 = Convert.ToByte(((Control)textBoxDay4).Text);
		TimeZone.Month1 = Convert.ToByte(((Control)textBoxMonth1).Text);
		TimeZone.Month2 = Convert.ToByte(((Control)textBoxMonth2).Text);
		TimeZone.Month3 = Convert.ToByte(((Control)textBoxMonth3).Text);
		TimeZone.Month4 = Convert.ToByte(((Control)textBoxMonth4).Text);
	}

	private void buttonSetTimeZone_Click(object sender, EventArgs e)
	{
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		if (!CheckAddr())
		{
			return;
		}
		switch (CheckTimeZoneSet())
		{
			case 2:
				MessageBox.Show("请确认输入的时段表不包含其他字符！");
				return;
			case 1:
				MessageBox.Show("请确认已输入时段表！");
				return;
			case 3:
				MessageBox.Show("请确认已输入正确的分钟！");
				return;
			case 4:
				MessageBox.Show("请确认已输入正确的时间！");
				return;
		}
		GetTimeZone();
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[21];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		if (MeterType == 3)
		{
			array[2] = 9;
			array[3] = 62;
		}
		else if (MeterType == 1)
		{
			array[2] = 32;
			array[3] = 0;
		}
		else
		{
			array[2] = 0;
			array[3] = 40;
		}
		array[4] = 0;
		array[5] = 6;
		array[6] = 12;
		array[7] = TimeZone.Schedule1;
		array[8] = TimeZone.Day1;
		array[9] = TimeZone.Month1;
		array[10] = TimeZone.Schedule2;
		array[11] = TimeZone.Day2;
		array[12] = TimeZone.Month2;
		array[13] = TimeZone.Schedule3;
		array[14] = TimeZone.Day3;
		array[15] = TimeZone.Month3;
		array[16] = TimeZone.Schedule4;
		array[17] = TimeZone.Day4;
		array[18] = TimeZone.Month4;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ShowTimeSchedu(byte[] message, int type)
	{
		TimeSchedule.Price1 = message[3];
		TimeSchedule.Minute1 = message[4];
		TimeSchedule.Hour1 = message[5];
		TimeSchedule.Price2 = message[6];
		TimeSchedule.Minute2 = message[7];
		TimeSchedule.Hour2 = message[8];
		TimeSchedule.Price3 = message[9];
		TimeSchedule.Minute3 = message[10];
		TimeSchedule.Hour3 = message[11];
		TimeSchedule.Price4 = message[12];
		TimeSchedule.Minute4 = message[13];
		TimeSchedule.Hour4 = message[14];
		TimeSchedule.Price5 = message[15];
		TimeSchedule.Minute5 = message[16];
		TimeSchedule.Hour5 = message[17];
		TimeSchedule.Price6 = message[18];
		TimeSchedule.Minute6 = message[19];
		TimeSchedule.Hour6 = message[20];
		TimeSchedule.Price7 = message[21];
		TimeSchedule.Minute7 = message[22];
		TimeSchedule.Hour7 = message[23];
		TimeSchedule.Price8 = message[24];
		TimeSchedule.Minute8 = message[25];
		TimeSchedule.Hour8 = message[26];
		TimeSchedule.Price9 = message[27];
		TimeSchedule.Minute9 = message[28];
		TimeSchedule.Hour9 = message[29];
		TimeSchedule.Price10 = message[30];
		TimeSchedule.Minute10 = message[31];
		TimeSchedule.Hour10 = message[32];
		TimeSchedule.Price11 = message[33];
		TimeSchedule.Minute11 = message[34];
		TimeSchedule.Hour11 = message[35];
		TimeSchedule.Price12 = message[36];
		TimeSchedule.Minute12 = message[37];
		TimeSchedule.Hour12 = message[38];
		TimeSchedule.Price13 = message[39];
		TimeSchedule.Minute13 = message[40];
		TimeSchedule.Hour13 = message[41];
		TimeSchedule.Price14 = message[42];
		TimeSchedule.Minute14 = message[43];
		TimeSchedule.Hour14 = message[44];
		if (type == 1)
		{
			((ListControl)comboBoxCharge1_S1).SelectedIndex = TimeSchedule.Price1;
			((ListControl)comboBoxCharge2_S1).SelectedIndex = TimeSchedule.Price2;
			((ListControl)comboBoxCharge3_S1).SelectedIndex = TimeSchedule.Price3;
			((ListControl)comboBoxCharge4_S1).SelectedIndex = TimeSchedule.Price4;
			((ListControl)comboBoxCharge5_S1).SelectedIndex = TimeSchedule.Price5;
			((ListControl)comboBoxCharge6_S1).SelectedIndex = TimeSchedule.Price6;
			((ListControl)comboBoxCharge7_S1).SelectedIndex = TimeSchedule.Price7;
			((ListControl)comboBoxCharge8_S1).SelectedIndex = TimeSchedule.Price8;
			((ListControl)comboBoxCharge9_S1).SelectedIndex = TimeSchedule.Price9;
			((ListControl)comboBoxCharge10_S1).SelectedIndex = TimeSchedule.Price10;
			((ListControl)comboBoxCharge11_S1).SelectedIndex = TimeSchedule.Price11;
			((ListControl)comboBoxCharge12_S1).SelectedIndex = TimeSchedule.Price12;
			((ListControl)comboBoxCharge13_S1).SelectedIndex = TimeSchedule.Price13;
			((ListControl)comboBoxCharge14_S1).SelectedIndex = TimeSchedule.Price14;
			((Control)textBoxMinute1_S1).Text = TimeSchedule.Minute1.ToString();
			((Control)textBoxMinute2_S1).Text = TimeSchedule.Minute2.ToString();
			((Control)textBoxMinute3_S1).Text = TimeSchedule.Minute3.ToString();
			((Control)textBoxMinute4_S1).Text = TimeSchedule.Minute4.ToString();
			((Control)textBoxMinute5_S1).Text = TimeSchedule.Minute5.ToString();
			((Control)textBoxMinute6_S1).Text = TimeSchedule.Minute6.ToString();
			((Control)textBoxMinute7_S1).Text = TimeSchedule.Minute7.ToString();
			((Control)textBoxMinute8_S1).Text = TimeSchedule.Minute8.ToString();
			((Control)textBoxMinute9_S1).Text = TimeSchedule.Minute9.ToString();
			((Control)textBoxMinute10_S1).Text = TimeSchedule.Minute10.ToString();
			((Control)textBoxMinute11_S1).Text = TimeSchedule.Minute11.ToString();
			((Control)textBoxMinute12_S1).Text = TimeSchedule.Minute12.ToString();
			((Control)textBoxMinute13_S1).Text = TimeSchedule.Minute13.ToString();
			((Control)textBoxMinute14_S1).Text = TimeSchedule.Minute14.ToString();
			((Control)textBoxHour1_S1).Text = TimeSchedule.Hour1.ToString();
			((Control)textBoxHour2_S1).Text = TimeSchedule.Hour2.ToString();
			((Control)textBoxHour3_S1).Text = TimeSchedule.Hour3.ToString();
			((Control)textBoxHour4_S1).Text = TimeSchedule.Hour4.ToString();
			((Control)textBoxHour5_S1).Text = TimeSchedule.Hour5.ToString();
			((Control)textBoxHour6_S1).Text = TimeSchedule.Hour6.ToString();
			((Control)textBoxHour7_S1).Text = TimeSchedule.Hour7.ToString();
			((Control)textBoxHour8_S1).Text = TimeSchedule.Hour8.ToString();
			((Control)textBoxHour9_S1).Text = TimeSchedule.Hour9.ToString();
			((Control)textBoxHour10_S1).Text = TimeSchedule.Hour10.ToString();
			((Control)textBoxHour11_S1).Text = TimeSchedule.Hour11.ToString();
			((Control)textBoxHour12_S1).Text = TimeSchedule.Hour12.ToString();
			((Control)textBoxHour13_S1).Text = TimeSchedule.Hour13.ToString();
			((Control)textBoxHour14_S1).Text = TimeSchedule.Hour14.ToString();
		}
		else
		{
			((ListControl)comboBoxCharge1_S2).SelectedIndex = TimeSchedule.Price1;
			((ListControl)comboBoxCharge2_S2).SelectedIndex = TimeSchedule.Price2;
			((ListControl)comboBoxCharge3_S2).SelectedIndex = TimeSchedule.Price3;
			((ListControl)comboBoxCharge4_S2).SelectedIndex = TimeSchedule.Price4;
			((ListControl)comboBoxCharge5_S2).SelectedIndex = TimeSchedule.Price5;
			((ListControl)comboBoxCharge6_S2).SelectedIndex = TimeSchedule.Price6;
			((ListControl)comboBoxCharge7_S2).SelectedIndex = TimeSchedule.Price7;
			((ListControl)comboBoxCharge8_S2).SelectedIndex = TimeSchedule.Price8;
			((ListControl)comboBoxCharge9_S2).SelectedIndex = TimeSchedule.Price9;
			((ListControl)comboBoxCharge10_S2).SelectedIndex = TimeSchedule.Price10;
			((ListControl)comboBoxCharge11_S2).SelectedIndex = TimeSchedule.Price11;
			((ListControl)comboBoxCharge12_S2).SelectedIndex = TimeSchedule.Price12;
			((ListControl)comboBoxCharge13_S2).SelectedIndex = TimeSchedule.Price13;
			((ListControl)comboBoxCharge14_S2).SelectedIndex = TimeSchedule.Price14;
			((Control)textBoxMinute1_S2).Text = TimeSchedule.Minute1.ToString();
			((Control)textBoxMinute2_S2).Text = TimeSchedule.Minute2.ToString();
			((Control)textBoxMinute3_S2).Text = TimeSchedule.Minute3.ToString();
			((Control)textBoxMinute4_S2).Text = TimeSchedule.Minute4.ToString();
			((Control)textBoxMinute5_S2).Text = TimeSchedule.Minute5.ToString();
			((Control)textBoxMinute6_S2).Text = TimeSchedule.Minute6.ToString();
			((Control)textBoxMinute7_S2).Text = TimeSchedule.Minute7.ToString();
			((Control)textBoxMinute8_S2).Text = TimeSchedule.Minute8.ToString();
			((Control)textBoxMinute9_S2).Text = TimeSchedule.Minute9.ToString();
			((Control)textBoxMinute10_S2).Text = TimeSchedule.Minute10.ToString();
			((Control)textBoxMinute11_S2).Text = TimeSchedule.Minute11.ToString();
			((Control)textBoxMinute12_S2).Text = TimeSchedule.Minute12.ToString();
			((Control)textBoxMinute13_S2).Text = TimeSchedule.Minute13.ToString();
			((Control)textBoxMinute14_S2).Text = TimeSchedule.Minute14.ToString();
			((Control)textBoxHour1_S2).Text = TimeSchedule.Hour1.ToString();
			((Control)textBoxHour2_S2).Text = TimeSchedule.Hour2.ToString();
			((Control)textBoxHour3_S2).Text = TimeSchedule.Hour3.ToString();
			((Control)textBoxHour4_S2).Text = TimeSchedule.Hour4.ToString();
			((Control)textBoxHour5_S2).Text = TimeSchedule.Hour5.ToString();
			((Control)textBoxHour6_S2).Text = TimeSchedule.Hour6.ToString();
			((Control)textBoxHour7_S2).Text = TimeSchedule.Hour7.ToString();
			((Control)textBoxHour8_S2).Text = TimeSchedule.Hour8.ToString();
			((Control)textBoxHour9_S2).Text = TimeSchedule.Hour9.ToString();
			((Control)textBoxHour10_S2).Text = TimeSchedule.Hour10.ToString();
			((Control)textBoxHour11_S2).Text = TimeSchedule.Hour11.ToString();
			((Control)textBoxHour12_S2).Text = TimeSchedule.Hour12.ToString();
			((Control)textBoxHour13_S2).Text = TimeSchedule.Hour13.ToString();
			((Control)textBoxHour14_S2).Text = TimeSchedule.Hour14.ToString();
		}
	}

	private void buttonReadSched1_Click(object sender, EventArgs e)
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[52];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		if (MeterType == 3)
		{
			array[2] = 9;
			array[3] = 20;
		}
		else if (MeterType == 1)
		{
			array[2] = 32;
			array[3] = 6;
		}
		else
		{
			array[2] = 32;
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 21;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			ShowTimeSchedu(response, 1);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取失败！");
		}
	}

	private void buttonReadSched2_Click(object sender, EventArgs e)
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[52];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 32;
		if (MeterType == 3)
		{
			array[2] = 9;
			array[3] = 41;
		}
		else if (MeterType == 1)
		{
			array[2] = 32;
			array[3] = 27;
		}
		else
		{
			array[2] = 32;
			array[3] = 21;
		}
		array[4] = 0;
		array[5] = 21;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			ShowTimeSchedu(response, 2);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取失败！");
		}
	}

	private void buttonReadTimeZone_Click(object sender, EventArgs e)
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[17];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		if (MeterType == 3)
		{
			array[2] = 9;
			array[3] = 62;
		}
		else if (MeterType == 1)
		{
			array[2] = 32;
			array[3] = 0;
		}
		else
		{
			array[2] = 0;
			array[3] = 40;
		}
		array[4] = 0;
		array[5] = 6;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			ShowTimeZone(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取失败！");
		}
	}

	private void ShowTimeZone(byte[] message)
	{
		((ListControl)comboBoxschedu1).SelectedIndex = message[3];
		((Control)textBoxDay1).Text = message[4].ToString();
		((Control)textBoxMonth1).Text = message[5].ToString();
		((ListControl)comboBoxschedu2).SelectedIndex = message[6];
		((Control)textBoxDay2).Text = message[7].ToString();
		((Control)textBoxMonth2).Text = message[8].ToString();
		((ListControl)comboBoxschedu3).SelectedIndex = message[9];
		((Control)textBoxDay3).Text = message[10].ToString();
		((Control)textBoxMonth3).Text = message[11].ToString();
		((ListControl)comboBoxschedu4).SelectedIndex = message[12];
		((Control)textBoxDay4).Text = message[13].ToString();
		((Control)textBoxMonth4).Text = message[14].ToString();
	}

	private void 初始化_Click(object sender, EventArgs e)
	{
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[15];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 152;
		array[2] = 100;
		array[3] = 1;
		array[4] = 0;
		array[5] = 3;
		array[6] = 6;
		if (((ListControl)comboBoxUn).SelectedIndex == 0)
		{
			array[7] = 2;
			array[8] = 65;
		}
		else if (((ListControl)comboBoxUn).SelectedIndex == 1)
		{
			array[7] = 8;
			array[8] = 152;
		}
		else
		{
			array[7] = 14;
			array[8] = 216;
		}
		if (((Control)comboBoxIb).Text == "1")
		{
			array[9] = 0;
			array[10] = 100;
		}
		if (((Control)comboBoxIb).Text == "10")
		{
			array[9] = 3;
			array[10] = 232;
		}
		if (((Control)comboBoxEc).Text == "400")
		{
			array[11] = 1;
			array[12] = 144;
		}
		else if (((Control)comboBoxEc).Text == "1600")
		{
			array[11] = 6;
			array[12] = 64;
		}
		else if (((Control)comboBoxEc).Text == "6400")
		{
			array[11] = 25;
			array[12] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 初始化成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 增益_Click(object sender, EventArgs e)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 153;
		array[2] = 103;
		array[3] = 1;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(2000);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 校准成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void GetDate()
	{
		dh = DateTime.Now;
		CorrectTime.Second = (byte)dh.Second;
		CorrectTime.Minute = (byte)dh.Minute;
		CorrectTime.Hour = (byte)dh.Hour;
		CorrectTime.Day = (byte)dh.Day;
		CorrectTime.Month = (byte)dh.Month;
		CorrectTime.DayOfWeek = (byte)dh.DayOfWeek;
		if (dh.Year >= 2000)
		{
			CorrectTime.Year = (byte)(dh.Year - 2000);
		}
		else
		{
			CorrectTime.Year = (byte)(dh.Year - 1900);
		}
	}

	private void button14_Click(object sender, EventArgs e)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		GetDate();
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[19];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 3;
		array[3] = 84;
		array[4] = 0;
		array[5] = 5;
		array[6] = 10;
		array[7] = CorrectTime.Second;
		array[8] = CorrectTime.Minute;
		array[9] = CorrectTime.Hour;
		array[10] = CorrectTime.DayOfWeek;
		array[11] = CorrectTime.Day;
		array[12] = CorrectTime.Month;
		array[13] = CorrectTime.Year;
		array[14] = 0;
		array[15] = 0;
		array[16] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(2000);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 校时成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 170;
		array[2] = 100;
		array[3] = 1;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(2000);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 清零成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void comboBoxIb_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)comboBoxIb).SelectedIndex == 1)
		{
			if (MeterType == 1)
			{
				((ListControl)comboBoxEc).SelectedIndex = 1;
			}
			else
			{
				((ListControl)comboBoxEc).SelectedIndex = 0;
			}
		}
	}

	private void 读取地址_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 55;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			((Control)CTValue).Text = ((response[3] << 8) | response[4]).ToString("f0");
			((Control)PTValue).Text = ((response[5] << 8) | response[6]).ToString("f0");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void GetMeterID2()
	{
		string text = "";
		int num = 12 - ((Control)textBox8).Text.Length;
		for (int i = 0; i < num; i++)
		{
			text += "0";
		}
		((Control)textBox8).Text = text + ((Control)textBox8).Text;
		int num2 = 0;
		int num3 = 0;
		while (num2 < 6)
		{
			MeterIDToSet[num3] = (byte)(Convert.ToInt16(((Control)textBox8).Text.Substring(num2 * 2, 2)) / 10 * 16 + Convert.ToInt16(((Control)textBox8).Text.Substring(num2 * 2, 2)) % 10);
			num2++;
			num3++;
		}
	}

	public static uint ConvertByteArrayToUInt(byte[] In, int len)
	{
		return (uint)((In[len] << 24) | (In[len + 1] << 16) | (In[len + 2] << 8) | In[len + 3]);
	}

	public static byte[] ConvertUIntToByteArray(uint n)
	{
		return new byte[4]
		{
			(byte)(n >> 24),
			(byte)(n >> 16),
			(byte)(n >> 8),
			(byte)n
		};
	}

	public static byte[] Encrypt(byte[] IN, int size, uint[] key)
	{
		int num = IN.Length % 4;
		if (num != 0)
		{
			num = 4 - num;
		}
		int num2 = size + num;
		byte[] array = new byte[num2];
		Array.Copy(IN, array, size);
		ushort[] array2 = new ushort[num2 / 2];
		for (int i = 0; i < num; i++)
		{
			array[size + i] = 0;
		}
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = (ushort)((array[j * 2] << 8) | array[j * 2 + 1]);
		}
		uint num3 = 0u;
		uint num4 = 2654435769u;
		for (int k = 0; k < array2.Length / 2; k++)
		{
			ushort num5 = array2[k * 2];
			ushort num6 = array2[k * 2 + 1];
			for (int l = 0; l < 16; l++)
			{
				num3 += num4;
				num5 += (ushort)(((num6 << 4) + key[0]) ^ (num6 + num3) ^ ((num6 >> 5) + key[1]));
				num6 += (ushort)(((num5 << 4) + key[2]) ^ (num5 + num3) ^ ((num5 >> 5) + key[3]));
			}
			num3 = 0u;
			array2[k * 2] = num5;
			array2[k * 2 + 1] = num6;
		}
		for (int m = 0; m < array2.Length; m++)
		{
			array[m * 2 + 1] = (byte)array2[m];
			array[m * 2] = (byte)(array2[m] >> 8);
		}
		return array;
	}

	private void MoneyControl_Click(object sender, EventArgs e)
	{
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[69];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 2;
		array[3] = 0;
		array[4] = 0;
		array[5] = 30;
		array[6] = 60;
		if (FKEN0.Checked)
		{
			array[7] = 1;
		}
		else
		{
			array[7] = 0;
		}
		if (ONFK.Checked)
		{
			array[8] = 1;
		}
		else
		{
			array[8] = 0;
		}
		if (FKEN1.Checked)
		{
			array[9] = 1;
			array[10] = (byte)(Convert.ToInt32(((Control)LeaveE).Text) >> 24);
			array[11] = (byte)(Convert.ToInt32(((Control)LeaveE).Text) >> 16);
			array[12] = (byte)(Convert.ToInt32(((Control)LeaveE).Text) >> 8);
			array[13] = (byte)Convert.ToInt32(((Control)LeaveE).Text);
		}
		else
		{
			array[9] = 0;
		}
		if (FKEN2.Checked)
		{
			array[14] = 1;
			array[15] = (byte)(Convert.ToInt16(((Control)BuyTimes).Text) >> 8);
			array[16] = (byte)Convert.ToInt16(((Control)BuyTimes).Text);
		}
		else
		{
			array[14] = 0;
		}
		if (FKEN3.Checked)
		{
			array[17] = 1;
			array[18] = (byte)(Convert.ToInt32(((Control)TotalE).Text) >> 24);
			array[19] = (byte)(Convert.ToInt32(((Control)TotalE).Text) >> 16);
			array[20] = (byte)(Convert.ToInt32(((Control)TotalE).Text) >> 8);
			array[21] = (byte)Convert.ToInt32(((Control)TotalE).Text);
		}
		else
		{
			array[17] = 0;
		}
		if (FKEN4.Checked)
		{
			array[22] = 1;
			array[23] = (byte)(Convert.ToInt32(((Control)BaseE).Text) >> 24);
			array[24] = (byte)(Convert.ToInt32(((Control)BaseE).Text) >> 16);
			array[25] = (byte)(Convert.ToInt32(((Control)BaseE).Text) >> 8);
			array[26] = (byte)Convert.ToInt32(((Control)BaseE).Text);
		}
		else
		{
			array[22] = 0;
		}
		if (FKEN5.Checked)
		{
			array[27] = 1;
			array[28] = (byte)(Convert.ToInt32(((Control)Alarm1).Text) >> 24);
			array[29] = (byte)(Convert.ToInt32(((Control)Alarm1).Text) >> 16);
			array[30] = (byte)(Convert.ToInt32(((Control)Alarm1).Text) >> 8);
			array[31] = (byte)Convert.ToInt32(((Control)Alarm1).Text);
			array[32] = (byte)(Convert.ToInt32(((Control)Alarm2).Text) >> 24);
			array[33] = (byte)(Convert.ToInt32(((Control)Alarm2).Text) >> 16);
			array[34] = (byte)(Convert.ToInt32(((Control)Alarm2).Text) >> 8);
			array[35] = (byte)Convert.ToInt32(((Control)Alarm2).Text);
		}
		else
		{
			array[27] = 0;
		}
		if (FKEN6.Checked)
		{
			array[36] = 1;
			array[37] = (byte)(Convert.ToInt32(((Control)textBoxPrice1).Text) >> 24);
			array[38] = (byte)(Convert.ToInt32(((Control)textBoxPrice1).Text) >> 16);
			array[39] = (byte)(Convert.ToInt32(((Control)textBoxPrice1).Text) >> 8);
			array[40] = (byte)Convert.ToInt32(((Control)textBoxPrice1).Text);
			array[41] = (byte)(Convert.ToInt32(((Control)textBoxPrice2).Text) >> 24);
			array[42] = (byte)(Convert.ToInt32(((Control)textBoxPrice2).Text) >> 16);
			array[43] = (byte)(Convert.ToInt32(((Control)textBoxPrice2).Text) >> 8);
			array[44] = (byte)Convert.ToInt32(((Control)textBoxPrice2).Text);
			array[45] = (byte)(Convert.ToInt32(((Control)textBoxPrice3).Text) >> 24);
			array[46] = (byte)(Convert.ToInt32(((Control)textBoxPrice3).Text) >> 16);
			array[47] = (byte)(Convert.ToInt32(((Control)textBoxPrice3).Text) >> 8);
			array[48] = (byte)Convert.ToInt32(((Control)textBoxPrice3).Text);
			array[49] = (byte)(Convert.ToInt32(((Control)textBoxPrice4).Text) >> 24);
			array[50] = (byte)(Convert.ToInt32(((Control)textBoxPrice4).Text) >> 16);
			array[51] = (byte)(Convert.ToInt32(((Control)textBoxPrice4).Text) >> 8);
			array[52] = (byte)Convert.ToInt32(((Control)textBoxPrice4).Text);
		}
		else
		{
			array[36] = 0;
		}
		if (FKEN7.Checked)
		{
			array[53] = 1;
			array[54] = (byte)(Convert.ToInt32(((Control)TouZhi).Text) >> 24);
			array[55] = (byte)(Convert.ToInt32(((Control)TouZhi).Text) >> 16);
			array[56] = (byte)(Convert.ToInt32(((Control)TouZhi).Text) >> 8);
			array[57] = (byte)Convert.ToInt32(((Control)TouZhi).Text);
		}
		else
		{
			array[53] = 0;
		}
		if (FKEN8.Checked)
		{
			array[58] = 1;
			array[59] = Convert.ToByte(((Control)textBox7).Text);
		}
		else
		{
			array[58] = 0;
		}
		if (FKEN10.Checked)
		{
			array[60] = 1;
			GetMeterID2();
			array[61] = MeterIDToSet[0];
			array[62] = MeterIDToSet[1];
			array[63] = MeterIDToSet[2];
			array[64] = MeterIDToSet[3];
			array[65] = MeterIDToSet[4];
			array[66] = MeterIDToSet[5];
		}
		else
		{
			array[60] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		if (radioButton2.Checked)
		{
			byte[] array2 = new byte[72];
			SysKey[0] = uint.Parse(((Control)密钥1).Text, NumberStyles.HexNumber);
			SysKey[1] = uint.Parse(((Control)密钥2).Text, NumberStyles.HexNumber);
			SysKey[2] = uint.Parse(((Control)密钥3).Text, NumberStyles.HexNumber);
			SysKey[3] = uint.Parse(((Control)密钥4).Text, NumberStyles.HexNumber);
			array2 = Encrypt(array, array.Length, SysKey);
			array = array2;
		}
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void PowerControl_Click(object sender, EventArgs e)
	{
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[35];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 4;
		if (FKL1.Checked)
		{
			array[3] = 0;
		}
		else if (FKL2.Checked)
		{
			array[3] = 13;
		}
		else if (FKL3.Checked)
		{
			array[3] = 26;
		}
		else
		{
			array[3] = 0;
		}
		if (FKALL.Checked)
		{
			array[7] = byte.MaxValue;
		}
		else
		{
			array[7] = 0;
		}
		array[4] = 0;
		array[5] = 13;
		array[6] = 26;
		if (checkBoxPowerEN0.Checked)
		{
			if (FKALL.Checked)
			{
				array[7] = byte.MaxValue;
			}
			else
			{
				array[7] = 1;
			}
			if (OpenPower.Checked)
			{
				array[8] = 1;
			}
			else
			{
				array[8] = 0;
			}
		}
		if (checkBoxPowerEN1.Checked)
		{
			array[9] = 1;
			array[10] = (byte)(Convert.ToInt32(((Control)MaxPower).Text) >> 8);
			array[11] = (byte)Convert.ToInt32(((Control)MaxPower).Text);
			array[12] = (byte)(Convert.ToInt32(((Control)textBoxMaxPAdd).Text) >> 8);
			array[13] = (byte)Convert.ToInt32(((Control)textBoxMaxPAdd).Text);
			array[14] = (byte)(Convert.ToInt32(((Control)textBoxMaxPF).Text) >> 8);
			array[15] = (byte)Convert.ToInt32(((Control)textBoxMaxPF).Text);
		}
		else
		{
			array[9] = 0;
		}
		if (checkBoxPowerEN3.Checked)
		{
			array[16] = 1;
			array[17] = Convert.ToByte(((Control)RecoverTime).Text);
		}
		else
		{
			array[16] = 0;
		}
		if (checkBoxPowerEN4.Checked)
		{
			array[18] = 1;
			array[19] = (byte)(Convert.ToInt32(((Control)MaxOverCount).Text) >> 8);
			array[20] = (byte)Convert.ToInt32(((Control)MaxOverCount).Text);
		}
		else
		{
			array[18] = 0;
		}
		if (checkBox9.Checked)
		{
			array[21] = 1;
			array[22] = (byte)(Convert.ToInt32(((Control)textBox9).Text) >> 8);
			array[23] = (byte)Convert.ToInt32(((Control)textBox9).Text);
		}
		else
		{
			array[21] = 0;
		}
		if (checkBox10.Checked)
		{
			array[24] = 1;
			array[25] = Convert.ToByte(((Control)textBox10).Text);
		}
		array[26] = 0;
		array[27] = 0;
		array[28] = 0;
		array[29] = 0;
		array[30] = 0;
		array[31] = 0;
		array[32] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void TimeControl_Click(object sender, EventArgs e)
	{
		//IL_07db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[65];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 3;
		if (SKL1.Checked)
		{
			array[3] = 0;
		}
		else if (SKL2.Checked)
		{
			array[3] = 28;
		}
		else if (SKL3.Checked)
		{
			array[3] = 56;
		}
		else
		{
			array[3] = 0;
		}
		if (SKALL.Checked)
		{
			array[7] = byte.MaxValue;
		}
		array[4] = 0;
		array[5] = 28;
		array[6] = 56;
		if (checkBox2.Checked)
		{
			if (SKALL.Checked)
			{
				array[7] = byte.MaxValue;
			}
			else
			{
				array[7] = 1;
			}
			if (OpenTime.Checked)
			{
				array[8] = 1;
			}
			else
			{
				array[8] = 0;
			}
		}
		else
		{
			array[7] = 0;
			array[8] = 0;
		}
		if (checkBoxTimeEN1.Checked)
		{
			array[9] = 1;
			array[10] = 0;
			array[11] = 0;
			if (checkBoxL1Sun.Checked)
			{
				array[11] |= 128;
			}
			if (checkBoxL1Sat.Checked)
			{
				array[11] |= 64;
			}
			if (checkBoxL1Fri.Checked)
			{
				array[11] |= 32;
			}
			if (checkBoxL1Thu.Checked)
			{
				array[11] |= 16;
			}
			if (checkBoxL1Wed.Checked)
			{
				array[11] |= 8;
			}
			if (checkBoxL1Tue.Checked)
			{
				array[11] |= 4;
			}
			if (checkBoxL1Mon.Checked)
			{
				array[11] |= 2;
			}
			array[12] = Convert.ToByte(((Control)textBox1).Text);
			array[13] = Convert.ToByte(((Control)textBox2).Text);
		}
		else
		{
			array[10] = 0;
		}
		if (checkBox11.Checked)
		{
			array[14] = 1;
			if (((Control)comboBoxL1Free1).Text == "通")
			{
				array[15] = 1;
			}
			else
			{
				array[15] = 0;
			}
			array[16] = Convert.ToByte(((Control)textBoxL1FreeM1).Text);
			array[17] = Convert.ToByte(((Control)textBoxL1FreeH1).Text);
			if (((Control)comboBoxL1Free2).Text == "通")
			{
				array[18] = 1;
			}
			else
			{
				array[18] = 0;
			}
			array[19] = Convert.ToByte(((Control)textBoxL1FreeM2).Text);
			array[20] = Convert.ToByte(((Control)textBoxL1FreeH2).Text);
			if (((Control)comboBoxL1Free3).Text == "通")
			{
				array[21] = 1;
			}
			else
			{
				array[21] = 0;
			}
			array[22] = Convert.ToByte(((Control)textBoxL1FreeM3).Text);
			array[23] = Convert.ToByte(((Control)textBoxL1FreeH3).Text);
			if (((Control)comboBoxL1Free4).Text == "通")
			{
				array[24] = 1;
			}
			else
			{
				array[24] = 0;
			}
			array[25] = Convert.ToByte(((Control)textBoxL1FreeM4).Text);
			array[26] = Convert.ToByte(((Control)textBoxL1FreeH4).Text);
			if (((Control)comboBoxL1Free5).Text == "通")
			{
				array[27] = 1;
			}
			else
			{
				array[27] = 0;
			}
			array[28] = Convert.ToByte(((Control)textBoxL1FreeM5).Text);
			array[29] = Convert.ToByte(((Control)textBoxL1FreeH5).Text);
			if (((Control)comboBoxL1Free6).Text == "通")
			{
				array[30] = 1;
			}
			else
			{
				array[30] = 0;
			}
			array[31] = Convert.ToByte(((Control)textBoxL1FreeM6).Text);
			array[32] = Convert.ToByte(((Control)textBoxL1FreeH6).Text);
			if (((Control)comboBoxL1Free7).Text == "通")
			{
				array[33] = 1;
			}
			else
			{
				array[33] = 0;
			}
			array[34] = Convert.ToByte(((Control)textBoxL1FreeM7).Text);
			array[35] = Convert.ToByte(((Control)textBoxL1FreeH7).Text);
			if (((Control)comboBoxL1Free8).Text == "通")
			{
				array[36] = 1;
			}
			else
			{
				array[36] = 0;
			}
			array[37] = Convert.ToByte(((Control)textBoxL1FreeM8).Text);
			array[38] = Convert.ToByte(((Control)textBoxL1FreeH8).Text);
			if (((Control)comboBoxL1Work1).Text == "通")
			{
				array[39] = 1;
			}
			else
			{
				array[39] = 0;
			}
			array[40] = Convert.ToByte(((Control)textBoxL1WorkM1).Text);
			array[41] = Convert.ToByte(((Control)textBoxL1WorkH1).Text);
			if (((Control)comboBoxL1Work2).Text == "通")
			{
				array[42] = 1;
			}
			else
			{
				array[42] = 0;
			}
			array[43] = Convert.ToByte(((Control)textBoxL1WorkM2).Text);
			array[44] = Convert.ToByte(((Control)textBoxL1WorkH2).Text);
			if (((Control)comboBoxL1Work3).Text == "通")
			{
				array[45] = 1;
			}
			else
			{
				array[45] = 0;
			}
			array[46] = Convert.ToByte(((Control)textBoxL1WorkM3).Text);
			array[47] = Convert.ToByte(((Control)textBoxL1WorkH3).Text);
			if (((Control)comboBoxL1Work4).Text == "通")
			{
				array[48] = 1;
			}
			else
			{
				array[48] = 0;
			}
			array[49] = Convert.ToByte(((Control)textBoxL1WorkM4).Text);
			array[50] = Convert.ToByte(((Control)textBoxL1WorkH4).Text);
			if (((Control)comboBoxL1Work5).Text == "通")
			{
				array[51] = 1;
			}
			else
			{
				array[51] = 0;
			}
			array[52] = Convert.ToByte(((Control)textBoxL1WorkM5).Text);
			array[53] = Convert.ToByte(((Control)textBoxL1WorkH5).Text);
			if (((Control)comboBoxL1Work6).Text == "通")
			{
				array[54] = 1;
			}
			else
			{
				array[54] = 0;
			}
			array[55] = Convert.ToByte(((Control)textBoxL1WorkM6).Text);
			array[56] = Convert.ToByte(((Control)textBoxL1WorkH6).Text);
			if (((Control)comboBoxL1Work7).Text == "通")
			{
				array[57] = 1;
			}
			else
			{
				array[57] = 0;
			}
			array[58] = Convert.ToByte(((Control)textBoxL1WorkM7).Text);
			array[59] = Convert.ToByte(((Control)textBoxL1WorkH7).Text);
			if (((Control)comboBoxL1Work8).Text == "通")
			{
				array[60] = 1;
			}
			else
			{
				array[60] = 0;
			}
			array[61] = Convert.ToByte(((Control)textBoxL1WorkM8).Text);
			array[62] = Convert.ToByte(((Control)textBoxL1WorkH8).Text);
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ForceControl_Click(object sender, EventArgs e)
	{
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[20];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 5;
		array[3] = 0;
		array[4] = 0;
		array[5] = 5;
		array[6] = 10;
		if (checkBoxForceEN1.Checked)
		{
			array[7] = 1;
			if (L1ON.Checked)
			{
				array[8] = 1;
				if (L1Open.Checked)
				{
					array[9] = 1;
				}
				else
				{
					array[9] = 0;
				}
			}
			else
			{
				array[8] = 0;
				array[9] = 0;
			}
		}
		if (checkBoxForceEN2.Checked)
		{
			array[10] = 1;
			if (L2ON.Checked)
			{
				array[11] = 1;
				if (L2Open.Checked)
				{
					array[12] = 1;
				}
				else
				{
					array[12] = 0;
				}
			}
			else
			{
				array[11] = 0;
				array[12] = 0;
			}
		}
		if (checkBoxForceEN3.Checked)
		{
			array[13] = 1;
			if (L3ON.Checked)
			{
				array[14] = 1;
				if (L3Open.Checked)
				{
					array[15] = 1;
				}
				else
				{
					array[15] = 0;
				}
			}
			else
			{
				array[14] = 0;
				array[15] = 0;
			}
		}
		array[16] = 0;
		array[17] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ResetPC_Click(object sender, EventArgs e)
	{
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[17];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 4;
		array[3] = 16;
		array[4] = 0;
		array[5] = 4;
		array[6] = 8;
		if (FWL1.Checked)
		{
			array[7] = 1;
			array[8] = (byte)Convert.ToInt32(((Control)OverCount1).Text);
		}
		else
		{
			array[7] = 0;
		}
		if (FWL2.Checked)
		{
			array[9] = 1;
			array[10] = (byte)Convert.ToInt32(((Control)OverCount2).Text);
		}
		else
		{
			array[9] = 0;
		}
		if (FWL3.Checked)
		{
			array[11] = 1;
			array[12] = (byte)Convert.ToInt32(((Control)OverCount3).Text);
		}
		else
		{
			array[11] = 0;
		}
		if (FWALL.Checked)
		{
			array[13] = 1;
			array[14] = (byte)Convert.ToInt32(((Control)OverCountALL).Text);
		}
		else
		{
			array[13] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 输出方式设置_Click(object sender, EventArgs e)
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 99;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		if (电平.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 输出方式读取_Click(object sender, EventArgs e)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 99;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[4] == 0)
			{
				电平.Checked = true;
			}
			else
			{
				脉冲.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 输出方式读取_Click_1(object sender, EventArgs e)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 99;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[4] == 0)
			{
				电平.Checked = true;
			}
			else
			{
				脉冲.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 输出方式设置_Click_1(object sender, EventArgs e)
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 99;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		if (电平.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void buttonReadPhase_Click_1(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[21];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 3;
		array[4] = 0;
		array[5] = 8;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			((Control)单相数量).Text = response[6].ToString();
			((Control)三相数量).Text = response[4].ToString();
			string text = "";
			int[] array2 = new int[5];
			for (int i = 0; i < 5; i++)
			{
				array2[i] = response[7 + i] / 16 * 10 + response[7 + i] % 16;
			}
			for (int j = 0; j < 5; j++)
			{
				text = ((array2[j] != 0) ? ((array2[j] >= 10 || array2[j] <= 0) ? (text + array2[j]) : (text + "0" + array2[j])) : (text + "00"));
			}
			((Control)ADF表号).Text = text;
			if (response[13] == 1)
			{
				jiliangxing.Checked = true;
			}
			else
			{
				yufufei.Checked = true;
			}
			if (response[14] == 1)
			{
				dlt645xieyi.Checked = true;
			}
			else
			{
				dlt645xieyi.Checked = false;
			}
			if (response[18] == 1)
			{
				使能IC.Checked = true;
			}
			else
			{
				无IC.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private byte[] GetResponseCount()
	{
		if (MeterType2 == 0)
		{
			return new byte[17];
		}
		if (MeterType2 == 1)
		{
			return new byte[13];
		}
		if (MeterType2 == 2)
		{
			return new byte[9];
		}
		return new byte[17];
	}

	public void ReadAllSetResponse(byte[] response)
	{
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int[] array = new int[12];
		try
		{
			if (MeterType2 == 0)
			{
				AllSetResult[0] = response[3];
				AllSetResult[1] = response[4];
				AllSetResult[2] = response[5];
				AllSetResult[3] = response[6];
				AllSetResult[4] = response[7];
				AllSetResult[5] = response[8];
				AllSetResult[6] = response[9];
				AllSetResult[7] = response[10];
				AllSetResult[8] = response[11];
				AllSetResult[9] = response[12];
				AllSetResult[10] = response[13];
				AllSetResult[11] = response[14];
				for (int i = 3; i < 15; i++)
				{
					if (response[i] == 2)
					{
						array[i - 3] = 1;
						num++;
					}
				}
				if (num == 0)
				{
					MessageBox.Show("所有下板Set successfully！");
					return;
				}
				string text = "第";
				for (int j = 0; j < 12; j++)
				{
					if (array[j] == 1)
					{
						text += j + 1;
						text += ",";
					}
				}
				text = text.Remove(text.Length - 1);
				text += "块下板的广播下发失败，请确认！";
				MessageBox.Show(text);
				return;
			}
			if (MeterType2 == 1)
			{
				AllSetResult[0] = response[3];
				AllSetResult[1] = response[4];
				AllSetResult[2] = response[5];
				AllSetResult[3] = response[6];
				AllSetResult[4] = response[7];
				AllSetResult[5] = response[8];
				AllSetResult[6] = response[9];
				AllSetResult[7] = response[10];
				for (int k = 3; k < 11; k++)
				{
					if (response[k] == 2)
					{
						array[k - 3] = 1;
						num++;
					}
				}
				if (num == 0)
				{
					MessageBox.Show("所有下板Set successfully！");
					return;
				}
				string text2 = "第";
				for (int l = 0; l < 12; l++)
				{
					if (array[l] == 1)
					{
						text2 += l + 1;
						text2 += ",";
					}
				}
				text2 = text2.Remove(text2.Length - 1);
				text2 += "块下板的广播下发失败，请确认！";
				MessageBox.Show(text2);
				return;
			}
			AllSetResult[0] = response[3];
			AllSetResult[1] = response[4];
			AllSetResult[2] = response[5];
			AllSetResult[3] = response[6];
			for (int m = 3; m < 7; m++)
			{
				if (response[m] == 2)
				{
					array[m - 3] = 1;
					num++;
				}
			}
			if (num == 0)
			{
				MessageBox.Show("所有下板Set successfully！");
				return;
			}
			string text3 = "第";
			for (int n = 0; n < 12; n++)
			{
				if (array[n] == 1)
				{
					text3 += n + 1;
					text3 += ",";
				}
			}
			text3 = text3.Remove(text3.Length - 1);
			text3 += "块下板的广播下发失败，请确认！";
			MessageBox.Show(text3);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " 请设置ADF300型号规格！");
		}
	}

	private void buttonChangePhase_Click(object sender, EventArgs e)
	{
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		GetMeterID3();
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		int num = 0;
		byte[] array = new byte[25];
		num = ((MeterType2 == 0) ? 16 : ((MeterType2 != 1) ? 8 : 12));
		byte[] response = new byte[num];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 3;
		array[4] = 0;
		array[5] = 8;
		array[6] = 16;
		array[7] = 0;
		array[8] = (byte)Convert.ToInt16(((Control)三相数量).Text);
		array[9] = 0;
		array[10] = (byte)Convert.ToInt16(((Control)单相数量).Text);
		GetMeterID3();
		array[11] = MeterIDToSet[0];
		array[12] = MeterIDToSet[1];
		array[13] = MeterIDToSet[2];
		array[14] = MeterIDToSet[3];
		array[15] = MeterIDToSet[4];
		array[16] = 0;
		if (yufufei.Checked)
		{
			array[17] = 0;
		}
		else
		{
			array[17] = 1;
		}
		if (dlt645xieyi.Checked)
		{
			array[18] = 1;
		}
		else
		{
			array[18] = 0;
		}
		array[19] = 0;
		array[20] = 0;
		array[21] = 0;
		if (使能IC.Checked)
		{
			array[22] = 1;
		}
		else
		{
			array[22] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			ReadAllSetResponse(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		if (ADF副通讯.Checked)
		{
			array[3] = 17;
		}
		else
		{
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			if (MeterType2 == 0)
			{
				((ListControl)ADF300地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 36);
			}
			else if (MeterType2 == 1)
			{
				((ListControl)ADF300地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 24);
			}
			else if (MeterType2 == 2)
			{
				((ListControl)ADF300地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 12);
			}
			else
			{
				((ListControl)ADF300地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 36);
			}
			((ListControl)ADF300波特率).SelectedIndex = response[6];
			((Control)地址).Text = Convert.ToString(response[4]);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		if (ADF副通讯.Checked)
		{
			array[3] = 17;
		}
		else
		{
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = 0;
		if (MeterType2 == 0)
		{
			array[8] = Convert.ToByte(((ListControl)ADF300地址).SelectedIndex * 36 + 1);
		}
		else if (MeterType2 == 1)
		{
			array[8] = Convert.ToByte(((ListControl)ADF300地址).SelectedIndex * 24 + 1);
		}
		else if (MeterType2 == 2)
		{
			array[8] = Convert.ToByte(((ListControl)ADF300地址).SelectedIndex * 12 + 1);
		}
		else
		{
			array[8] = Convert.ToByte(((ListControl)ADF300地址).SelectedIndex * 24 + 1);
		}
		array[9] = 0;
		array[10] = Convert.ToByte(((ListControl)ADF300波特率).SelectedIndex);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 脉冲_Click(object sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Form val = (Form)(object)new 脉冲参数设置();
		val.ShowDialog();
	}

	private void ADF300清零_Click(object sender, EventArgs e)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 9;
		array[3] = 0;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF300广播清零_Click(object sender, EventArgs e)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 9;
		array[3] = byte.MaxValue;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF300地址_Click(object sender, EventArgs e)
	{
		if (MeterType2 == 0)
		{
			ADF300地址.Items.Clear();
			ADF300地址.Items.AddRange(new object[7] { 1, 37, 73, 109, 145, 181, 217 });
		}
		else if (MeterType2 == 1)
		{
			ADF300地址.Items.Clear();
			ADF300地址.Items.AddRange(new object[10] { 1, 25, 49, 73, 97, 121, 145, 169, 193, 217 });
		}
		else
		{
			ADF300地址.Items.Clear();
			ADF300地址.Items.AddRange(new object[20]
			{
				1, 13, 25, 37, 49, 61, 73, 85, 97, 109,
				121, 133, 145, 157, 169, 181, 193, 205, 217, 229
			});
			MeterType2 = 2;
		}
	}

	private void Init_Click(object sender, EventArgs e)
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[15];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 152;
		if (MeterType == 3)
		{
			array[2] = 100;
			array[3] = 6;
		}
		else
		{
			array[2] = 100;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 3;
		array[6] = 6;
		if (((ListControl)ADF电压).SelectedIndex == 0)
		{
			array[7] = 2;
			array[8] = 65;
		}
		else if (((ListControl)ADF电压).SelectedIndex == 1)
		{
			array[7] = 8;
			array[8] = 152;
		}
		else
		{
			array[7] = 14;
			array[8] = 216;
		}
		if (((ListControl)ADF电流).SelectedIndex == 0)
		{
			array[9] = 0;
			array[10] = 100;
		}
		else
		{
			array[9] = 3;
			array[10] = 232;
		}
		if (((Control)ADF脉冲常数).Text == "400")
		{
			array[11] = 1;
			array[12] = 144;
		}
		else if (((Control)ADF脉冲常数).Text == "6400")
		{
			array[11] = 25;
			array[12] = 0;
		}
		else if (((Control)ADF脉冲常数).Text == "1600")
		{
			array[11] = 6;
			array[12] = 64;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 初始化成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void CorrectMeter_Click(object sender, EventArgs e)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 153;
		if (MeterType == 3)
		{
			array[2] = 100;
			array[3] = 6;
		}
		else
		{
			array[2] = 103;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(2000);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 校准成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ReadMoneyControl_Click(object sender, EventArgs e)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		if (MeterType == 3)
		{
			主轮抄定时器.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[41];
			byte[] CRC = new byte[2];
			array[0] = Convert.ToByte(Variable.Address);
			array[1] = 3;
			if (IS3P == 1)
			{
				array[2] = 5;
				array[3] = 54;
			}
			else
			{
				array[2] = 5;
				array[3] = 0;
			}
			array[4] = 0;
			array[5] = 18;
			m.GetCRC(array, ref CRC);
			array[^2] = CRC[0];
			array[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array, 0, array.Length);
				m.GetResponse(ref response);
				PortFalshGOOD();
				Thread.Sleep(20);
			}
			catch (Exception ex)
			{
				主轮抄定时器.Enabled = true;
				PortFalshERROR();
				MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
				return;
			}
			if (m.CheckResponse(response, 0))
			{
				MessageBox.Show(" Read successfully！");
				if (((response[3] << 8) | response[4]) == 0)
				{
					OFFFK.Checked = true;
				}
				else
				{
					ONFK.Checked = true;
				}
				double num = (response[5] << 24) | (response[6] << 16) | (response[7] << 8) | response[8];
				((Control)textBoxPrice1).Text = num.ToString("f0");
				num = (response[9] << 24) | (response[10] << 16) | (response[11] << 8) | response[12];
				((Control)textBoxPrice2).Text = num.ToString("f0");
				num = (response[13] << 24) | (response[14] << 16) | (response[15] << 8) | response[16];
				((Control)textBoxPrice3).Text = num.ToString("f0");
				num = (response[17] << 24) | (response[18] << 16) | (response[19] << 8) | response[20];
				((Control)textBoxPrice4).Text = num.ToString("f0");
				num = (response[21] << 24) | (response[22] << 16) | (response[23] << 8) | response[24];
				((Control)Alarm1).Text = num.ToString("f0");
				num = (response[25] << 24) | (response[26] << 16) | (response[27] << 8) | response[28];
				((Control)Alarm2).Text = num.ToString("f0");
				num = Convert.ToDouble(((Control)基础电量).Text);
				((Control)BaseE).Text = (num * 100.0).ToString("f0");
				((Control)BuyTimes).Text = Convert.ToString((response[33] << 8) | response[34]);
				主轮抄定时器.Enabled = true;
			}
			else
			{
				主轮抄定时器.Enabled = true;
				MessageBox.Show("Setting error！");
			}
			return;
		}
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array2 = new byte[8];
		byte[] response2 = new byte[55];
		byte[] CRC2 = new byte[2];
		array2[0] = Convert.ToByte(Variable.Address);
		array2[1] = 3;
		array2[2] = 4;
		array2[3] = 0;
		array2[4] = 0;
		array2[5] = 25;
		m.GetCRC(array2, ref CRC2);
		array2[^2] = CRC2[0];
		array2[^1] = CRC2[1];
		try
		{
			Modbus.sp.Write(array2, 0, array2.Length);
			m.GetResponse(ref response2);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex2)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex2.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response2, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (((response2[3] << 8) | response2[4]) == 0)
			{
				OFFFK.Checked = true;
			}
			else
			{
				ONFK.Checked = true;
			}
			((Control)BuyTimes).Text = Convert.ToString((response2[5] << 8) | response2[6]);
			double num = (response2[7] << 24) | (response2[8] << 16) | (response2[9] << 8) | response2[10];
			((Control)textBoxPrice1).Text = num.ToString("f0");
			num = (response2[11] << 24) | (response2[12] << 16) | (response2[13] << 8) | response2[14];
			((Control)textBoxPrice2).Text = num.ToString("f0");
			num = (response2[15] << 24) | (response2[16] << 16) | (response2[17] << 8) | response2[18];
			((Control)textBoxPrice3).Text = num.ToString("f0");
			num = (response2[19] << 24) | (response2[20] << 16) | (response2[21] << 8) | response2[22];
			((Control)textBoxPrice4).Text = num.ToString("f0");
			num = (response2[23] << 24) | (response2[24] << 16) | (response2[25] << 8) | response2[26];
			((Control)Alarm1).Text = num.ToString("f0");
			num = (response2[27] << 24) | (response2[28] << 16) | (response2[29] << 8) | response2[30];
			((Control)Alarm2).Text = num.ToString("f0");
			num = (response2[31] << 24) | (response2[32] << 16) | (response2[33] << 8) | response2[34];
			((Control)TouZhi).Text = num.ToString("f0");
			num = (response2[39] << 24) | (response2[40] << 16) | (response2[41] << 8) | response2[42];
			((Control)TotalE).Text = num.ToString("f0");
			num = (response2[43] << 24) | (response2[44] << 16) | (response2[45] << 8) | response2[46];
			((Control)LeaveE).Text = num.ToString("f0");
			num = (response2[47] << 24) | (response2[48] << 16) | (response2[49] << 8) | response2[50];
			((Control)BaseE).Text = num.ToString("f0");
			num = (response2[51] << 8) | response2[52];
			((Control)textBox7).Text = num.ToString("f0");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取失败！");
		}
	}

	private void ReadPowerControl_Click(object sender, EventArgs e)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		if (MeterType == 3)
		{
			主轮抄定时器.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[21];
			byte[] CRC = new byte[2];
			array[0] = Convert.ToByte(Variable.Address);
			array[1] = 3;
			if (IS3P == 1)
			{
				if (FKALL.Checked)
				{
					array[2] = 7;
					array[3] = 24;
				}
				else if (FKL2.Checked)
				{
					array[0] = Convert.ToByte(array[0] + 1);
				}
				else if (FKL3.Checked)
				{
					array[0] = Convert.ToByte(array[0] + 2);
				}
				else
				{
					array[2] = 7;
					array[3] = 0;
				}
			}
			else
			{
				array[2] = 7;
				array[3] = 0;
			}
			array[4] = 0;
			array[5] = 8;
			m.GetCRC(array, ref CRC);
			array[^2] = CRC[0];
			array[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array, 0, array.Length);
				m.GetResponse(ref response);
				PortFalshGOOD();
				Thread.Sleep(20);
			}
			catch (Exception ex)
			{
				主轮抄定时器.Enabled = true;
				PortFalshERROR();
				MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
				return;
			}
			if (m.CheckResponse(response, 0))
			{
				MessageBox.Show(" Set successfully！");
				if (((response[3] << 8) | response[4]) == 0)
				{
					ClosePower.Checked = true;
				}
				else
				{
					OpenPower.Checked = true;
				}
				((Control)MaxPower).Text = Convert.ToString((response[5] << 8) | response[6]);
				((Control)textBoxMaxPAdd).Text = Convert.ToString((response[7] << 8) | response[8]);
				((Control)textBoxMaxPF).Text = Convert.ToString((response[9] << 8) | response[10]);
				((Control)textBox9).Text = Convert.ToString((response[11] << 8) | response[12]);
				((Control)MaxOverCount).Text = Convert.ToString((response[13] << 8) | response[14]);
				((Control)RecoverTime).Text = Convert.ToString((response[15] << 8) | response[16]);
				((Control)textBox10).Text = Convert.ToString((response[17] << 8) | response[18]);
				主轮抄定时器.Enabled = true;
			}
			else
			{
				主轮抄定时器.Enabled = true;
				MessageBox.Show("Setting error！");
			}
			return;
		}
		if (MeterType == 2)
		{
			主轮抄定时器.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array2 = new byte[8];
			byte[] response2 = new byte[43];
			byte[] CRC2 = new byte[2];
			array2[0] = Convert.ToByte(Variable.Address);
			array2[1] = 3;
			array2[2] = 4;
			array2[3] = 128;
			array2[4] = 0;
			array2[5] = 19;
			m.GetCRC(array2, ref CRC2);
			array2[^2] = CRC2[0];
			array2[^1] = CRC2[1];
			try
			{
				Modbus.sp.Write(array2, 0, array2.Length);
				m.GetResponse(ref response2);
				PortFalshGOOD();
				Thread.Sleep(20);
			}
			catch (Exception ex2)
			{
				主轮抄定时器.Enabled = true;
				PortFalshERROR();
				MessageBox.Show(ex2.Message + "Please confirm the serial port and address settings！");
				return;
			}
			if (m.CheckResponse(response2, 0))
			{
				MessageBox.Show(" Set successfully！");
				if (FKALL.Checked)
				{
					if (((response2[4] >> 3) & 1) == 1)
					{
						ClosePower.Checked = true;
					}
					else
					{
						OpenPower.Checked = true;
					}
					((Control)MaxPower).Text = Convert.ToString((response2[5] << 8) | response2[6]);
					((Control)textBoxMaxPAdd).Text = Convert.ToString((response2[7] << 8) | response2[8]);
					((Control)textBoxMaxPF).Text = Convert.ToString((response2[9] << 8) | response2[10]);
					((Control)textBox9).Text = Convert.ToString((response2[11] << 8) | response2[12]);
					((Control)MaxOverCount).Text = Convert.ToString((response2[13] << 8) | response2[14]);
					((Control)RecoverTime).Text = Convert.ToString(response2[15]);
					((Control)textBox10).Text = Convert.ToString(response2[16]);
					主轮抄定时器.Enabled = true;
				}
				else if (FKL1.Checked)
				{
					if (((response2[4] >> 2) & 1) == 1)
					{
						ClosePower.Checked = true;
					}
					else
					{
						OpenPower.Checked = true;
					}
					((Control)MaxPower).Text = Convert.ToString((response2[5] << 8) | response2[6]);
					((Control)textBoxMaxPAdd).Text = Convert.ToString((response2[7] << 8) | response2[8]);
					((Control)textBoxMaxPF).Text = Convert.ToString((response2[9] << 8) | response2[10]);
					((Control)textBox9).Text = Convert.ToString((response2[11] << 8) | response2[12]);
					((Control)MaxOverCount).Text = Convert.ToString((response2[13] << 8) | response2[14]);
					((Control)RecoverTime).Text = Convert.ToString(response2[15]);
					((Control)textBox10).Text = Convert.ToString(response2[16]);
					主轮抄定时器.Enabled = true;
				}
				else if (FKL2.Checked)
				{
					if (((response2[4] >> 1) & 1) == 1)
					{
						ClosePower.Checked = true;
					}
					else
					{
						OpenPower.Checked = true;
					}
					((Control)MaxPower).Text = Convert.ToString((response2[17] << 8) | response2[18]);
					((Control)textBoxMaxPAdd).Text = Convert.ToString((response2[19] << 8) | response2[20]);
					((Control)textBoxMaxPF).Text = Convert.ToString((response2[21] << 8) | response2[22]);
					((Control)textBox9).Text = Convert.ToString((response2[23] << 8) | response2[24]);
					((Control)MaxOverCount).Text = Convert.ToString((response2[25] << 8) | response2[26]);
					((Control)RecoverTime).Text = Convert.ToString(response2[27]);
					((Control)textBox10).Text = Convert.ToString(response2[28]);
					主轮抄定时器.Enabled = true;
				}
				else if (FKL3.Checked)
				{
					if ((response2[4] & 1) == 1)
					{
						ClosePower.Checked = true;
					}
					else
					{
						OpenPower.Checked = true;
					}
					((Control)MaxPower).Text = Convert.ToString((response2[29] << 8) | response2[30]);
					((Control)textBoxMaxPAdd).Text = Convert.ToString((response2[31] << 8) | response2[32]);
					((Control)textBoxMaxPF).Text = Convert.ToString((response2[33] << 8) | response2[34]);
					((Control)textBox9).Text = Convert.ToString((response2[35] << 8) | response2[36]);
					((Control)MaxOverCount).Text = Convert.ToString((response2[37] << 8) | response2[38]);
					((Control)RecoverTime).Text = Convert.ToString(response2[39]);
					((Control)textBox10).Text = Convert.ToString(response2[40]);
					主轮抄定时器.Enabled = true;
				}
				else
				{
					if (response2[4] == 1)
					{
						ClosePower.Checked = true;
					}
					else
					{
						OpenPower.Checked = true;
					}
					((Control)MaxPower).Text = Convert.ToString((response2[5] << 8) | response2[6]);
					((Control)textBoxMaxPAdd).Text = Convert.ToString((response2[7] << 8) | response2[8]);
					((Control)textBoxMaxPF).Text = Convert.ToString((response2[9] << 8) | response2[10]);
					((Control)textBox9).Text = Convert.ToString((response2[11] << 8) | response2[12]);
					((Control)MaxOverCount).Text = Convert.ToString((response2[13] << 8) | response2[14]);
					((Control)RecoverTime).Text = Convert.ToString(response2[15]);
					((Control)textBox10).Text = Convert.ToString(response2[16]);
				}
			}
			else
			{
				主轮抄定时器.Enabled = true;
				MessageBox.Show("Setting error！");
			}
			return;
		}
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array3 = new byte[8];
		byte[] response3 = new byte[19];
		byte[] CRC3 = new byte[2];
		array3[0] = Convert.ToByte(Variable.Address);
		array3[1] = 3;
		array3[2] = 4;
		array3[3] = 128;
		array3[4] = 0;
		array3[5] = 7;
		m.GetCRC(array3, ref CRC3);
		array3[^2] = CRC3[0];
		array3[^1] = CRC3[1];
		try
		{
			Modbus.sp.Write(array3, 0, array3.Length);
			m.GetResponse(ref response3);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex3)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex3.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response3, 0))
		{
			MessageBox.Show(" Set successfully！");
			if (((response3[3] << 8) | response3[4]) == 0)
			{
				ClosePower.Checked = true;
			}
			else
			{
				OpenPower.Checked = true;
			}
			((Control)MaxPower).Text = Convert.ToString((response3[5] << 8) | response3[6]);
			((Control)textBoxMaxPAdd).Text = Convert.ToString((response3[7] << 8) | response3[8]);
			((Control)textBoxMaxPF).Text = Convert.ToString((response3[9] << 8) | response3[10]);
			((Control)textBox9).Text = Convert.ToString((response3[11] << 8) | response3[12]);
			((Control)MaxOverCount).Text = Convert.ToString((response3[13] << 8) | response3[14]);
			((Control)RecoverTime).Text = Convert.ToString(response3[15]);
			((Control)textBox10).Text = Convert.ToString(response3[16]);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void AllMoneyControl_Click(object sender, EventArgs e)
	{
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[69];
		byte[] response = GetResponseCount();
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 2;
		array[3] = byte.MaxValue;
		array[4] = 0;
		array[5] = 30;
		array[6] = 60;
		if (FKEN0.Checked)
		{
			array[7] = 1;
		}
		else
		{
			array[7] = 0;
		}
		if (ONFK.Checked)
		{
			array[8] = 1;
		}
		else
		{
			array[8] = 0;
		}
		if (FKEN1.Checked)
		{
			array[9] = 1;
			array[10] = (byte)(Convert.ToInt32(((Control)LeaveE).Text) >> 24);
			array[11] = (byte)(Convert.ToInt32(((Control)LeaveE).Text) >> 16);
			array[12] = (byte)(Convert.ToInt32(((Control)LeaveE).Text) >> 8);
			array[13] = (byte)Convert.ToInt32(((Control)LeaveE).Text);
		}
		else
		{
			array[9] = 0;
		}
		if (FKEN2.Checked)
		{
			array[14] = 1;
			array[15] = (byte)(Convert.ToInt16(((Control)BuyTimes).Text) >> 8);
			array[16] = (byte)Convert.ToInt16(((Control)BuyTimes).Text);
		}
		else
		{
			array[14] = 0;
		}
		if (FKEN3.Checked)
		{
			array[17] = 1;
			array[18] = (byte)(Convert.ToInt32(((Control)TotalE).Text) >> 24);
			array[19] = (byte)(Convert.ToInt32(((Control)TotalE).Text) >> 16);
			array[20] = (byte)(Convert.ToInt32(((Control)TotalE).Text) >> 8);
			array[21] = (byte)Convert.ToInt32(((Control)TotalE).Text);
		}
		else
		{
			array[17] = 0;
		}
		if (FKEN4.Checked)
		{
			array[22] = 1;
			array[23] = (byte)(Convert.ToInt32(((Control)BaseE).Text) >> 24);
			array[24] = (byte)(Convert.ToInt32(((Control)BaseE).Text) >> 16);
			array[25] = (byte)(Convert.ToInt32(((Control)BaseE).Text) >> 8);
			array[26] = (byte)Convert.ToInt32(((Control)BaseE).Text);
		}
		else
		{
			array[22] = 0;
		}
		if (FKEN5.Checked)
		{
			array[27] = 1;
			array[28] = (byte)(Convert.ToInt32(((Control)Alarm1).Text) >> 24);
			array[29] = (byte)(Convert.ToInt32(((Control)Alarm1).Text) >> 16);
			array[30] = (byte)(Convert.ToInt32(((Control)Alarm1).Text) >> 8);
			array[31] = (byte)Convert.ToInt32(((Control)Alarm1).Text);
			array[32] = (byte)(Convert.ToInt32(((Control)Alarm2).Text) >> 24);
			array[33] = (byte)(Convert.ToInt32(((Control)Alarm2).Text) >> 16);
			array[34] = (byte)(Convert.ToInt32(((Control)Alarm2).Text) >> 8);
			array[35] = (byte)Convert.ToInt32(((Control)Alarm2).Text);
		}
		else
		{
			array[27] = 0;
		}
		if (FKEN6.Checked)
		{
			array[36] = 1;
			array[37] = (byte)(Convert.ToInt32(((Control)textBoxPrice1).Text) >> 24);
			array[38] = (byte)(Convert.ToInt32(((Control)textBoxPrice1).Text) >> 16);
			array[39] = (byte)(Convert.ToInt32(((Control)textBoxPrice1).Text) >> 8);
			array[40] = (byte)Convert.ToInt32(((Control)textBoxPrice1).Text);
			array[41] = (byte)(Convert.ToInt32(((Control)textBoxPrice2).Text) >> 24);
			array[42] = (byte)(Convert.ToInt32(((Control)textBoxPrice2).Text) >> 16);
			array[43] = (byte)(Convert.ToInt32(((Control)textBoxPrice2).Text) >> 8);
			array[44] = (byte)Convert.ToInt32(((Control)textBoxPrice2).Text);
			array[45] = (byte)(Convert.ToInt32(((Control)textBoxPrice3).Text) >> 24);
			array[46] = (byte)(Convert.ToInt32(((Control)textBoxPrice3).Text) >> 16);
			array[47] = (byte)(Convert.ToInt32(((Control)textBoxPrice3).Text) >> 8);
			array[48] = (byte)Convert.ToInt32(((Control)textBoxPrice3).Text);
			array[49] = (byte)(Convert.ToInt32(((Control)textBoxPrice4).Text) >> 24);
			array[50] = (byte)(Convert.ToInt32(((Control)textBoxPrice4).Text) >> 16);
			array[51] = (byte)(Convert.ToInt32(((Control)textBoxPrice4).Text) >> 8);
			array[52] = (byte)Convert.ToInt32(((Control)textBoxPrice4).Text);
		}
		else
		{
			array[36] = 0;
		}
		if (FKEN7.Checked)
		{
			array[53] = 1;
			array[54] = (byte)(Convert.ToInt32(((Control)TouZhi).Text) >> 24);
			array[55] = (byte)(Convert.ToInt32(((Control)TouZhi).Text) >> 16);
			array[56] = (byte)(Convert.ToInt32(((Control)TouZhi).Text) >> 8);
			array[57] = (byte)Convert.ToInt32(((Control)TouZhi).Text);
		}
		else
		{
			array[53] = 0;
		}
		if (FKEN8.Checked)
		{
			array[58] = 1;
			array[59] = Convert.ToByte(((Control)textBox7).Text);
		}
		else
		{
			array[58] = 0;
		}
		if (FKEN10.Checked)
		{
			array[60] = 1;
			GetMeterID2();
			array[61] = MeterIDToSet[0];
			array[62] = MeterIDToSet[1];
			array[63] = MeterIDToSet[2];
			array[64] = MeterIDToSet[3];
			array[65] = MeterIDToSet[4];
			array[66] = MeterIDToSet[5];
		}
		else
		{
			array[60] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void FKALL_CheckedChanged(object sender, EventArgs e)
	{
		checkBoxPowerEN0.Checked = true;
	}

	private void AllPowerControl_Click(object sender, EventArgs e)
	{
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[35];
		byte[] response = GetResponseCount();
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 4;
		array[3] = byte.MaxValue;
		if (FKALL.Checked)
		{
			array[7] = byte.MaxValue;
		}
		else
		{
			array[7] = 0;
		}
		array[4] = 0;
		array[5] = 13;
		array[6] = 26;
		if (checkBoxPowerEN0.Checked)
		{
			if (FKALL.Checked)
			{
				array[7] = byte.MaxValue;
			}
			else
			{
				array[7] = 1;
			}
			if (OpenPower.Checked)
			{
				array[8] = 1;
			}
			else
			{
				array[8] = 0;
			}
		}
		if (checkBoxPowerEN1.Checked)
		{
			array[9] = 1;
			array[10] = (byte)(Convert.ToInt32(((Control)MaxPower).Text) >> 8);
			array[11] = (byte)Convert.ToInt32(((Control)MaxPower).Text);
			array[12] = (byte)(Convert.ToInt32(((Control)textBoxMaxPAdd).Text) >> 8);
			array[13] = (byte)Convert.ToInt32(((Control)textBoxMaxPAdd).Text);
			array[14] = (byte)(Convert.ToInt32(((Control)textBoxMaxPF).Text) >> 8);
			array[15] = (byte)Convert.ToInt32(((Control)textBoxMaxPF).Text);
		}
		else
		{
			array[9] = 0;
		}
		if (checkBoxPowerEN3.Checked)
		{
			array[16] = 1;
			array[17] = Convert.ToByte(((Control)RecoverTime).Text);
		}
		else
		{
			array[16] = 0;
		}
		if (checkBoxPowerEN4.Checked)
		{
			array[18] = 1;
			array[19] = (byte)(Convert.ToInt32(((Control)MaxOverCount).Text) >> 8);
			array[20] = (byte)Convert.ToInt32(((Control)MaxOverCount).Text);
		}
		else
		{
			array[18] = 0;
		}
		if (checkBox9.Checked)
		{
			array[21] = 1;
			array[22] = (byte)(Convert.ToInt32(((Control)textBox9).Text) >> 8);
			array[23] = (byte)Convert.ToInt32(((Control)textBox9).Text);
		}
		else
		{
			array[21] = 0;
		}
		if (checkBox10.Checked)
		{
			array[24] = 1;
			array[25] = Convert.ToByte(((Control)textBox10).Text);
		}
		array[26] = 0;
		array[27] = 0;
		array[28] = 0;
		array[29] = 0;
		array[30] = 0;
		array[31] = 0;
		array[32] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[17];
		byte[] response = GetResponseCount();
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 4;
		array[3] = byte.MaxValue;
		array[4] = 0;
		array[5] = 4;
		array[6] = 8;
		if (FWL1.Checked)
		{
			array[7] = 1;
			array[8] = (byte)Convert.ToInt32(((Control)OverCount1).Text);
		}
		else
		{
			array[7] = 0;
		}
		if (FWL2.Checked)
		{
			array[9] = 1;
			array[10] = (byte)Convert.ToInt32(((Control)OverCount2).Text);
		}
		else
		{
			array[9] = 0;
		}
		if (FWL3.Checked)
		{
			array[11] = 1;
			array[12] = (byte)Convert.ToInt32(((Control)OverCount3).Text);
		}
		else
		{
			array[11] = 0;
		}
		if (FWALL.Checked)
		{
			array[13] = 1;
			array[14] = (byte)Convert.ToInt32(((Control)OverCountALL).Text);
		}
		else
		{
			array[13] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void AllTimeControl_Click(object sender, EventArgs e)
	{
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[65];
		byte[] response = GetResponseCount();
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 3;
		array[3] = byte.MaxValue;
		if (SKALL.Checked)
		{
			array[7] = byte.MaxValue;
		}
		else
		{
			array[7] = 0;
		}
		array[4] = 0;
		array[5] = 28;
		array[6] = 56;
		if (checkBox2.Checked)
		{
			if (SKALL.Checked)
			{
				array[7] = byte.MaxValue;
			}
			else
			{
				array[7] = 1;
			}
			if (OpenTime.Checked)
			{
				array[8] = 1;
			}
			else
			{
				array[8] = 0;
			}
		}
		else
		{
			array[7] = 0;
			array[8] = 0;
		}
		if (checkBoxTimeEN1.Checked)
		{
			array[9] = 1;
			array[10] = 0;
			array[11] = 0;
			if (checkBoxL1Sun.Checked)
			{
				array[11] |= 128;
			}
			if (checkBoxL1Sat.Checked)
			{
				array[11] |= 64;
			}
			if (checkBoxL1Fri.Checked)
			{
				array[11] |= 32;
			}
			if (checkBoxL1Thu.Checked)
			{
				array[11] |= 16;
			}
			if (checkBoxL1Wed.Checked)
			{
				array[11] |= 8;
			}
			if (checkBoxL1Tue.Checked)
			{
				array[11] |= 4;
			}
			if (checkBoxL1Mon.Checked)
			{
				array[11] |= 2;
			}
			array[12] = Convert.ToByte(((Control)textBox1).Text);
			array[13] = Convert.ToByte(((Control)textBox2).Text);
		}
		else
		{
			array[10] = 0;
		}
		if (checkBox11.Checked)
		{
			array[14] = 1;
			if (((Control)comboBoxL1Free1).Text == "通")
			{
				array[15] = 1;
			}
			else
			{
				array[15] = 0;
			}
			array[16] = Convert.ToByte(((Control)textBoxL1FreeM1).Text);
			array[17] = Convert.ToByte(((Control)textBoxL1FreeH1).Text);
			if (((Control)comboBoxL1Free2).Text == "通")
			{
				array[18] = 1;
			}
			else
			{
				array[18] = 0;
			}
			array[19] = Convert.ToByte(((Control)textBoxL1FreeM2).Text);
			array[20] = Convert.ToByte(((Control)textBoxL1FreeH2).Text);
			if (((Control)comboBoxL1Free3).Text == "通")
			{
				array[21] = 1;
			}
			else
			{
				array[21] = 0;
			}
			array[22] = Convert.ToByte(((Control)textBoxL1FreeM3).Text);
			array[23] = Convert.ToByte(((Control)textBoxL1FreeH3).Text);
			if (((Control)comboBoxL1Free4).Text == "通")
			{
				array[24] = 1;
			}
			else
			{
				array[24] = 0;
			}
			array[25] = Convert.ToByte(((Control)textBoxL1FreeM4).Text);
			array[26] = Convert.ToByte(((Control)textBoxL1FreeH4).Text);
			if (((Control)comboBoxL1Free5).Text == "通")
			{
				array[27] = 1;
			}
			else
			{
				array[27] = 0;
			}
			array[28] = Convert.ToByte(((Control)textBoxL1FreeM5).Text);
			array[29] = Convert.ToByte(((Control)textBoxL1FreeH5).Text);
			if (((Control)comboBoxL1Free6).Text == "通")
			{
				array[30] = 1;
			}
			else
			{
				array[30] = 0;
			}
			array[31] = Convert.ToByte(((Control)textBoxL1FreeM6).Text);
			array[32] = Convert.ToByte(((Control)textBoxL1FreeH6).Text);
			if (((Control)comboBoxL1Free7).Text == "通")
			{
				array[33] = 1;
			}
			else
			{
				array[33] = 0;
			}
			array[34] = Convert.ToByte(((Control)textBoxL1FreeM7).Text);
			array[35] = Convert.ToByte(((Control)textBoxL1FreeH7).Text);
			if (((Control)comboBoxL1Free8).Text == "通")
			{
				array[36] = 1;
			}
			else
			{
				array[36] = 0;
			}
			array[37] = Convert.ToByte(((Control)textBoxL1FreeM8).Text);
			array[38] = Convert.ToByte(((Control)textBoxL1FreeH8).Text);
			if (((Control)comboBoxL1Work1).Text == "通")
			{
				array[39] = 1;
			}
			else
			{
				array[39] = 0;
			}
			array[40] = Convert.ToByte(((Control)textBoxL1WorkM1).Text);
			array[41] = Convert.ToByte(((Control)textBoxL1WorkH1).Text);
			if (((Control)comboBoxL1Work2).Text == "通")
			{
				array[42] = 1;
			}
			else
			{
				array[42] = 0;
			}
			array[43] = Convert.ToByte(((Control)textBoxL1WorkM2).Text);
			array[44] = Convert.ToByte(((Control)textBoxL1WorkH2).Text);
			if (((Control)comboBoxL1Work3).Text == "通")
			{
				array[45] = 1;
			}
			else
			{
				array[45] = 0;
			}
			array[46] = Convert.ToByte(((Control)textBoxL1WorkM3).Text);
			array[47] = Convert.ToByte(((Control)textBoxL1WorkH3).Text);
			if (((Control)comboBoxL1Work4).Text == "通")
			{
				array[48] = 1;
			}
			else
			{
				array[48] = 0;
			}
			array[49] = Convert.ToByte(((Control)textBoxL1WorkM4).Text);
			array[50] = Convert.ToByte(((Control)textBoxL1WorkH4).Text);
			if (((Control)comboBoxL1Work5).Text == "通")
			{
				array[51] = 1;
			}
			else
			{
				array[51] = 0;
			}
			array[52] = Convert.ToByte(((Control)textBoxL1WorkM5).Text);
			array[53] = Convert.ToByte(((Control)textBoxL1WorkH5).Text);
			if (((Control)comboBoxL1Work6).Text == "通")
			{
				array[54] = 1;
			}
			else
			{
				array[54] = 0;
			}
			array[55] = Convert.ToByte(((Control)textBoxL1WorkM6).Text);
			array[56] = Convert.ToByte(((Control)textBoxL1WorkH6).Text);
			if (((Control)comboBoxL1Work7).Text == "通")
			{
				array[57] = 1;
			}
			else
			{
				array[57] = 0;
			}
			array[58] = Convert.ToByte(((Control)textBoxL1WorkM7).Text);
			array[59] = Convert.ToByte(((Control)textBoxL1WorkH7).Text);
			if (((Control)comboBoxL1Work8).Text == "通")
			{
				array[60] = 1;
			}
			else
			{
				array[60] = 0;
			}
			array[61] = Convert.ToByte(((Control)textBoxL1WorkM8).Text);
			array[62] = Convert.ToByte(((Control)textBoxL1WorkH8).Text);
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[20];
		byte[] response = GetResponseCount();
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 5;
		array[3] = byte.MaxValue;
		array[4] = 0;
		array[5] = 5;
		array[6] = 10;
		if (checkBoxForceEN1.Checked)
		{
			array[7] = 1;
			if (L1ON.Checked)
			{
				array[8] = 1;
				if (L1Open.Checked)
				{
					array[9] = 1;
				}
				else
				{
					array[9] = 0;
				}
			}
			else
			{
				array[8] = 0;
				array[9] = 0;
			}
		}
		if (checkBoxForceEN2.Checked)
		{
			array[10] = 1;
			if (L2ON.Checked)
			{
				array[11] = 1;
				if (L2Open.Checked)
				{
					array[12] = 1;
				}
				else
				{
					array[12] = 0;
				}
			}
			else
			{
				array[11] = 0;
				array[12] = 0;
			}
		}
		if (checkBoxForceEN3.Checked)
		{
			array[13] = 1;
			if (L3ON.Checked)
			{
				array[14] = 1;
				if (L3Open.Checked)
				{
					array[15] = 1;
				}
				else
				{
					array[15] = 0;
				}
			}
			else
			{
				array[14] = 0;
				array[15] = 0;
			}
		}
		array[16] = 0;
		array[17] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 表号读取_Click(object sender, EventArgs e)
	{
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		int[] array = new int[6];
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array2 = new byte[8];
		byte[] response = new byte[11];
		byte[] CRC = new byte[2];
		array2[0] = Convert.ToByte(Variable.Address);
		array2[1] = 3;
		if (MeterType == 3)
		{
			array2[2] = 9;
			array2[3] = 5;
		}
		else
		{
			array2[2] = 3;
			array2[3] = 98;
		}
		array2[4] = 0;
		array2[5] = 3;
		m.GetCRC(array2, ref CRC);
		array2[^2] = CRC[0];
		array2[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array2, 0, array2.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			for (int i = 0; i < 6; i++)
			{
				array[i] = response[3 + i] / 16 * 10 + response[3 + i] % 16;
			}
			for (int j = 0; j < 6; j++)
			{
				text = ((array[j] != 0) ? ((array[j] >= 10 || array[j] <= 0) ? (text + array[j]) : (text + "0" + array[j])) : (text + "00"));
			}
			((Control)textBox8).Text = text;
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取错误！");
		}
	}

	private void ReadTimeControl_Click(object sender, EventArgs e)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aac: Unknown result type (might be due to invalid IL or missing references)
		//IL_340e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		if (MeterType == 3)
		{
			主轮抄定时器.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[59];
			byte[] CRC = new byte[2];
			array[0] = Convert.ToByte(Variable.Address);
			array[1] = 3;
			if (SKL2.Checked)
			{
				array[0] = Convert.ToByte(array[0] + 1);
			}
			if (SKL3.Checked)
			{
				array[0] = Convert.ToByte(array[0] + 2);
			}
			array[2] = 6;
			array[3] = 0;
			array[4] = 0;
			array[5] = 27;
			m.GetCRC(array, ref CRC);
			array[^2] = CRC[0];
			array[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array, 0, array.Length);
				m.GetResponse(ref response);
				PortFalshGOOD();
				Thread.Sleep(20);
			}
			catch (Exception ex)
			{
				主轮抄定时器.Enabled = true;
				PortFalshERROR();
				MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
				return;
			}
			if (m.CheckResponse(response, 0))
			{
				MessageBox.Show(" Set successfully！");
				if (((response[3] << 8) | response[4]) == 0)
				{
					CloseTime.Checked = true;
				}
				else
				{
					OpenTime.Checked = true;
				}
				if (response[5] == 1)
				{
					((ListControl)comboBoxL1Free1).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free1).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM1).Text = response[6].ToString("f0");
				((Control)textBoxL1FreeH1).Text = response[7].ToString("f0");
				if (response[8] == 1)
				{
					((ListControl)comboBoxL1Free2).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free2).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM2).Text = response[9].ToString("f0");
				((Control)textBoxL1FreeH2).Text = response[10].ToString("f0");
				if (response[11] == 1)
				{
					((ListControl)comboBoxL1Free3).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free3).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM3).Text = response[12].ToString("f0");
				((Control)textBoxL1FreeH3).Text = response[13].ToString("f0");
				if (response[14] == 1)
				{
					((ListControl)comboBoxL1Free4).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free4).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM4).Text = response[15].ToString("f0");
				((Control)textBoxL1FreeH4).Text = response[16].ToString("f0");
				if (response[17] == 1)
				{
					((ListControl)comboBoxL1Free5).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free5).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM5).Text = response[18].ToString("f0");
				((Control)textBoxL1FreeH5).Text = response[19].ToString("f0");
				if (response[20] == 1)
				{
					((ListControl)comboBoxL1Free6).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free6).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM6).Text = response[21].ToString("f0");
				((Control)textBoxL1FreeH6).Text = response[22].ToString("f0");
				if (response[23] == 1)
				{
					((ListControl)comboBoxL1Free7).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free7).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM7).Text = response[24].ToString("f0");
				((Control)textBoxL1FreeH7).Text = response[25].ToString("f0");
				if (response[26] == 1)
				{
					((ListControl)comboBoxL1Free8).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free8).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM8).Text = response[27].ToString("f0");
				((Control)textBoxL1FreeH8).Text = response[28].ToString("f0");
				if (response[29] == 1)
				{
					((ListControl)comboBoxL1Work1).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work1).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM1).Text = response[30].ToString("f0");
				((Control)textBoxL1WorkH1).Text = response[31].ToString("f0");
				if (response[32] == 1)
				{
					((ListControl)comboBoxL1Work2).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work2).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM2).Text = response[33].ToString("f0");
				((Control)textBoxL1WorkH2).Text = response[34].ToString("f0");
				if (response[35] == 1)
				{
					((ListControl)comboBoxL1Work3).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work3).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM3).Text = response[36].ToString("f0");
				((Control)textBoxL1WorkH3).Text = response[37].ToString("f0");
				if (response[38] == 1)
				{
					((ListControl)comboBoxL1Work4).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work4).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM4).Text = response[39].ToString("f0");
				((Control)textBoxL1WorkH4).Text = response[40].ToString("f0");
				if (response[41] == 1)
				{
					((ListControl)comboBoxL1Work5).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work5).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM5).Text = response[42].ToString("f0");
				((Control)textBoxL1WorkH5).Text = response[43].ToString("f0");
				if (response[44] == 1)
				{
					((ListControl)comboBoxL1Work6).SelectedIndex = 0;
				}
				((Control)textBoxL1WorkM6).Text = response[45].ToString("f0");
				((Control)textBoxL1WorkH6).Text = response[46].ToString("f0");
				if (response[47] == 1)
				{
					((ListControl)comboBoxL1Work7).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work7).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM7).Text = response[48].ToString("f0");
				((Control)textBoxL1WorkH7).Text = response[49].ToString("f0");
				if (response[50] == 1)
				{
					((ListControl)comboBoxL1Work8).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work8).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM8).Text = response[51].ToString("f0");
				((Control)textBoxL1WorkH8).Text = response[52].ToString("f0");
				((Control)textBox1).Text = response[55].ToString("f0");
				((Control)textBox2).Text = response[56].ToString("f0");
				if (((response[54] >> 7) & 1) == 1)
				{
					checkBoxL1Sun.Checked = true;
				}
				else
				{
					checkBoxL1Sun.Checked = false;
				}
				if (((response[54] >> 6) & 1) == 1)
				{
					checkBoxL1Sat.Checked = true;
				}
				else
				{
					checkBoxL1Sat.Checked = false;
				}
				if (((response[54] >> 5) & 1) == 1)
				{
					checkBoxL1Fri.Checked = true;
				}
				else
				{
					checkBoxL1Fri.Checked = false;
				}
				if (((response[54] >> 4) & 1) == 1)
				{
					checkBoxL1Thu.Checked = true;
				}
				else
				{
					checkBoxL1Thu.Checked = false;
				}
				if (((response[54] >> 3) & 1) == 1)
				{
					checkBoxL1Wed.Checked = true;
				}
				else
				{
					checkBoxL1Wed.Checked = false;
				}
				if (((response[54] >> 2) & 1) == 1)
				{
					checkBoxL1Tue.Checked = true;
				}
				else
				{
					checkBoxL1Tue.Checked = false;
				}
				if (((response[54] >> 1) & 1) == 1)
				{
					checkBoxL1Mon.Checked = true;
				}
				else
				{
					checkBoxL1Mon.Checked = false;
				}
				主轮抄定时器.Enabled = true;
			}
			else
			{
				主轮抄定时器.Enabled = true;
				MessageBox.Show("Setting error！");
			}
		}
		else if (MeterType == 2)
		{
			主轮抄定时器.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array2 = new byte[8];
			byte[] response2 = new byte[163];
			byte[] CRC2 = new byte[2];
			array2[0] = Convert.ToByte(Variable.Address);
			array2[1] = 3;
			array2[2] = 4;
			array2[3] = 32;
			array2[4] = 0;
			array2[5] = 79;
			m.GetCRC(array2, ref CRC2);
			array2[^2] = CRC2[0];
			array2[^1] = CRC2[1];
			try
			{
				Modbus.sp.Write(array2, 0, array2.Length);
				m.GetResponse(ref response2);
				PortFalshGOOD();
				Thread.Sleep(20);
			}
			catch (Exception ex2)
			{
				主轮抄定时器.Enabled = true;
				PortFalshERROR();
				MessageBox.Show(ex2.Message + "Please confirm the serial port and address settings！");
				return;
			}
			if (m.CheckResponse(response2, 0))
			{
				MessageBox.Show(" Set successfully！");
				if (SKALL.Checked)
				{
					if (((response2[3] << 8) | response2[4]) == 0)
					{
						CloseTime.Checked = true;
					}
					else
					{
						OpenTime.Checked = true;
					}
					if (((response2[6] >> 7) & 1) == 1)
					{
						checkBoxL1Sun.Checked = true;
					}
					else
					{
						checkBoxL1Sun.Checked = false;
					}
					if (((response2[6] >> 6) & 1) == 1)
					{
						checkBoxL1Sat.Checked = true;
					}
					else
					{
						checkBoxL1Sat.Checked = false;
					}
					if (((response2[6] >> 5) & 1) == 1)
					{
						checkBoxL1Fri.Checked = true;
					}
					else
					{
						checkBoxL1Fri.Checked = false;
					}
					if (((response2[6] >> 4) & 1) == 1)
					{
						checkBoxL1Thu.Checked = true;
					}
					else
					{
						checkBoxL1Thu.Checked = false;
					}
					if (((response2[6] >> 3) & 1) == 1)
					{
						checkBoxL1Wed.Checked = true;
					}
					else
					{
						checkBoxL1Wed.Checked = false;
					}
					if (((response2[6] >> 2) & 1) == 1)
					{
						checkBoxL1Tue.Checked = true;
					}
					else
					{
						checkBoxL1Tue.Checked = false;
					}
					if (((response2[6] >> 1) & 1) == 1)
					{
						checkBoxL1Mon.Checked = true;
					}
					else
					{
						checkBoxL1Mon.Checked = false;
					}
					((Control)textBox1).Text = response2[7].ToString("f0");
					((Control)textBox2).Text = response2[8].ToString("f0");
					if (response2[9] == 1)
					{
						((ListControl)comboBoxL1Free1).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free1).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM1).Text = response2[10].ToString("f0");
					((Control)textBoxL1FreeH1).Text = response2[11].ToString("f0");
					if (response2[12] == 1)
					{
						((ListControl)comboBoxL1Free2).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free2).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM2).Text = response2[13].ToString("f0");
					((Control)textBoxL1FreeH2).Text = response2[14].ToString("f0");
					if (response2[15] == 1)
					{
						((ListControl)comboBoxL1Free3).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free3).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM3).Text = response2[16].ToString("f0");
					((Control)textBoxL1FreeH3).Text = response2[17].ToString("f0");
					if (response2[18] == 1)
					{
						((ListControl)comboBoxL1Free4).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free4).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM4).Text = response2[19].ToString("f0");
					((Control)textBoxL1FreeH4).Text = response2[20].ToString("f0");
					if (response2[21] == 1)
					{
						((ListControl)comboBoxL1Free5).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free5).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM5).Text = response2[22].ToString("f0");
					((Control)textBoxL1FreeH5).Text = response2[23].ToString("f0");
					if (response2[24] == 1)
					{
						((ListControl)comboBoxL1Free6).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free6).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM6).Text = response2[25].ToString("f0");
					((Control)textBoxL1FreeH6).Text = response2[26].ToString("f0");
					if (response2[27] == 1)
					{
						((ListControl)comboBoxL1Free7).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free7).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM7).Text = response2[28].ToString("f0");
					((Control)textBoxL1FreeH7).Text = response2[29].ToString("f0");
					if (response2[30] == 1)
					{
						((ListControl)comboBoxL1Free8).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free8).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM8).Text = response2[31].ToString("f0");
					((Control)textBoxL1FreeH8).Text = response2[32].ToString("f0");
					if (response2[33] == 1)
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM1).Text = response2[34].ToString("f0");
					((Control)textBoxL1WorkH1).Text = response2[35].ToString("f0");
					if (response2[36] == 1)
					{
						((ListControl)comboBoxL1Work2).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work2).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM2).Text = response2[37].ToString("f0");
					((Control)textBoxL1WorkH2).Text = response2[38].ToString("f0");
					if (response2[39] == 1)
					{
						((ListControl)comboBoxL1Work3).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work3).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM3).Text = response2[40].ToString("f0");
					((Control)textBoxL1WorkH3).Text = response2[41].ToString("f0");
					if (response2[42] == 1)
					{
						((ListControl)comboBoxL1Work4).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work4).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM4).Text = response2[43].ToString("f0");
					((Control)textBoxL1WorkH4).Text = response2[44].ToString("f0");
					if (response2[45] == 1)
					{
						((ListControl)comboBoxL1Work5).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work5).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM5).Text = response2[46].ToString("f0");
					((Control)textBoxL1WorkH5).Text = response2[47].ToString("f0");
					if (response2[48] == 1)
					{
						((ListControl)comboBoxL1Work6).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work6).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM6).Text = response2[49].ToString("f0");
					((Control)textBoxL1WorkH6).Text = response2[50].ToString("f0");
					if (response2[51] == 1)
					{
						((ListControl)comboBoxL1Work7).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work7).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM7).Text = response2[52].ToString("f0");
					((Control)textBoxL1WorkH7).Text = response2[53].ToString("f0");
					if (response2[54] == 1)
					{
						((ListControl)comboBoxL1Work8).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work8).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM8).Text = response2[55].ToString("f0");
					((Control)textBoxL1WorkH8).Text = response2[56].ToString("f0");
					主轮抄定时器.Enabled = true;
				}
				else if (SKL1.Checked)
				{
					if (((response2[4] >> 2) & 1) == 1)
					{
						CloseTime.Checked = true;
					}
					else
					{
						OpenTime.Checked = true;
					}
					if (((response2[6] >> 7) & 1) == 1)
					{
						checkBoxL1Sun.Checked = true;
					}
					else
					{
						checkBoxL1Sun.Checked = false;
					}
					if (((response2[6] >> 6) & 1) == 1)
					{
						checkBoxL1Sat.Checked = true;
					}
					else
					{
						checkBoxL1Sat.Checked = false;
					}
					if (((response2[6] >> 5) & 1) == 1)
					{
						checkBoxL1Fri.Checked = true;
					}
					else
					{
						checkBoxL1Fri.Checked = false;
					}
					if (((response2[6] >> 4) & 1) == 1)
					{
						checkBoxL1Thu.Checked = true;
					}
					else
					{
						checkBoxL1Thu.Checked = false;
					}
					if (((response2[6] >> 3) & 1) == 1)
					{
						checkBoxL1Wed.Checked = true;
					}
					else
					{
						checkBoxL1Wed.Checked = false;
					}
					if (((response2[6] >> 2) & 1) == 1)
					{
						checkBoxL1Tue.Checked = true;
					}
					else
					{
						checkBoxL1Tue.Checked = false;
					}
					if (((response2[6] >> 1) & 1) == 1)
					{
						checkBoxL1Mon.Checked = true;
					}
					else
					{
						checkBoxL1Mon.Checked = false;
					}
					((Control)textBox1).Text = response2[7].ToString("f0");
					((Control)textBox2).Text = response2[8].ToString("f0");
					if (response2[9] == 1)
					{
						((ListControl)comboBoxL1Free1).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free1).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM1).Text = response2[10].ToString("f0");
					((Control)textBoxL1FreeH1).Text = response2[11].ToString("f0");
					if (response2[12] == 1)
					{
						((ListControl)comboBoxL1Free2).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free2).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM2).Text = response2[13].ToString("f0");
					((Control)textBoxL1FreeH2).Text = response2[14].ToString("f0");
					if (response2[15] == 1)
					{
						((ListControl)comboBoxL1Free3).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free3).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM3).Text = response2[16].ToString("f0");
					((Control)textBoxL1FreeH3).Text = response2[17].ToString("f0");
					if (response2[18] == 1)
					{
						((ListControl)comboBoxL1Free4).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free4).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM4).Text = response2[19].ToString("f0");
					((Control)textBoxL1FreeH4).Text = response2[20].ToString("f0");
					if (response2[21] == 1)
					{
						((ListControl)comboBoxL1Free5).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free5).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM5).Text = response2[22].ToString("f0");
					((Control)textBoxL1FreeH5).Text = response2[23].ToString("f0");
					if (response2[24] == 1)
					{
						((ListControl)comboBoxL1Free6).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free6).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM6).Text = response2[25].ToString("f0");
					((Control)textBoxL1FreeH6).Text = response2[26].ToString("f0");
					if (response2[27] == 1)
					{
						((ListControl)comboBoxL1Free7).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free7).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM7).Text = response2[28].ToString("f0");
					((Control)textBoxL1FreeH7).Text = response2[29].ToString("f0");
					if (response2[30] == 1)
					{
						((ListControl)comboBoxL1Free8).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Free8).SelectedIndex = 1;
					}
					((Control)textBoxL1FreeM8).Text = response2[31].ToString("f0");
					((Control)textBoxL1FreeH8).Text = response2[32].ToString("f0");
					if (response2[33] == 1)
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM1).Text = response2[34].ToString("f0");
					((Control)textBoxL1WorkH1).Text = response2[35].ToString("f0");
					if (response2[36] == 1)
					{
						((ListControl)comboBoxL1Work2).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work2).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM2).Text = response2[37].ToString("f0");
					((Control)textBoxL1WorkH2).Text = response2[38].ToString("f0");
					if (response2[39] == 1)
					{
						((ListControl)comboBoxL1Work3).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work3).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM3).Text = response2[40].ToString("f0");
					((Control)textBoxL1WorkH3).Text = response2[41].ToString("f0");
					if (response2[42] == 1)
					{
						((ListControl)comboBoxL1Work4).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work4).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM4).Text = response2[43].ToString("f0");
					((Control)textBoxL1WorkH4).Text = response2[44].ToString("f0");
					if (response2[45] == 1)
					{
						((ListControl)comboBoxL1Work5).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work5).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM5).Text = response2[46].ToString("f0");
					((Control)textBoxL1WorkH5).Text = response2[47].ToString("f0");
					if (response2[48] == 1)
					{
						((ListControl)comboBoxL1Work6).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work6).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM6).Text = response2[49].ToString("f0");
					((Control)textBoxL1WorkH6).Text = response2[50].ToString("f0");
					if (response2[51] == 1)
					{
						((ListControl)comboBoxL1Work7).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work7).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM7).Text = response2[52].ToString("f0");
					((Control)textBoxL1WorkH7).Text = response2[53].ToString("f0");
					if (response2[54] == 1)
					{
						((ListControl)comboBoxL1Work8).SelectedIndex = 0;
					}
					else
					{
						((ListControl)comboBoxL1Work8).SelectedIndex = 1;
					}
					((Control)textBoxL1WorkM8).Text = response2[55].ToString("f0");
					((Control)textBoxL1WorkH8).Text = response2[56].ToString("f0");
					主轮抄定时器.Enabled = true;
				}
				else if (SKL2.Checked)
				{
					if (((response2[4] >> 1) & 1) == 1)
					{
						CloseTime.Checked = true;
					}
					else
					{
						OpenTime.Checked = true;
					}
					if (((response2[58] >> 7) & 1) == 128)
					{
						checkBoxL1Sun.Checked = true;
					}
					if (((response2[58] >> 6) & 1) == 128)
					{
						checkBoxL1Sat.Checked = true;
					}
					if (((response2[58] >> 5) & 1) == 128)
					{
						checkBoxL1Fri.Checked = true;
					}
					if (((response2[58] >> 4) & 1) == 128)
					{
						checkBoxL1Thu.Checked = true;
					}
					if (((response2[58] >> 3) & 1) == 128)
					{
						checkBoxL1Wed.Checked = true;
					}
					if (((response2[58] >> 2) & 1) == 128)
					{
						checkBoxL1Tue.Checked = true;
					}
					if (((response2[58] >> 1) & 1) == 128)
					{
						checkBoxL1Mon.Checked = true;
					}
					((Control)textBox1).Text = response2[59].ToString("f0");
					((Control)textBox2).Text = response2[60].ToString("f0");
					if (response2[61] == 1)
					{
						((ListControl)comboBoxL1Free1).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM1).Text = response2[62].ToString("f0");
					((Control)textBoxL1FreeH1).Text = response2[63].ToString("f0");
					if (response2[64] == 1)
					{
						((ListControl)comboBoxL1Free2).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM2).Text = response2[65].ToString("f0");
					((Control)textBoxL1FreeH2).Text = response2[66].ToString("f0");
					if (response2[67] == 1)
					{
						((ListControl)comboBoxL1Free3).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM3).Text = response2[68].ToString("f0");
					((Control)textBoxL1FreeH3).Text = response2[69].ToString("f0");
					if (response2[70] == 1)
					{
						((ListControl)comboBoxL1Free4).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM4).Text = response2[71].ToString("f0");
					((Control)textBoxL1FreeH4).Text = response2[72].ToString("f0");
					if (response2[73] == 1)
					{
						((ListControl)comboBoxL1Free5).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM5).Text = response2[74].ToString("f0");
					((Control)textBoxL1FreeH5).Text = response2[75].ToString("f0");
					if (response2[76] == 1)
					{
						((ListControl)comboBoxL1Free6).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM6).Text = response2[77].ToString("f0");
					((Control)textBoxL1FreeH6).Text = response2[78].ToString("f0");
					if (response2[79] == 1)
					{
						((ListControl)comboBoxL1Free7).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM7).Text = response2[80].ToString("f0");
					((Control)textBoxL1FreeH7).Text = response2[81].ToString("f0");
					if (response2[82] == 1)
					{
						((ListControl)comboBoxL1Free8).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM8).Text = response2[83].ToString("f0");
					((Control)textBoxL1FreeH8).Text = response2[84].ToString("f0");
					if (response2[85] == 1)
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM1).Text = response2[86].ToString("f0");
					((Control)textBoxL1WorkH1).Text = response2[87].ToString("f0");
					if (response2[88] == 1)
					{
						((ListControl)comboBoxL1Work2).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM2).Text = response2[89].ToString("f0");
					((Control)textBoxL1WorkH2).Text = response2[90].ToString("f0");
					if (response2[91] == 1)
					{
						((ListControl)comboBoxL1Work3).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM3).Text = response2[92].ToString("f0");
					((Control)textBoxL1WorkH3).Text = response2[93].ToString("f0");
					if (response2[94] == 1)
					{
						((ListControl)comboBoxL1Work4).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM4).Text = response2[95].ToString("f0");
					((Control)textBoxL1WorkH4).Text = response2[96].ToString("f0");
					if (response2[97] == 1)
					{
						((ListControl)comboBoxL1Work5).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM5).Text = response2[98].ToString("f0");
					((Control)textBoxL1WorkH5).Text = response2[99].ToString("f0");
					if (response2[100] == 1)
					{
						((ListControl)comboBoxL1Work6).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM6).Text = response2[101].ToString("f0");
					((Control)textBoxL1WorkH6).Text = response2[102].ToString("f0");
					if (response2[103] == 1)
					{
						((ListControl)comboBoxL1Work7).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM7).Text = response2[104].ToString("f0");
					((Control)textBoxL1WorkH7).Text = response2[105].ToString("f0");
					if (response2[106] == 1)
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM8).Text = response2[107].ToString("f0");
					((Control)textBoxL1WorkH8).Text = response2[108].ToString("f0");
					主轮抄定时器.Enabled = true;
				}
				else if (SKL3.Checked)
				{
					if ((response2[4] & 1) == 1)
					{
						CloseTime.Checked = true;
					}
					else
					{
						OpenTime.Checked = true;
					}
					if (((response2[110] >> 7) & 1) == 128)
					{
						checkBoxL1Sun.Checked = true;
					}
					if (((response2[110] >> 6) & 1) == 128)
					{
						checkBoxL1Sat.Checked = true;
					}
					if (((response2[110] >> 5) & 1) == 128)
					{
						checkBoxL1Fri.Checked = true;
					}
					if (((response2[110] >> 4) & 1) == 128)
					{
						checkBoxL1Thu.Checked = true;
					}
					if (((response2[110] >> 3) & 1) == 128)
					{
						checkBoxL1Wed.Checked = true;
					}
					if (((response2[110] >> 2) & 1) == 128)
					{
						checkBoxL1Tue.Checked = true;
					}
					if (((response2[110] >> 1) & 1) == 128)
					{
						checkBoxL1Mon.Checked = true;
					}
					((Control)textBox1).Text = response2[111].ToString("f0");
					((Control)textBox2).Text = response2[112].ToString("f0");
					if (response2[113] == 1)
					{
						((ListControl)comboBoxL1Free1).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM1).Text = response2[114].ToString("f0");
					((Control)textBoxL1FreeH1).Text = response2[115].ToString("f0");
					if (response2[116] == 1)
					{
						((ListControl)comboBoxL1Free2).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM2).Text = response2[117].ToString("f0");
					((Control)textBoxL1FreeH2).Text = response2[118].ToString("f0");
					if (response2[119] == 1)
					{
						((ListControl)comboBoxL1Free3).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM3).Text = response2[120].ToString("f0");
					((Control)textBoxL1FreeH3).Text = response2[121].ToString("f0");
					if (response2[122] == 1)
					{
						((ListControl)comboBoxL1Free4).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM4).Text = response2[123].ToString("f0");
					((Control)textBoxL1FreeH4).Text = response2[124].ToString("f0");
					if (response2[125] == 1)
					{
						((ListControl)comboBoxL1Free5).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM5).Text = response2[126].ToString("f0");
					((Control)textBoxL1FreeH5).Text = response2[127].ToString("f0");
					if (response2[128] == 1)
					{
						((ListControl)comboBoxL1Free6).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM6).Text = response2[129].ToString("f0");
					((Control)textBoxL1FreeH6).Text = response2[130].ToString("f0");
					if (response2[131] == 1)
					{
						((ListControl)comboBoxL1Free7).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM7).Text = response2[132].ToString("f0");
					((Control)textBoxL1FreeH7).Text = response2[133].ToString("f0");
					if (response2[134] == 1)
					{
						((ListControl)comboBoxL1Free8).SelectedIndex = 0;
					}
					((Control)textBoxL1FreeM8).Text = response2[135].ToString("f0");
					((Control)textBoxL1FreeH8).Text = response2[136].ToString("f0");
					if (response2[137] == 1)
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM1).Text = response2[138].ToString("f0");
					((Control)textBoxL1WorkH1).Text = response2[139].ToString("f0");
					if (response2[140] == 1)
					{
						((ListControl)comboBoxL1Work2).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM2).Text = response2[141].ToString("f0");
					((Control)textBoxL1WorkH2).Text = response2[142].ToString("f0");
					if (response2[143] == 1)
					{
						((ListControl)comboBoxL1Work3).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM3).Text = response2[144].ToString("f0");
					((Control)textBoxL1WorkH3).Text = response2[145].ToString("f0");
					if (response2[146] == 1)
					{
						((ListControl)comboBoxL1Work4).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM4).Text = response2[147].ToString("f0");
					((Control)textBoxL1WorkH4).Text = response2[148].ToString("f0");
					if (response2[149] == 1)
					{
						((ListControl)comboBoxL1Work5).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM5).Text = response2[150].ToString("f0");
					((Control)textBoxL1WorkH5).Text = response2[151].ToString("f0");
					if (response2[152] == 1)
					{
						((ListControl)comboBoxL1Work6).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM6).Text = response2[153].ToString("f0");
					((Control)textBoxL1WorkH6).Text = response2[154].ToString("f0");
					if (response2[155] == 1)
					{
						((ListControl)comboBoxL1Work7).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM7).Text = response2[156].ToString("f0");
					((Control)textBoxL1WorkH7).Text = response2[157].ToString("f0");
					if (response2[158] == 1)
					{
						((ListControl)comboBoxL1Work1).SelectedIndex = 0;
					}
					((Control)textBoxL1WorkM8).Text = response2[159].ToString("f0");
					((Control)textBoxL1WorkH8).Text = response2[160].ToString("f0");
					主轮抄定时器.Enabled = true;
				}
			}
			else
			{
				主轮抄定时器.Enabled = true;
				MessageBox.Show("Setting error！");
			}
		}
		else
		{
			if (MeterType != 1)
			{
				return;
			}
			主轮抄定时器.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array3 = new byte[8];
			byte[] response3 = new byte[59];
			byte[] CRC3 = new byte[2];
			array3[0] = Convert.ToByte(Variable.Address);
			array3[1] = 3;
			array3[2] = 4;
			array3[3] = 32;
			array3[4] = 0;
			array3[5] = 27;
			m.GetCRC(array3, ref CRC3);
			array3[^2] = CRC3[0];
			array3[^1] = CRC3[1];
			try
			{
				Modbus.sp.Write(array3, 0, array3.Length);
				m.GetResponse(ref response3);
				PortFalshGOOD();
				Thread.Sleep(20);
			}
			catch (Exception ex3)
			{
				主轮抄定时器.Enabled = true;
				PortFalshERROR();
				MessageBox.Show(ex3.Message + "Please confirm the serial port and address settings！");
				return;
			}
			if (m.CheckResponse(response3, 0))
			{
				MessageBox.Show(" Set successfully！");
				if (((response3[4] >> 3) & 1) == 1)
				{
					CloseTime.Checked = true;
				}
				else
				{
					OpenTime.Checked = true;
				}
				if (((response3[6] >> 7) & 1) == 1)
				{
					checkBoxL1Sun.Checked = true;
				}
				else
				{
					checkBoxL1Sun.Checked = false;
				}
				if (((response3[6] >> 6) & 1) == 1)
				{
					checkBoxL1Sat.Checked = true;
				}
				else
				{
					checkBoxL1Sat.Checked = false;
				}
				if (((response3[6] >> 5) & 1) == 1)
				{
					checkBoxL1Fri.Checked = true;
				}
				else
				{
					checkBoxL1Fri.Checked = false;
				}
				if (((response3[6] >> 4) & 1) == 1)
				{
					checkBoxL1Thu.Checked = true;
				}
				else
				{
					checkBoxL1Thu.Checked = false;
				}
				if (((response3[6] >> 3) & 1) == 1)
				{
					checkBoxL1Wed.Checked = true;
				}
				else
				{
					checkBoxL1Wed.Checked = false;
				}
				if (((response3[6] >> 2) & 1) == 1)
				{
					checkBoxL1Tue.Checked = true;
				}
				else
				{
					checkBoxL1Tue.Checked = false;
				}
				if (((response3[6] >> 1) & 1) == 1)
				{
					checkBoxL1Mon.Checked = true;
				}
				else
				{
					checkBoxL1Mon.Checked = false;
				}
				((Control)textBox1).Text = response3[7].ToString("f0");
				((Control)textBox2).Text = response3[8].ToString("f0");
				if (response3[9] == 1)
				{
					((ListControl)comboBoxL1Free1).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free1).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM1).Text = response3[10].ToString("f0");
				((Control)textBoxL1FreeH1).Text = response3[11].ToString("f0");
				if (response3[12] == 1)
				{
					((ListControl)comboBoxL1Free2).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free2).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM2).Text = response3[13].ToString("f0");
				((Control)textBoxL1FreeH2).Text = response3[14].ToString("f0");
				if (response3[15] == 1)
				{
					((ListControl)comboBoxL1Free3).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free3).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM3).Text = response3[16].ToString("f0");
				((Control)textBoxL1FreeH3).Text = response3[17].ToString("f0");
				if (response3[18] == 1)
				{
					((ListControl)comboBoxL1Free4).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free4).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM4).Text = response3[19].ToString("f0");
				((Control)textBoxL1FreeH4).Text = response3[20].ToString("f0");
				if (response3[21] == 1)
				{
					((ListControl)comboBoxL1Free5).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free5).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM5).Text = response3[22].ToString("f0");
				((Control)textBoxL1FreeH5).Text = response3[23].ToString("f0");
				if (response3[24] == 1)
				{
					((ListControl)comboBoxL1Free6).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free6).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM6).Text = response3[25].ToString("f0");
				((Control)textBoxL1FreeH6).Text = response3[26].ToString("f0");
				if (response3[27] == 1)
				{
					((ListControl)comboBoxL1Free7).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free7).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM7).Text = response3[28].ToString("f0");
				((Control)textBoxL1FreeH7).Text = response3[29].ToString("f0");
				if (response3[30] == 1)
				{
					((ListControl)comboBoxL1Free8).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Free8).SelectedIndex = 1;
				}
				((Control)textBoxL1FreeM8).Text = response3[31].ToString("f0");
				((Control)textBoxL1FreeH8).Text = response3[32].ToString("f0");
				if (response3[33] == 1)
				{
					((ListControl)comboBoxL1Work1).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work1).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM1).Text = response3[34].ToString("f0");
				((Control)textBoxL1WorkH1).Text = response3[35].ToString("f0");
				if (response3[36] == 1)
				{
					((ListControl)comboBoxL1Work2).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work2).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM2).Text = response3[37].ToString("f0");
				((Control)textBoxL1WorkH2).Text = response3[38].ToString("f0");
				if (response3[39] == 1)
				{
					((ListControl)comboBoxL1Work3).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work3).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM3).Text = response3[40].ToString("f0");
				((Control)textBoxL1WorkH3).Text = response3[41].ToString("f0");
				if (response3[42] == 1)
				{
					((ListControl)comboBoxL1Work4).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work4).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM4).Text = response3[43].ToString("f0");
				((Control)textBoxL1WorkH4).Text = response3[44].ToString("f0");
				if (response3[45] == 1)
				{
					((ListControl)comboBoxL1Work5).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work5).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM5).Text = response3[46].ToString("f0");
				((Control)textBoxL1WorkH5).Text = response3[47].ToString("f0");
				if (response3[48] == 1)
				{
					((ListControl)comboBoxL1Work6).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work6).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM6).Text = response3[49].ToString("f0");
				((Control)textBoxL1WorkH6).Text = response3[50].ToString("f0");
				if (response3[51] == 1)
				{
					((ListControl)comboBoxL1Work7).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work7).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM7).Text = response3[52].ToString("f0");
				((Control)textBoxL1WorkH7).Text = response3[53].ToString("f0");
				if (response3[54] == 1)
				{
					((ListControl)comboBoxL1Work8).SelectedIndex = 0;
				}
				else
				{
					((ListControl)comboBoxL1Work8).SelectedIndex = 1;
				}
				((Control)textBoxL1WorkM8).Text = response3[55].ToString("f0");
				((Control)textBoxL1WorkH8).Text = response3[56].ToString("f0");
				主轮抄定时器.Enabled = true;
			}
			else
			{
				主轮抄定时器.Enabled = true;
				MessageBox.Show("Setting error！");
			}
		}
	}

	private void ADF300类型设置_Click(object sender, EventArgs e)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 16;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		if (I.Checked)
		{
			array[8] = 12;
		}
		else if (II.Checked)
		{
			array[8] = 24;
		}
		else if (III.Checked)
		{
			array[8] = 36;
		}
		else
		{
			array[8] = 24;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF300类型读取_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 16;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[4] == 12)
			{
				I.Checked = true;
				((Control)三相数量).Text = "4";
			}
			else if (response[4] == 24)
			{
				II.Checked = true;
				((Control)三相数量).Text = "8";
			}
			else if (response[4] == 36)
			{
				III.Checked = true;
				((Control)三相数量).Text = "12";
			}
			else
			{
				MessageBox.Show(" 返回数值不对！");
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取错误！");
		}
	}

	private void 读取ADF_Click(object sender, EventArgs e)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[25];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 80;
		array[4] = 0;
		array[5] = 10;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[4] == 1)
			{
				ADF三相三线.Checked = true;
			}
			else if (response[4] == 24)
			{
				ADF三相四线.Checked = true;
			}
			((Control)ADFPT).Text = ((response[5] << 8) | response[6]).ToString("f0");
			((Control)ADFCT1).Text = ((response[7] << 8) | response[8]).ToString("f0");
			((Control)ADFCT2).Text = ((response[9] << 8) | response[10]).ToString("f0");
			((Control)ADFCT3).Text = ((response[11] << 8) | response[12]).ToString("f0");
			((Control)ADFCT4).Text = ((response[13] << 8) | response[14]).ToString("f0");
			if (response[16] == 1)
			{
				ADF脉冲.Checked = true;
			}
			else
			{
				ADF电平.Checked = true;
			}
			((Control)ADF脉宽).Text = ((response[17] << 8) | response[18]).ToString("f0");
			((Control)ADF间隔).Text = ((response[19] << 8) | response[20]).ToString("f0");
			if (response[22] == 1)
			{
				有无线.Checked = true;
			}
			else
			{
				无无线.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 设置ADF_Click(object sender, EventArgs e)
	{
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[29];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 80;
		array[4] = 0;
		array[5] = 10;
		array[6] = 20;
		array[7] = 0;
		if (ADF三相四线.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		array[9] = (byte)(Convert.ToInt16(((Control)ADFPT).Text) / 256);
		array[10] = (byte)Convert.ToInt16(((Control)ADFPT).Text);
		array[11] = (byte)(Convert.ToInt16(((Control)ADFCT1).Text) / 256);
		array[12] = (byte)Convert.ToInt16(((Control)ADFCT1).Text);
		array[13] = (byte)(Convert.ToInt16(((Control)ADFCT2).Text) / 256);
		array[14] = (byte)Convert.ToInt16(((Control)ADFCT2).Text);
		array[15] = (byte)(Convert.ToInt16(((Control)ADFCT3).Text) / 256);
		array[16] = (byte)Convert.ToInt16(((Control)ADFCT3).Text);
		array[17] = (byte)(Convert.ToInt16(((Control)ADFCT4).Text) / 256);
		array[18] = (byte)Convert.ToInt16(((Control)ADFCT4).Text);
		array[19] = 0;
		if (ADF脉冲.Checked)
		{
			array[20] = 1;
		}
		else
		{
			array[20] = 0;
		}
		array[21] = (byte)(Convert.ToInt16(((Control)ADF脉宽).Text) / 256);
		array[22] = (byte)Convert.ToInt16(((Control)ADF脉宽).Text);
		array[23] = (byte)(Convert.ToInt16(((Control)ADF间隔).Text) / 256);
		array[24] = (byte)Convert.ToInt16(((Control)ADF间隔).Text);
		array[25] = 0;
		if (有无线.Checked)
		{
			array[26] = 1;
		}
		else
		{
			array[26] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void groupBox28_Enter(object sender, EventArgs e)
	{
	}

	private void ADF电流_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void button6_Click(object sender, EventArgs e)
	{
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[113];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		int[] array2 = new int[8];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		if (DDSYDTSY.Checked)
		{
			array[2] = 19;
			array[3] = 0;
		}
		else if (ADF300.Checked)
		{
			array[2] = 16;
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 52;
		array[6] = 104;
		array[7] = (byte)(Convert.ToInt16(((Control)无线调制信息).Text) >> 8);
		array[8] = (byte)Convert.ToInt16(((Control)无线调制信息).Text);
		array[9] = (byte)(Convert.ToInt16(((Control)数据上报间隔).Text) >> 8);
		array[10] = (byte)Convert.ToInt16(((Control)数据上报间隔).Text);
		string s = Convert.ToString(((Control)序列号).Text);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		int num = 16 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[11 + i] = bytes[i];
		}
		for (int j = 0; j < num; j++)
		{
			array[11 + bytes.Length + j] = 0;
		}
		array[27] = Convert.ToByte(((Control)IP1).Text);
		array[28] = Convert.ToByte(((Control)IP2).Text);
		array[29] = Convert.ToByte(((Control)IP3).Text);
		array[30] = Convert.ToByte(((Control)IP4).Text);
		array[31] = (byte)(Convert.ToInt16(((Control)端口号).Text) >> 8);
		array[32] = (byte)Convert.ToInt16(((Control)端口号).Text);
		array[33] = Convert.ToByte(((Control)协议模式).Text);
		array[34] = 0;
		string s2 = Convert.ToString(((Control)域名).Text);
		byte[] bytes2 = Encoding.ASCII.GetBytes(s2);
		int num2 = 24 - bytes2.Length;
		for (int k = 0; k < bytes2.Length; k++)
		{
			array[35 + k] = bytes2[k];
		}
		for (int l = 0; l < num2; l++)
		{
			array[35 + bytes2.Length + l] = 0;
		}
		array[59] = Convert.ToByte(((Control)设备数量).Text);
		array[60] = Convert.ToByte(((Control)数据段数量).Text);
		array[61] = Convert.ToByte(((Control)告警段数量).Text);
		array[62] = Convert.ToByte(((Control)TCP).Text);
		string s3 = ((Control)Addr1).Text.Substring(2, 4);
		array[63] = (byte)(short.Parse(s3, NumberStyles.HexNumber) >> 8);
		array[64] = (byte)short.Parse(s3, NumberStyles.HexNumber);
		string s4 = ((Control)Addr2).Text.Substring(2, 4);
		array[65] = (byte)(short.Parse(s4, NumberStyles.HexNumber) >> 8);
		array[66] = (byte)short.Parse(s4, NumberStyles.HexNumber);
		string s5 = ((Control)Addr3).Text.Substring(2, 4);
		array[67] = (byte)(short.Parse(s5, NumberStyles.HexNumber) >> 8);
		array[68] = (byte)short.Parse(s5, NumberStyles.HexNumber);
		string s6 = ((Control)Addr4).Text.Substring(2, 4);
		array[69] = (byte)(short.Parse(s6, NumberStyles.HexNumber) >> 8);
		array[70] = (byte)short.Parse(s6, NumberStyles.HexNumber);
		string s7 = ((Control)Addr5).Text.Substring(2, 4);
		array[71] = (byte)(short.Parse(s7, NumberStyles.HexNumber) >> 8);
		array[72] = (byte)short.Parse(s7, NumberStyles.HexNumber);
		string s8 = ((Control)Addr6).Text.Substring(2, 4);
		array[73] = (byte)(short.Parse(s8, NumberStyles.HexNumber) >> 8);
		array[74] = (byte)short.Parse(s8, NumberStyles.HexNumber);
		string s9 = ((Control)Addr7).Text.Substring(2, 4);
		array[75] = (byte)(short.Parse(s9, NumberStyles.HexNumber) >> 8);
		array[76] = (byte)short.Parse(s9, NumberStyles.HexNumber);
		string s10 = ((Control)Addr8).Text.Substring(2, 4);
		array[77] = (byte)(short.Parse(s10, NumberStyles.HexNumber) >> 8);
		array[78] = (byte)short.Parse(s10, NumberStyles.HexNumber);
		string s11 = ((Control)LONG1).Text.Substring(2, 4);
		array[79] = (byte)(short.Parse(s11, NumberStyles.HexNumber) >> 8);
		array[80] = (byte)short.Parse(s11, NumberStyles.HexNumber);
		string s12 = ((Control)LONG2).Text.Substring(2, 4);
		array[81] = (byte)(short.Parse(s12, NumberStyles.HexNumber) >> 8);
		array[82] = (byte)short.Parse(s12, NumberStyles.HexNumber);
		string s13 = ((Control)LONG3).Text.Substring(2, 4);
		array[83] = (byte)(short.Parse(s13, NumberStyles.HexNumber) >> 8);
		array[84] = (byte)short.Parse(s13, NumberStyles.HexNumber);
		string s14 = ((Control)LONG4).Text.Substring(2, 4);
		array[85] = (byte)(short.Parse(s14, NumberStyles.HexNumber) >> 8);
		array[86] = (byte)short.Parse(s14, NumberStyles.HexNumber);
		string s15 = ((Control)LONG5).Text.Substring(2, 4);
		array[87] = (byte)(short.Parse(s15, NumberStyles.HexNumber) >> 8);
		array[88] = (byte)short.Parse(s15, NumberStyles.HexNumber);
		string s16 = ((Control)LONG6).Text.Substring(2, 4);
		array[89] = (byte)(short.Parse(s16, NumberStyles.HexNumber) >> 8);
		array[90] = (byte)short.Parse(s16, NumberStyles.HexNumber);
		string s17 = ((Control)LONG7).Text.Substring(2, 4);
		array[91] = (byte)(short.Parse(s17, NumberStyles.HexNumber) >> 8);
		array[92] = (byte)short.Parse(s17, NumberStyles.HexNumber);
		string s18 = ((Control)LONG8).Text.Substring(2, 4);
		array[93] = (byte)(short.Parse(s18, NumberStyles.HexNumber) >> 8);
		array[94] = (byte)short.Parse(s18, NumberStyles.HexNumber);
		array[95] = (byte)(Convert.ToByte(((Control)ALMM1).Text) >> 8);
		array[96] = Convert.ToByte(((Control)ALMM1).Text);
		array[97] = (byte)(Convert.ToByte(((Control)ALMM2).Text) >> 8);
		array[98] = Convert.ToByte(((Control)ALMM2).Text);
		array[99] = (byte)(Convert.ToByte(((Control)ALMM3).Text) >> 8);
		array[100] = Convert.ToByte(((Control)ALMM3).Text);
		array[101] = (byte)(Convert.ToByte(((Control)ALMM4).Text) >> 8);
		array[102] = Convert.ToByte(((Control)ALMM4).Text);
		array[103] = (byte)(Convert.ToByte(((Control)ALMM5).Text) >> 8);
		array[104] = Convert.ToByte(((Control)ALMM5).Text);
		array[105] = (byte)(Convert.ToByte(((Control)ALMM6).Text) >> 8);
		array[106] = Convert.ToByte(((Control)ALMM6).Text);
		array[107] = (byte)(Convert.ToByte(((Control)ALMM7).Text) >> 8);
		array[108] = Convert.ToByte(((Control)ALMM7).Text);
		array[109] = (byte)(Convert.ToByte(((Control)ALMM8).Text) >> 8);
		array[110] = Convert.ToByte(((Control)ALMM8).Text);
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[93];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 23;
		array[3] = 0;
		array[4] = 0;
		array[5] = 44;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Read successfully！");
		}
		((Control)编号).Text = ((response[3] << 8) | response[4]).ToString("f0");
		((Control)软件版本号).Text = ((response[5] << 8) | response[6]).ToString("f0");
		((Control)连接状态值).Text = response[7].ToString("f0");
		((Control)连接状态信号值).Text = response[8].ToString("f0");
		((Control)系统复位值).Text = response[9].ToString("f0");
		string text = "";
		byte[] array2 = new byte[24];
		for (int i = 0; i < 24; i++)
		{
			array2[i] = response[11 + i];
		}
		text = Encoding.ASCII.GetString(array2);
		text = text.Replace("\0", " ");
		((Control)CCID卡号值).Text = text;
		((Control)发送次数值).Text = ((response[39] << 8) | response[40]).ToString("f0");
		((Control)接受次数值).Text = ((response[41] << 8) | response[42]).ToString("f0");
		string text2 = "";
		byte[] array3 = new byte[20];
		for (int j = 0; j < 20; j++)
		{
			array3[j] = response[43 + j];
		}
		text2 = Encoding.ASCII.GetString(array3);
		text2 = text2.Replace("\0", " ");
		((Control)IMEI号值).Text = text2;
	}

	private void groupBox34_Enter(object sender, EventArgs e)
	{
	}

	private void button4_Click(object sender, EventArgs e)
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[109];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		if (DDSYDTSY.Checked)
		{
			array[2] = 19;
			array[3] = 0;
		}
		else if (ADF300.Checked)
		{
			array[2] = 16;
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 52;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Read successfully！");
			((Control)无线调制信息).Text = ((response[3] << 8) | response[4]).ToString("f0");
			((Control)数据上报间隔).Text = ((response[5] << 8) | response[6]).ToString("f0");
			string text = "";
			byte[] array2 = new byte[16];
			for (int i = 0; i < 16; i++)
			{
				array2[i] = response[7 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			text = text.Replace("\0", " ");
			((Control)序列号).Text = text;
			((Control)IP1).Text = response[23].ToString("f0");
			((Control)IP2).Text = response[24].ToString("f0");
			((Control)IP3).Text = response[25].ToString("f0");
			((Control)IP4).Text = response[26].ToString("f0");
			((Control)端口号).Text = ((response[27] << 8) | response[28]).ToString("f0");
			((Control)协议模式).Text = response[29].ToString("f0");
			string text2 = "";
			byte[] array3 = new byte[24];
			for (int j = 0; j < 24; j++)
			{
				array3[j] = response[31 + j];
			}
			text2 = Encoding.ASCII.GetString(array3);
			text2 = text2.Replace("\0", " ");
			((Control)域名).Text = text2;
			((Control)设备数量).Text = response[55].ToString("f0");
			((Control)数据段数量).Text = response[56].ToString("f0");
			((Control)告警段数量).Text = response[57].ToString("f0");
			((Control)TCP).Text = response[58].ToString("f0");
			((Control)Addr1).Text = "0x" + ((response[59] << 8) | response[60]).ToString("x4");
			((Control)Addr2).Text = "0x" + ((response[61] << 8) | response[62]).ToString("x4");
			((Control)Addr3).Text = "0x" + ((response[63] << 8) | response[64]).ToString("x4");
			((Control)Addr4).Text = "0x" + ((response[65] << 8) | response[66]).ToString("x4");
			((Control)Addr5).Text = "0x" + ((response[67] << 8) | response[68]).ToString("x4");
			((Control)Addr6).Text = "0x" + ((response[69] << 8) | response[70]).ToString("x4");
			((Control)Addr7).Text = "0x" + ((response[71] << 8) | response[72]).ToString("x4");
			((Control)Addr8).Text = "0x" + ((response[73] << 8) | response[74]).ToString("x4");
			((Control)LONG1).Text = "0x" + ((response[75] << 8) | response[76]).ToString("x4");
			((Control)LONG2).Text = "0x" + ((response[77] << 8) | response[78]).ToString("x4");
			((Control)LONG3).Text = "0x" + ((response[79] << 8) | response[80]).ToString("x4");
			((Control)LONG4).Text = "0x" + ((response[81] << 8) | response[82]).ToString("x4");
			((Control)LONG5).Text = "0x" + ((response[83] << 8) | response[84]).ToString("x4");
			((Control)LONG6).Text = "0x" + ((response[85] << 8) | response[86]).ToString("x4");
			((Control)LONG7).Text = "0x" + ((response[87] << 8) | response[88]).ToString("x4");
			((Control)LONG8).Text = "0x" + ((response[89] << 8) | response[90]).ToString("x4");
			((Control)ALMM1).Text = ((response[91] << 8) | response[92]).ToString("f0");
			((Control)ALMM2).Text = ((response[93] << 8) | response[94]).ToString("f0");
			((Control)ALMM3).Text = ((response[95] << 8) | response[96]).ToString("f0");
			((Control)ALMM4).Text = ((response[97] << 8) | response[98]).ToString("f0");
			((Control)ALMM5).Text = ((response[99] << 8) | response[100]).ToString("f0");
			((Control)ALMM6).Text = ((response[101] << 8) | response[102]).ToString("f0");
			((Control)ALMM7).Text = ((response[103] << 8) | response[104]).ToString("f0");
			((Control)ALMM8).Text = ((response[105] << 8) | response[106]).ToString("f0");
		}
	}

	private void 无线调制信息_TextChanged(object sender, EventArgs e)
	{
	}

	private void 序列号_TextChanged(object sender, EventArgs e)
	{
	}

	private void v(object sender, EventArgs e)
	{
	}

	private void timer3_Tick(object sender, EventArgs e)
	{
	}

	private void 透传定时器_Tick(object sender, EventArgs e)
	{
	}

	private void tabPage6_Click(object sender, EventArgs e)
	{
	}

	private void button9_Click(object sender, EventArgs e)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 8;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[3] == 0)
			{
				yufufei.Checked = true;
			}
			else if (response[3] == 1)
			{
				jiliangxing.Checked = true;
			}
			else
			{
				MessageBox.Show(" 返回数值不对！");
			}
			if (response[4] == 1)
			{
				dlt645xieyi.Checked = true;
			}
			else
			{
				dlt645xieyi.Checked = false;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button10_Click_1(object sender, EventArgs e)
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 8;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		if (yufufei.Checked)
		{
			array[7] = 0;
		}
		else
		{
			array[7] = 1;
		}
		if (dlt645xieyi.Checked)
		{
			array[8] = 1;
		}
		else
		{
			array[8] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void groupBox43_Enter(object sender, EventArgs e)
	{
	}

	private void radioButton3_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void groupBoxChangePhaseType_Enter(object sender, EventArgs e)
	{
	}

	private void groupBox39_Enter(object sender, EventArgs e)
	{
	}

	private void ADF电压_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void IMEI号值_Click(object sender, EventArgs e)
	{
	}

	private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
	{
		if (外控.AutoCheck)
		{
			内控.Checked = true;
		}
		else
		{
			内控.Checked = false;
		}
		无射频.Checked = true;
	}

	private void radioButton4_CheckedChanged(object sender, EventArgs e)
	{
		if (外控.AutoCheck)
		{
			内控.Checked = true;
		}
		else
		{
			内控.Checked = false;
		}
		有射频.Checked = true;
	}

	private void radioButton5_CheckedChanged(object sender, EventArgs e)
	{
		外控.Checked = true;
		有射频.Checked = true;
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (单费率.Checked)
		{
			复费率.Checked = true;
		}
		else
		{
			单费率.Checked = true;
		}
	}

	private void checkBox4_CheckedChanged(object sender, EventArgs e)
	{
		if (红外.Checked)
		{
			副通讯.Checked = true;
		}
		else
		{
			红外.Checked = true;
		}
	}

	private void checkBox3_CheckStateChanged(object sender, EventArgs e)
	{
		单费率.Checked = true;
	}

	private void comboBoxIb_SelectionChangeCommitted(object sender, EventArgs e)
	{
		if (((ListControl)comboBoxIb).SelectedIndex == 0)
		{
			外控.Checked = true;
			外控.AutoCheck = false;
			内控.Checked = false;
			内控.AutoCheck = false;
			((Control)radioButton4).Visible = false;
			((ListControl)comboBoxEc).SelectedIndex = 2;
		}
		else
		{
			外控.AutoCheck = true;
			内控.AutoCheck = true;
			((Control)radioButton4).Visible = true;
			((ListControl)comboBoxEc).SelectedIndex = 0;
		}
	}

	private void 购电命令下发_Click(object sender, EventArgs e)
	{
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[17];
		byte[] response = new byte[15];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 1;
		array[3] = 0;
		array[4] = 0;
		array[5] = 4;
		array[6] = 8;
		array[7] = (byte)(Convert.ToInt32(((Control)新购电量).Text) >> 24);
		array[8] = (byte)(Convert.ToInt32(((Control)新购电量).Text) >> 16);
		array[9] = (byte)(Convert.ToInt32(((Control)新购电量).Text) >> 8);
		array[10] = (byte)Convert.ToInt32(((Control)新购电量).Text);
		array[11] = (byte)(Convert.ToInt16(((Control)new购电次数).Text) >> 8);
		array[12] = (byte)Convert.ToInt16(((Control)new购电次数).Text);
		array[13] = 0;
		array[14] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		if (radioButton2.Checked)
		{
			byte[] array2 = new byte[20];
			SysKey[0] = uint.Parse(((Control)密钥1).Text, NumberStyles.HexNumber);
			SysKey[1] = uint.Parse(((Control)密钥2).Text, NumberStyles.HexNumber);
			SysKey[2] = uint.Parse(((Control)密钥3).Text, NumberStyles.HexNumber);
			SysKey[3] = uint.Parse(((Control)密钥4).Text, NumberStyles.HexNumber);
			array2 = Encrypt(array, array.Length, SysKey);
			array = array2;
		}
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 设置密钥_Click(object sender, EventArgs e)
	{
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[17];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 171;
		array[2] = 102;
		array[3] = 1;
		array[4] = 0;
		array[5] = 4;
		array[6] = 8;
		int num = int.Parse(((Control)密钥1).Text, NumberStyles.HexNumber);
		array[7] = (byte)(num >> 8);
		array[8] = (byte)num;
		num = int.Parse(((Control)密钥2).Text, NumberStyles.HexNumber);
		array[9] = (byte)(num >> 8);
		array[10] = (byte)num;
		num = int.Parse(((Control)密钥3).Text, NumberStyles.HexNumber);
		array[11] = (byte)(num >> 8);
		array[12] = (byte)num;
		num = int.Parse(((Control)密钥4).Text, NumberStyles.HexNumber);
		array[13] = (byte)(num >> 8);
		array[14] = (byte)num;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button9_Click_1(object sender, EventArgs e)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 171;
		array[2] = 102;
		array[3] = 2;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 9;
		array[8] = 16;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF电流_SelectionChangeCommitted(object sender, EventArgs e)
	{
		if (((ListControl)ADF电流).SelectedIndex == 0)
		{
			((ListControl)ADF脉冲常数).SelectedIndex = 0;
		}
		else if (((ListControl)ADF电流).SelectedIndex == 1)
		{
			((ListControl)ADF脉冲常数).SelectedIndex = 1;
		}
		else if (((ListControl)ADF电流).SelectedIndex == 2)
		{
			((ListControl)ADF脉冲常数).SelectedIndex = 2;
		}
	}

	private void button10_Click_2(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 93;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[4] == 0)
			{
				内置互感器.Checked = true;
			}
			else if (response[4] == 1)
			{
				外置互感器.Checked = true;
			}
			else
			{
				MessageBox.Show(" 返回数值不对！");
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取错误！");
		}
	}

	private void button11_Click_1(object sender, EventArgs e)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 93;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		if (内置互感器.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button13_Click_1(object sender, EventArgs e)
	{
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 0;
		array[3] = 34;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		if (单费率.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		if (电能脉冲.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 2;
		}
		if (红外.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 4;
		}
		if (内控.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 8;
		}
		if (无射频.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 16;
		}
		if (加密开.Checked)
		{
			array[8] |= 32;
		}
		else
		{
			array[8] |= 0;
		}
		if (三相四线.Checked)
		{
			array[8] |= 0;
		}
		else
		{
			array[8] |= 128;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button12_Click(object sender, EventArgs e)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 0;
		array[3] = 34;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			运行状态显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button15_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[21];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 3;
		array[4] = 0;
		array[5] = 8;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			((Control)ADF400单相数量).Text = response[6].ToString();
			((Control)ADF400三相数量).Text = response[4].ToString();
			string text = "";
			int[] array2 = new int[5];
			for (int i = 0; i < 5; i++)
			{
				array2[i] = response[7 + i] / 16 * 10 + response[7 + i] % 16;
			}
			for (int j = 0; j < 5; j++)
			{
				text = ((array2[j] != 0) ? ((array2[j] >= 10 || array2[j] <= 0) ? (text + array2[j]) : (text + "0" + array2[j])) : (text + "00"));
			}
			((Control)ADF400表号).Text = text;
			if (response[13] == 1)
			{
				ADF400计量型.Checked = true;
			}
			else
			{
				ADF400预付费型.Checked = true;
			}
			if (response[14] == 1)
			{
				ADF400dlt645协议.Checked = true;
			}
			else
			{
				ADF400dlt645协议.Checked = false;
			}
			if (response[18] == 1)
			{
				ADF400使能IC.Checked = true;
			}
			else
			{
				ADF400无使能IC.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button16_Click(object sender, EventArgs e)
	{
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		int num = 0;
		byte[] array = new byte[25];
		num = ((MeterType2 == 0) ? 16 : ((MeterType2 != 1) ? 8 : 12));
		byte[] response = new byte[num];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 3;
		array[4] = 0;
		array[5] = 8;
		array[6] = 16;
		array[7] = 0;
		array[8] = (byte)Convert.ToInt16(((Control)ADF400三相数量).Text);
		array[9] = 0;
		array[10] = (byte)Convert.ToInt16(((Control)ADF400单相数量).Text);
		GetMeterID5();
		array[11] = MeterIDToSet[0];
		array[12] = MeterIDToSet[1];
		array[13] = MeterIDToSet[2];
		array[14] = MeterIDToSet[3];
		array[15] = MeterIDToSet[4];
		array[16] = 0;
		if (ADF400预付费型.Checked)
		{
			array[17] = 0;
		}
		else
		{
			array[17] = 1;
		}
		if (ADF400dlt645协议.Checked)
		{
			array[18] = 1;
		}
		else
		{
			array[18] = 0;
		}
		array[19] = 0;
		array[20] = 0;
		array[21] = 0;
		if (ADF400使能IC.Checked)
		{
			array[22] = 1;
		}
		else
		{
			array[22] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button22_Click(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[11];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 98;
		array[4] = 0;
		array[5] = 3;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			((Control)ADF400互感器接入回路).Text = response[4].ToString();
			if (response[6] == 0)
			{
				ADF400从机地址重排2.Checked = true;
			}
			else
			{
				ADF400从机地址重排1.Checked = true;
			}
			if (response[8] == 0)
			{
				ADF400使能CE以太网0.Checked = true;
			}
			else
			{
				ADF400使能CE以太网1.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button21_Click(object sender, EventArgs e)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[15];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 98;
		array[4] = 0;
		array[5] = 3;
		array[6] = 6;
		array[7] = 0;
		array[8] = (byte)Convert.ToInt16(((Control)ADF400互感器接入回路).Text);
		array[9] = 0;
		if (ADF400从机地址重排1.Checked)
		{
			array[10] = 1;
		}
		else if (ADF400从机地址重排2.Checked)
		{
			array[10] = 0;
		}
		array[11] = 0;
		if (ADF400使能CE以太网1.Checked)
		{
			array[12] = 1;
		}
		else if (ADF400使能CE以太网0.Checked)
		{
			array[12] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button17_Click(object sender, EventArgs e)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[41];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 80;
		array[4] = 0;
		array[5] = 18;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if (response[4] == 1)
			{
				ADF4003p3l.Checked = true;
			}
			else if (response[4] == 0)
			{
				ADF4003p4l.Checked = true;
			}
			((Control)ADF400PT).Text = ((response[5] << 8) | response[6]).ToString("f0");
			((Control)ADF400CT1).Text = ((response[7] << 8) | response[8]).ToString("f0");
			((Control)ADF400CT2).Text = ((response[9] << 8) | response[10]).ToString("f0");
			((Control)ADF400CT3).Text = ((response[11] << 8) | response[12]).ToString("f0");
			((Control)ADF400CT4).Text = ((response[13] << 8) | response[14]).ToString("f0");
			((Control)ADF400CT5).Text = ((response[15] << 8) | response[16]).ToString("f0");
			((Control)ADF400CT6).Text = ((response[17] << 8) | response[18]).ToString("f0");
			((Control)ADF400CT7).Text = ((response[19] << 8) | response[20]).ToString("f0");
			((Control)ADF400CT8).Text = ((response[21] << 8) | response[22]).ToString("f0");
			((Control)ADF400CT9).Text = ((response[23] << 8) | response[24]).ToString("f0");
			((Control)ADF400CT10).Text = ((response[25] << 8) | response[26]).ToString("f0");
			((Control)ADF400CT11).Text = ((response[27] << 8) | response[28]).ToString("f0");
			((Control)ADF400CT12).Text = ((response[29] << 8) | response[30]).ToString("f0");
			if (response[32] == 1)
			{
				ADF400脉冲.Checked = true;
			}
			else if (response[32] == 0)
			{
				ADF400电平.Checked = true;
			}
			((Control)ADF400脉宽).Text = ((response[33] << 8) | response[34]).ToString("f0");
			((Control)ADF400间隔).Text = ((response[35] << 8) | response[36]).ToString("f0");
			if (response[38] == 1)
			{
				ADF400无线.Checked = true;
			}
			else if (response[38] == 0)
			{
				ADF400无无线.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button18_Click(object sender, EventArgs e)
	{
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[45];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 80;
		array[4] = 0;
		array[5] = 18;
		array[6] = 36;
		array[7] = 0;
		if (ADF4003p4l.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		array[9] = (byte)(Convert.ToInt16(((Control)ADF400PT).Text) / 256);
		array[10] = (byte)Convert.ToInt16(((Control)ADF400PT).Text);
		array[11] = (byte)(Convert.ToInt16(((Control)ADF400CT1).Text) / 256);
		array[12] = (byte)Convert.ToInt16(((Control)ADF400CT1).Text);
		array[13] = (byte)(Convert.ToInt16(((Control)ADF400CT2).Text) / 256);
		array[14] = (byte)Convert.ToInt16(((Control)ADF400CT2).Text);
		array[15] = (byte)(Convert.ToInt16(((Control)ADF400CT3).Text) / 256);
		array[16] = (byte)Convert.ToInt16(((Control)ADF400CT3).Text);
		array[17] = (byte)(Convert.ToInt16(((Control)ADF400CT4).Text) / 256);
		array[18] = (byte)Convert.ToInt16(((Control)ADF400CT4).Text);
		array[19] = (byte)(Convert.ToInt16(((Control)ADF400CT5).Text) / 256);
		array[20] = (byte)Convert.ToInt16(((Control)ADF400CT5).Text);
		array[21] = (byte)(Convert.ToInt16(((Control)ADF400CT6).Text) / 256);
		array[22] = (byte)Convert.ToInt16(((Control)ADF400CT6).Text);
		array[23] = (byte)(Convert.ToInt16(((Control)ADF400CT7).Text) / 256);
		array[24] = (byte)Convert.ToInt16(((Control)ADF400CT7).Text);
		array[25] = (byte)(Convert.ToInt16(((Control)ADF400CT8).Text) / 256);
		array[26] = (byte)Convert.ToInt16(((Control)ADF400CT8).Text);
		array[27] = (byte)(Convert.ToInt16(((Control)ADF400CT9).Text) / 256);
		array[28] = (byte)Convert.ToInt16(((Control)ADF400CT9).Text);
		array[29] = (byte)(Convert.ToInt16(((Control)ADF400CT10).Text) / 256);
		array[30] = (byte)Convert.ToInt16(((Control)ADF400CT10).Text);
		array[31] = (byte)(Convert.ToInt16(((Control)ADF400CT11).Text) / 256);
		array[32] = (byte)Convert.ToInt16(((Control)ADF400CT11).Text);
		array[33] = (byte)(Convert.ToInt16(((Control)ADF400CT12).Text) / 256);
		array[34] = (byte)Convert.ToInt16(((Control)ADF400CT12).Text);
		array[35] = 0;
		if (ADF400脉冲.Checked)
		{
			array[36] = 1;
		}
		if (ADF400电平.Checked)
		{
			array[36] = 0;
		}
		array[37] = (byte)(Convert.ToInt16(((Control)ADF400脉宽).Text) / 256);
		array[38] = (byte)Convert.ToInt16(((Control)ADF400脉宽).Text);
		array[39] = (byte)(Convert.ToInt16(((Control)ADF400间隔).Text) / 256);
		array[40] = (byte)Convert.ToInt16(((Control)ADF400间隔).Text);
		array[41] = 0;
		if (ADF400无线.Checked)
		{
			array[42] = 1;
		}
		else
		{
			array[42] = 0;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400初始化_Click(object sender, EventArgs e)
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[15];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 152;
		if (MeterType == 3)
		{
			array[2] = 100;
			array[3] = 6;
		}
		else
		{
			array[2] = 100;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 3;
		array[6] = 6;
		if (((ListControl)ADF400电压).SelectedIndex == 0)
		{
			array[7] = 2;
			array[8] = 65;
		}
		else if (((ListControl)ADF400电压).SelectedIndex == 1)
		{
			array[7] = 8;
			array[8] = 152;
		}
		else
		{
			array[7] = 14;
			array[8] = 216;
		}
		if (((ListControl)ADF400电流).SelectedIndex == 0)
		{
			array[9] = 0;
			array[10] = 100;
		}
		else
		{
			array[9] = 3;
			array[10] = 232;
		}
		if (((Control)ADF400脉冲常数).Text == "400")
		{
			array[11] = 1;
			array[12] = 144;
		}
		else if (((Control)ADF400脉冲常数).Text == "6400")
		{
			array[11] = 25;
			array[12] = 0;
		}
		else if (((Control)ADF400脉冲常数).Text == "1600")
		{
			array[11] = 6;
			array[12] = 64;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 初始化成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400校准_Click(object sender, EventArgs e)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 153;
		if (MeterType == 3)
		{
			array[2] = 100;
			array[3] = 6;
		}
		else
		{
			array[2] = 103;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(2000);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 校准成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400电能清零_Click(object sender, EventArgs e)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 9;
		array[3] = 0;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400广播清零_Click(object sender, EventArgs e)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 9;
		array[3] = byte.MaxValue;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button33_Click(object sender, EventArgs e)
	{
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		if (ADF4001通讯.Checked)
		{
			array[2] = 9;
			array[3] = 0;
		}
		else if (ADF4002通讯.Checked)
		{
			array[2] = 9;
			array[3] = 17;
		}
		else if (ADF4003通讯.Checked)
		{
			array[2] = 9;
			array[3] = 101;
		}
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			if (MeterType2 == 0)
			{
				((ListControl)ADF400地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 36);
			}
			else if (MeterType2 == 1)
			{
				((ListControl)ADF400地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 24);
			}
			else if (MeterType2 == 2)
			{
				((ListControl)ADF400地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 12);
			}
			else
			{
				((ListControl)ADF400地址).SelectedIndex = Convert.ToByte((response[4] - 1) / 36);
			}
			((ListControl)ADF400校验位).SelectedIndex = response[5];
			((ListControl)ADF400波特率).SelectedIndex = response[6];
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button32_Click(object sender, EventArgs e)
	{
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		if (ADF4001通讯.Checked)
		{
			array[2] = 9;
			array[3] = 0;
		}
		else if (ADF4002通讯.Checked)
		{
			array[2] = 9;
			array[3] = 17;
		}
		else if (ADF4003通讯.Checked)
		{
			array[2] = 9;
			array[3] = 101;
		}
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = 0;
		if (MeterType2 == 0)
		{
			array[8] = Convert.ToByte(((ListControl)ADF400地址).SelectedIndex * 36 + 1);
		}
		else if (MeterType2 == 1)
		{
			array[8] = Convert.ToByte(((ListControl)ADF400地址).SelectedIndex * 24 + 1);
		}
		else if (MeterType2 == 2)
		{
			array[8] = Convert.ToByte(((ListControl)ADF400地址).SelectedIndex * 12 + 1);
		}
		else
		{
			array[8] = Convert.ToByte(((ListControl)ADF400地址).SelectedIndex * 24 + 1);
		}
		array[9] = Convert.ToByte(((ListControl)ADF400校验位).SelectedIndex);
		array[10] = Convert.ToByte(((ListControl)ADF400波特率).SelectedIndex);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button29_Click(object sender, EventArgs e)
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[15];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 152;
		if (MeterType == 3)
		{
			array[2] = 100;
			array[3] = 6;
		}
		else
		{
			array[2] = 100;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 3;
		array[6] = 6;
		if (((ListControl)ADF400L从电压).SelectedIndex == 0)
		{
			array[7] = 2;
			array[8] = 65;
		}
		else if (((ListControl)ADF400L从电压).SelectedIndex == 1)
		{
			array[7] = 8;
			array[8] = 152;
		}
		else
		{
			array[7] = 14;
			array[8] = 216;
		}
		if (((ListControl)ADF400L从电流).SelectedIndex == 0)
		{
			array[9] = 0;
			array[10] = 100;
		}
		else
		{
			array[9] = 3;
			array[10] = 232;
		}
		if (((Control)ADF400L从pulse).Text == "400")
		{
			array[11] = 1;
			array[12] = 144;
		}
		else if (((Control)ADF400L从pulse).Text == "6400")
		{
			array[11] = 25;
			array[12] = 0;
		}
		else if (((Control)ADF400L从pulse).Text == "1600")
		{
			array[11] = 6;
			array[12] = 64;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 初始化成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button28_Click(object sender, EventArgs e)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 153;
		if (MeterType == 3)
		{
			array[2] = 100;
			array[3] = 6;
		}
		else
		{
			array[2] = 103;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(2000);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" 校准成功！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button27_Click(object sender, EventArgs e)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 9;
		array[3] = 0;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button24_Click(object sender, EventArgs e)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 32;
		array[2] = 9;
		array[3] = byte.MaxValue;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从通讯R_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 32;
		array[3] = 0;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			((Control)ADF400L从地址).Text = ((response[3] << 8) | response[4]).ToString("f0");
			if (response[6] == 0)
			{
				((Control)ADF400L从波特率).Text = "9600";
			}
			if (response[6] == 1)
			{
				((Control)ADF400L从波特率).Text = "4800";
			}
			if (response[6] == 2)
			{
				((Control)ADF400L从波特率).Text = "2400";
			}
			if (response[6] == 3)
			{
				((Control)ADF400L从波特率).Text = "1200";
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从通讯W_Click(object sender, EventArgs e)
	{
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 32;
		array[3] = 0;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = (byte)(Convert.ToInt16(((Control)ADF400L从地址).Text) / 256);
		array[8] = (byte)Convert.ToInt16(((Control)ADF400L从地址).Text);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L额定参数读取_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 32;
		array[3] = 2;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			((Control)ADF400L从额定电流).Text = ((response[3] << 8) | response[4]).ToString("f0");
			((Control)ADF400L从额定电压).Text = ((response[5] << 8) | response[6]).ToString("f0");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从参数R_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[17];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 32;
		array[3] = 4;
		array[4] = 0;
		array[5] = 6;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			((Control)ADF400L从脉冲常数).Text = ((response[3] << 8) | response[4]).ToString("f0");
			if (response[6] == 1)
			{
				ADF400L从3p3l.Checked = true;
			}
			else if (response[6] == 0)
			{
				ADF400L从3p4l.Checked = true;
			}
			if (response[8] == 1)
			{
				ADF400L从脉冲.Checked = true;
			}
			else if (response[8] == 0)
			{
				ADF400L从电平.Checked = true;
			}
			((Control)ADF400L从脉冲宽度).Text = ((response[9] << 8) | response[10]).ToString("f0");
			((Control)ADF400L从脉冲间隔).Text = ((response[11] << 8) | response[12]).ToString("f0");
			((Control)ADF400L从消抖时间).Text = ((response[13] << 8) | response[14]).ToString("f0");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从参数W_Click(object sender, EventArgs e)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[19];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 32;
		array[3] = 5;
		array[4] = 0;
		array[5] = 5;
		array[6] = 10;
		array[7] = 0;
		if (ADF400L从3p4l.Checked)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 1;
		}
		array[9] = 0;
		if (ADF400脉冲.Checked)
		{
			array[10] = 1;
		}
		else
		{
			array[10] = 0;
		}
		array[11] = (byte)(Convert.ToInt16(((Control)ADF400L从脉冲宽度).Text) / 256);
		array[12] = (byte)Convert.ToInt16(((Control)ADF400L从脉冲宽度).Text);
		array[13] = (byte)(Convert.ToInt16(((Control)ADF400L从脉冲间隔).Text) / 256);
		array[14] = (byte)Convert.ToInt16(((Control)ADF400L从脉冲间隔).Text);
		array[15] = (byte)(Convert.ToInt16(((Control)ADF400L从消抖时间).Text) / 256);
		array[16] = (byte)Convert.ToInt16(((Control)ADF400L从消抖时间).Text);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请确认电表状态是否正确！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从DI_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 32;
		array[3] = 10;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if ((response[4] & 1) == 1)
			{
				ADF400L从DI1合.Checked = true;
			}
			else
			{
				ADF400L从DI1分.Checked = true;
			}
			if ((response[4] & 2) == 2)
			{
				ADF400L从DI2合.Checked = true;
			}
			else
			{
				ADF400L从DI2分.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从DOR_Click(object sender, EventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 32;
		array[3] = 11;
		array[4] = 0;
		array[5] = 1;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if ((response[4] & 1) == 1)
			{
				ADF400L从DO1合.Checked = true;
			}
			else
			{
				ADF400L从DO1分.Checked = true;
			}
			if ((response[4] & 2) == 2)
			{
				ADF400L从DO2合.Checked = true;
			}
			else
			{
				ADF400L从DO2分.Checked = true;
			}
			if ((response[4] & 4) == 4)
			{
				ADF400L从DO3合.Checked = true;
			}
			else
			{
				ADF400L从DO3分.Checked = true;
			}
			if ((response[4] & 8) == 8)
			{
				ADF400L从DO4合.Checked = true;
			}
			else
			{
				ADF400L从DO4分.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400L从DOW_Click(object sender, EventArgs e)
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 32;
		array[3] = 11;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		if (ADF400L从DO1合.Checked)
		{
			array[8] = 1;
		}
		if (ADF400L从DO2合.Checked)
		{
			array[8] = (byte)(array[8] | 2u);
		}
		if (ADF400L从DO3合.Checked)
		{
			array[8] = (byte)(array[8] | 4u);
		}
		if (ADF400L从DO4合.Checked)
		{
			array[8] = (byte)(array[8] | 8u);
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 读取DIO_Click(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 78;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if ((response[4] & 1) == 1)
			{
				DI1checkBox.Checked = true;
			}
			else
			{
				DI1checkBox.Checked = false;
			}
			if ((response[4] & 2) == 2)
			{
				DI2checkBox.Checked = true;
			}
			else
			{
				DI2checkBox.Checked = false;
			}
			if ((response[4] & 4) == 4)
			{
				DI3checkBox.Checked = true;
			}
			else
			{
				DI3checkBox.Checked = false;
			}
			if ((response[4] & 8) == 8)
			{
				DI4checkBox.Checked = true;
			}
			else
			{
				DI4checkBox.Checked = false;
			}
			if ((response[4] & 0x10) == 16)
			{
				DI5checkBox.Checked = true;
			}
			else
			{
				DI5checkBox.Checked = false;
			}
			if ((response[4] & 0x20) == 32)
			{
				DI6checkBox.Checked = true;
			}
			else
			{
				DI6checkBox.Checked = false;
			}
			if ((response[4] & 0x40) == 64)
			{
				DI7checkBox.Checked = true;
			}
			else
			{
				DI7checkBox.Checked = false;
			}
			if ((response[4] & 0x80) == 128)
			{
				DI8checkBox.Checked = true;
			}
			else
			{
				DI8checkBox.Checked = false;
			}
			if ((response[6] & 1) == 1)
			{
				DO1checkBox.Checked = true;
			}
			else
			{
				DO1checkBox.Checked = false;
			}
			if ((response[6] & 2) == 2)
			{
				DO2checkBox.Checked = true;
			}
			else
			{
				DO2checkBox.Checked = false;
			}
			if ((response[6] & 4) == 4)
			{
				DO3checkBox.Checked = true;
			}
			else
			{
				DO3checkBox.Checked = false;
			}
			if ((response[6] & 8) == 8)
			{
				DO4checkBox.Checked = true;
			}
			else
			{
				DO4checkBox.Checked = false;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取错误！");
		}
	}

	private void 设置DO_Click(object sender, EventArgs e)
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 79;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		if (DO1checkBox.Checked)
		{
			array[8] = 1;
		}
		if (DO2checkBox.Checked)
		{
			array[8] = (byte)(array[8] | 2u);
		}
		if (DO3checkBox.Checked)
		{
			array[8] = (byte)(array[8] | 4u);
		}
		if (DO4checkBox.Checked)
		{
			array[8] = (byte)(array[8] | 8u);
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			ReadAllSetResponse(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400主机_CheckedChanged(object sender, EventArgs e)
	{
		if (ADF400从机.Checked)
		{
			((Control)groupBox70).Enabled = false;
		}
		else
		{
			((Control)groupBox70).Enabled = true;
		}
	}

	private void button19_Click(object sender, EventArgs e)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		if (ADF400主机.Checked)
		{
			array[2] = 9;
			array[3] = 78;
		}
		else
		{
			array[2] = 24;
			array[3] = 0;
		}
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			if ((response[4] & 1) == 1)
			{
				ADF400DI1合.Checked = true;
			}
			else
			{
				ADF400DI1分.Checked = true;
			}
			if (ADF400主机.Checked)
			{
				if ((response[4] & 2) == 2)
				{
					ADF400DI2合.Checked = true;
				}
				else
				{
					ADF400DI2分.Checked = true;
				}
			}
			if ((response[6] & 1) == 1)
			{
				ADF400DO1合.Checked = true;
			}
			else
			{
				ADF400DO1分.Checked = true;
			}
			if ((response[6] & 2) == 2)
			{
				ADF400DO2合.Checked = true;
			}
			else
			{
				ADF400DO2分.Checked = true;
			}
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("读取错误！");
		}
	}

	private void ADF400设置DO_Click(object sender, EventArgs e)
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		if (ADF400主机.Checked)
		{
			array[2] = 9;
			array[3] = 79;
		}
		else
		{
			array[2] = 24;
			array[3] = 1;
		}
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[7] = 0;
		array[8] = 0;
		if (ADF400DO1合.Checked)
		{
			array[8] = 1;
		}
		if (ADF400DO2合.Checked)
		{
			array[8] = (byte)(array[8] | 2u);
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void XuLieHao读取_Click(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[19];
		byte[] CRC = new byte[2];
		string[] array2 = new string[14];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 3;
		array[3] = 160;
		array[4] = 0;
		array[5] = 7;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			char c = (char)response[3];
			array2[0] = c.ToString();
			c = (char)response[4];
			array2[1] = c.ToString();
			c = (char)response[5];
			array2[2] = c.ToString();
			c = (char)response[6];
			array2[3] = c.ToString();
			c = (char)response[7];
			array2[4] = c.ToString();
			c = (char)response[8];
			array2[5] = c.ToString();
			c = (char)response[9];
			array2[6] = c.ToString();
			c = (char)response[10];
			array2[7] = c.ToString();
			c = (char)response[11];
			array2[8] = c.ToString();
			c = (char)response[12];
			array2[9] = c.ToString();
			c = (char)response[13];
			array2[10] = c.ToString();
			c = (char)response[14];
			array2[11] = c.ToString();
			c = (char)response[15];
			array2[12] = c.ToString();
			c = (char)response[16];
			array2[13] = c.ToString();
			string text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i];
			}
			((Control)XuLieHao).Text = text;
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void XuLieHao设置_Click(object sender, EventArgs e)
	{
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[23];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 3;
		array[3] = 160;
		array[4] = 0;
		array[5] = 7;
		array[6] = 14;
		byte[] array2 = new byte[14];
		string text = "";
		if (((Control)XuLieHao).Text.Length < 14)
		{
			int length = ((Control)XuLieHao).Text.Length;
			text = ((Control)XuLieHao).Text;
			for (int i = 0; i < 14 - length; i++)
			{
				text += "0";
			}
			((Control)XuLieHao).Text = text;
		}
		string text2 = ((Control)XuLieHao).Text;
		array2 = Encoding.ASCII.GetBytes(text2);
		if (array2[0] <= 9 && array2[0] >= 0)
		{
			array[7] = array2[0];
		}
		else
		{
			int num = array2[0];
			array[7] = (byte)num;
		}
		if (array2[1] <= 9 && array2[1] >= 0)
		{
			array[8] = array2[1];
		}
		else
		{
			int num = array2[1];
			array[8] = (byte)num;
		}
		if (array2[2] <= 9 && array2[2] >= 0)
		{
			array[9] = array2[2];
		}
		else
		{
			int num = array2[2];
			array[9] = (byte)num;
		}
		if (array2[3] <= 9 && array2[3] >= 0)
		{
			array[10] = array2[3];
		}
		else
		{
			int num = array2[3];
			array[10] = (byte)num;
		}
		if (array2[4] <= 9 && array2[4] >= 0)
		{
			array[11] = array2[4];
		}
		else
		{
			int num = array2[4];
			array[11] = (byte)num;
		}
		if (array2[5] <= 9 && array2[5] >= 0)
		{
			array[12] = array2[5];
		}
		else
		{
			int num = array2[5];
			array[12] = (byte)num;
		}
		if (array2[6] <= 9 && array2[6] >= 0)
		{
			array[13] = array2[6];
		}
		else
		{
			int num = array2[6];
			array[13] = (byte)num;
		}
		if (array2[7] <= 9 && array2[7] >= 0)
		{
			array[14] = array2[7];
		}
		else
		{
			int num = array2[7];
			array[14] = (byte)num;
		}
		if (array2[8] <= 9 && array2[8] >= 0)
		{
			array[15] = array2[8];
		}
		else
		{
			int num = array2[8];
			array[15] = (byte)num;
		}
		if (array2[9] <= 9 && array2[9] >= 0)
		{
			array[16] = array2[9];
		}
		else
		{
			int num = array2[9];
			array[16] = (byte)num;
		}
		if (array2[10] <= 9 && array2[10] >= 0)
		{
			array[17] = array2[10];
		}
		else
		{
			int num = array2[10];
			array[17] = (byte)num;
		}
		if (array2[11] <= 9 && array2[11] >= 0)
		{
			array[18] = array2[11];
		}
		else
		{
			int num = array2[11];
			array[18] = (byte)num;
		}
		if (array2[12] <= 9 && array2[12] >= 0)
		{
			array[19] = array2[12];
		}
		else
		{
			int num = array2[12];
			array[19] = (byte)num;
		}
		if (array2[13] <= 9 && array2[13] >= 0)
		{
			array[20] = array2[13];
		}
		else
		{
			int num = array2[13];
			array[20] = (byte)num;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void Read序列号_Click(object sender, EventArgs e)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[19];
		byte[] CRC = new byte[2];
		string[] array2 = new string[14];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 71;
		array[4] = 0;
		array[5] = 7;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			char c = (char)response[3];
			array2[0] = c.ToString();
			c = (char)response[4];
			array2[1] = c.ToString();
			c = (char)response[5];
			array2[2] = c.ToString();
			c = (char)response[6];
			array2[3] = c.ToString();
			c = (char)response[7];
			array2[4] = c.ToString();
			c = (char)response[8];
			array2[5] = c.ToString();
			c = (char)response[9];
			array2[6] = c.ToString();
			c = (char)response[10];
			array2[7] = c.ToString();
			c = (char)response[11];
			array2[8] = c.ToString();
			c = (char)response[12];
			array2[9] = c.ToString();
			c = (char)response[13];
			array2[10] = c.ToString();
			c = (char)response[14];
			array2[11] = c.ToString();
			c = (char)response[15];
			array2[12] = c.ToString();
			c = (char)response[16];
			array2[13] = c.ToString();
			string text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i];
			}
			((Control)ADF400序列号).Text = text;
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void Set序列号_Click(object sender, EventArgs e)
	{
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[23];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 71;
		array[4] = 0;
		array[5] = 7;
		array[6] = 14;
		byte[] array2 = new byte[14];
		string text = "";
		if (((Control)ADF400序列号).Text.Length < 14)
		{
			int length = ((Control)ADF400序列号).Text.Length;
			text = ((Control)ADF400序列号).Text;
			for (int i = 0; i < 14 - length; i++)
			{
				text += "0";
			}
			((Control)ADF400序列号).Text = text;
		}
		string text2 = ((Control)ADF400序列号).Text;
		array2 = Encoding.ASCII.GetBytes(text2);
		if (array2[0] <= 9 && array2[0] >= 0)
		{
			array[7] = array2[0];
		}
		else
		{
			int num = array2[0];
			array[7] = (byte)num;
		}
		if (array2[1] <= 9 && array2[1] >= 0)
		{
			array[8] = array2[1];
		}
		else
		{
			int num = array2[1];
			array[8] = (byte)num;
		}
		if (array2[2] <= 9 && array2[2] >= 0)
		{
			array[9] = array2[2];
		}
		else
		{
			int num = array2[2];
			array[9] = (byte)num;
		}
		if (array2[3] <= 9 && array2[3] >= 0)
		{
			array[10] = array2[3];
		}
		else
		{
			int num = array2[3];
			array[10] = (byte)num;
		}
		if (array2[4] <= 9 && array2[4] >= 0)
		{
			array[11] = array2[4];
		}
		else
		{
			int num = array2[4];
			array[11] = (byte)num;
		}
		if (array2[5] <= 9 && array2[5] >= 0)
		{
			array[12] = array2[5];
		}
		else
		{
			int num = array2[5];
			array[12] = (byte)num;
		}
		if (array2[6] <= 9 && array2[6] >= 0)
		{
			array[13] = array2[6];
		}
		else
		{
			int num = array2[6];
			array[13] = (byte)num;
		}
		if (array2[7] <= 9 && array2[7] >= 0)
		{
			array[14] = array2[7];
		}
		else
		{
			int num = array2[7];
			array[14] = (byte)num;
		}
		if (array2[8] <= 9 && array2[8] >= 0)
		{
			array[15] = array2[8];
		}
		else
		{
			int num = array2[8];
			array[15] = (byte)num;
		}
		if (array2[9] <= 9 && array2[9] >= 0)
		{
			array[16] = array2[9];
		}
		else
		{
			int num = array2[9];
			array[16] = (byte)num;
		}
		if (array2[10] <= 9 && array2[10] >= 0)
		{
			array[17] = array2[10];
		}
		else
		{
			int num = array2[10];
			array[17] = (byte)num;
		}
		if (array2[11] <= 9 && array2[11] >= 0)
		{
			array[18] = array2[11];
		}
		else
		{
			int num = array2[11];
			array[18] = (byte)num;
		}
		if (array2[12] <= 9 && array2[12] >= 0)
		{
			array[19] = array2[12];
		}
		else
		{
			int num = array2[12];
			array[19] = (byte)num;
		}
		if (array2[13] <= 9 && array2[13] >= 0)
		{
			array[20] = array2[13];
		}
		else
		{
			int num = array2[13];
			array[20] = (byte)num;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void Readxulihao_Click(object sender, EventArgs e)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[19];
		byte[] CRC = new byte[2];
		string[] array2 = new string[14];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 71;
		array[4] = 0;
		array[5] = 7;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			char c = (char)response[3];
			array2[0] = c.ToString();
			c = (char)response[4];
			array2[1] = c.ToString();
			c = (char)response[5];
			array2[2] = c.ToString();
			c = (char)response[6];
			array2[3] = c.ToString();
			c = (char)response[7];
			array2[4] = c.ToString();
			c = (char)response[8];
			array2[5] = c.ToString();
			c = (char)response[9];
			array2[6] = c.ToString();
			c = (char)response[10];
			array2[7] = c.ToString();
			c = (char)response[11];
			array2[8] = c.ToString();
			c = (char)response[12];
			array2[9] = c.ToString();
			c = (char)response[13];
			array2[10] = c.ToString();
			c = (char)response[14];
			array2[11] = c.ToString();
			c = (char)response[15];
			array2[12] = c.ToString();
			c = (char)response[16];
			array2[13] = c.ToString();
			string text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i];
			}
			((Control)ADF300序列号).Text = text;
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void Setxuliehao_Click(object sender, EventArgs e)
	{
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[23];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 71;
		array[4] = 0;
		array[5] = 7;
		array[6] = 14;
		byte[] array2 = new byte[14];
		string text = "";
		if (((Control)ADF300序列号).Text.Length < 14)
		{
			int length = ((Control)ADF300序列号).Text.Length;
			text = ((Control)ADF300序列号).Text;
			for (int i = 0; i < 14 - length; i++)
			{
				text += "0";
			}
			((Control)ADF300序列号).Text = text;
		}
		string text2 = ((Control)ADF300序列号).Text;
		array2 = Encoding.ASCII.GetBytes(text2);
		if (array2[0] <= 9 && array2[0] >= 0)
		{
			array[7] = array2[0];
		}
		else
		{
			int num = array2[0];
			array[7] = (byte)num;
		}
		if (array2[1] <= 9 && array2[1] >= 0)
		{
			array[8] = array2[1];
		}
		else
		{
			int num = array2[1];
			array[8] = (byte)num;
		}
		if (array2[2] <= 9 && array2[2] >= 0)
		{
			array[9] = array2[2];
		}
		else
		{
			int num = array2[2];
			array[9] = (byte)num;
		}
		if (array2[3] <= 9 && array2[3] >= 0)
		{
			array[10] = array2[3];
		}
		else
		{
			int num = array2[3];
			array[10] = (byte)num;
		}
		if (array2[4] <= 9 && array2[4] >= 0)
		{
			array[11] = array2[4];
		}
		else
		{
			int num = array2[4];
			array[11] = (byte)num;
		}
		if (array2[5] <= 9 && array2[5] >= 0)
		{
			array[12] = array2[5];
		}
		else
		{
			int num = array2[5];
			array[12] = (byte)num;
		}
		if (array2[6] <= 9 && array2[6] >= 0)
		{
			array[13] = array2[6];
		}
		else
		{
			int num = array2[6];
			array[13] = (byte)num;
		}
		if (array2[7] <= 9 && array2[7] >= 0)
		{
			array[14] = array2[7];
		}
		else
		{
			int num = array2[7];
			array[14] = (byte)num;
		}
		if (array2[8] <= 9 && array2[8] >= 0)
		{
			array[15] = array2[8];
		}
		else
		{
			int num = array2[8];
			array[15] = (byte)num;
		}
		if (array2[9] <= 9 && array2[9] >= 0)
		{
			array[16] = array2[9];
		}
		else
		{
			int num = array2[9];
			array[16] = (byte)num;
		}
		if (array2[10] <= 9 && array2[10] >= 0)
		{
			array[17] = array2[10];
		}
		else
		{
			int num = array2[10];
			array[17] = (byte)num;
		}
		if (array2[11] <= 9 && array2[11] >= 0)
		{
			array[18] = array2[11];
		}
		else
		{
			int num = array2[11];
			array[18] = (byte)num;
		}
		if (array2[12] <= 9 && array2[12] >= 0)
		{
			array[19] = array2[12];
		}
		else
		{
			int num = array2[12];
			array[19] = (byte)num;
		}
		if (array2[13] <= 9 && array2[13] >= 0)
		{
			array[20] = array2[13];
		}
		else
		{
			int num = array2[13];
			array[20] = (byte)num;
		}
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF400无线读取_Click(object sender, EventArgs e)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[25];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 9;
		array[3] = 104;
		array[4] = 0;
		array[5] = 10;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Read successfully！");
			((Control)ADF400网关IP1).Text = response[3].ToString("f0");
			((Control)ADF400网关IP2).Text = response[4].ToString("f0");
			((Control)ADF400网关IP3).Text = response[5].ToString("f0");
			((Control)ADF400网关IP4).Text = response[6].ToString("f0");
			((Control)子网掩码1).Text = response[7].ToString("f0");
			((Control)子网掩码2).Text = response[8].ToString("f0");
			((Control)子网掩码3).Text = response[9].ToString("f0");
			((Control)子网掩码4).Text = response[10].ToString("f0");
			((Control)ADF400IP1).Text = response[11].ToString("f0");
			((Control)ADF400IP2).Text = response[12].ToString("f0");
			((Control)ADF400IP3).Text = response[13].ToString("f0");
			((Control)ADF400IP4).Text = response[14].ToString("f0");
			((Control)ADF400端口号).Text = ((response[21] << 8) | response[22]).ToString("f0");
		}
	}

	private void ADF400无线设置_Click(object sender, EventArgs e)
	{
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[21];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		byte[] array2 = new byte[11];
		byte[] response2 = new byte[8];
		byte[] CRC2 = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 9;
		array[3] = 104;
		array[4] = 0;
		array[5] = 6;
		array[6] = 12;
		array[7] = Convert.ToByte(((Control)ADF400网关IP1).Text);
		array[8] = Convert.ToByte(((Control)ADF400网关IP2).Text);
		array[9] = Convert.ToByte(((Control)ADF400网关IP3).Text);
		array[10] = Convert.ToByte(((Control)ADF400网关IP4).Text);
		array[11] = Convert.ToByte(((Control)子网掩码1).Text);
		array[12] = Convert.ToByte(((Control)子网掩码2).Text);
		array[13] = Convert.ToByte(((Control)子网掩码3).Text);
		array[14] = Convert.ToByte(((Control)子网掩码4).Text);
		array[15] = Convert.ToByte(((Control)ADF400IP1).Text);
		array[16] = Convert.ToByte(((Control)ADF400IP2).Text);
		array[17] = Convert.ToByte(((Control)ADF400IP3).Text);
		array[18] = Convert.ToByte(((Control)ADF400IP4).Text);
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		array2[0] = Convert.ToByte(Variable.Address);
		array2[1] = 16;
		array2[2] = 9;
		array2[3] = 113;
		array2[4] = 0;
		array2[5] = 1;
		array2[6] = 2;
		array2[7] = (byte)(Convert.ToInt16(((Control)ADF400端口号).Text) >> 8);
		array2[8] = (byte)Convert.ToInt16(((Control)ADF400端口号).Text);
		m.GetCRC(array2, ref CRC2);
		m.GetCRC(array2, ref CRC2);
		array2[^2] = CRC2[0];
		array2[^1] = CRC2[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + "Please confirm the serial port and address settings！");
			return;
		}
		try
		{
			Modbus.sp.Write(array2, 0, array2.Length);
			m.GetResponse(ref response2);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex2)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex2.Message + "Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0) && m.CheckResponse(response2, 0))
		{
			MessageBox.Show(" Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void ADF参数设置_Enter(object sender, EventArgs e)
	{
	}

	private void label245_Click(object sender, EventArgs e)
	{
	}

	private void label197_Click(object sender, EventArgs e)
	{
	}

	private void readWIFI_Click(object sender, EventArgs e)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[108];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 25;
		array[3] = 16;
		array[4] = 0;
		array[5] = 51;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Successfully read！");
			wifi参数显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void wifi参数显示(byte[] bb)
	{
		if ((ushort)((bb[3] << 8) | bb[4]) == 0)
		{
			((ListControl)comboBox1).SelectedIndex = 0;
		}
		else
		{
			((ListControl)comboBox1).SelectedIndex = 1;
		}
		for (ushort num = 0; num < 40; num++)
		{
			if (bb[5 + num] == 0)
			{
				Num = num;
				num = 40;
			}
		}
		string text = "";
		byte[] array = new byte[Num];
		for (int i = 0; i < Num; i++)
		{
			array[i] = bb[5 + i];
		}
		text = Encoding.ASCII.GetString(array);
		text = text.Replace("\0", " ");
		((Control)WIFIname).Text = text;
		for (ushort num = 0; num < 40; num++)
		{
			if (bb[45 + num] == 0)
			{
				Num1 = num;
				num = 40;
			}
		}
		string text2 = "";
		byte[] array2 = new byte[Num1];
		for (int j = 0; j < Num1; j++)
		{
			array2[j] = bb[45 + j];
		}
		text2 = Encoding.ASCII.GetString(array2);
		text2 = text2.Replace("\0", " ");
		((Control)WIFIpassword).Text = text2;
		for (ushort num = 0; num < 40; num++)
		{
			if (bb[85 + num] == 0)
			{
				Num2 = num;
				num = 40;
			}
		}
		string text3 = "";
		byte[] array3 = new byte[Num2];
		for (int k = 0; k < Num2; k++)
		{
			if (bb[85 + k] != 0)
			{
				array3[k] = bb[85 + k];
			}
			else
			{
				array3[k] = 48;
			}
		}
		text3 = Encoding.ASCII.GetString(array3);
		text3 = text3.Replace("\0", " ");
		((Control)MACaddress).Text = text3;
		if ((ushort)((bb[98] << 8) | bb[99]) == 0)
		{
			((ListControl)comboBox2).SelectedIndex = 0;
		}
		else
		{
			((ListControl)comboBox2).SelectedIndex = 1;
		}
		((Control)WIFIsignal).Text = bb[100].ToString("f0");
		((Control)label366).Text = bb[101].ToString("f0");
		((Control)label367).Text = bb[102].ToString("f0");
		((Control)cxzcycsj).Text = ((bb[103] << 8) | bb[104]).ToString("f0");
	}

	private void setWIFI_Click(object sender, EventArgs e)
	{
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[111];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 25;
		array[3] = 16;
		array[4] = 0;
		array[5] = 51;
		array[6] = 102;
		array[7] = 0;
		array[8] = (byte)((ListControl)comboBox1).SelectedIndex;
		byte[] bytes = Encoding.ASCII.GetBytes(((Control)WIFIname).Text);
		int num = 40 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[9 + i] = bytes[i];
		}
		string s = Convert.ToString(((Control)WIFIpassword).Text);
		byte[] bytes2 = Encoding.ASCII.GetBytes(s);
		int num2 = 40 - bytes2.Length;
		for (int j = 0; j < bytes2.Length; j++)
		{
			array[49 + j] = bytes2[j];
		}
		string s2 = Convert.ToString(((Control)MACaddress).Text);
		byte[] bytes3 = Encoding.ASCII.GetBytes(s2);
		int num3 = 12 - bytes3.Length;
		for (int k = 0; k < bytes3.Length; k++)
		{
			array[89 + k] = bytes3[k];
		}
		array[101] = 0;
		array[102] = (byte)((ListControl)comboBox2).SelectedIndex;
		array[107] = (byte)(Convert.ToUInt16(((Control)cxzcycsj).Text) >> 8);
		array[108] = (byte)Convert.ToUInt16(((Control)cxzcycsj).Text);
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show("  Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 无线信息读取_Click(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[53];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 19;
		array[3] = 2;
		array[4] = 0;
		array[5] = 24;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Successfully read！");
			string text = "";
			byte[] array2 = new byte[16];
			for (int i = 0; i < 16; i++)
			{
				array2[i] = response[3 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			text = text.Replace("\0", " ");
			((Control)序列号1).Text = text;
			((Control)IP11).Text = response[19].ToString("f0");
			((Control)IP22).Text = response[20].ToString("f0");
			((Control)IP33).Text = response[21].ToString("f0");
			((Control)IP44).Text = response[22].ToString("f0");
			((Control)端口号1).Text = ((response[23] << 8) | response[24]).ToString("f0");
			((Control)协议模式1).Text = response[25].ToString("f0");
			string text2 = "";
			byte[] array3 = new byte[24];
			for (int j = 0; j < 24; j++)
			{
				array3[j] = response[27 + j];
			}
			text2 = Encoding.ASCII.GetString(array3);
			text2 = text2.Replace("\0", " ");
			((Control)域名1).Text = text2;
		}
	}

	private void 无限信息设置_Click(object sender, EventArgs e)
	{
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[57];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		int[] array2 = new int[8];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 19;
		array[3] = 2;
		array[4] = 0;
		array[5] = 24;
		array[6] = 48;
		string s = Convert.ToString(((Control)序列号1).Text);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		int num = 16 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[7 + i] = bytes[i];
		}
		for (int j = 0; j < num; j++)
		{
			array[7 + bytes.Length + j] = 0;
		}
		array[23] = Convert.ToByte(((Control)IP11).Text);
		array[24] = Convert.ToByte(((Control)IP22).Text);
		array[25] = Convert.ToByte(((Control)IP33).Text);
		array[26] = Convert.ToByte(((Control)IP44).Text);
		array[27] = (byte)(Convert.ToUInt16(((Control)端口号1).Text) >> 8);
		array[28] = (byte)Convert.ToUInt16(((Control)端口号1).Text);
		array[29] = Convert.ToByte(((Control)协议模式1).Text);
		string s2 = Convert.ToString(((Control)域名1).Text);
		byte[] bytes2 = Encoding.ASCII.GetBytes(s2);
		array[30] = (byte)bytes2.Length;
		int num2 = 24 - bytes2.Length;
		for (int k = 0; k < bytes2.Length; k++)
		{
			array[31 + k] = bytes2[k];
		}
		for (int l = 0; l < num2; l++)
		{
			array[31 + bytes2.Length + l] = 0;
		}
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show("  Set successfully, please confirm whether the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void setZT1_Click(object sender, EventArgs e)
	{
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[55];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 25;
		array[3] = 80;
		array[4] = 0;
		array[5] = 23;
		array[6] = 46;
		array[7] = (byte)((ListControl)中台EIOT协议模式).SelectedIndex;
		array[8] = (byte)((ListControl)平台选择).SelectedIndex;
		byte[] bytes = Encoding.ASCII.GetBytes(((Control)中台域名).Text);
		int num = 40 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[9 + i] = bytes[i];
		}
		string text = Convert.ToString(((Control)中台域名).Text);
		array[49] = (byte)(Convert.ToUInt16(((Control)ztDKH).Text) >> 8);
		array[50] = (byte)Convert.ToUInt16(((Control)ztDKH).Text);
		array[51] = 0;
		array[52] = (byte)Convert.ToUInt16(((Control)ztSBZQ).Text);
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void setZT2_Click(object sender, EventArgs e)
	{
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[89];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 25;
		array[3] = 103;
		array[4] = 0;
		array[5] = 40;
		array[6] = 80;
		string s = Convert.ToString(((Control)用户名).Text);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		int num = 40 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[7 + i] = bytes[i];
		}
		string s2 = Convert.ToString(((Control)密码).Text);
		byte[] bytes2 = Encoding.ASCII.GetBytes(s2);
		int num2 = 40 - bytes2.Length;
		for (int j = 0; j < bytes2.Length; j++)
		{
			array[47 + j] = bytes2[j];
		}
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void readZhongtai_Click(object sender, EventArgs e)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[251];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 25;
		array[3] = 80;
		array[4] = 0;
		array[5] = 123;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			中台参数显示(response);
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void 中台参数显示(byte[] bb)
	{
		if (bb[3] == 0)
		{
			((ListControl)中台EIOT协议模式).SelectedIndex = 0;
		}
		else
		{
			((ListControl)中台EIOT协议模式).SelectedIndex = 1;
		}
		if (bb[4] == 0)
		{
			((ListControl)平台选择).SelectedIndex = 0;
		}
		else
		{
			((ListControl)平台选择).SelectedIndex = 1;
		}
		for (ushort num = 0; num < 40; num++)
		{
			if (bb[5 + num] == 0)
			{
				Zt1 = num;
				num = 40;
			}
		}
		string text = "";
		byte[] array = new byte[Zt1];
		for (int i = 0; i < Zt1; i++)
		{
			array[i] = bb[5 + i];
		}
		text = Encoding.ASCII.GetString(array);
		text = text.Replace("\0", " ");
		((Control)中台域名).Text = text;
		((Control)ztDKH).Text = ((bb[45] << 8) | bb[46]).ToString("f0");
		((Control)ztSBZQ).Text = bb[48].ToString("f0");
		for (ushort num = 0; num < 40; num++)
		{
			if (bb[49 + num] == 0)
			{
				Zt = num;
				num = 40;
			}
		}
		string text2 = "";
		byte[] array2 = new byte[Zt];
		for (int j = 0; j < Zt; j++)
		{
			array2[j] = bb[49 + j];
		}
		text2 = Encoding.ASCII.GetString(array2);
		text2 = text2.Replace("\0", " ");
		((Control)用户名).Text = text2;
		for (ushort num2 = 0; num2 < 40; num2++)
		{
			if (bb[89 + num2] == 0)
			{
				Zt1 = num2;
				num2 = 40;
			}
		}
		string text3 = "";
		byte[] array3 = new byte[Zt1];
		for (int k = 0; k < Zt1; k++)
		{
			array3[k] = bb[89 + k];
		}
		text3 = Encoding.ASCII.GetString(array3);
		text3 = text3.Replace("\0", " ");
		((Control)密码).Text = text3;
		for (ushort num3 = 0; num3 < 16; num3++)
		{
			if (bb[129 + num3] == 0)
			{
				Zt2 = num3;
				num3 = 16;
			}
		}
		string text4 = "";
		byte[] array4 = new byte[Zt2];
		for (int l = 0; l < Zt2; l++)
		{
			array4[l] = bb[129 + l];
		}
		text4 = Encoding.ASCII.GetString(array4);
		text4 = text4.Replace("\0", " ");
		((Control)ztXLH).Text = text4;
		for (ushort num4 = 0; num4 < 40; num4++)
		{
			if (bb[145 + num4] == 0)
			{
				Num123 = num4;
				num4 = 40;
			}
		}
		string text5 = "";
		byte[] array5 = new byte[Num123];
		for (int m = 0; m < Num123; m++)
		{
			array5[m] = bb[145 + m];
		}
		text5 = Encoding.ASCII.GetString(array5);
		text5 = text5.Replace("\0", " ");
		((Control)调试网站ip).Text = text5;
		((Control)tswzDKH).Text = ((bb[185] << 8) | bb[186]).ToString("f0");
		for (ushort num4 = 0; num4 < 40; num4++)
		{
			if (bb[187 + num4] == 0)
			{
				Num456 = num4;
				num4 = 40;
			}
		}
		string text6 = "";
		byte[] array6 = new byte[Num456];
		for (int n = 0; n < Num456; n++)
		{
			array6[n] = bb[187 + n];
		}
		text6 = Encoding.ASCII.GetString(array6);
		text6 = text6.Replace("\0", " ");
		((Control)自注册IP).Text = text6;
		((Control)zzcDKH).Text = ((bb[227] << 8) | bb[228]).ToString("f0");
		for (ushort num5 = 0; num5 < 20; num5++)
		{
			if (bb[229 + num5] == 0)
			{
				Zt3 = num5;
				num5 = 20;
			}
		}
		string text7 = "";
		byte[] array7 = new byte[Zt3];
		for (int num6 = 0; num6 < Zt3; num6++)
		{
			array7[num6] = bb[229 + num6];
		}
		text7 = Encoding.ASCII.GetString(array7);
		text7 = text7.Replace("\0", " ");
		((Control)仪表型号).Text = text7;
	}

	private void setZhongtai_Click(object sender, EventArgs e)
	{
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[129];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 25;
		array[3] = 143;
		array[4] = 0;
		array[5] = 60;
		array[6] = 120;
		byte[] bytes = Encoding.ASCII.GetBytes(((Control)ztXLH).Text);
		int num = 16 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[7 + i] = bytes[i];
		}
		string s = Convert.ToString(((Control)调试网站ip).Text);
		byte[] bytes2 = Encoding.ASCII.GetBytes(s);
		int num2 = 40 - bytes2.Length;
		for (int j = 0; j < bytes2.Length; j++)
		{
			array[23 + j] = bytes2[j];
		}
		array[63] = (byte)(Convert.ToUInt16(((Control)tswzDKH).Text) >> 8);
		array[64] = (byte)Convert.ToUInt16(((Control)tswzDKH).Text);
		string s2 = Convert.ToString(((Control)自注册IP).Text);
		byte[] bytes3 = Encoding.ASCII.GetBytes(s2);
		int num3 = 40 - bytes3.Length;
		for (int k = 0; k < bytes3.Length; k++)
		{
			array[65 + k] = bytes3[k];
		}
		array[105] = (byte)(Convert.ToUInt16(((Control)zzcDKH).Text) >> 8);
		array[106] = (byte)Convert.ToUInt16(((Control)zzcDKH).Text);
		byte[] bytes4 = Encoding.ASCII.GetBytes(((Control)仪表型号).Text);
		int num4 = 20 - bytes4.Length;
		for (int l = 0; l < bytes4.Length; l++)
		{
			array[107 + l] = bytes4[l];
		}
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button20_Click(object sender, EventArgs e)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[35];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 19;
		array[3] = 56;
		array[4] = 0;
		array[5] = 15;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Read successfully！");
		}
		string text = "";
		byte[] array2 = new byte[30];
		for (int i = 0; i < 30; i++)
		{
			array2[i] = response[3 + i];
		}
		text = Encoding.ASCII.GetString(array2);
		text = text.Replace("\0", " ");
		((Control)APN号).Text = text;
	}

	private void button23_Click(object sender, EventArgs e)
	{
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[39];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 19;
		array[3] = 56;
		array[4] = 0;
		array[5] = 15;
		array[6] = 30;
		string s = Convert.ToString(((Control)APN号).Text);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		int num = 30 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[7 + i] = bytes[i];
		}
		for (int j = 0; j < num; j++)
		{
			array[7 + bytes.Length + j] = 0;
		}
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button80_Click(object sender, EventArgs e)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[251];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 25;
		array[3] = 203;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			((ListControl)comboBox6).SelectedIndex = response[3];
			if (response[4] == 165)
			{
				((ListControl)comboBox5).SelectedIndex = 1;
			}
			else
			{
				((ListControl)comboBox5).SelectedIndex = 0;
			}
			((Control)textBox201).Text = Convert.ToString((sbyte)response[5]);
			((Control)textBox199).Text = response[6].ToString("00");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button82_Click(object sender, EventArgs e)
	{
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 25;
		array[3] = 203;
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = Convert.ToByte(((ListControl)comboBox6).SelectedIndex);
		if (((ListControl)comboBox5).SelectedIndex == 0)
		{
			array[8] = 0;
		}
		else
		{
			array[8] = 165;
		}
		array[9] = (byte)Convert.ToInt16(((Control)textBox201).Text);
		array[10] = (byte)Convert.ToInt16(((Control)textBox199).Text);
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button20_Click_1(object sender, EventArgs e)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[35];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 19;
		array[3] = 56;
		array[4] = 0;
		array[5] = 15;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Read successfully！");
		}
		string text = "";
		byte[] array2 = new byte[30];
		for (int i = 0; i < 30; i++)
		{
			array2[i] = response[3 + i];
		}
		text = Encoding.ASCII.GetString(array2);
		text = text.Replace("\0", " ");
		((Control)APN号).Text = text;
	}

	private void button23_Click_1(object sender, EventArgs e)
	{
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[39];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 19;
		array[3] = 56;
		array[4] = 0;
		array[5] = 15;
		array[6] = 30;
		string s = Convert.ToString(((Control)APN号).Text);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		int num = 30 - bytes.Length;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[7 + i] = bytes[i];
		}
		for (int j = 0; j < num; j++)
		{
			array[7 + bytes.Length + j] = 0;
		}
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	private void button70_Click(object sender, EventArgs e)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[35];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 19;
		array[3] = 71;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show(" Read successfully！");
		}
		((Control)心跳).Text = ((response[3] << 8) | response[4]).ToString("f0");
		if (((response[5] << 8) | response[6]) == 0)
		{
			APNOFF.Checked = true;
		}
		else
		{
			APNON.Checked = true;
		}
	}

	private void button71_Click(object sender, EventArgs e)
	{
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		主轮抄定时器.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 19;
		array[3] = 71;
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = (byte)(Convert.ToInt16(((Control)心跳).Text) >> 8);
		array[8] = (byte)Convert.ToInt16(((Control)心跳).Text);
		array[9] = 0;
		if (APNOFF.Checked)
		{
			array[10] = 0;
		}
		else if (APNON.Checked)
		{
			array[10] = 1;
		}
		else
		{
			array[10] = 0;
		}
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			PortFalshGOOD();
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			主轮抄定时器.Enabled = true;
			PortFalshERROR();
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Setting successful, please confirm if the meter parameters are correct！");
			主轮抄定时器.Enabled = true;
		}
		else
		{
			主轮抄定时器.Enabled = true;
			MessageBox.Show("Setting error！");
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}
}

