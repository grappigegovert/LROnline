using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace LEGORacersAPI
{
	/// <summary>
	/// Represents a skeleton for a LEGO Racers game client.
	/// </summary>
	public abstract class GameClient
	{
		/// <summary>
		/// Specifies the formatted client name.
		/// </summary>
		protected string CLIENT_FORMATTED_NAME = "Unknown";
		
		/// <summary>
		/// The base address to load RRB files.
		/// </summary>
		protected UInt32 LOAD_RRB_BASE;

		/// <summary>
		/// The Power-up function base address.
		/// </summary>
		protected UInt32 POWERUP_FUNCTION_BASE;

		internal UInt32 POWERUP_RED_ADDRESS,
			POWERUP_BLUE_ADDRESS,
			POWERUP_GREEN_ADDRESS,
			POWERUP_YELLOW_ADDRESS;

		/// <summary>
		/// The base address to continue running in the background.
		/// </summary>
		protected UInt32 RUN_IN_BACKGROUND_ADDRESS;

		/// <summary>
		/// The base address of the number of AI racers.
		/// </summary>
		protected UInt32 AI_COUNT_ADDRESS;

		protected UInt32 MAINMENU_BUTTONS_BASE;
		protected UInt32 RACERSELECT_BUTTONS_BASE;
			
		protected UInt32 MENU_BASEADDRESS;
		protected int TARGETMENU_ECX_OFFSET;
		protected int TARGETMENU_ESI_OFFSET;
		protected int CURRENT_MENU_OFFSET;
		protected int[] SELECTED_RACE_OFFSETS;
		protected int[] SELECTED_CIRCUIT_OFFSETS;
		protected int[] CIRCUIT_BASE_OFFSETS;
		protected int[] MENUSTRINGS_ECX_OFFSETS;
		protected int[] MENUSTRINGS_FILESTART_OFFSETS;

		protected UInt32 INRACE_BASEADDRESS;
		protected int DRIVERCOUNT_OFFSET;
		protected int INRACE_ESI_OFFSET;
		protected int INRACE_PAUSED_OFFSET;
		protected int PAUSED_SELECTED_INDEX_OFFSET;
		protected int PAUSED_CURRENT_MENU_OFFSET;
		protected UInt32 PAUSE_FUNCTION_ADDRESS;
		protected UInt32 UNPAUSE_FUNCTION_ADDRESS;

		internal UInt32 DRIVER_BASEADDRESS;
		internal int[] DRIVER_BASE_OFFSETS;

		internal int DRIVER_OFFSET_COORDINATE_X,
			DRIVER_OFFSET_COORDINATE_Y,
			DRIVER_OFFSET_COORDINATE_Z,
			DRIVER_OFFSET_SPEED_X,
			DRIVER_OFFSET_SPEED_Y,
			DRIVER_OFFSET_SPEED_Z,
			DRIVER_OFFSET_ROT_FWD_X,
			DRIVER_OFFSET_ROT_FWD_Y,
			DRIVER_OFFSET_ROT_FWD_Z,
			DRIVER_OFFSET_ROT_UP_X,
			DRIVER_OFFSET_ROT_UP_Y,
			DRIVER_OFFSET_ROT_UP_Z,
			DRIVER_OFFSET_BRICK,
			DRIVER_OFFSET_WHITEBRICKS;

		private bool initialized;
		private bool active;
		private bool loadRRB;
		private bool enableAIPowerUps;
		private Thread initializeThread;
		protected Process process;

		/// <summary>
		/// The list of drivers in the game.
		/// </summary>
		public Driver[] drivers { get; private set; }

		/// <summary>
		/// Gets the game clients formatted name.
		/// </summary>
		public string FormattedName
		{
			get
			{
				return CLIENT_FORMATTED_NAME;
			}
		}

		/// <summary>
		/// Gets or sets the value whether to load RRB (AI path) files.
		/// </summary>
		public bool LoadRRB
		{
			get
			{
				return loadRRB;
			}
			set
			{
				if (initialized)
				{
					loadRRB = value;

					SetLoadRRB(value);
				}
			}
		}

		/// <summary>
		/// Gets or sets the value whether AI drivers use the Power-ups they carry.
		/// </summary>
		public bool AIUsePowerUps
		{
			get
			{
				return enableAIPowerUps;
			}
			set
			{
				if (initialized)
				{
					enableAIPowerUps = value;

					SetAIUsePowerUps(value);
				}
			}
		}

		/// <summary>
		/// Gets or sets the value whether the game will continue to run in the background while minimized.
		/// </summary>
		public bool RunInBackground
		{
			get
			{
				return initialized ? MemoryManager.ReadByte(RUN_IN_BACKGROUND_ADDRESS) == 0xEB : false;
			}
			set
			{
				if (initialized)
				{
					if (value)
					{
						MemoryManager.WriteByte(RUN_IN_BACKGROUND_ADDRESS, 0xEB);
					}
					else
					{
						MemoryManager.WriteByte(RUN_IN_BACKGROUND_ADDRESS, 0x75);
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the amount of AI drivers in the current race.
		/// </summary>
		public int AIDriversAmount
		{
			get
			{
				return initialized ? MemoryManager.ReadInt(AI_COUNT_ADDRESS) : 0;
			}
			set
			{
				if (initialized && value >= 0 && value <= 5)
				{
					MemoryManager.WriteInt(AI_COUNT_ADDRESS, value);
				}
			}
		}

		/// <summary>
		/// Gets the value whether a race is currently running.
		/// </summary>
		public bool IsRaceRunning
		{
			get
			{
				return initialized ? MemoryManager.ReadInt(MemoryManager.CalculatePointer(INRACE_BASEADDRESS, DRIVERCOUNT_OFFSET)) == MemoryManager.ReadInt(AI_COUNT_ADDRESS) : false;
			}
		}

		/// <summary>
		/// Gets or sets the value whether a race is currently paused.
		/// </summary>
		public bool Paused
		{
			get
			{
				return initialized ? MemoryManager.ReadInt(MemoryManager.CalculatePointer(INRACE_BASEADDRESS, INRACE_PAUSED_OFFSET)) == 1 : false;
			}
			set
			{
				if (value && !this.Paused)
					this.PauseGame();
				if (!value && this.Paused)
					this.UnpauseGame();
			}
		}

		/// <summary>
		/// Gets the value of the API initialization.
		/// </summary>
		public InitializedType InitializedType { get; private set; }

		public delegate void InitializedHandler(InitializedType type);
		public event InitializedHandler Initialized;

		protected void OnInitialized(InitializedType type)
		{
			if (InitializedType == InitializedType.Core)
			{
				InitializedType = InitializedType.Both;
			}

			if (Initialized != null)
			{
				Initialized(type);
			}
		}

		public GameClient()
		{
			initialized = false;
			InitializedType = InitializedType.None;
		}

		/// <summary>
		/// Safely unloads the API.
		/// </summary>
		public void Unload()
		{
			this.active = false;
			Thread.Sleep((int)Settings.RefreshRate);
			MemoryManager.Unload();
		}

		/// <summary>
		/// Initializes the in-game objects so they can be managed using the API.
		/// </summary>
		protected void Initialize()
		{
			MemoryManager.Initialize(process);
			this.drivers = new Driver[6];
			for (int i = 0; i < 6; i++)
			{
				this.drivers[i] = new Driver(this, i);
			}
			active = true;
			new Thread(eventLoop).Start();
			initialized = true;
			InitializedType = LEGORacersAPI.InitializedType.Both;
		}

		private void eventLoop()
		{
			while (active)
			{
				for (int i = 0; i < drivers.Length; i++)
				{
					drivers[i].CheckPowerUp();
				}

				Thread.Sleep((int)Settings.RefreshRate);
			}
		}

		/// <summary>
		/// Retrieves the current menu.
		/// </summary>
		/// <returns>Returns a Menu containing the current menu.</returns>
		public Menu GetCurrentMenu()
		{
			Menu currentMenu = Menu.MainMenu;

			currentMenu = (Menu)MemoryManager.ReadByte(MemoryManager.CalculatePointer(MENU_BASEADDRESS, CURRENT_MENU_OFFSET));

			return currentMenu;
		}

		/// <summary>
		/// Navigates to a given menu.
		/// </summary>
		/// <param name="targetmenu">The menu to navigate to.</param>
		public void GotoMenu(Menu targetmenu)
		{
			if (initialized)
			{
				Menu currentMenu = GetCurrentMenu();
				Console.WriteLine(currentMenu + " -> " + targetmenu);

				int offset = 0;
				int ECXbase = MemoryManager.ReadInt(MemoryManager.CalculatePointer(MENU_BASEADDRESS, TARGETMENU_ECX_OFFSET));
				int ESIbase = MemoryManager.ReadInt(MemoryManager.CalculatePointer(MENU_BASEADDRESS, TARGETMENU_ESI_OFFSET));

				if (ECXbase != ESIbase) // if a prompt is open
				{
					switch (currentMenu)
					{
						case Menu.Options:
							if (targetmenu == Menu.DisplayOptions)
								offset = 0x549C;
							break;
						case Menu.Build: // delete racer
							if (targetmenu == Menu.PromptYes)
								offset = 0x5B38;
							else if (targetmenu == Menu.PromptNo)
								offset = 0x5E28;
							break;
						case Menu.CreateDriver: // cancel
							if (targetmenu == Menu.PromptYes)
								offset = 0x3FD0;
							else if (targetmenu == Menu.PromptNo)
								offset = 0x42C0;
							break;
						default:
							return;
					}
				}
				else
				{
					switch (currentMenu)
					{
						case Menu.MainMenu:
							if (targetmenu == Menu.Build)
								offset = 0x1058;
							else if (targetmenu == Menu.SingleRace)
								offset = 0x498;
							else if (targetmenu == Menu.Options)
								offset = 0x1348;
							else if (targetmenu == Menu.TimeAttack)
								offset = 0xD68;
							else if (targetmenu == Menu.Circuit)
								offset = 0x788;
							else
								return;
							break;
						case Menu.Build:
							if (targetmenu == Menu.MainMenu)
								offset = 0x5848;
							else if (targetmenu == Menu.CreateDriver)
								offset = 0x40C8;
							else if (targetmenu == Menu.DeleteRacer) // opens a prompt
								offset = 0x4999;
							else if (targetmenu == Menu.EditRacer) // Not finished
								offset = 0x43B8;
							else if (targetmenu == Menu.CopyRacer)
								offset = 0x46A8;
							else
								return;
							break;
						case Menu.Options:
							if (targetmenu == Menu.MainMenu)
								offset = 0x18D8;
							else if (targetmenu == Menu.ControlsP1)
								offset = 0xA28;
							else if (targetmenu == Menu.ControlsP2)
								offset = 0xD18;
							else if (targetmenu == Menu.GameOptions)
								offset = 0x448;
							else if (targetmenu == Menu.PromptDisplayOptions) // opens a prompt
								offset = 0x51AC;
							else if (targetmenu == Menu.Options) // currentmenu==DisplayOptions or GameOptions
								offset = 0x18D8;
							else
								return;
							break;
						case Menu.Controls:
							if (targetmenu == Menu.Options)
								offset = 0x47C;
							else
								return;
							break;
						case Menu.SingleRace:
							if (targetmenu == Menu.MainMenu)
								offset = 0x1CCC;
							else if (targetmenu == Menu.ChooseRacer)
								offset = 0x19DC;
							else
								return;
							break;
						case Menu.TimeAttack:
							if (targetmenu == Menu.MainMenu)
								offset = 0x1CC;
							else
								return;
							break;
						case Menu.Circuit:
							if (targetmenu == Menu.MainMenu)
								offset = 0x1c34;
							else if (targetmenu == Menu.ChooseRacer)
								offset = 0x1F24;
							else
								return;
							break;
						case Menu.CreateDriver:
							if (targetmenu == Menu.CancelDriver) // opens a prompt
								offset = 0x39F0;
							else if (targetmenu == Menu.CreateLicense)
								offset = 0x3CE0;
							else
								return;
							break;
						case Menu.CreateLicense:
							if (targetmenu == Menu.CreateDriver)
								offset = 0xA88;
							else if (targetmenu == Menu.BuildCar)
								offset = 0xD78;
							else
								return;
							break;
						case Menu.BuildCar:
							if (targetmenu == Menu.Build)
								offset = 0x11E4;
							else if (targetmenu == Menu.CreateLicense)
								offset = 0x14D4;
							else
								return;
							break;
						case Menu.ChooseRacer:
							if (targetmenu == Menu.Circuit || targetmenu == Menu.SingleRace || targetmenu == Menu.TimeAttack)
								offset = 0x4998;
							else if (targetmenu == Menu.StartRace)
								offset = 0x40C8;
							else
								return;
							break;
						default:
							return;
					}
				}

				List<byte> codeToInject = new List<byte>();

				codeToInject.Add(0xB9);
				codeToInject.AddRange(BitConverter.GetBytes(ECXbase)); // mov ecx,neededECX
				codeToInject.Add(0xBE);
				codeToInject.AddRange(BitConverter.GetBytes(ESIbase + offset)); // mov esi,neededESI
				codeToInject.AddRange(new byte[] { 0x8B, 0x11, 0x56, 0xFF, 0x52, 0x38, 0xC3 }); // mov edx,[ecx] | push esi | call dword ptr [edx+38] | ret
				
				// Write code to the assigned memory and execute it
				MemoryManager.WriteBytes(MemoryManager.NewMemory, codeToInject.ToArray());
				MemoryManager.CreateThread(MemoryManager.NewMemory);
			}
		}

		/// <summary>
		/// Selects a race.
		/// </summary>
		/// <param name="circuit">The race circuit number to select.</param>
		/// <param name="race">The race number to select.</param>
		public void SelectRace(int circuit, int race)
		{
			if (initialized)
			{
				MemoryManager.WriteInt(MemoryManager.CalculatePointer(MENU_BASEADDRESS, SELECTED_CIRCUIT_OFFSETS), MemoryManager.ReadInt(MemoryManager.CalculatePointer(MENU_BASEADDRESS, CIRCUIT_BASE_OFFSETS)) + 100 * circuit);
				MemoryManager.WriteInt(MemoryManager.CalculatePointer(MENU_BASEADDRESS, SELECTED_RACE_OFFSETS), race);
			}
		}

		/// <summary>
		/// Sets up a new race.
		/// </summary>
		/// <param name="circuit">The race circuit number to setup.</param>
		/// <param name="race">The race number to setup.</param>
		public void SetupRace(int circuit, int race)
		{
			if (initialized)
			{
				if (GetCurrentMenu() != Menu.SingleRace)
				{
					if (GetCurrentMenu() != Menu.MainMenu)
					{
						if (GetCurrentMenu() != Menu.Build && GetCurrentMenu() != Menu.Circuit && GetCurrentMenu() != Menu.TimeAttack && GetCurrentMenu() != Menu.Options)
						{
							return;
						}

						GotoMenu(Menu.MainMenu);

						Thread.Sleep(30);
					}

					GotoMenu(Menu.SingleRace);

					Thread.Sleep(30);
				}

				SelectRace(circuit, race);

				Thread.Sleep(30);

				GotoMenu(Menu.ChooseRacer);
			}
		}

		/// <summary>
		/// Sets up a new race.
		/// </summary>
		/// <param name="circuit">The circuit to setup.</param>
		public void SetupRace(Circuit circuit)
		{
			SetupRace(circuit, false);
		}

		/// <summary>
		/// Sets up a new race.
		/// </summary>
		/// <param name="circuit">The circuit to setup.</param>
		/// <param name="mirror">Determines whether to setup the mirrored version of the circuit.</param>
		public void SetupRace(Circuit circuit, bool mirror)
		{
			if (mirror)
			{
				SetupRace(circuit.MirrorBlockNumber, circuit.MirrorNumber);
			}
			else
			{
				SetupRace(circuit.BlockNumber, circuit.Number);
			}
		}

		/// <summary>
		/// Sets the value whether to load RRB (AI path) files.
		/// </summary>
		/// <param name="value">The value whether to load RRB (AI path) files or not.</param>
		/// <returns>Returns whether the set was successful or not.</returns>
		private bool SetLoadRRB(bool value)
		{
			bool result = true;

			if (initialized)
			{
				if (value == true)
				{
					result &= MemoryManager.WriteBytes(LOAD_RRB_BASE, new byte[] { 0x75, 0x0C }); // JNE +332AD
					result &= MemoryManager.WriteBytes(LOAD_RRB_BASE + 4, new byte[] { 0x75, 0x08 }); // JNE +332AD
					result &= MemoryManager.WriteByte(LOAD_RRB_BASE + 0xC, 0x74); // JE
				}
				else
				{
					result &= MemoryManager.WriteBytes(LOAD_RRB_BASE, new byte[] { 0x90, 0x90 }); // NOP NOP
					result &= MemoryManager.WriteBytes(LOAD_RRB_BASE + 4, new byte[] { 0x90, 0x90 }); // NOP NOP
					result &= MemoryManager.WriteByte(LOAD_RRB_BASE + 0xC, 0xEB); // JMP
				}
			}

			return result;
		}

		/// <summary>
		/// Sets the value whether AI drivers use Power-ups.
		/// </summary>
		/// <param name="value">The value whether the AI drivers use Power-ups or not.</param>
		/// <returns>Returns whether the set was successful or not.</returns>
		private bool SetAIUsePowerUps(bool value)
		{
			bool result = true;

			if (value)
			{
				result &= MemoryManager.WriteBytes(POWERUP_FUNCTION_BASE, new byte[] { 0x8b, 0x86 });
				result &= MemoryManager.WriteBytes(POWERUP_FUNCTION_BASE + 2, BitConverter.GetBytes(DRIVER_OFFSET_BRICK)); // mov eax,[esi+00000CCC]
			}
			else
			{
				UInt32 targetMem = MemoryManager.NewMemory + 0x300;

				List<byte> bytestowrite = new List<byte>();
				bytestowrite.Add(0xE9);
				bytestowrite.AddRange(BitConverter.GetBytes((int)(targetMem - (POWERUP_FUNCTION_BASE + 5)))); // jmp targetmem
				bytestowrite.Add(0x90); // nop
				result &= MemoryManager.WriteBytes(POWERUP_FUNCTION_BASE, bytestowrite.ToArray());

				bytestowrite.Clear();
				bytestowrite.AddRange(new byte[] { 0x8b, 0x0d });
				bytestowrite.AddRange(BitConverter.GetBytes(DRIVER_BASEADDRESS)); // mov ecx,[004C67BC]

				for (int i = 0; i < DRIVER_BASE_OFFSETS.Length; i++)
				{
					bytestowrite.AddRange(new byte[] { 0x8b, 0x89 });
					bytestowrite.AddRange(BitConverter.GetBytes(DRIVER_BASE_OFFSETS[i]));
				}

				bytestowrite.AddRange(new byte[] { 0x39, 0xf1 });                           // cmp ecx,esi
				bytestowrite.AddRange(new byte[] { 0x0f, 0x84, 0x05, 0x00, 0x00, 0x00 });   // je +5
				bytestowrite.AddRange(new byte[] { 0x8b, 0xce });                           // mov ecx,esi
				bytestowrite.Add(0x5f);                                                     // pop edi
				bytestowrite.Add(0x5e);                                                     // pop esi
				bytestowrite.Add(0xc3);                                                     // ret
				bytestowrite.AddRange(new byte[] { 0x8b, 0x86 });
				bytestowrite.AddRange(BitConverter.GetBytes(DRIVER_OFFSET_BRICK));   // mov eax,[esi+poweruptype_offset]
				bytestowrite.Add(0xe9);
				bytestowrite.AddRange(BitConverter.GetBytes((POWERUP_FUNCTION_BASE + 6) - (int)(targetMem + bytestowrite.Count + 4)));// jmp 0043910A
				result &= MemoryManager.WriteBytes(targetMem, bytestowrite.ToArray());
			}

			return result;
		}

		public bool RemoveMenuButtons()
		{
			bool result = true;
			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0xB, 0x00); // build
			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0xB + 1 * 0x14, 0x00); // circuit
			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0xB + 2 * 0x14, 0x00); // singlerace
			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0xB + 3 * 0x14, 0x55); // versus (moving to location 55 (circuit))
			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0xB + 4 * 0x14, 0x00); // timeattack
			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0xB + 5 * 0x14, 0x00); // options
			//result &= writeByte(MAINMENU_BUTTONS_BASE + 0xB + 6*0x14, 0x00); // exit

			result &= MemoryManager.WriteByte(RACERSELECT_BUTTONS_BASE + 0x49, 0x00); // cancel racer selection

			result &= MemoryManager.WriteBytes(MAINMENU_BUTTONS_BASE + 0x98, new byte[] { 0x90, 0x90, 0x90, 0x90 });// always disable versus

			result &= MemoryManager.WriteByte(MAINMENU_BUTTONS_BASE + 0x3D, 46); // set versus button text to line 47 of menustrings.srf
			result &= MemoryManager.WriteBytes(GetMenuStringsAddress(46), MemoryManager.GetStringBytes("WAITING FOR SERVER TO START A RACE..."));

			return result;
		}

		private UInt32 GetMenuStringsAddress(int line)
		{
			// code from 0x0044E500
			uint ecx = MemoryManager.ReadUInt(MemoryManager.ReadUInt(MemoryManager.ReadUInt(MemoryManager.ReadUInt(0x004c4918) + 0x4dc8) + 0x354) + 0x4d00);
			short offset = MemoryManager.ReadShort((UInt32)(ecx + line * 2));
			int filestart = MemoryManager.ReadInt(MemoryManager.ReadUInt(MemoryManager.ReadUInt(MemoryManager.ReadUInt(0x004c4918) + 0x4dc8) + 0x354) + 0x4cfc);
			return (UInt32)(filestart + offset * 2);
		}

		private void PauseGame()
		{
			MemoryManager.WriteInt(MemoryManager.CalculatePointer(INRACE_BASEADDRESS, INRACE_PAUSED_OFFSET), 1); // 1) pause game
			int esi = MemoryManager.ReadInt(INRACE_BASEADDRESS) + INRACE_ESI_OFFSET;
			List<byte> codetoinject = new List<byte>();
			if (this.GetType() == typeof(Client_2001))
				codetoinject.AddRange(new byte[] { 0x6A, 0x00 }); // push 00
			codetoinject.Add(0xBE);
			codetoinject.AddRange(BitConverter.GetBytes(esi)); // mov esi,'esi'
			codetoinject.AddRange(new byte[] { 0x8B, 0xCE }); // mov ecx,esi
			codetoinject.Add(0xE8);
			codetoinject.AddRange(BitConverter.GetBytes(PAUSE_FUNCTION_ADDRESS - (int)(MemoryManager.NewMemory + codetoinject.Count + 4))); // call function
			codetoinject.Add(0xC3); // ret
			MemoryManager.WriteBytes(MemoryManager.NewMemory, codetoinject.ToArray());
			MemoryManager.CreateThread(MemoryManager.NewMemory); // 2) stop music, open menu, etc.
		}

		private void UnpauseGame()
		{
			MemoryManager.WriteInt(MemoryManager.CalculatePointer(INRACE_BASEADDRESS, PAUSED_SELECTED_INDEX_OFFSET), 0); // select index 0
			MemoryManager.WriteInt(MemoryManager.CalculatePointer(INRACE_BASEADDRESS, PAUSED_CURRENT_MENU_OFFSET), 0); // set current menu to 0
			int esi = MemoryManager.ReadInt(INRACE_BASEADDRESS) + INRACE_ESI_OFFSET;
			List<byte> codetoinject = new List<byte>();
			codetoinject.Add(0xBE);
			codetoinject.AddRange(BitConverter.GetBytes(esi)); // mov esi,'esi'
			codetoinject.AddRange(new byte[] { 0x8B, 0xCE }); // mov ecx,esi
			codetoinject.Add(0xE8);
			codetoinject.AddRange(BitConverter.GetBytes(UNPAUSE_FUNCTION_ADDRESS - (int)(MemoryManager.NewMemory + codetoinject.Count + 4))); // call function
			codetoinject.Add(0xC3); // ret
			MemoryManager.WriteBytes(MemoryManager.NewMemory, codetoinject.ToArray());
			MemoryManager.CreateThread(MemoryManager.NewMemory); // select menu item 0,0 (continue race)
		}
	}
}
