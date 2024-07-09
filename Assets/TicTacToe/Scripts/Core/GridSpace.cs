using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Scripts
{
    public class GridSpace : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buttonText;
        
        public string GetText() => buttonText.text;

        public void SetSpace(string playerMark)
        {
            buttonText.text = playerMark.ToString();
            button.interactable = false;
        }
    }
}
