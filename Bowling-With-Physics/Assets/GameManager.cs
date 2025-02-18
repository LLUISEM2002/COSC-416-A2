using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    private FallTrigger[] pins;
    [SerializeField] private TextMeshProUGUI scoreText;

private void Start(){
    //We find all objects of type FallTrigger
    pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);

    //We then loop over our array of pins and add the
    // IncrementScore function as their listener
    foreach (FallTrigger pin in pins){
        pin.OnPinFall.AddListener(IncrementScore);
    }
}

    private void IncrementScore(){
        score++;
        scoreText.text = $"Score: {score}";
    }

}
