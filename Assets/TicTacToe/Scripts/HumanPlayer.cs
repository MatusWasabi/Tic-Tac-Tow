using UnityEngine;
using UnityEngine.Serialization;

namespace TicTacToe.Scripts
{
    public class HumanPlayer : MonoBehaviour, IPlayer {
        [FormerlySerializedAs("_symbol")] [SerializeField] private char symbol;
        private int _x = 0;
        private int _y = 0;
        

        public void MakeMove(BoardManager boardManager)
        {
            if (boardManager.IsStale())
            {
                return;
            }
            boardManager.MakeMove(_x, _y, symbol);
        }

        public char GetSymbol() {
            return symbol;
        }

        public bool IsTurn()
        {
            return true;
        }

        public void SetX(int x)
        {
            _x = x;
        }

        public void SetY(int y)
        {
            _y = y;
        }
    }
}
