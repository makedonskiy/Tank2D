using UnityEngine;

public class LiveObject : MonoBehaviour
{
    [SerializeField] protected float Health;
    [Range(.001f,1f)]
    [SerializeField] protected float Protection;
    [SerializeField] protected int Strength;
    [SerializeField] protected int Speed;
}
