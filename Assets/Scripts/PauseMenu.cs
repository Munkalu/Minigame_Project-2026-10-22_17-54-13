using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool paused;
    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                Resume();
            }
            else{
                Pause();
            }

        }
    }
    public void Pause(){
        paused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Resume(){
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitToMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
