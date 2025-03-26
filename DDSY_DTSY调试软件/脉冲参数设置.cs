using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DDSY_DTSY调试软件;

public class 脉冲参数设置 : Form
{
	private Modbus m = new Modbus();

	private ADF400读取DIDO Tow = new ADF400读取DIDO();

	private IContainer components = null;

	private Button 脉冲读取;

	private TextBox 脉冲长度;

	private Label label120;

	private TextBox 脉冲间隔;

	private Label label121;

	private Button 脉冲设置;

	private Label label1;

	private Label label2;

	public 脉冲参数设置()
	{
		InitializeComponent();
	}

	private void 脉冲读取_Click(object sender, EventArgs e)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[9];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 3;
		array[2] = 3;
		array[3] = 153;
		array[4] = 0;
		array[5] = 2;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + " Read failed, please read again or close the window！！！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Read successfully！");
			((Control)脉冲长度).Text = ((response[3] << 8) | response[4]).ToString("f0");
			((Control)脉冲间隔).Text = ((response[5] << 8) | response[6]).ToString("f0");
		}
		else
		{
			MessageBox.Show("Setting error！");
		}
	}

	private void 脉冲设置_Click(object sender, EventArgs e)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[13];
		byte[] response = new byte[8];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Variable.Address);
		array[1] = 16;
		array[2] = 3;
		array[3] = 153;
		array[4] = 0;
		array[5] = 2;
		array[6] = 4;
		array[7] = (byte)(Convert.ToInt16(((Control)脉冲长度).Text) / 256);
		array[8] = (byte)Convert.ToInt16(((Control)脉冲长度).Text);
		array[9] = (byte)(Convert.ToInt16(((Control)脉冲间隔).Text) / 256);
		array[10] = (byte)Convert.ToInt16(((Control)脉冲间隔).Text);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			m.GetResponse(ref response);
			Thread.Sleep(20);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + " Please confirm the serial port and address settings！");
			return;
		}
		if (m.CheckResponse(response, 0))
		{
			MessageBox.Show(" Set successfully，请测试脉冲参数是否正常！");
			((Form)this).Close();
		}
		else
		{
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
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		脉冲读取 = new Button();
		脉冲长度 = new TextBox();
		label120 = new Label();
		脉冲间隔 = new TextBox();
		label121 = new Label();
		脉冲设置 = new Button();
		label1 = new Label();
		label2 = new Label();
		((Control)this).SuspendLayout();
		((Control)脉冲读取).Font = new Font("宋体", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)脉冲读取).Location = new Point(145, 146);
		((Control)脉冲读取).Name = "脉冲读取";
		((Control)脉冲读取).Size = new Size(58, 23);
		((Control)脉冲读取).TabIndex = 52;
		((Control)脉冲读取).Text = "读取";
		((ButtonBase)脉冲读取).UseVisualStyleBackColor = true;
		((Control)脉冲读取).Click += 脉冲读取_Click;
		((Control)脉冲长度).Location = new Point(129, 94);
		((TextBoxBase)脉冲长度).MaxLength = 5;
		((Control)脉冲长度).Name = "脉冲长度";
		((Control)脉冲长度).Size = new Size(60, 21);
		((Control)脉冲长度).TabIndex = 51;
		((Control)脉冲长度).Text = "500";
		((Control)label120).AutoSize = true;
		((Control)label120).Location = new Point(66, 97);
		((Control)label120).Name = "label120";
		((Control)label120).Size = new Size(59, 12);
		((Control)label120).TabIndex = 50;
		((Control)label120).Text = "脉冲长度:";
		((Control)脉冲间隔).Location = new Point(128, 120);
		((TextBoxBase)脉冲间隔).MaxLength = 5;
		((Control)脉冲间隔).Name = "脉冲间隔";
		((Control)脉冲间隔).Size = new Size(60, 21);
		((Control)脉冲间隔).TabIndex = 49;
		((Control)脉冲间隔).Text = "30";
		((Control)label121).AutoSize = true;
		((Control)label121).Location = new Point(66, 123);
		((Control)label121).Name = "label121";
		((Control)label121).Size = new Size(59, 12);
		((Control)label121).TabIndex = 48;
		((Control)label121).Text = "脉冲间隔:";
		((Control)脉冲设置).Font = new Font("宋体", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)脉冲设置).Location = new Point(81, 146);
		((Control)脉冲设置).Name = "脉冲设置";
		((Control)脉冲设置).Size = new Size(52, 23);
		((Control)脉冲设置).TabIndex = 47;
		((Control)脉冲设置).Text = "设置";
		((ButtonBase)脉冲设置).UseVisualStyleBackColor = true;
		((Control)脉冲设置).Click += 脉冲设置_Click;
		((Control)label1).AutoSize = true;
		((Control)label1).Location = new Point(195, 97);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(17, 12);
		((Control)label1).TabIndex = 53;
		((Control)label1).Text = "Ms";
		((Control)label2).AutoSize = true;
		((Control)label2).Location = new Point(196, 123);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(11, 12);
		((Control)label2).TabIndex = 54;
		((Control)label2).Text = "s";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(264, 231);
		((Control)this).Controls.Add((Control)(object)label2);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Controls.Add((Control)(object)脉冲读取);
		((Control)this).Controls.Add((Control)(object)脉冲长度);
		((Control)this).Controls.Add((Control)(object)label120);
		((Control)this).Controls.Add((Control)(object)脉冲间隔);
		((Control)this).Controls.Add((Control)(object)label121);
		((Control)this).Controls.Add((Control)(object)脉冲设置);
		((Control)this).Name = "脉冲参数设置";
		((Control)this).Text = "脉冲参数设置";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
