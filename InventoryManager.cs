using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
	public Dictionary<string, int> itemList = new Dictionary<string, int>();
	public Dictionary<string, GameObject> itemHolders = new Dictionary<string, GameObject>();

	public GameObject inventoryPanel;
	public GameObject slotPrefab;

	bool isActive;

	public void AddItem(Item item)
	{
		if(itemList.ContainsKey(item.Name))
		{
			itemList[item.Name] += item.Qty;
			itemHolders[item.Name].transform.FindChild("Item Qty").GetComponent<Text>().text = itemList[item.Name].ToString();
			return;
		}

		itemList.Add(item.Name, item.Qty);
		int y = itemList.Count * -35;
		GameObject instance = Instantiate(slotPrefab, inventoryPanel.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
		instance.transform.SetParent(inventoryPanel.transform);
		instance.transform.FindChild("Item Name").GetComponent<Text>().text = item.Name;
		instance.transform.FindChild("Item Qty").GetComponent<Text>().text = item.Qty.ToString();
		itemHolders.Add(item.Name, instance);
	}

	public void AddItem(string name, int qty)
	{
		if(itemList.ContainsKey(name))
		{
			itemList[name] += qty;
			return;
		}

		itemList.Add(name, qty);
		int y = itemList.Count == 0 ? 0 : (itemList.Count - 1) * -35;
		GameObject instance = Instantiate(slotPrefab, inventoryPanel.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
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
		GameObject instance = Instantiate(slotPrefab, inventoryPanel.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
		instance.transform.SetParent(inventoryPanel.transform);
	}
}
