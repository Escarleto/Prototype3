using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private Animator PlayerAnim;
    
    [SerializeField] private float JumpForce = 100f;
    [SerializeField] private float GravityModifier = 1f;
    [SerializeField] private bool OnGround = false;
    public bool GameOver = false;
    
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
        Physics.gravity *= GravityModifier;
        //PlayerRB.AddForce(Vector3.up * 1000f);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround && !GameOver)
        {
            PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            OnGround = false;
            PlayerAnim.SetTrigger("Jump_trig");
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            OnGround = true;
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game Over!");
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
        }
            
    }
}
