using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public float speed = 2.0f;
    public int damage = 18;
    public float coolTime = 2.0f;
    public int hp = 20;
    public int maxHp = 20;
    // Start is called before the first frame update

    public Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        damage = 12;
    }

    public int attacked(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 1.0f);
            gameObject.GetComponent<MonsterBehavior>().died = true;
        }
        return hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
