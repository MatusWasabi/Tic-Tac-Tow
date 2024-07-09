using TicTacToe.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace TicTacToe.Scripts.Player
{
    public class HumanPlayer : MonoBehaviour, IPlayer {
        [FormerlySerializedAs("_symbol")] [SerializeField] private char symbol;
        private int _col = 0;
        private int _row = 0;
        

        public void MakeMove(BoardManager boardManager)
        {
            if (boardManager.IsStale())
            {
                return;
            }
            boardManager.MakeMove(_col, _row, symbol);
        }

        public char GetSymbol() {
            return symbol;
        }
        

        public void SetCol(int col)
        {
            _col = col;
        }

        public void SetRow(int row)
        {
            _row = row;
        }
    }
}
