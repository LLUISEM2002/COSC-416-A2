using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        // Added check to make sure only the ball can trigger this
        if (triggeredBody.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidBody = triggeredBody.gameObject.GetComponent<Rigidbody>();
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        }
    }
    
}
