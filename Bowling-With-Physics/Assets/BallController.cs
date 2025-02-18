using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
private bool isBallLaunched;
[SerializeField] private float force = 1f;
[SerializeField] private Transform ballAnchor;
[SerializeField] private Transform launchIndicator;
[SerializeField] private InputManager inputManager;

private Rigidbody ballRB;

void Start(){
    ballRB = GetComponent<Rigidbody>();
    inputManager.OnSpacePressed.AddListener(LaunchBall);
    transform.parent = ballAnchor;
    transform.localPosition = Vector3.zero;
    ballRB.isKinematic = true;
    ResetBall();
}


private void LaunchBall(){
    if(isBallLaunched) return;
    isBallLaunched = true;
    transform.parent = null;
    ballRB.isKinematic = false;
    ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
    launchIndicator.gameObject.SetActive(false);

}
public void ResetBall()
{
isBallLaunched = false;
//We are setting the ball to be a Kinematic Body
ballRB.isKinematic = true;
launchIndicator.gameObject.SetActive(true);
transform.parent = ballAnchor;
transform.localPosition = Vector3.zero;
}

}