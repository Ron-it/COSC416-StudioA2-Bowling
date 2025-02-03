using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        if (!triggeredBody.CompareTag("Ball"))
        {
            Debug.Log($"Object {triggeredBody.gameObject.name} ignored by gutter - not tagged as Ball");
            return;
        }

        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
        if (ballRigidBody == null)
        {
            Debug.LogWarning($"Object {triggeredBody.gameObject.name} has no Rigidbody component");
            return;
        }

        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
}
