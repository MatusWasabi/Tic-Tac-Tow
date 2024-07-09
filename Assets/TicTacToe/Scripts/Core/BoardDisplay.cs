using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TicTacToe.Scripts
{
    public class BoardDisplay : MonoBehaviour
    {
        [SerializeField] private GridStruct[] rows;
        [SerializeField] private UnityEvent onDisplayUpdated;

        public void UpdateDisplay(Move moveCommand)
        {
            rows[moveCommand.Y].GetGridSpace(moveCommand.X).SetSpace(moveCommand.Player.ToString());
            onDisplayUpdated.Invoke();
        }
    }


    [Serializable] 
    public struct GridStruct
    {
        [SerializeField] private GridSpace[] columns;

        public GridSpace GetGridSpace(int index)
        {
            return columns[index];
        }
    }

   
}
