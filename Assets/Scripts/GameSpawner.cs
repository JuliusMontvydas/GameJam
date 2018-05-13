using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour {
    public GameObject[] itemSpawns;
    public GameObject[] item;

    void Start()
    {
        SpawnItem();
    }

    public void SpawnItem()
    {
		int type = GetItemType();
        int roll = Random.Range(0, itemSpawns.Length);

        Vector2 itemPos = itemSpawns[roll].transform.position;
        Instantiate(item[type], itemPos, Quaternion.identity);
    }

	int GetItemType()
	{
		int value = Random.Range(0, 100);

		if (value <= 10) // 10% chance
		{
			return 1; // Skull
		}
		else if (value <= 20) // 10% chance
		{
			return 2; // Live
		}
		else if (value <= 30) // 10% chance
		{
			return 3; // Ice
		}

		return 0; // Default
	}
}
