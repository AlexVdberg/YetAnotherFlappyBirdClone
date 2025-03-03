using UnityEngine;
using UnityEngine.Events;

public class LogicManagerScript : MonoBehaviour
{
    private int playerScore = 0;
    public GameObject userInterface;

    // Unity Action allows passing arguments
    public static event UnityAction<int> OnAddScore;

    private void OnEnable()
    {
        // add observer to event
        MiddleCollision.OnPassPipesEvent += AddScore;
    }

    private void OnDisable()
    {
        // remove observer from event
        MiddleCollision.OnPassPipesEvent -=AddScore;
    }

    // Add an option to the context menu of this script in unity
    [ContextMenu("Increase Score")]
    void AddScore()
    {
        playerScore++;
        Debug.Log("Added to the score: " + playerScore);
        OnAddScore?.Invoke(playerScore);
    }
}
