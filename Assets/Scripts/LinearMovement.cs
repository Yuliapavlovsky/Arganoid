using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] Vector2 velocity;

    void Start() {
        GetComponent<Rigidbody2D>().linearVelocity = velocity;
    }
}
