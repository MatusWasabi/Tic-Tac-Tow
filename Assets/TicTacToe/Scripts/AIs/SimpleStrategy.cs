using System.Collections.Generic;
using TicTacToe.Scripts.Core;
using UnityEngine;
using Grid = TicTacToe.Scripts.Core.Grid;

namespace TicTacToe.Scripts.AIs
{
    public class SimpleStrategy : AIStrategy
    {
        public override void Execute(BoardManager boardManager, char symbol)
        {
            List<Grid> possibleGrids = FindEmptyGrids(boardManager.GetBoardState());
            char opponentSymbol = FindOpponentSymbol(boardManager.GetBoardState(), symbol);
            Grid grid = BlockPlayer(boardManager.GetBoardState(), possibleGrids, opponentSymbol);
            boardManager.MakeMove(grid.X, grid.Y, symbol);
        }

        private Grid BlockPlayer(char[,] originalBoard, List<Grid> possibleGrids, char opponentSymbol)
        {
            foreach (var possibleGrid in possibleGrids)
            {
                char[,] copyBoard = CloneBoard(originalBoard);
                int row = copyBoard.GetLength(0);
                copyBoard[possibleGrid.X, possibleGrid.Y] = opponentSymbol;
            
                // Check Row and Column
                for (int i = 0; i < row; i++) {
                
                    if ((copyBoard[i, 0] == opponentSymbol && copyBoard[i, 1] == opponentSymbol && copyBoard[i, 2] == opponentSymbol) ||
                        (copyBoard[0, i] == opponentSymbol && copyBoard[1, i] == opponentSymbol && copyBoard[2, i] == opponentSymbol))
                    {
                        return possibleGrid;
                    }
                }

                // Check diagonals
                if ((copyBoard[0, 0] == opponentSymbol && copyBoard[1, 1] == opponentSymbol && copyBoard[2, 2] == opponentSymbol) ||
                    (copyBoard[0, 2] == opponentSymbol && copyBoard[1, 1] == opponentSymbol && copyBoard[2, 0] == opponentSymbol)) {
                    return possibleGrid;
                }
            }
            
            // Random in case there is no grid to block
            int randomIndex = Random.Range(0, possibleGrids.Count);
            return possibleGrids[randomIndex];;

        }
        
        // AI must test and try it out with clone board. Not the game board as it will affect the game with AI logic.
        // Similar idea from when I do minimax in my university.
        private char[,] CloneBoard(char[,] sourceBoard)
        {
            int rows = sourceBoard.GetLength(0);
            int cols = sourceBoard.GetLength(1);
            char[,] newBoard = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newBoard[i, j] = sourceBoard[i, j];
                }
            }

            return newBoard;
        }

        private char FindOpponentSymbol(char[,] board, char playerSymbol)
        {
            char opponentSymbol = ' '; 
            foreach (char space in board)
            {
                if (space != playerSymbol && space != '\0')
                {
                    opponentSymbol = space;
                }
            }

            return opponentSymbol;
        }
    }
}
