using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
	public static AddItem instance { get; private set; }

	private GameController gc;

    [SerializeField]
	private InputField namefield, value, notes;
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
		    gc.Rooms[room.options[room.value].text].AddItem(new Item(namefield.text, float.Parse(value.text), room.options[room.value].text, (ItemCategory)category.value - 1, notes.text));
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
		namefield.text = "";
		value.text = "";
		notes.text = "";

		room.value = 0;
		category.value = 0;
	}

	public void UpdateRooms()
	{
		room.ClearOptions();
		List<string> options = new List<string>();

        options.Add("Please Select");
		foreach (KeyValuePair<string, Room> r in gc.Rooms)
		{
			options.Add(r.Value.ObjName);
		}

		room.AddOptions(options);
	}
}
