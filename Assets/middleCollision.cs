using System;
using UnityEngine;

public class MiddleCollision : MonoBehaviour
{
    public static event Action OnPassPipesEvent;

    // The "Is Trigger" option must be checked on this collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Made it through the pipe");
            OnPassPipesEvent?.Invoke();
        }

    }
}
