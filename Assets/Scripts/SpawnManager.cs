using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    private Vector3 SpawnPos = new Vector3(25f, 0, 0);

    private void Start()
    {
        Instantiate(ObstaclePrefab, SpawnPos, ObstaclePrefab.transform.rotation);
    }
}
