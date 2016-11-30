using System;
using System.Collections.Generic;
using System.Threading;

namespace LEGORacersAPI
{
	/// <summary>
	/// Represents an in-game driver.
	/// </summary>
	public class Driver
	{
		GameClient gameClient;
		int driverIndex;
		Brick lastKnownBrick = Brick.None;
		int lastKnownWhiteBricks = 0;

		public Driver(GameClient gameClient, int driverIndex)
		{
			this.gameClient = gameClient;
			this.driverIndex = driverIndex;
		}

		private UInt32 baseAddress
		{
			get
			{
				return MemoryManager.ReadUInt(
					(UInt32)(MemoryManager.CalculatePointer(gameClient.DRIVER_BASEADDRESS, gameClient.DRIVER_BASE_OFFSETS)+ driverIndex * 4));
			}
		}

		/// <summary>
		/// The driver's X-coordinate.
		/// </summary>
		public float X
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_COORDINATE_X));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_COORDINATE_X), value);
			}
		}

		/// <summary>
		/// The driver's Y-coordinate.
		/// </summary>
		public float Y
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_COORDINATE_Y));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_COORDINATE_Y), value);
			}
		}

		/// <summary>
		/// The driver's Z-coordinate.
		/// </summary>
		public float Z
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_COORDINATE_Z));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_COORDINATE_Z), value);
			}
		}

		/// <summary>
		/// The driver's X-speed.
		/// </summary>
		public float SpeedX
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_SPEED_X));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_SPEED_X), value);
			}
		}

		/// <summary>
		/// The driver's Y-speed.
		/// </summary>
		public float SpeedY
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_SPEED_Y));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_SPEED_Y), value);
			}
		}

		/// <summary>
		/// The driver's Z-speed.
		/// </summary>
		public float SpeedZ
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_SPEED_Z));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_SPEED_Z), value);
			}
		}

		/// <summary>
		/// The X-value of the driver's 'up' vector
		/// </summary>
		public float Up_X
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_UP_X));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_UP_X), value);
			}
		}

		/// <summary>
		/// The Y-value of the driver's 'up' vector
		/// </summary>
		public float Up_Y
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_UP_Y));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_UP_Y), value);
			}
		}

		/// <summary>
		/// The Z-value of the driver's 'up' vector
		/// </summary>
		public float Up_Z
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_UP_Z));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_UP_Z), value);
			}
		}

		/// <summary>
		/// The X-value of the driver's 'forward' vector
		/// </summary>
		public float Forward_X
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_FWD_X));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_FWD_X), value);
			}
		}

		/// <summary>
		/// The Y-value of the driver's 'forward' vector
		/// </summary>
		public float Forward_Y
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_FWD_Y));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_FWD_Y), value);
			}
		}

		/// <summary>
		/// The Z-value of the driver's 'forward' vector
		/// </summary>
		public float Forward_Z
		{
			get
			{
				return MemoryManager.ReadFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_FWD_Z));
			}
			set
			{
				MemoryManager.WriteFloat((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_ROT_FWD_Z), value);
			}
		}

		/// <summary>
		/// Gets or sets the drivers Brick type.
		/// </summary>
		public Brick Brick
		{
			get
			{
				return (Brick)MemoryManager.ReadInt((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_BRICK));
			}
			set
			{
				if (value != Brick.White)
					MemoryManager.WriteInt((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_BRICK), (int)value);
			}
		}

		/// <summary>
		/// Gets or sets the drivers White bricks amount.
		/// </summary>
		public int WhiteBricks
		{
			get
			{
				return MemoryManager.ReadInt((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_WHITEBRICKS));
			}
			set
			{
				if (value >= 0 && value <= 3)
					MemoryManager.WriteInt((UInt32)(baseAddress + gameClient.DRIVER_OFFSET_WHITEBRICKS), value);
			}
		}

		public delegate void PowerUpUsedHandler(object sender, PowerUpUsedEventArgs data);
		public event PowerUpUsedHandler PowerUpUsed;

		protected void OnPowerUpUsed(object sender, PowerUpUsedEventArgs data)
		{
			if (PowerUpUsed != null)
			{
				PowerUpUsed(this, data);
			}
		}

		public delegate void PickedUpBrickHandler(object sender, PickedUpBrickEventArgs data);

		/// <summary>
		/// Occurs when the Driver picks up a Brick. Does not fire when the Brick type or amount is the same as the previous.
		/// </summary>
		public event PickedUpBrickHandler PickedUpBrick;

		protected void OnPickedUpBrick(object sender, PickedUpBrickEventArgs data)
		{
			if (PickedUpBrick != null)
			{
				PickedUpBrick(this, data);
			}
		}

		public void CheckPowerUp()
		{
			if (lastKnownBrick != Brick)
			{
				if (Brick == Brick.None)
				{
					OnPowerUpUsed(this, new PowerUpUsedEventArgs(lastKnownBrick, lastKnownWhiteBricks));
				}
				else
				{
					OnPickedUpBrick(this, new PickedUpBrickEventArgs(Brick));
				}
			}

			if (WhiteBricks > lastKnownWhiteBricks)
			{
				OnPickedUpBrick(this, new PickedUpBrickEventArgs(Brick.White));
			}

			lastKnownBrick = Brick;
			lastKnownWhiteBricks = WhiteBricks;
		}

		/// <summary>
		/// Uses a Power-up from the driver. This does not trigger the PowerUpUsed event.
		/// </summary>
		/// <param name="brick">The Brick type to use.</param>
		/// <param name="whiteBricks">Amount of White bricks to use.</param>
		public void UsePowerUp(Brick brick, int whiteBricks)
		{
			if (driverIndex >= 0 && driverIndex <= 5 && brick != Brick.White && brick != Brick.None)
			{
				UInt32 function = 0;

				switch (brick)
				{
					case Brick.Red:
						// Red Power-up
						function = gameClient.POWERUP_RED_ADDRESS;
						break;
					case Brick.Blue:
						// Blue Power-up
						function = gameClient.POWERUP_RED_ADDRESS;
						break;
					case Brick.Green:
						// Green Power-up
						function = gameClient.POWERUP_GREEN_ADDRESS;
						break;
					case Brick.Yellow:
						// Yellow Power-up
						function = gameClient.POWERUP_YELLOW_ADDRESS;
						break;
					default:
						return;
				}

				uint ecx = MemoryManager.ReadUInt(baseAddress + 0x8);
				uint ebx = 0;
				uint edx = 0;

				switch (driverIndex)
				{
					case 0: // Local player
						ebx = ecx - 0x498;
						edx = ecx - 0x444;
						break;
					case 1: // Opponent 1
						edx = 0xD1;
						break;
					case 2: // Opponent 2
						edx = 0xA4;
						break;
					case 3: // Opponent 3
						edx = 0xBA;
						break;
					case 4: // Opponent 4
						edx = 0x49;
						break;
					case 5: // Opponent 5
						edx = 0x8D;
						break;
					default:
						return;
				}

				List<byte> codeToInject = new List<byte>();

				codeToInject.Add(0xBB);
				codeToInject.AddRange(BitConverter.GetBytes(ebx)); // mov ebx,neededEBX
				codeToInject.Add(0xB9);
				codeToInject.AddRange(BitConverter.GetBytes(ecx)); // mov ecx,neededECX
				codeToInject.Add(0xBA);
				codeToInject.AddRange(BitConverter.GetBytes(edx)); // mov edx,neededEDX
				codeToInject.Add(0x6A);
				codeToInject.Add((byte)whiteBricks); // push whitebricks
				codeToInject.Add(0x68);
				codeToInject.AddRange(BitConverter.GetBytes(baseAddress)); // push raceraddress
				codeToInject.Add(0xE8);
				codeToInject.AddRange(BitConverter.GetBytes((int)(-(MemoryManager.NewMemory + codeToInject.Count + 4) + function))); // call function
				codeToInject.Add(0xC3); // ret

				// Write code to the assigned memory and execute it
				MemoryManager.WriteBytes(MemoryManager.NewMemory, codeToInject.ToArray());
				MemoryManager.CreateThread(MemoryManager.NewMemory);
			}
		}
	}
}