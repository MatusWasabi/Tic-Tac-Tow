using System.Collections.Generic;
using System.Linq;
using TicTacToe.Scripts.Core;
using Grid = TicTacToe.Scripts.Core.Grid;

namespace TicTacToe.Scripts.AIs
{
    /// <summary>
    /// Concrete strategy of AI
    /// </summary>
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
            possibleGrids = possibleGrids.OrderBy(grid => grid.X).ToList();
            Grid leftMost = possibleGrids[0];
            return leftMost;
        }
    }
}
