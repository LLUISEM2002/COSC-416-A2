using UnityEngine;
using UnityEngine.Events;
public class BallController : MonoBehaviour
{
private bool isBallLaunched;
[SerializeField] private float force = 1f;
[SerializeField] private Transform ballAnchor;
[SerializeField] private InputManager inputManager;

private Rigidbody ballRB;

void Start(){
    ballRB = GetComponent<Rigidbody>();
    inputManager.OnSpacePressed.AddListener(LaunchBall);
    transform.parent = ballAnchor;
    transform.localPosition = Vector3.zero;
    ballRB.isKinematic = true;
}


private void LaunchBall(){
    if(isBallLaunched) return;
    isBallLaunched = true;
    transform.parent = null;
    ballRB.isKinematic = false;
    ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
}
 }