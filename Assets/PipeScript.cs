using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float pipeSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        // move to the left
        transform.position = transform.position + (Vector3.left * pipeSpeed * Time.deltaTime);
        
        // destroy off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < -100)
        {
            Destroy(gameObject);
        }
    }
}
