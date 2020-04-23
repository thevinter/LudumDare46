using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Decrement();
            AudioController.PlaySound("enemyDeath");
            gameObject.SetActive(false);
            //Destroy(this.gameObject.GetComponent<Collider2D>());
            //Destroy(this.gameObject, 0.8f);
        }
        if (canAttack && isAttacking)
        {
            target.GetComponent<IDamageable>().Damage(damage);
            canAttack = false;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {

        yield return new WaitForSeconds(.4f);
        canAttack = true;

    }
}
