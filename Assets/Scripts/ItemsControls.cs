using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsControls : MonoBehaviour
{
	private GameController gc;

    void Start ()
	{
		gc = GameController.instance;
	}

	public void AddItem()
	{
		gc.ChangePage(Page.AddItem);
	}
}
