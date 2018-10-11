using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDisplay : MonoBehaviour
{
	public Room Display;

	[SerializeField]
	private Text label, category;

	public void UpdateDisplay ()
	{
		label.text = Display.ObjName;
		category.text = Display.Type.ToString();
	}
}
