using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    private Rigidbody rb;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        rb.AddForce(speed * moveDirection);
    }
}
