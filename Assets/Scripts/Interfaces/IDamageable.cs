using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IDamageable 
{
    /// <summary>
    /// The health of the Damageable entity
    /// </summary>
    int Health { get; set; }

    /// <summary>
    /// Damages the entity based on the damage provided
    /// </summary>
    /// <param name="damage">The amount of damage</param>
    void Damage(int damage);
}
