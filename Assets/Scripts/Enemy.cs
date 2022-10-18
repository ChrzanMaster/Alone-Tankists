using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private Vector3 startingPosition;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float viewRange;
    private bool seen;

    private float timeBtwShots;
    public float Firerate;


    public GameObject bullet;
    private Transform player;
    private SpriteRenderer spriteRenderer;

    public GameObject DeadEffect;
    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        this.spriteRenderer.flipX = player.transform.position.x > this.transform.position.x;
        if (Vector2.Distance(transform.position, player.position) <= viewRange || seen == true)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timeBtwShots = Firerate;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            seen = true;
        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(DeadEffect, transform.position, Quaternion.identity); 
        Destroy(gameObject);
        Score.wynik += 10;
        EnemyTemplates.EnemiesKilled++;
    }

}
