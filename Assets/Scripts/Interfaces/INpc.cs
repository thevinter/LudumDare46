using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface INpc
{
    string Name { get; set; }
    Dialogue[] Dialogue { get; set; }
    void Speak();
}
