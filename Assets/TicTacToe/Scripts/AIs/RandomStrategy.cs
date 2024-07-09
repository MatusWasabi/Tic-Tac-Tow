using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Scripts
{
    public class RandomStrategy : AIStrategy
    {
        public override void Execute(BoardManager boardManager, char symbol)
        {
            char[,] boardState = boardManager.GetBoardState();

            List<Grid> possibleGrids = FindEmptyGrids(boardState);
            int randomIndex = Random.Range(0, possibleGrids.Count);
            Grid grid = possibleGrids[randomIndex];
            boardManager.MakeMove(grid.X, grid.Y, symbol);
        }

        
        
    }
}
