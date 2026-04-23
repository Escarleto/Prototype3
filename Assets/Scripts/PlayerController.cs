using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private Animator PlayerAnim;
    private AudioSource PlayerAudio;
    [SerializeField] private ParticleSystem Explosion;
    [SerializeField] private ParticleSystem Dirt;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip CrashSound;
    
    [SerializeField] private float JumpForce = 100f;
    [SerializeField] private float GravityModifier = 1f;
    [SerializeField] private bool OnGround = false;
    public bool GameOver = false;
    
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
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
            Dirt.Stop();
            PlayerAudio.PlayOneShot(JumpSound, 1.0f);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
            Dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            Explosion.Play();
            Dirt.Stop();
            PlayerAudio.PlayOneShot(CrashSound, 1.0f);
        }
            
    }
}
