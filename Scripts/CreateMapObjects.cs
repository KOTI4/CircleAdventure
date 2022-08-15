using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateMapObjects : MonoBehaviour
{
    public static Dictionary<string, List<GameObject>> CreateObjects(int minCount, int maxCount, int xPositionMax, int yPositionMax, 
        int excep,params GameObject[] prefabs)
    {
        var dict = new Dictionary<string, List<GameObject>>();

        foreach (var prefab in prefabs)
        {
            dict.Add(prefab.name, new List<GameObject>());
        }
        var positions = CreatePositions(minCount, maxCount, xPositionMax, yPositionMax, excep);
        foreach (var position in positions)
        {
            var randPrefabNum = Random.Range(0, prefabs.Length);
            var randPrefabName = prefabs[randPrefabNum].name;
            var gameObject = Instantiate(prefabs[randPrefabNum], position, new Quaternion());
            dict[randPrefabName].Add(gameObject);
        }
        return dict;    
    }

    private static List<Vector3> CreatePositions(int minCount, int maxCount,int xPositionMax, int yPositionMax, int excep)
    {
        var amount = Random.Range(minCount, maxCount);
        var positions = new List<Vector3>();
        for (int i = 0; i < amount; i++)
        {
            float xPosition = RandomWithException(-xPositionMax, xPositionMax, -excep, excep);
            float yPosition = RandomWithException(-yPositionMax, yPositionMax, -excep, excep);
            positions.Add(new Vector3(xPosition, yPosition, 0));
        }
        positions = new HashSet<Vector3>(positions).ToList();
        return positions;
    }

    private static float RandomWithException(int min, int max, int exMin, int exMax)
    {
        float rand;
        if (Random.value > 0.5f) rand = Random.Range(min, exMin);
        else rand = Random.Range(exMax, max);

        return rand;
    }

}
