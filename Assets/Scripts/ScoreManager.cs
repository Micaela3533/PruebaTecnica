using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  

    public TextMeshProUGUI scoreText;  

    private int score = 0;
    private const string ScoreKey = "PlayerScore";

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        LoadScore();
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        SaveScore();
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text =  score.ToString();
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score);  // Guardar la puntuación usando PlayerPrefs
        PlayerPrefs.Save();  // Asegurarse de guardar los cambios
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0);  // Cargar la puntuación (0 es el valor predeterminado si no se encuentra)
    }
}