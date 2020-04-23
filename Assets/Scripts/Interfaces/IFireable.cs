using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IFireable
{
    AudioClip ShootSound { get; set; }
    int Damage { get; set; }
    float BulletSpeed { get; set; }
    float BulletDelay { get; set; }
}
