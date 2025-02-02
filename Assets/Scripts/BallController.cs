using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{

    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager;

    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        // Grabbing a reference to the Rigidbody component
        ballRB = GetComponent<Rigidbody>();

        // Add a listener to the OnSpacePressed event
        // When the s[ace ley is pressed, the LaunchBall method will be called
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        if (isBallLaunched)
        {
            return;
        }
        isBallLaunched = true;
        transform.parent = null;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
        ballRB.isKinematic = false;
        // Add a force to the ball
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
