using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleship_asp.MyLibrary
{
    public static class MyMethods
    {
        public static char IntToChar(int x)
        {
            if (x==0) { return 'A';}
            if (x == 1) { return 'B'; }
            if (x == 2) { return 'C'; }
            if (x == 3) { return 'D'; }
            if (x == 4) { return 'E'; }
            if (x == 5) { return 'F'; }
            if (x == 6) { return 'G'; }
            if (x == 7) { return 'H'; }
            if (x == 8) { return 'I'; }
            if (x == 9) { return 'J'; }
            
            else { return 'X'; }
        }
    }
}