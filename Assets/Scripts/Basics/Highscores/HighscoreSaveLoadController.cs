using System.Linq;
using UnityEngine;

public static class HighscoreSaveLoadController
{

    private static string _playerPrefsKey = "Highscores";
    private static int _maxHighscoresCount = 5;

    private static Highscores LoadHigscores()
    {
        if (!PlayerPrefs.HasKey(_playerPrefsKey))
        {
            return new Highscores();
        }

        string jsonData = PlayerPrefs.GetString(_playerPrefsKey);
        return JsonUtility.FromJson<Highscores>(jsonData);
    }

    public static void SaveHighscore(int score)
    {
        if (score == 0) return;

        Highscores savedHighscores = LoadHigscores();

        if (!savedHighscores.value.Contains(score))
        {
            savedHighscores.value.Add(score);
            savedHighscores.value.Sort((a, b) => b.CompareTo(a));

            if (savedHighscores.value.Count > _maxHighscoresCount)
            {
                savedHighscores.value.RemoveAt(_maxHighscoresCount);
            }
        }

        string jsonData = JsonUtility.ToJson(savedHighscores);
        PlayerPrefs.SetString(_playerPrefsKey, jsonData);
    }

    public static int LoadFirstHighscore()
    {
        Highscores highscores = LoadHigscores();
        return highscores.value.Count == 0 ? 0 : highscores.value.First();
    }

    public static string CreateHigscoresTable()
    {
        Highscores savedScores = LoadHigscores();
        if (savedScores.value.Count == 0) return "Empty";

        string highscoresTable = "";
        for (int i = 0; i < savedScores.value.Count; i++)
        {
            highscoresTable += $"{i+1} place - {savedScores.value[i]} points\n";
        }

        return highscoresTable;
    }
}
