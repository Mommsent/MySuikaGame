using UnityEngine;

public class FruitInfo : MonoBehaviour
{
    public int FruitIndex = 0;
    public int PointsWhenAnnihilated = 1;
    public float FruitMass = 1.0f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.mass = FruitMass;
    }
}
