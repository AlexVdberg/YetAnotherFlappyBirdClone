using UnityEngine;
using UnityEngine.UIElements;

public class PipeSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    float pipeDelay = 0;
    public float pipeDelayInterval = 5f;
    public float heightOffset = 10;
    private bool isGameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            if (pipeDelay <= 0)
            {
                SpawnPipe();
                pipeDelay = pipeDelayInterval;
            } else {
                pipeDelay = pipeDelay - Time.deltaTime;
            }
        }
    }

    private void OnEnable()
    {
        birdScript.OnGameStart += OnGameStarting;
    }

    private void OnDisable()
    {
        birdScript.OnGameStart -= OnGameStarting;
    }

    void OnGameStarting()
    {
        isGameStarted = true;
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        Instantiate(pipe, spawnPosition, transform.rotation);
    }
}
