using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Scripts
{
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
