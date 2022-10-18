using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gracz : MonoBehaviour
{
    private Vector2 moveDelta;
    public Animator animator;
    public HPbar HpBar;


    private int maxHp = 100;
    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
        HpBar.SetMaxHp(maxHp);
    }
    private void FixedUpdate()
    {
        //Sterowanie
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector2(x, y);

        animator.SetFloat("Horizontal", x);

        animator.SetFloat("Speed", moveDelta.sqrMagnitude);
        


        //Ruch
        transform.Translate(moveDelta * Time.deltaTime);

    }
    void Update()
    {
        //Obrazenia
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDmg(10);
        }
    }

    public void TakeDmg(int dmg)
    {
        currentHp -= dmg;
        HpBar.SetHp(currentHp);
        if(currentHp <= 0)
        {
            SceneManager.LoadScene("Over");
        }
    }

}
