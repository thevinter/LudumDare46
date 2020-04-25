using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Slime : EnemyController{
    void Update(){
        if (health < 0){
            AudioController.PlaySound("enemyDeath");
            gameObject.SetActive(false);
        }
        if (canAttack && isAttacking){
            target.GetComponent<IDamageable>().Damage(damage);
            canAttack = false;
            _ = Attack();
        }
    }

    async Task Attack(){
        await Task.Delay(400);
        canAttack = true;
    }
}
