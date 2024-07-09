using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacToe.Scripts
{
    public class LeftFirstStrategy : AIStrategy
    {
        

        public override void Execute(BoardManager boardManager, char symbol)
        {
            char[,] boardState = boardManager.GetBoardState();

            List<Grid> possibleGrids = FindEmptyGrids(boardState);
            Grid grid = LeftFirstAlgorithm(possibleGrids);
            boardManager.MakeMove(grid.X, grid.Y, symbol);
        }

        private Grid LeftFirstAlgorithm(List<Grid> possibleGrids)
        {
            Grid leftMost;
            possibleGrids = possibleGrids.OrderBy(grid => grid.X).ToList();

            leftMost = possibleGrids[0];
            
            return leftMost;
        }
    }
}
