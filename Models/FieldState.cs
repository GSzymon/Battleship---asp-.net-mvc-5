using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleship_asp.Models
{
    public enum EnumFieldState { Empty = 1, OccupiedAlive = 2, OccupiedDead = 3, Missed = 4 };

    public class FieldState
    {
        public EnumFieldState state { get; private set; }


        public FieldState()                             
        {
            state = EnumFieldState.Empty;               // EMPTY <- default  (ctor)
        }

        public void SetShipHere()
        {
            state = EnumFieldState.OccupiedAlive;       // OCCUPIED ALIVE
        }

        public bool ShowResultAndUpdateFieldState()
        {
            if (state == EnumFieldState.Empty)
            {
                state = EnumFieldState.Missed;
                return false;
            }
            else if (state == EnumFieldState.OccupiedAlive)
            {
                state = EnumFieldState.OccupiedDead;
                return false;
            }
            else
            {
                throw new Exception("Error during checking shoot -> class: FieldState, method: UpdateField");
            }
        }
    }
}