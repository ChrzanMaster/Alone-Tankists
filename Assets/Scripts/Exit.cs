using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && (EnemyTemplates.EnemiesKilled) >= ((EnemyTemplates.EnemiesCount + 1)/2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Score.wynik += 100;
            Score.poziom += 1;
            EnemyTemplates.EnemiesKilled = 0;
            EnemyTemplates.EnemiesCount = 0;
        }
    }
}
