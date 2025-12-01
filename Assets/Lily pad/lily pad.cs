using UnityEngine;

public class lilypad : MonoBehaviour
{
    Animator animator;
    float futureTime;
    float randomTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        futureTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        randomTime = Random.Range(1f, 4f);
        if (Time.time > futureTime)
        {
            animator.SetBool("Disappear", true);
            futureTime = Time.time + randomTime;
            appear();
        }
    }
    private void appear()
    {
        animator.SetBool("Disappear", false);
    }
}
