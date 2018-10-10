using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsControls : MonoBehaviour
{
	private GameController gc;
	void Start ()
	{
		gc = GameController.instance;
	}

	public void AddRoom ()
	{
	    gc.ChangePage(Page.AddRoom);
	}
}
