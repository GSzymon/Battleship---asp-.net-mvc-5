using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleship_asp.Models
{
    public class PlayerState
    {
        public int CurrentShipsAmount { get; private set; }
        public bool MyTurn { get; private set; }

        public PlayerState(int currentShipsAmount, bool myTurn)
        {
            CurrentShipsAmount = currentShipsAmount;
            MyTurn = myTurn;
        }
        public void AnotherTurnIsForMe()
        {
            MyTurn = true;
        }
        public void AnotherTurnIsForOpponent()
        {
            MyTurn = false;
        }

        public void LostAnotherShip()
        {
            CurrentShipsAmount--;
        }
    }
}