using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerRB.AddForce(Vector3.up * 1000f);
    }
}
