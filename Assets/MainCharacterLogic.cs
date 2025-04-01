using UnityEngine;

public class MainCharacterLogic : MonoBehaviour
{
    private AudioSource Death_Effect;

    private Rigidbody2D rb;
    public float speed = 5.0f;
    public int hp = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Death_Effect = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (hp <= 0)
        {
            Death_Effect.Play();
            Destroy(gameObject);
        }
    }

    private void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);
    }
}
