using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents gameEvents;

    void Awake()
    {
        if (gameEvents == null)
        {
            gameEvents = this;
        }
        else if (gameEvents != this)
        {
            Destroy(gameObject);
        }
    }

    public event Action OnTubePass;
    public void TubePass()
    {
        OnTubePass?.Invoke();
    }

    public event Action OnDifficultyChange;
    public void DifficultyChange()
    {
        OnDifficultyChange?.Invoke();
    }

    public event Action OnGameOver;
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
