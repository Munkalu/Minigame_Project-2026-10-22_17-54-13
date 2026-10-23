using UnityEngine;
using TMPro;
public class HUDController : MonoBehaviour
{
    [SerializeField] TMP_Text hudText;
    [SerializeField] PlayerController player;
    void Update()
    {
        hudText.text = "Hearts: " + GameManager.Instance.Hearts+
        "\nLetters: " + player.Letters +
        "\nStamina: " + Mathf.RoundToInt(player.Stamina) + 
        "\nScore: " + GameManager.Instance.Score + 
        "\nCombo: " + GameManager.Instance.Combo + 
        "\nTime: " + Mathf.CeilToInt(GameManager.Instance.TimeLeft);  
    }
}
