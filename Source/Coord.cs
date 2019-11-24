using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public class Coord
    {
	//https://docs.microsoft.com/en-us/dotnet/api/system.console?redirectedfrom=MSDN&view=netframework-4.8

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
