using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{

    [SerializeField] private float force = 1f;
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
    }

    private void LaunchBall()
    {
        if (isBallLaunched)
        {
            return;
        }
        isBallLaunched = true;
        // Add a force to the ball
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
