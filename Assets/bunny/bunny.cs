using UnityEngine;

public class bunny : MonoBehaviour
{
    public float speed = 2f;
        Animator animator;
    Vector3 start;
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


        float y = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * y * speed * Time.deltaTime);
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
        if (collision.CompareTag("Horse"))
        {
            transform.position = start;
        }
        if (collision.CompareTag("Water") && collision.CompareTag("Lily Pad"))
        {
            transform.position = Vector3.MoveTowards(transform.position, start, .03f);
        }
    }
}
