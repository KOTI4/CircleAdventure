using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    public delegate void CoinPickUp();
    public static event CoinPickUp CoinPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            CoinPicked();
        }
    }
}
