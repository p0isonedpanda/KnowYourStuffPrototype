using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
	public static AddItem instance { get; private set; }

	private GameController gc;

    [SerializeField]
	private InputField name, value, notes;
	[SerializeField]
	private Dropdown room, category;

	void Awake ()
	{
		if (instance != null) throw new System.Exception();
		instance = this;
	}

	void Start ()
	{
		gc = GameController.instance;
	}

	public void Save ()
	{
		if (Validate())
		{
			ResetFields();
		    gc.ChangePage(Page.Items);
		}
		else
		{
            value.text = "Invalid value";
		}
	}

	private bool Validate ()
	{
        try 
		{
			float.Parse(value.text);
		}
		catch
		{
			return false;
		}

		return true;
	}

	private void ResetFields ()
	{
		name.text = "";
		value.text = "";
		notes.text = "";

		room.value = 0;
		category.value = 0;
	}

	public void UpdateRooms()
	{
		Debug.Log("Clearing options");
		room.ClearOptions();
		List<string> options = new List<string>();

        options.Add("Please Select");
        Debug.Log("Making options");
		foreach (Room r in gc.Rooms)
		{
			Debug.Log("Adding room: " + r.name);
			options.Add(r.name);
		}

        Debug.Log("Adding options");
		room.AddOptions(options);
	}
}
