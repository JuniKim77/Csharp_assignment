﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    private Animator animator;
    private MonsterStat monsterStat;
    private bool attacking = false;

    private float lastAttackTime;
    private CharacterStat targetStat;
    private GameManager gameManager;

    public bool died = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        animator = gameObject.GetComponent<Animator>();
        monsterStat = gameObject.GetComponent<MonsterStat>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (died)
        {
            attacking = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            transform.Translate(Vector2.left * monsterStat.speed * Time.deltaTime);
            if (attacking)
            {
                transform.Translate(Vector2.right * monsterStat.speed * Time.deltaTime);
            }
            if (targetStat != null && targetStat.hp <= 0)
            {
                targetStat = null;
                attacking = false;
                animator.SetTrigger("Walk");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Fence")
        {
            Destroy(gameObject);
            gameManager.decreseLife();
        }
        else if (other.gameObject.tag == "Character")
        {
            attacking = true;
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
            targetStat = other.gameObject.GetComponent<CharacterStat>();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Character")
        {
            if(Time.time - lastAttackTime > monsterStat.coolTime)
            {
                int hp = other.gameObject.GetComponent<CharacterStat>().attacked(monsterStat.damage);
                if (hp <= 0)
                {
                    attacking = false;
                    animator.SetTrigger("Walk");
                }
                lastAttackTime = Time.time;
            }
        }
    }
}
