using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace DDSY_DTSY调试软件;

public class PortConfig : Form
{
	private Modbus m = new Modbus();

	private static int Int;

	private IContainer components = null;

	private Button button2;

	private Button button1;

	private Label label5;

	private Label label4;

	private Label label2;

	private Label label3;

	private ComboBox comboBoxCheck;

	private ComboBox comboBoxStop;

	private ComboBox comboBoxData;

	private ComboBox comboBoxBaud;

	private Label label1;

	private ComboBox comboBoxPort;

	public PortConfig()
	{
		InitializeComponent();
	}

	public bool check()
	{
		if (Variable.PortSet.PortNumber != ((Control)comboBoxPort).Text || Variable.PortSet.PortData != ((Control)comboBoxData).Text || Variable.PortSet.PortStop != ((Control)comboBoxStop).Text || Variable.PortSet.PortCheck != ((Control)comboBoxCheck).Text || Variable.PortSet.PortBaud != ((Control)comboBoxBaud).Text)
		{
			return true;
		}
		return false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		if (check())
		{
			Variable.PortSet.PortNumber = ((Control)comboBoxPort).Text;
			Variable.PortSet.PortData = ((Control)comboBoxData).Text;
			Variable.PortSet.PortStop = ((Control)comboBoxStop).Text;
			Variable.PortSet.PortCheck = ((Control)comboBoxCheck).Text;
			Variable.PortSet.PortBaud = ((Control)comboBoxBaud).Text;
			if (Modbus.sp.IsOpen)
			{
				m.close();
				Thread.Sleep(200);
				if (m.Open())
				{
					MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
					((Form)this).Close();
				}
				else
				{
					MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "失败");
				}
			}
			else if (m.Open())
			{
				MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
				((Form)this).Close();
			}
			else
			{
				MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "失败");
			}
		}
		else if (Variable.IsPortOpen == 1)
		{
			MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
			((Form)this).Close();
		}
		else if (m.Open())
		{
			MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
			((Form)this).Close();
		}
		else
		{
			MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "失败");
		}
	}

	private void PortConfig_Load(object sender, EventArgs e)
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		string[] portNames = SerialPort.GetPortNames();
		((Control)comboBoxPort).Text = Variable.PortSet.PortNumber;
		((Control)comboBoxData).Text = Variable.PortSet.PortData;
		((Control)comboBoxStop).Text = Variable.PortSet.PortStop;
		((Control)comboBoxCheck).Text = Variable.PortSet.PortCheck;
		((Control)comboBoxBaud).Text = Variable.PortSet.PortBaud;
		if (portNames.LongLength != 1 || Int != 0)
		{
			return;
		}
		Int = 1;
		ObjectCollection items = comboBoxPort.Items;
		object[] array = portNames;
		items.AddRange(array);
		((Control)comboBoxPort).Text = portNames[0];
		if (Modbus.sp.IsOpen)
		{
			m.close();
			Thread.Sleep(200);
			if (m.Open())
			{
				MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
				((Form)this).Close();
			}
			else
			{
				MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "失败");
			}
		}
		else if (m.Open())
		{
			MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "成功");
			((Form)this).Close();
		}
		else
		{
			MessageBox.Show("打开" + Variable.PortSet.PortNumber.ToString() + "失败");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void comboBoxPort_DropDown(object sender, EventArgs e)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		comboBoxPort.Items.Clear();
		string[] portNames = SerialPort.GetPortNames();
		if (portNames.Length != 0)
		{
			((Control)button1).Enabled = true;
			ObjectCollection items = comboBoxPort.Items;
			object[] array = portNames;
			items.AddRange(array);
		}
		else
		{
			((Control)button1).Enabled = false;
			MessageBox.Show("没有可用的串口！");
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

	private void InitializeComponent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Expected O, but got Unknown
		button2 = new Button();
		button1 = new Button();
		label5 = new Label();
		label4 = new Label();
		label2 = new Label();
		label3 = new Label();
		comboBoxCheck = new ComboBox();
		comboBoxStop = new ComboBox();
		comboBoxData = new ComboBox();
		comboBoxBaud = new ComboBox();
		comboBoxPort = new ComboBox();
		label1 = new Label();
		((Control)this).SuspendLayout();
		((Control)button2).Location = new Point(102, 205);
		((Control)button2).Name = "button2";
		((Control)button2).Size = new Size(75, 23);
		((Control)button2).TabIndex = 36;
		((Control)button2).Text = "Cancel";
		((ButtonBase)button2).UseVisualStyleBackColor = true;
		((Control)button1).Location = new Point(21, 205);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(75, 23);
		((Control)button1).TabIndex = 35;
		((Control)button1).Text = "Enter";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		((Control)label5).AutoSize = true;
		((Control)label5).Font = new Font("宋体", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label5).Location = new Point(5, 142);
		((Control)label5).Name = "label5";
		((Control)label5).Size = new Size(91, 14);
		((Control)label5).TabIndex = 34;
		((Control)label5).Text = "Parity bit：";
		((Control)label4).AutoSize = true;
		((Control)label4).Font = new Font("宋体", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label4).Location = new Point(19, 115);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(77, 14);
		((Control)label4).TabIndex = 33;
		((Control)label4).Text = "Stop bit：";
		((Control)label2).AutoSize = true;
		((Control)label2).Font = new Font("宋体", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label2).Location = new Point(5, 90);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(84, 14);
		((Control)label2).TabIndex = 32;
		((Control)label2).Text = "Data bits：";
		((Control)label3).AutoSize = true;
		((Control)label3).Font = new Font("宋体", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label3).Location = new Point(5, 61);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(84, 14);
		((Control)label3).TabIndex = 31;
		((Control)label3).Text = "Baud rate：";
		comboBoxCheck.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxCheck).FormattingEnabled = true;
		comboBoxCheck.Items.AddRange(new object[3] { "N", "E", "O" });
		((Control)comboBoxCheck).Location = new Point(101, 142);
		((Control)comboBoxCheck).Name = "comboBoxCheck";
		((Control)comboBoxCheck).Size = new Size(76, 20);
		((Control)comboBoxCheck).TabIndex = 30;
		comboBoxStop.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxStop).FormattingEnabled = true;
		comboBoxStop.Items.AddRange(new object[3] { "0", "1", "2" });
		((Control)comboBoxStop).Location = new Point(101, 116);
		((Control)comboBoxStop).Name = "comboBoxStop";
		((Control)comboBoxStop).Size = new Size(76, 20);
		((Control)comboBoxStop).TabIndex = 29;
		comboBoxData.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxData).FormattingEnabled = true;
		comboBoxData.Items.AddRange(new object[3] { "8", "7", "6" });
		((Control)comboBoxData).Location = new Point(101, 90);
		((Control)comboBoxData).Name = "comboBoxData";
		((Control)comboBoxData).Size = new Size(76, 20);
		((Control)comboBoxData).TabIndex = 28;
		comboBoxBaud.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxBaud).FormattingEnabled = true;
		comboBoxBaud.Items.AddRange(new object[5] { "57600", "9600", "4800", "2400", "1200" });
		((Control)comboBoxBaud).Location = new Point(101, 61);
		((Control)comboBoxBaud).Name = "comboBoxBaud";
		((Control)comboBoxBaud).Size = new Size(76, 20);
		((Control)comboBoxBaud).TabIndex = 27;
		comboBoxPort.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxPort).FormattingEnabled = true;
		comboBoxPort.Items.AddRange(new object[12]
		{
			"COM1", "COM10", "COM11", "COM12", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7",
			"COM8", "COM9"
		});
		((Control)comboBoxPort).Location = new Point(101, 35);
		((Control)comboBoxPort).Name = "comboBoxPort";
		((Control)comboBoxPort).Size = new Size(76, 20);
		((Control)comboBoxPort).TabIndex = 26;
		comboBoxPort.DropDown += comboBoxPort_DropDown;
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("宋体", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label1).Location = new Point(40, 35);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(49, 14);
		((Control)label1).TabIndex = 25;
		((Control)label1).Text = "port：";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(200, 262);
		((Control)this).Controls.Add((Control)(object)button2);
		((Control)this).Controls.Add((Control)(object)button1);
		((Control)this).Controls.Add((Control)(object)label5);
		((Control)this).Controls.Add((Control)(object)label4);
		((Control)this).Controls.Add((Control)(object)label2);
		((Control)this).Controls.Add((Control)(object)label3);
		((Control)this).Controls.Add((Control)(object)comboBoxCheck);
		((Control)this).Controls.Add((Control)(object)comboBoxStop);
		((Control)this).Controls.Add((Control)(object)comboBoxData);
		((Control)this).Controls.Add((Control)(object)comboBoxBaud);
		((Control)this).Controls.Add((Control)(object)comboBoxPort);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Name = "PortConfig";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "串口设置";
		((Form)this).Load += PortConfig_Load;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
