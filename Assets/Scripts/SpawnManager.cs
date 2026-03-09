using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    private Vector3 SpawnPos = new Vector3(25f, 0, 0);
    [SerializeField] private float StartDelay = 2f;
    [SerializeField] private float SpawnInterval = 2f;
    private PlayerController PlayerControllerScript;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, SpawnInterval);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    private void SpawnObstacle()
    {
        if (PlayerControllerScript.GameOver)
            return;
        Instantiate(ObstaclePrefab, SpawnPos, ObstaclePrefab.transform.rotation);
    }
}
