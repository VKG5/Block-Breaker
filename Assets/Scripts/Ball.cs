using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] float randomFactor = 0.2f;
    
    // State
    Vector2 paddleToBall;
    bool hasStarted = false;

    // Cached component references
    private AudioSource myAudioSource;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        paddleToBall = transform.position - paddle1.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBalltoPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = (paddleToBall + paddlePos);
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Primary Button pressed
            hasStarted = true;
            rb.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(0f, randomFactor), 
             Random.Range(0f, randomFactor));

        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            rb.velocity += velocityTweak;
        }
    }
}
