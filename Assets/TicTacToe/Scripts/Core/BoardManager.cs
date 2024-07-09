using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TicTacToe.Scripts
{
    /// <summary>
    /// Responsible for making move on the board
    /// Is logic behind the board
    /// </summary>
    public class BoardManager : MonoBehaviour
    {
        private char[,] _board = new char[3, 3];
        [SerializeField] private UnityEvent<Move> onMoveMade;
        
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
            
            for (int i = 0; i < 3; i++) {
                
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
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public class Move {
        public int X, Y;
        public char Player;

        public Move(int x, int y, char player) {
            X = x;
            Y = y;
            Player = player;
        }
    }

    public class Grid
    {
        public int X, Y;

        public Grid(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }


}
