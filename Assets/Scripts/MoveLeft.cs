using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float Speed = 30f;
    
    private void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}
