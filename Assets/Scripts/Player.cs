using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; // Control the speed
    private Rigidbody2D rb;
    public bool isDead = false;
    public GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Get Rigidbody2D component of the bird
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click or space key press
        if (!isDead && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            Fly();
        }
    }

    private void Fly()
    {
        rb.linearVelocity = Vector2.up * speed; // Apply upward force
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        rb.simulated = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        audioManager.PlaySFX(audioManager.death);
        gameManager.GameOver();
    }
}
