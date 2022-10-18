using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int wynik;
    public static int poziom;
    public TextMeshProUGUI floor;
    public TextMeshProUGUI score;
    public TextMeshProUGUI enemycounter;
    void Update()
    {
        score.SetText(wynik.ToString());
        floor.SetText(poziom.ToString());
        enemycounter.SetText(EnemyTemplates.EnemiesKilled + "/" + EnemyTemplates.EnemiesCount);
        if((EnemyTemplates.EnemiesKilled) >= ((EnemyTemplates.EnemiesCount + 1) / 2))
        {
            enemycounter.color = Color.green;
        }
        else
        {
            enemycounter.color = Color.white;
        }
    }
    
}
