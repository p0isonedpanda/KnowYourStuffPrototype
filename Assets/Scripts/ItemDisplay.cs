using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
	public Item Display;

	[SerializeField]
	private Text label, value, room, category;
	private GameController gc;
	private ItemsControls ic;

	void Start()
	{
		gc = GameController.instance;
		ic = ItemsControls.instance;
	}

	public void UpdateDisplay ()
	{
		label.text = Display.ObjName;
        value.text = "$" + Display.Value.ToString();
		room.text = Display.Room;
		category.text = Display.Category.ToString();
	}

	public void Delete ()
	{
		foreach (KeyValuePair<string, Room> r in gc.Rooms)
		{
			foreach (Item i in r.Value.Items)
			{
				if (i == Display) r.Value.Items.Remove(i);
				break;
			}
		}

		ic.UpdateDisplay();
	}
}
