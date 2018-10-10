using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRoom : MonoBehaviour
{
	private GameController gc;
	private AddItem ai;

	[SerializeField]
	private InputField namefield, notes;
	[SerializeField]
	private Dropdown category;

	void Start ()
	{
		gc = GameController.instance;
		ai = AddItem.instance;
	}

	public void Save ()
	{
		gc.Rooms.Add(namefield.text, new Room(namefield.text, notes.text, (RoomType)category.value - 1));
		gc.ChangePage(Page.Rooms);
	}

	public void ResetFields ()
	{
		namefield.text = "";
		notes.text = "";

		category.value = 0;
	}
}
