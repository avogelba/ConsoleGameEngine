using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    //code taken from PInvoke.net and modified for my needs
    //https://www.pinvoke.net/default.aspx/kernel32/GetCurrentConsoleFontEx.html
    //https://www.pinvoke.net/termsofuse.htm#4
    //also see https://docs.microsoft.com/en-us/dotnet/api/system.console?redirectedfrom=MSDN&view=netframework-4.8

    //Why? I could not start the 3D example, I found out that I need a smaller font (I had Font Size 16)
    public class GetFontInfo
    {
        private const int STD_OUTPUT_HANDLE = -11;

        //[StructLayout(LayoutKind.Sequential)]
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal Coord.COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string FaceName;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool GetCurrentConsoleFontEx(
              IntPtr consoleOutput,
              bool maximumWindow,
              ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        CONSOLE_FONT_INFO_EX ConsoleFontInfo = new CONSOLE_FONT_INFO_EX();

	public GetFontInfo()
    {
            ConsoleFontInfo.cbSize = (uint)Marshal.SizeOf(ConsoleFontInfo);
            GetCurrentConsoleFontEx(GetStdHandle(STD_OUTPUT_HANDLE), false, ref ConsoleFontInfo);
	}
        public String GetFontName()
        {




            // Printing the results
            //var myFontSize = String.Format($"Font size is: x: {ConsoleFontInfo.dwFontSize.X} y: {ConsoleFontInfo.dwFontSize.Y}");
//            var myFontName = String.Format($"Font name is: {ConsoleFontInfo.FaceName}");
  //          var myFontFamily = String.Format($"Fontfamily is: {ConsoleFontInfo.FontFamily}");
    //        var myFontWeight = String.Format($"Fontweight is: {ConsoleFontInfo.FontWeight}");
      //      var myFontIndex = String.Format($"Font index is: {ConsoleFontInfo.nFont}");
            return ConsoleFontInfo.FaceName;
        }

        public short GetFontSize()
        {

            // Printing the results
//            var myFontSize = String.Format($"Font size is: x: {ConsoleFontInfo.dwFontSize.X} y: {ConsoleFontInfo.dwFontSize.Y}");
  //          var myFontName = String.Format($"Font name is: {ConsoleFontInfo.FaceName}");
   //         var myFontFamily = String.Format($"Fontfamily is: {ConsoleFontInfo.FontFamily}");
     //       var myFontWeight = String.Format($"Fontweight is: {ConsoleFontInfo.FontWeight}");
       //     var myFontIndex = String.Format($"Font index is: {ConsoleFontInfo.nFont}");
            return ConsoleFontInfo.dwFontSize.Y;
        }

        public Coord.COORD calcFontSize(short fSize)
        {
            Coord.COORD newFSize = new Coord.COORD();
            newFSize.Y = fSize;
            int calced = fSize / 2;
            newFSize.X = (short)calced;

            return newFSize;

        }

    }
}
