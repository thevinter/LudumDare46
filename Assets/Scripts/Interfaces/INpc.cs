using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INpc
{
    string Name { get; set; }
    State[] States { get; set; }
    void Speak();
}
