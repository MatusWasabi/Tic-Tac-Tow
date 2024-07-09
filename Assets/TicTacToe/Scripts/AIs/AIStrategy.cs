using System.Collections.Generic;
using TicTacToe.Scripts.Core;
using UnityEngine;
using Grid = TicTacToe.Scripts.Core.Grid;

namespace TicTacToe.Scripts.AIs
{
    /// <summary>
    /// Bass class for AI brain AKA Strategy Patterns.
    /// For convenient of developing the AI brain separately from the AI Player
    /// https://refactoring.guru/design-patterns/strategy
    /// You may extend this to use minimax alpha-beta pruning algorithm if you want.
    /// </summary>
    public abstract class AIStrategy : MonoBehaviour
    {
        public abstract void Execute(BoardManager boardManager, char symbol);
        
        protected List<Grid> FindEmptyGrids(char[,] boardState)
        {
            List<Grid> possibleGrids = new List<Grid>();
            int rows = boardState.GetLength(0);
            int cols = boardState.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (boardState[i, j] == '\0')
                    {
                        possibleGrids.Add(new Grid(i, j));
                    }
                }
            }
            return possibleGrids;
        }
    }
}
