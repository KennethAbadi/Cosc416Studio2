using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    private FallTrigger[] pins;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;
    private void Start()
    {
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in pins){
            pin.OnPinFall.AddListener(IncrementScore);
        }
        inputManager.OnResetPressed.AddListener(handleReset);
         SetPins();
    }

    // Update is called once per frame
    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    private void handleReset(){
        ball.ResetBall();
        SetPins();
    }
    private void SetPins()
 {

        if(pinObjects)
        {
        foreach (Transform child in pinObjects.transform)
        {
        Destroy(child.gameObject);
        }

        Destroy(pinObjects);
        }

        // We then instatiate a new set of pins to our pin anchor transform
        pinObjects = Instantiate(pinCollection,
        pinAnchor.transform.position,
        Quaternion.identity, transform);

        // We add the Increment Score function as a listener to
        // the OnPinFall event each of new pins
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
        pin.OnPinFall.AddListener(IncrementScore);
}
}
}
