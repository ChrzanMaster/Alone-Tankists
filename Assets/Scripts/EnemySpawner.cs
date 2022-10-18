using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyTemplates Etemplates;
    private int rand;

    public float waitTime = 2f;

    private int spawningdiff;
    void Start()
    {
        if(Score.poziom == 0)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, waitTime);
        Etemplates = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTemplates>();
        Invoke("Spawn", 0.1f);

    }

    private void Spawn()
    {

        if (Score.poziom >= 1 && Score.poziom <= 4)
        {
            spawningdiff = 1;
        }
        else if (Score.poziom >= 5 && Score.poziom <= 10)
        {
            spawningdiff = 2;
        }
        else
        {
            spawningdiff = 3;
        }    

        switch(spawningdiff)
        {
            case 1:
                InstantiateEnemy();
                break;
            case 2:
                for(int i = 0; i < 2; i++)
                    InstantiateEnemy();
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                    InstantiateEnemy();
                break;
        }
    }
    private void InstantiateEnemy()
    {
        rand = Random.Range(0, Etemplates.Opponents.Length);
        Instantiate(Etemplates.Opponents[rand], transform.position, Quaternion.identity);
        EnemyTemplates.EnemiesCount++;
    }
}
