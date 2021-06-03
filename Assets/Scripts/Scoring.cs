using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public delegate void OnLifeZero();

    public static event OnLifeZero onLifeZero;

    private static Scoring _instance;

    public int initialLives;

    private int lives;

    public int scoringAmount;

    private int score;

    public TMPro.TMP_Text scoreboard;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy (gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad (gameObject);
        Initialize();
    }

    void OnEnable()
    {
        Alien.onDeath += Score;
        AlienShot.hitShip += OnLoseLife;
    }

    public void Initialize()
    {
        this.score = 0;
        this.lives = initialLives;
        UpdateScoreboard();
    }

    void OnLoseLife()
    {
        this.lives--;
        UpdateScoreboard();
        if (lives <= 0 && onLifeZero != null)
        {
            onLifeZero();
        }
    }

    private void UpdateScoreboard()
    {
        const string TAB = "\t";
        const string SPACE = " ";
        string separator = "";
        for (int i = 0; i < 10; i++)
        {
            separator += SPACE;
        }
        for (int i = 0; i < 3; i++)
        {
            separator += TAB;
        }

        this
            .scoreboard
            .SetText("Score: " + score + separator + "Lives: " + lives);
    }

    private void Score()
    {
        this.score += scoringAmount;
        UpdateScoreboard();
    }
}
