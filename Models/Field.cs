using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleship_asp.Models
{
    public class Field
    {
        public short X { get; set; }
        public char Y { get; set; }

        public Field(short _X, char _Y)
        {
            this.X = _X;
            this.Y = _Y;
        }
    }
}