using UnityEngine;
public class bunny : MonoBehaviour
{
    public float speed = 2f;
    float y;
    Animator animator;
    Vector3 start;
    public GameObject point, death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        start = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);

        if (x > 0.05f) // going right
        {
            animator.SetBool("right", true);
        }
        else if (x < -0.05f) // going left
        {
            animator.SetBool("left", true);
        }
        else
        {
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }
        
        y = Input.GetAxis("Vertical");
        // allowing bunny to travel vertically at user-provided speed in the bottom half of the screen
        if (transform.position.y <= 0.3){
            transform.Translate(Vector2.up * y * speed * Time.deltaTime);
        }
        // ensuring bunny takes measured steps in the upper-half of the screen
        else if (transform.position.y > 0.3 && transform.position.y < 5)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * 0.7f);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(Vector2.down * 0.7f);
            }
        }
        // ensuring bunny goes back down if it goes beyond the game screen
        else
        {
            transform.Translate(Vector2.down * 0.7f);
        }
        if (y > 0.05f) // going up
        {
            animator.SetBool("back", true);
        }
        else if (y < -0.05f) // going back
        {
            animator.SetBool("front", true);
        }
        else
        {
            animator.SetBool("back", false);
            animator.SetBool("front", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checking if bunny has parent
        if (collision.CompareTag("Respawn"))
        {
            transform.position = start;
            GameManager.Score -= 10;
            GameManager.Lives -= 1;
            Instantiate(death);
        }
        // checks if bunny is on log, turtle, or lily pad and sets parent to one of the three options
        if (collision.CompareTag("Logs") || collision.CompareTag("Turtle") || collision.CompareTag("Lily Pad")){
            transform.SetParent(collision.gameObject.transform);
        }
        // adds points to player's score when they reach the carrot
        if (collision.CompareTag("Finish"))
        {
            transform.position = start;
            GameManager.Score += 20;
            Instantiate(point);
        }
        
    }
    // when the bunny gets off the log, turtle, or lily pad, the parent gets removed
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Logs")){
            transform.SetParent(null);
        }
        if (collision.CompareTag("Turtle")){
            transform.SetParent(null);
        }
        if (collision.CompareTag("Lily Pad")){
            transform.SetParent(null);
        }
    }
    // continuously tracks the collision status of triggers that are still touching
    private void OnTriggerStay2D(Collider2D collision){
        // if the bunny is colliding with the water, and the bunny has no parent, the bunny dies
        if (collision.CompareTag("Water")){
            if(transform.parent == null)
            {
                transform.position = start;
                GameManager.Score -= 10;
                GameManager.Lives -= 1;
                Instantiate(death);
            }

        }
    }
}

