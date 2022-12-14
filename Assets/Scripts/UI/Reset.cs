using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Reset : MonoBehaviour
{
    public TMP_Text scoreText;

    private void OnEnable()
    {
        scoreText.text = $"But you got a score of {Mathf.RoundToInt(Score.scoreAct)}!";
    }
    public void ResetButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FMODUnity.RuntimeManager.GetBus("Bus:/").stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
