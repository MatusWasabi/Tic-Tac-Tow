using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TicTacToe.Scripts
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

        public bool IsTurn()
        {
            return true;
        }
        
    }
}
