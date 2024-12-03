using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public Animator asteroidAnimator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
