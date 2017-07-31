using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleship_asp.Models
{
    public enum EnumGameState { WaitingFor2Players, WaitingForSecondPlayer, PlayersInGame, ShipsSetting, Battle, Over, RemoveGame }
    //WaitingFor2Players - unusual case when game player-creator left room but there was spectator and that's why room still exists without players
    //WaitingForSecondPlayer - one player is in room, waiting for opponent
    //PlayersInGame - two players in room but match not started yet
    //ShipsSetting - match started, players set their ships
    //Battle - just battle
    //Over - room still exists and shows match result until players or spectators are here
    //RemoveGame - end of game, all players ands spectators left

    public class Game
    {
        private static int _id = 0;
        public EnumGameState GameState { get; private set; }
        public int Id { get; private set; }
        public String Name { get; private set; }
        public Player PlayerA { get; private set; }
        public Player PlayerB { get; private set; }
        public List<String> Spectators { get; private set; }
        public Player Winner { get; private set; }

        public Game(String name, Player player)             // create new game and add player who did it
        {
            Id = _id++;
            Name = name + $"  #{Id}";
            AddPlayer(player);
            GameState = EnumGameState.WaitingForSecondPlayer;
        }

        public int AddPlayer(Player player)
        {
            switch (GameState)
            {
                case EnumGameState.WaitingFor2Players:
                {
                    PlayerA = player;
                    GameState=EnumGameState.WaitingForSecondPlayer;
                    break;
                }
                case EnumGameState.WaitingForSecondPlayer:
                {
                    PlayerB = player;
                    GameState = EnumGameState.PlayersInGame;
                    break;
                }
                default:
                {
                    return -1;
                }
            }        
            return (int) GameState;
        }

        public int RemovePlayer(Player player)
        {
            if (PlayerA.Id == player.Id) { PlayerA = null; }
            else if (PlayerB.Id == player.Id) { PlayerB = null; }
            else { throw new Exception("problem with removing players"); }
            if (PlayerA == null && PlayerB == null && Spectators.Count==0) { GameState = EnumGameState.RemoveGame; }

            switch (GameState)
            {
                case EnumGameState.ShipsSetting:
                case EnumGameState.Battle:
                {
                    Winner = PlayerA ?? PlayerB;
                    GameState = EnumGameState.Over;
                    break;
                }
                case EnumGameState.PlayersInGame:
                {
                    GameState = EnumGameState.WaitingForSecondPlayer;
                    break;
                }
                case EnumGameState.WaitingForSecondPlayer:
                {
                    GameState = EnumGameState.RemoveGame;
                    break;
                }
            }
            return (int)GameState;
        }

        public int AddSpectator(String name)
        {
            Spectators.Add(name);
            return (int)GameState;
        }

        public int RemoveSpectator(String name)
        {
            Spectators.Remove(name);
            if (PlayerA == null && PlayerB == null && Spectators.Count == 0)
            {
                GameState = EnumGameState.RemoveGame;
            }
            return (int)GameState;
        }

        public int GameOver(Player winner)
        {
            GameState=EnumGameState.Over;
            Winner = winner;
            return (int) GameState;
        }
    }
}