using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    public Vector2 direction = Vector2.down; 
    public float speed = 3f;   
    public MainCharacterLogic mainCharacter;
    public float swingSpeed = 200f; // Speed of the swing
    public float forwardAngle = 70f;   // Max forward angle
    public float backwardAngle = -20f;  // Angle range of the swing
    private float angle = 0f;
    private bool swingingForward = true;
    private Rigidbody2D rb;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            mainCharacter = other.gameObject.GetComponent<MainCharacterLogic>();
            mainCharacter.hp = mainCharacter.hp - 10;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // Prevent physics from interfering
    }
    // Update is called once per frame
    void Update()
    {
        if (swingingForward)
        {
            angle += swingSpeed * Time.fixedDeltaTime;
            if (angle >= forwardAngle)
            {
                angle = forwardAngle;
                swingingForward = false;
            }
        }
        else
        {
            angle -= swingSpeed * Time.fixedDeltaTime;
            if (angle <= backwardAngle)
            {
                angle = backwardAngle;
                swingingForward = true;
            }
        }

        // Apply rotation using Rigidbody2D
        rb.MoveRotation(angle);
    }
}
