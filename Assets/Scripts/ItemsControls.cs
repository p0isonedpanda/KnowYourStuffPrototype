using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsControls : MonoBehaviour
{
	public static ItemsControls instance { get; private set; }
	private GameController gc;

	public List<GameObject> ItemDisplay;
	[SerializeField]
	private GameObject displayTemplate;
	[SerializeField]
	private Transform displayStart;

	void Awake ()
	{
		if (instance != null) throw new System.Exception();
		instance = this;
	}

    void Start ()
	{
		gc = GameController.instance;
	}

	public void AddItem()
	{
		gc.ChangePage(Page.AddItem);
	}

	public void UpdateDisplay ()
	{
		// Clear and then populate the list
		foreach (GameObject id in ItemDisplay)
		{
			Destroy(id);
		}

		ItemDisplay = new List<GameObject>();

		int currentPos = 0;

		foreach (KeyValuePair<string, Room> r in gc.Rooms)
		{
			foreach (Item i in r.Value.Items)
			{
			    GameObject temp = Instantiate(displayTemplate, new Vector3(displayStart.position.x, displayStart.position.y - currentPos, displayStart.position.z), displayStart.rotation);
			    temp.GetComponent<ItemDisplay>().Display = i;
				temp.GetComponent<ItemDisplay>().UpdateDisplay();
				temp.transform.SetParent(displayStart);
				ItemDisplay.Add(temp);

				currentPos += 120;
			}
		}
	}
}
