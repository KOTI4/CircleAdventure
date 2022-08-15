using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Mine;

    public Canvas WinCanvas;
    public Canvas LoseCanvas;

    public GameObject touchManager;

    public GameObject player;

    private Dictionary<string, List<GameObject>> objects;
    private int coinCount;

    public delegate void Restart();
    public static event Restart RestartScene;

    public delegate void Win();
    public static event Win GameWasWin;

    public delegate void Loss();
    public static event Loss GameWasLosed;
    void Start()
    {
        PlayerCollision.CoinPicked += DecreaseCoinCount;
        PlayerCollision.CoinPicked += WinGame;

        PlayerCollision.MineTouch += LoseGame;
        CreateNewObjectsOnScene(Coin, Mine);
    }

    void WinGame()
    {
        if (coinCount == 0)
        {
            WinCanvas.gameObject.SetActive(true);
            touchManager.GetComponent<TouchToPathPoint>().enabled = false;
            Path.ResetPath();
            GameWasWin();
        }
    }

    void DecreaseCoinCount() => coinCount--;

    void LoseGame()
    {
        LoseCanvas.gameObject.SetActive(true);
        touchManager.GetComponent<TouchToPathPoint>().enabled = false;
        Path.ResetPath();
        GameWasLosed();
    }

    void DestroyAllObjectsInDict(Dictionary<string, List<GameObject>> objects)
    {
        foreach (var name in objects)
        {
            foreach (var obj in name.Value)
            {
                if (obj != null) Destroy(obj);
            }
        }
    }

    public void RestartGame()
    {
        RestartScene();
       
        DestroyAllObjectsInDict(objects);

        player.transform.position = new Vector3(0, 0);

        touchManager.GetComponent<TouchToPathPoint>().enabled = true;
        CreateNewObjectsOnScene(Coin, Mine);

        LoseCanvas.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(false);
    }

    public void CreateNewObjectsOnScene(params GameObject[] prefabs)
    {
        objects = CreateMapObjects.CreateObjects(8, 24, 11, 4, 1, prefabs);
        coinCount = objects["coin"].Count;
    }
}
