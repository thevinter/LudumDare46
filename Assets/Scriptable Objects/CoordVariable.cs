using UnityEngine;

[CreateAssetMenu]
public class CoordVariable : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Vector3 Value;

    public void SetValue(Vector3 value) {
        Value = value;
    }

    public void SetValue(CoordVariable value) {
        Value = value.Value;
    }

    public void ApplyChange(int x, int y = 0, int z = 0) {
        Value.x += x;
        Value.y += y;
        Value.z += z;
    }

    public void ApplyChange(Vector3 amount) {
        Value += amount;
    }

    public void ApplyChange(CoordVariable amount) {
        Value += amount.Value;
    }
}