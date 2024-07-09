using TicTacToe.Scripts.AIs;
using TicTacToe.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace TicTacToe.Scripts.Player
{
    public class AIPlayer : MonoBehaviour, IPlayer {
        [FormerlySerializedAs("_symbol")] [SerializeField] private char symbol;
        [FormerlySerializedAs("_strategy")] [SerializeField] private AIStrategy strategy;
        
        public void MakeMove(BoardManager boardManager) {
            if (boardManager.IsStale())
            {
                return;
            }
            strategy.Execute(boardManager, symbol);
        }

        public char GetSymbol() {
            return symbol;
        }
        
    }
}
