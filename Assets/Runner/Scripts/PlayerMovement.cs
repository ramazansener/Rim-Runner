using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool isGameActive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    public GameObject gameOverScreen;
    
    

    private void FixedUpdate ()
    {
        if (!isGameActive) return;

        Vector3 forwardMove = transform.forward * (speed * Time.fixedDeltaTime);
        Vector3 horizontalMove = transform.right * (horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier);
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        
    }

    private void Update () {
        
        
        horizontalInput = Input.GetAxis("Horizontal");

        
        if (transform.position.y < -5) {
            gameOverScreen.SetActive(true);
            Time.timeScale = 1.0f;
        }
        
        
	}

    public void Die ()
    {
        isGameActive = false;
        // Restart the game
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;

    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"Obstacle"))
        {
            gameOverScreen.SetActive(true);
            
        }
        
    }

   
    
        public void QuitGame ()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
        }
    
}