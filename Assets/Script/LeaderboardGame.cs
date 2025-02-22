using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardGame : MonoBehaviour
{
    public static LeaderboardGame Instance;
    public TMP_Text leaderboardText;
    private List<PlayerScore> leaderboardData = new List<PlayerScore>();

    public class PlayerScore
    {
        public string playerName;
        public int score;
        public float accuracy;

        public PlayerScore(string playerName, int score, float accuracy)
        {
            this.playerName = playerName;
            this.score = score;
            this.accuracy = accuracy;
        }
    }

    void Start()
    {
        LoadLeaderboard();
    }

    // Méthode pour ajouter un score dans le leaderboard
    public void AddScore(string playerName, int score, float accuracy)
    {
        PlayerScore newScore = new PlayerScore(playerName, score, accuracy);
        leaderboardData.Add(newScore);

        // Trier les scores par ordre décroissant (du meilleur score au plus bas)
        leaderboardData.Sort((x, y) => y.score.CompareTo(x.score));

        // Garder seulement les 5 meilleurs scores
        if (leaderboardData.Count > 5)
        {
            leaderboardData.RemoveAt(leaderboardData.Count - 1);
        }

        SaveLeaderboard();
        DisplayLeaderboard();
    }

    // Sauvegarder les données du leaderboard
    void SaveLeaderboard()
    {
        for (int i = 0; i < leaderboardData.Count; i++)
        {
            PlayerPrefs.SetInt("Score_" + i, leaderboardData[i].score);
            PlayerPrefs.SetFloat("Accuracy_" + i, leaderboardData[i].accuracy);
            PlayerPrefs.SetString("PlayerName_" + i, leaderboardData[i].playerName);
        }
        PlayerPrefs.Save();
    }

    // Charger les scores sauvegardés
    void LoadLeaderboard()
    {
        leaderboardData.Clear();
        int count = PlayerPrefs.GetInt("LeaderboardCount", 0);

        for (int i = 0; i < count; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName_" + i);
            int score = PlayerPrefs.GetInt("Score_" + i);
            float accuracy = PlayerPrefs.GetFloat("Accuracy_" + i);

            leaderboardData.Add(new PlayerScore(playerName, score, accuracy));
        }

        DisplayLeaderboard();
    }

    // Afficher les scores du leaderboard
    void DisplayLeaderboard()
    {
        leaderboardText.text = "Leaderboard:\n";
        for (int i = 0; i < leaderboardData.Count; i++)
        {
            leaderboardText.text += $"{i + 1}. {leaderboardData[i].playerName} - Score: {leaderboardData[i].score} - Accuracy: {leaderboardData[i].accuracy:0.00}%\n";
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
