using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float Speed = 30f;
    private float LeftBound = -15f;
    private PlayerController PlayerControllerScript;
    
    private void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    private void Update()
    {
        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
        
        if (PlayerControllerScript.GameOver)
            return;
        
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}
