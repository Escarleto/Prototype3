using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    
    [SerializeField] private float JumpForce = 100f;
    [SerializeField] private float GravityModifier = 1f;
    [SerializeField] private bool OnGround = false;
    
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        //PlayerRB.AddForce(Vector3.up * 1000f);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            OnGround = false;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            OnGround = true;
    }
}
