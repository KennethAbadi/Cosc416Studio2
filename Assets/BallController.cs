using UnityEngine;
using UnityEngine.Events;
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    private bool isBallLaunched;
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        ResetBall();
    }

    // Update is called once per frame
    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
      launchIndicator.gameObject.SetActive(false);
    }
    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
