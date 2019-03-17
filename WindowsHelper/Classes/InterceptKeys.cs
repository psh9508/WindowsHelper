using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Win32Interop.WinHandles.Internal;
using static Win32Interop.WinHandles.Internal.NativeMethods;

class InterceptKeys
{
    public static Action<Keys> CompleteHookingKey;

    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;

    public static IntPtr Start()
    {
        _hookID = SetHook(_proc);

        return _hookID;
    }

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            //Console.WriteLine((Keys)vkCode);
            CompleteHookingKey?.Invoke((Keys)vkCode);
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    private static Keys TestFunc()
    {
        return new Keys();
    }
}