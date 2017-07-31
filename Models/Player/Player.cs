using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleship_asp.Models
{
    public class Player
    {
        private int _id = 0;
        public int Id { get; }
        public String Name { get; private set; }
        public PlayerState MyState { get; private set; }
        public Map MyMap { get; private set; }
        public bool Lost { get; private set; }


        // player and ships setting (public methods) =======================
        public Player(String name, PlayerState myState)
        {
            Name = name;
            MyState = myState;
            Lost = false;
            Id = _id++;
        }
        public void SetMyShips(List<Field> MyShipsPositions)
        {
            if (MyMap == null)                  // protect from use this method more than 1 time
            {
                MyMap = new Map();
                MyMap.SetShipsOnMap(MyShipsPositions, MyState.CurrentShipsAmount);
            }
            else { throw new Exception("You can use method SetMyShips only 1 time"); }
        }


        //battle (public methods) =========================================
                    // ME===
        public void MyShot(Field field)         // where i shoot?
        {
            // send co-ordinates to parser's boolean method -> if true: HitByMe()    else -> MissedByMe()
        }
                    // OPP===
        public bool DidOpponentHit(Field field)                      // did my opponent hit my ship?
        {                                                      
            bool hit = MyMap.Shoot(field);                // this method update changes on map
            if (hit == true) { HitByOpponent(field);    }      // he did
            else             { MissedByOpponent(field); }      // he didn't
            return hit;
        }


        //updating after my/opp shoot (private methods) ====================
                    // ME===
        private void HitByMe()                  // i hit his ship so i've got another try
        {
            MyState.AnotherTurnIsForMe();
        }
        private void MissedByMe()               // i missed so next turn is NOT mine
        {
            MyState.AnotherTurnIsForOpponent();
        }

                    // OPP===
        private void HitByOpponent(Field field)               // my opp hit my ship so next turn is still NOT mine
        {
            MyState.LostAnotherShip();
            MyState.AnotherTurnIsForOpponent();
            if (MyState.CurrentShipsAmount == 0)
            {
                Lost = true;
            }
        }
        private void MissedByOpponent(Field field)               // my opp miss so i've got another try
        {
            MyState.AnotherTurnIsForMe();
        }


        // chat ==========================================================
        public String MyMessage(String message)
        {
            return Name + ": " + message;
        }
    }
}