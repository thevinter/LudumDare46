﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private Player p;
    // Start is called before the first frame update
    void Start() {
        p = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        anim.SetBool("isResting", p.GetResting());
    }
}
