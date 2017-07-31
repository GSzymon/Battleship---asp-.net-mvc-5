using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Battleship_asp.MyLibrary;

namespace Battleship_asp.Models
{
    public class Map
    {
        private Dictionary<Field, FieldState> Fields = new Dictionary<Field, FieldState>();

        public Map()                                            // Map 10x10 means 9xJ - creating all fields empty at start
        {
            for (short i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Field field = new Field(i,MyMethods.IntToChar(j));   // creating fields (10x10)  0-A, 0-B, 0-C ..... 9-J
                    Fields.Add(field, new FieldState());                 // add fields+fields state to collection 
                }
            }
        }

        public void SetShipsOnMap(List<Field> ShipsPositions, int dictionaryCapacity)
        {
            if (ShipsPositions.Count == dictionaryCapacity)                       // additional protection
            {
                foreach (Field field in ShipsPositions)
                {
                    FieldState fieldState = new FieldState();
                    fieldState.SetShipHere();
                    Fields.Add(field, fieldState);
                }
            }
            else { throw new Exception("Error: ShipsPositions.Count != dictionaryCapacity"); }
        }

        public bool Shoot(Field field)       // this method makes updates in chosen field - means where opp shot
        {
            return Fields[field].ShowResultAndUpdateFieldState();
        }
    }
}