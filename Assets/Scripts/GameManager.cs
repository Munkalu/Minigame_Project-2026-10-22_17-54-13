using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int finalScore;
    public static int lettersDelivered;
    public static int bestCombo;
    public static bool won;
    [SerializeField] int maxHearts = 3;
    [SerializeField] float dayLength = 120f;
    [SerializeField] int pointPerLetter = 100;
    public int Score {get; private set;}
    public int Combo {get; private set;}
    public int Hearts {get; private set;}
    public float TimeLeft {get; private set;}
    bool gameOver;
    
    void Start()
    {
        Instance = this;
        Hearts = maxHearts;
        TimeLeft = dayLength;
        Combo = 1;
        Score = 0;
        won = false;
        lettersDelivered = 0;
        bestCombo = 1;
        finalScore = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            return;
        }
        TimeLeft -= Time.deltaTime;
        if(TimeLeft<= 0){
            EndGame(true);
        }
        
    }
    public void Deliver(){
        Score += pointPerLetter*Combo;
        lettersDelivered++;
        if(Combo > bestCombo){
            bestCombo = Combo;
        }
        Combo++;

    }
    public void Miss(){
        Combo = 1;
    }
    public void LoseHeart(){
        if(gameOver){
            return;
        }
        Hearts--;
        if(Hearts<=0){
            EndGame(false);
        }
    }
    void EndGame(bool didWin){
        SceneManager.LoadScene("Results");
        gameOver = true;
        if(didWin){
            Score += 1000;
        }
        finalScore = Score;
        won = didWin;
    }
}
