using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsControls : MonoBehaviour
{
	public static RoomsControls instance { get; private set; }
	public List<GameObject> RoomDisplay;
	[SerializeField]
	private GameObject displayTemplate;
	[SerializeField]
	private Transform displayStart;
	private GameController gc;

	void Awake ()
	{
		if (instance != null) throw new System.Exception();
		instance = this;
	}

	void Start ()
	{
		gc = GameController.instance;
		RoomDisplay = new List<GameObject>();
	}

	public void AddRoom ()
	{
	    gc.ChangePage(Page.AddRoom);
	}

	public void UpdateDisplay ()
	{
		// Clear and then populate the list
		foreach (GameObject rd in RoomDisplay)
		{
			Destroy(rd);
		}

		RoomDisplay = new List<GameObject>();

        int index = 0;
		int currentPos = 0;

		foreach (KeyValuePair<string, Room> r in gc.Rooms)
		{
			GameObject temp = Instantiate(displayTemplate, new Vector3(displayStart.position.x, displayStart.position.y - currentPos, displayStart.position.z), displayStart.rotation);
			temp.GetComponent<RoomDisplay>().Display = r.Value;
			temp.GetComponent<RoomDisplay>().UpdateDisplay();
			temp.transform.SetParent(displayStart);
			RoomDisplay.Add(temp);

            currentPos += 90;
			index++;
		}
	}
}
