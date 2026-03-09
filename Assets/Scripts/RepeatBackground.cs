using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPos;
    [SerializeField] private float Speed = 30f;
    private float RepeatWidth;
    private PlayerController PlayerControllerScript;
    
    private void Start()
    {
        StartPos  = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (PlayerControllerScript.GameOver)
            return;
        
        transform.position += Vector3.left * Speed * Time.deltaTime;
        
        if (transform.position.x < StartPos.x - RepeatWidth)
            transform.position = StartPos;
    }
}
