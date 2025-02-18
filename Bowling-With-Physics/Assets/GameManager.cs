using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    private FallTrigger[] pins;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // A reference to our ballController
    [SerializeField] private BallController ball;

    // A reference for our PinCollection prefab
    [SerializeField] private GameObject pinCollection;

    // A reference for an empty GameObject which we'll use to spawn our pin collection prefab
    [SerializeField] private Transform pinAnchor;

    // A reference for our input manager
    [SerializeField] private InputManager inputManager;

    private GameObject pinObjects;
    private FallTrigger[] fallTriggers;

    private void Start()
    {
        // Find all objects of type FallTrigger
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);

        // Loop over our array of pins and add the IncrementScore function as their listener
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        inputManager.OnResetPressed.AddListener(HandleReset);
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();  // ✅ Pins are only spawned when the player resets the game
    }

    private void SetPins()
    {
        // Destroy existing pins
        if (pinObjects != null)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // Instantiate a new set of pins at the pin anchor position
        pinObjects = Instantiate(pinCollection, pinAnchor.position, Quaternion.identity, transform);

        // Find all FallTrigger objects in the new pin set
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        // Add the IncrementScore function as a listener to the OnPinFall event for each pin
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
