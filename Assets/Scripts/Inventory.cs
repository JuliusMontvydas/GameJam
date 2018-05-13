using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public bool hasItem = false;
    public GameObject spwn;
    public GameObject inventoryController;

	public Movement movementScript;
	public InventoryController inventoryControllerScript;

	void Start()
    {
        hasItem = false;        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

		switch (collision.tag)
		{
			case "damager":
				inventoryController.GetComponent<InventoryController>().takeDamage();
				Destroy(other);
				break;

			case "box":
				if (hasItem)
				{
					destroyEffects();
					inventoryController.GetComponent<InventoryController>().addItem();
					hasItem = false;
					spwn.GetComponent<GameSpawner>().SpawnItem();
				}
				break;

			default:
				initEffects(collision.tag);

				Debug.Log("Item picked up!");
				hasItem = true;
				Destroy(other);
				break;
		}
    }

	private void initEffects(string type)
	{
		switch (type)
		{
			case "skull":
				movementScript.speed = 300;
				break;

			case "ice":
				movementScript.speed = 30;
				break;

			case "live":
				inventoryControllerScript.addLive();
				break;

			default:

				break;
		}
	}

	private void destroyEffects()
	{
		movementScript.resetDefaults();
	}
}
