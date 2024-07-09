using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Scripts.Core
{
    public class GridSpace : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buttonText;
        

        public void SetSpace(string playerMark)
        {
            buttonText.text = playerMark.ToString();
            button.interactable = false;
        }

        public void ResetSpace()
        {
            buttonText.text = "";
            button.interactable = true;
        }
    }
}
