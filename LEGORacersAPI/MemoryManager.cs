using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace LEGORacersAPI
{
    public static class MemoryManager
    {
        [DllImport("kernel32")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
		[DllImport("kernel32")]
		private static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32")]
		private static extern bool ReadProcessMemory(IntPtr hProcess, UInt32 address, byte[] buffer, uint size, out int bytesread);
        [DllImport("kernel32")]
		private static extern bool WriteProcessMemory(IntPtr hProcess, UInt32 address, byte[] buffer, uint size, out int byteswritten);
        [DllImport("kernel32")]
		private static extern UInt32 VirtualAllocEx(IntPtr hProcess, UInt32 dwAddress, uint nSize, uint dwAllocationType, uint dwProtect);
		[DllImport("kernel32")]
		private static extern bool VirtualFreeEx(IntPtr hProcess, UInt32 dwAddress, uint nSize, uint dwFreeType);
        [DllImport("kernel32")]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, UInt32 lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out UInt32 dwThreadId);
        
        public static IntPtr OpenedProcess { get; private set; }
		public static UInt32 NewMemory { get; set; }
		public static bool initialized;

		private const uint PROCESS_ALL_ACCESS = 0x1F0FFF, MEM_COMMIT = 0x1000, MEM_RELEASE = 0x8000, PAGE_EXECUTE_READWRITE = 0x40;

        public static Process Process { get; private set; }

        public static void Initialize(Process process)
        {
            Process = process;
            OpenedProcess = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
            NewMemory = AllocateMemory(1024);
			initialized = true;
        }

		public static void Unload()
		{
			initialized = false;
			VirtualFreeEx(OpenedProcess, NewMemory, 0, MEM_RELEASE);
			NewMemory = 0;
			CloseHandle(OpenedProcess);
			OpenedProcess = IntPtr.Zero;
			Process = null;
		}

		public static void CreateThread(UInt32 address)
        {
			UInt32 threadid;
            CreateRemoteThread(OpenedProcess, IntPtr.Zero, 0, address, IntPtr.Zero, 0, out threadid);
        }

		private static UInt32 AllocateMemory(uint size)
        {
			return VirtualAllocEx(OpenedProcess, 0, size, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
        }

		public static int ReadInt(UInt32 address)
        {
            return BitConverter.ToInt32(ReadBytes(address, 4), 0);
        }

		public static uint ReadUInt(UInt32 address)
		{
			return BitConverter.ToUInt32(ReadBytes(address, 4), 0);
		}

		public static float ReadFloat(UInt32 address)
        {
            return BitConverter.ToSingle(ReadBytes(address, 4), 0);
        }

		public static bool WriteInt(UInt32 address, int value)
        {
            return WriteBytes(address, BitConverter.GetBytes(value));
        }

		public static bool WriteFloat(UInt32 address, float value)
        {
            return WriteBytes(address, BitConverter.GetBytes(value));
        }
		public static short ReadShort(UInt32 address)
        {
            return BitConverter.ToInt16(ReadBytes(address, 4), 0);
        }

        public static byte[] GetStringBytes(string input)
        {
            List<byte> output = new List<byte>();
            foreach (char c in input)
            {
                output.Add(Convert.ToByte(c));
                output.Add(0x00);
            }
            output.Add(0x00);
            return output.ToArray();
        }

		public static UInt32 CalculatePointer(UInt32 address, params int[] offsets)
        {
			address = (UInt32)ReadInt(address);
            
            for (int i = 0; i < offsets.Length - 1; i++)
            {
				address = (UInt32)ReadInt((UInt32)(address + offsets[i]));
            }

			return (UInt32)(address + offsets.LastOrDefault());
        }

		public static byte ReadByte(UInt32 address)
        {
            return ReadBytes(address, 1)[0];
        }

		public static byte[] ReadBytes(UInt32 address, uint count)
        {
            byte[] buffer = new byte[count];
            int bytesread;

            ReadProcessMemory(OpenedProcess, address, buffer, count, out bytesread);

            return buffer;
        }

		public static bool WriteBytes(UInt32 address, byte[] bytesToWrite)
        {
            int bytesWritten;

            return WriteProcessMemory(OpenedProcess, (uint)address, bytesToWrite, (uint)bytesToWrite.Length, out bytesWritten);
        }

		public static bool WriteByte(UInt32 address, byte byteToWrite)
        {
            return WriteBytes(address, new byte[] { byteToWrite });
        }
    }
}
