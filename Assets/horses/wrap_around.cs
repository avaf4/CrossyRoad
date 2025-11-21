using UnityEngine;

public class wrap_around : MonoBehaviour
{
    public float MinX = -15f;
    public float MaxX = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if we hit the left
        if (transform.position.x < MinX)
        {
            transform.position = new Vector2(MaxX, transform.position.y);
        }
                // check if we hit the left
        if (transform.position.x > MaxX)
        {
            transform.position = new Vector2(MinX, transform.position.y);
        }
    }
}
