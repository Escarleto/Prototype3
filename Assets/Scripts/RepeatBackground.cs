using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPos;
    private float RepeatWidth;
    
    private void Start()
    {
        StartPos  = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < StartPos.x - RepeatWidth)
            transform.position = StartPos;
    }
}
