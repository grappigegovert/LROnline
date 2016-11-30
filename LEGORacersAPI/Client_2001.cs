﻿using System.Diagnostics;

namespace LEGORacersAPI
{
    /// <summary>
    /// Represents the client of the LEGO Racers 2001 edition.
    /// </summary>
    public class Client_2001 : GameClient
    {
        /// <summary>
        /// Initializes a new instance of the LEGO Racers 2001 edition client.
        /// </summary>
        /// <param name="process">The LEGO Racers game client Process.</param>
        /// <param name="initialize">Determines whether to initialize the GameClient instance automatically.</param>
        public Client_2001(Process process, bool initialize)
        {
            this.process = process;

            CLIENT_FORMATTED_NAME = "2001";

            LOAD_RRB_BASE = 0x00419933;
            POWERUP_FUNCTION_BASE = 0x0041F8A4;
            POWERUP_RED_ADDRESS = 0x0043C270;
            POWERUP_BLUE_ADDRESS = 0x0043C950;
            POWERUP_GREEN_ADDRESS = 0x0043CB00;
            POWERUP_YELLOW_ADDRESS = 0x0043C2D0;
            RUN_IN_BACKGROUND_ADDRESS = 0x0048A562;
            AI_COUNT_ADDRESS = 0x004EFFFC;
            MAINMENU_BUTTONS_BASE = 0x0045324D;
            RACERSELECT_BUTTONS_BASE = 0x00457397;

            MENU_BASEADDRESS = 0x004EF320;
            TARGETMENU_ECX_OFFSET = 0x47d4;
            TARGETMENU_ESI_OFFSET = 0x4944;
            CURRENT_MENU_OFFSET = 0x493c;
            SELECTED_RACE_OFFSETS = new int[] { 0x4944, 0x202c };
            SELECTED_CIRCUIT_OFFSETS = new int[] { 0x4944, 0x1904 };
            CIRCUIT_BASE_OFFSETS = new int[] { 0x4944, 0x354, 0x3ea0 };
            MENUSTRINGS_ECX_OFFSETS = new int[] { 0x4944, 0x354, 0x4868 };
            MENUSTRINGS_FILESTART_OFFSETS = new int[] { 0x4944, 0x354, 0x4864 };

			INRACE_BASEADDRESS = 0x004EF31c;
			DRIVERCOUNT_OFFSET = 0x5a0;
			INRACE_ESI_OFFSET = 0x98;
			INRACE_PAUSED_OFFSET = 0x3164;
			PAUSED_SELECTED_INDEX_OFFSET = 0x3148;
			PAUSED_CURRENT_MENU_OFFSET = 0x3404;
			PAUSE_FUNCTION_ADDRESS = 0x0041C7C0;
			UNPAUSE_FUNCTION_ADDRESS = 0x0041C930;

			DRIVER_BASEADDRESS = 0x004F11C0;
            DRIVER_BASE_OFFSETS = new int[] { 0x8, 0x48, 0x7CC, 0x554 };

            DRIVER_OFFSET_COORDINATE_X = 0x528;
            DRIVER_OFFSET_COORDINATE_Y = 0x52c;
            DRIVER_OFFSET_COORDINATE_Z = 0x530;
            DRIVER_OFFSET_SPEED_X = 0x400;
            DRIVER_OFFSET_SPEED_Y = 0x404;
            DRIVER_OFFSET_SPEED_Z = 0x408;
            DRIVER_OFFSET_ROT_FWD_X = 0x504;
            DRIVER_OFFSET_ROT_FWD_Y = 0x508;
            DRIVER_OFFSET_ROT_FWD_Z = 0x50c;
            DRIVER_OFFSET_ROT_UP_X = 0x51c;
            DRIVER_OFFSET_ROT_UP_Y = 0x520;
            DRIVER_OFFSET_ROT_UP_Z = 0x524;
            DRIVER_OFFSET_BRICK = 0xCC8;
            DRIVER_OFFSET_WHITEBRICKS = 0x870;

			this.Initialize();
        }
    }
}