using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffSpike : MonoBehaviour
{
    public GameObject health;
    public GameObject minimap;

    void Start()
    {
        if(Score.poziom >= 5)
        {
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    health.SetActive(false);
                    break;
                case 1:
                    minimap.SetActive(false);
                    break;
                case 2:
                    health.SetActive(false);
                    minimap.SetActive(false);
                    break;
            }
        }
    }
}
