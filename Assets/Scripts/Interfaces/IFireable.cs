using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IFireable
{
    int Damage { get; set; }
    float BulletSpeed { get; set; }
    float BulletDelay { get; set; }
}
