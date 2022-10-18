using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
    public TextMeshProUGUI overfloor;
    public TextMeshProUGUI overscore;

    public Animator transition;
    public float transitionTime = 1f;
    public void Awake()
    {
        overfloor.SetText("Floor: " + Score.poziom.ToString());
        overscore.SetText("Score: " + Score.wynik.ToString());
    }

    public void RestartGame()
    {
        Reset();
        SceneManager.LoadScene("Game");
    }

    public void GameMenu()
    {
        Reset();
        SceneManager.LoadScene("Menu");
    }

    private void Reset()
    {
        Score.poziom = 0;
        Score.wynik = 0;
        EnemyTemplates.EnemiesKilled = 0;
        EnemyTemplates.EnemiesCount = 0;
    }
}
