using System;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacToe.Scripts.Core
{
    /// <summary>
    /// Core logic of the board.
    /// </summary>
    public class BoardManager : MonoBehaviour
    {
        private static int _boardSize = 3;
        private char[,] _board = new char[_boardSize, _boardSize];
        [SerializeField] private UnityEvent<Move> onMoveMade;
        [SerializeField] private UnityEvent onBoardReset;
        
        public char[,] GetBoardState() => _board;
        
        public void MakeMove(int x, int y, char player)
        {
            if (_board[x, y] == '\0') {
                _board[x, y] = player;
                Move move = new Move(x, y, player);
                onMoveMade.Invoke(move);
            }
        }
        
        public bool IsWinner(char player) {
            
            // Check Row and Column
            for (int i = 0; i < _boardSize; i++) {
                
                if ((_board[i, 0] == player && _board[i, 1] == player && _board[i, 2] == player) ||
                    (_board[0, i] == player && _board[1, i] == player && _board[2, i] == player)) {
                    return true;
                }
            }

            // Check diagonals
            if ((_board[0, 0] == player && _board[1, 1] == player && _board[2, 2] == player) ||
                (_board[0, 2] == player && _board[1, 1] == player && _board[2, 0] == player)) {
                return true;
            }
            return false;
        }

        public bool IsStale()
        {
            for (int i = 0; i < _boardSize; i++) {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (_board[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < _boardSize; i++) {
                for (int j = 0; j < _boardSize; j++)
                {
                    _board[i, j] = '\0';
                }
            }
            onBoardReset.Invoke();
        }
    }

    

    


}
