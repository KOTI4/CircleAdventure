using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public delegate void CoinPickUp();
    public static event CoinPickUp CoinPicked;

    public delegate void MineTouched();
    public static event MineTouched MineTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            CoinPicked();
        }

        if (collision.tag == "Mine")
        {
            MineTouch();
        }
    }
}
