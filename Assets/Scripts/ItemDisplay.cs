using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
	public Item Display;

	[SerializeField]
	private Text label, value, room, category;

	void Start ()
	{
		label.text = Display.ObjName;
        value.text = "$" + Display.Value.ToString();
		room.text = Display.Room;
		category.text = Display.Category.ToString();
	}
}
