using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private int damage = 10 + ((Score.poziom - 1)*2);

    private Transform player;
    private Vector2 target;

    public GameObject destroyeffect;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroybullet();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Gracz player = other.GetComponent<Gracz>();
        if (player != null)
        {
            player.TakeDmg(damage);
            
        }
        if(other.CompareTag("Enemy") == false)
        {
            Destroybullet();
        }

    }

    void Destroybullet()
    {
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
