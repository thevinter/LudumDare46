using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface INpc
{
    string Name { get; set; }
    State[] States { get; set; }
    void Speak();
}
