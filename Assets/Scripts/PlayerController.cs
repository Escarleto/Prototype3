using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        //PlayerRB.AddForce(Vector3.up * 1000f);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerRB.AddForce(Vector3.up * 100f, ForceMode.Impulse);
    }
}
