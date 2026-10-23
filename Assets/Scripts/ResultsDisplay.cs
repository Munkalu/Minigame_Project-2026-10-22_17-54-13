using UnityEngine;
using TMPro;
public class ResultsDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text statsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameManager.won){
            titleText.text = "Shift Complete!";
        }
        else{
            titleText.text = "Out of Hearts!";
        }
        statsText.text = "Score: " + GameManager.finalScore + "\nLetters Delivered: " + GameManager.lettersDelivered + "\nBest Combo: x" + GameManager.bestCombo;
        
    }
}
