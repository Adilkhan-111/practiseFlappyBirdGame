using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UI_logic : MonoBehaviour
{
    [SerializeField] GameObject DefeatUI;
    [SerializeField] TextMeshProUGUI ScoreText;

    private int Score;

    private void Start()
    {
        Score = 0;
        if (ScoreText != null) ScoreText.text = "Score: 0";
    }

    private void OnEnable()
    {
        Event_logic.PlayerDied += TurnOnDefeat;
        Event_logic.PlayerScore += UpdateScore;
    }

    private void OnDisable()
    {
        Event_logic.PlayerDied -= TurnOnDefeat;
        Event_logic.PlayerScore -= UpdateScore;
    }

    public void Restart()
    {
        Score = 0; // сброс счёта при рестарте
        if (ScoreText != null) ScoreText.text = "Score: 0";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TurnOnDefeat()
    {
        if (DefeatUI != null)
        {
            DefeatUI.gameObject.SetActive(true);
            Score = 0; // сброс счёта при поражении
            if (ScoreText != null) ScoreText.text = "Score: 0";
        }
    }

    public void UpdateScore()
    {
        Score += 10;
        if (ScoreText != null) ScoreText.text = "Score: " + Score;
        Debug.Log(Score);
        if (Score % 100 == 0)
        {
            if (SoundLogic.instance != null) SoundLogic.instance.PlaySfx("CoinSfx");
            Debug.Log("OnScore100 Attempt");
        }
    }
}
