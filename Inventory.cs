using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	public Dictionary<string, int> itemList = new Dictionary<string, int>();
	public Dictionary<string, GameObject> itemHolders = new Dictionary<string, GameObject>();

	public GameObject inventoryPanel;
	public GameObject holderPreb;

	bool isActive;

	void Start()
	{
		
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			AddItem("Potion", 20);
		}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			AddItem("Arrow", 50);
		}
		if(Input.GetKeyDown(KeyCode.X))
		{
			AddItem("Sword", 1);
		}
	}

	void AddItem(Item item)
	{
		if(itemList.ContainsKey(item.Name))
		{
			itemList[item.Name] += item.Qty;
			return;
		}

		itemList.Add(item.Name, item.Qty);
		int y = itemList.Count == 0 ? 0 : (itemList.Count - 1) * -35;
		GameObject instance = Instantiate(holderPreb, inventoryPanel.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
		instance.transform.SetParent(inventoryPanel.transform);
		itemHolders.Add(name, instance);
	}

	void AddItem(string name, int qty)
	{
		if(itemList.ContainsKey(name))
		{
			itemList[name] += qty;
			return;
		}

		itemList.Add(name, qty);
		int y = itemList.Count == 0 ? 0 : (itemList.Count - 1) * -35;
		GameObject instance = Instantiate(holderPreb, inventoryPanel.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
		instance.transform.SetParent(inventoryPanel.transform);
		instance.name = name;
		itemHolders.Add(name, instance);
	}

	void RemoveItem(Item item)
	{
		if(itemList.ContainsKey(item.Name))
		{
			itemList[item.Name] -= item.Qty;
		}
	}

	void AddItemHolder()
	{
		int y = itemList.Count == 0 ? 0 : (itemList.Count - 1) * -35;
		GameObject instance = Instantiate(holderPreb, inventoryPanel.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
		instance.transform.SetParent(inventoryPanel.transform);
	}
}
