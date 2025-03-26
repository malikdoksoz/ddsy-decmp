using System;
using System.IO.Ports;
using System.Threading;

namespace DDSY_DTSY调试软件;

internal class Modbus
{
	public static SerialPort sp = new SerialPort();

	private static readonly byte[] aucCRCHi = new byte[256]
	{
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64
	};

	private static readonly byte[] aucCRCLo = new byte[256]
	{
		0, 192, 193, 1, 195, 3, 2, 194, 198, 6,
		7, 199, 5, 197, 196, 4, 204, 12, 13, 205,
		15, 207, 206, 14, 10, 202, 203, 11, 201, 9,
		8, 200, 216, 24, 25, 217, 27, 219, 218, 26,
		30, 222, 223, 31, 221, 29, 28, 220, 20, 212,
		213, 21, 215, 23, 22, 214, 210, 18, 19, 211,
		17, 209, 208, 16, 240, 48, 49, 241, 51, 243,
		242, 50, 54, 246, 247, 55, 245, 53, 52, 244,
		60, 252, 253, 61, 255, 63, 62, 254, 250, 58,
		59, 251, 57, 249, 248, 56, 40, 232, 233, 41,
		235, 43, 42, 234, 238, 46, 47, 239, 45, 237,
		236, 44, 228, 36, 37, 229, 39, 231, 230, 38,
		34, 226, 227, 35, 225, 33, 32, 224, 160, 96,
		97, 161, 99, 163, 162, 98, 102, 166, 167, 103,
		165, 101, 100, 164, 108, 172, 173, 109, 175, 111,
		110, 174, 170, 106, 107, 171, 105, 169, 168, 104,
		120, 184, 185, 121, 187, 123, 122, 186, 190, 126,
		127, 191, 125, 189, 188, 124, 180, 116, 117, 181,
		119, 183, 182, 118, 114, 178, 179, 115, 177, 113,
		112, 176, 80, 144, 145, 81, 147, 83, 82, 146,
		150, 86, 87, 151, 85, 149, 148, 84, 156, 92,
		93, 157, 95, 159, 158, 94, 90, 154, 155, 91,
		153, 89, 88, 152, 136, 72, 73, 137, 75, 139,
		138, 74, 78, 142, 143, 79, 141, 77, 76, 140,
		68, 132, 133, 69, 135, 71, 70, 134, 130, 66,
		67, 131, 65, 129, 128, 64
	};

	public Modbus()
	{
		sp.ReadTimeout = 1000;
	}

	public bool Open()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		sp.PortName = Variable.PortSet.PortNumber;
		sp.BaudRate = int.Parse(Variable.PortSet.PortBaud);
		sp.DataBits = int.Parse(Variable.PortSet.PortData);
		sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Variable.PortSet.PortStop);
		sp.ReceivedBytesThreshold = 7;
		sp.RtsEnable = true;
		sp.DtrEnable = true;
		if (Variable.PortSet.PortCheck == "N")
		{
			sp.Parity = (Parity)0;
		}
		else if (Variable.PortSet.PortCheck == "E")
		{
			sp.Parity = (Parity)2;
		}
		else
		{
			sp.Parity = (Parity)1;
		}
		if (!sp.IsOpen)
		{
			try
			{
				sp.Open();
				Variable.IsPortOpen = 1;
				return true;
			}
			catch
			{
				Variable.IsPortOpen = 0;
				return false;
			}
		}
		Variable.IsPortOpen = 1;
		return true;
	}

	public bool close()
	{
		if (sp.IsOpen)
		{
			try
			{
				sp.Close();
				Variable.IsPortOpen = 0;
				return true;
			}
			catch
			{
				return false;
			}
		}
		Variable.IsPortOpen = 0;
		return true;
	}

	public void BuildMessage(ref byte[] message, byte Type)
	{
		Variable.MessageType = 0;
		byte[] CRC = new byte[2];
		message[0] = Convert.ToByte(Variable.Address);
		message[1] = Convert.ToByte(Variable.MessageSet.func);
		switch (Type)
		{
		case 0:
		{
			int num3 = Convert.ToInt16(Variable.MessageSet.Reg);
			int num4 = Convert.ToInt16(Variable.MessageSet.RegCount);
			message[2] = (byte)(num3 >> 8);
			message[3] = (byte)((uint)num3 & 0xFFu);
			message[4] = (byte)(num4 >> 8);
			message[5] = (byte)((uint)num4 & 0xFFu);
			break;
		}
		case 1:
		{
			int num = Convert.ToInt16(Variable.MessageSet.Reg1);
			int num2 = Convert.ToInt16(Variable.MessageSet.RegCount1);
			message[2] = (byte)(num >> 8);
			message[3] = (byte)((uint)num & 0xFFu);
			message[4] = (byte)(num2 >> 8);
			message[5] = (byte)((uint)num2 & 0xFFu);
			break;
		}
		}
		GetCRC(message, ref CRC);
		message[message.Length - 2] = CRC[0];
		message[message.Length - 1] = CRC[1];
	}

	public void BuildSetMessage(byte SetType, ref byte[] smessage)
	{
		byte[] CRC = new byte[2];
		switch (SetType)
		{
		case 1:
			Variable.MessageType = 1;
			smessage[0] = Convert.ToByte(Variable.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 0;
			smessage[4] = 0;
			smessage[5] = 52;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 2:
			smessage[0] = Convert.ToByte(Variable.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 0;
			smessage[4] = 0;
			smessage[5] = 52;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		}
	}

	public void ChangeMessage(ref byte[] message)
	{
		message[3] = byte.MaxValue;
	}

	public void ChangeMessageToAllCharge(ref byte[] message)
	{
		message[1] = 32;
		message[2] = 7;
		message[3] = byte.MaxValue;
	}

	public int GetResponse(ref byte[] response)
	{
		int num = 0;
		int num2 = 0;
		bool flag = true;
		try
		{
			while (flag && num2 < 100)
			{
				if (sp.BytesToRead < response.Length)
				{
					Thread.Sleep(30);
					num2++;
				}
				else
				{
					flag = false;
				}
			}
			num = sp.Read(response, 0, response.Length);
			if (num > 0)
			{
				Variable.ResLength = num;
				return num;
			}
			return 0;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool CheckResponse(byte[] response, byte MessageType)
	{
		byte[] CRC = new byte[2];
		GetCRC(response, ref CRC);
		if (CRC[0] == response[^2] && CRC[1] == response[^1])
		{
			return true;
		}
		return false;
	}

	public void GetCRC(byte[] message, ref byte[] CRC)
	{
		int num = message.Length - 2;
		int num2 = 0;
		CRC[0] = byte.MaxValue;
		CRC[1] = byte.MaxValue;
		ushort num3 = 0;
		while (num-- > 0)
		{
			num3 = (ushort)(CRC[0] ^ message[num2++]);
			CRC[0] = (byte)(CRC[1] ^ aucCRCHi[num3]);
			CRC[1] = aucCRCLo[num3];
		}
	}
}
