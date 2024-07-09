using System;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacToe.Scripts.Core
{
    /// <summary>
    /// As our game use button to interact with the board.
    /// We need a code separately just to display it.
    /// It is somewhat Model View Controller. Not exactly is but the idea is from there.
    /// https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns
    /// </summary>
    public class BoardDisplay : MonoBehaviour
    {
        [SerializeField] private GridStruct[] rows;
        [SerializeField] private UnityEvent onDisplayUpdated;

        public void UpdateDisplay(Move moveCommand)
        {
            GridStruct row = rows[moveCommand.Y];
            GridSpace grid = row.GetGridSpace(moveCommand.X);
            grid.SetSpace(moveCommand.Player.ToString());
            onDisplayUpdated.Invoke();
        }

        public void ResetDisplay()
        {
            foreach (var gridStruct in rows)
            {
                foreach (GridSpace gridSpace in gridStruct.GetColumn())
                {
                    gridSpace.ResetSpace();
                }
            }
        }
    }


    /// <summary>
    /// Collection of 2 dimension of interactable between buttons and board.
    /// Unity does not support 2 dimension collection so we work around using struct for easy setup.
    /// </summary>
    [Serializable] 
    public struct GridStruct
    {
        [SerializeField] private GridSpace[] columns;

        public GridSpace GetGridSpace(int columnIndex)
        {
            return columns[columnIndex];
        }

        public GridSpace[] GetColumn() => columns;
    }

   
}
