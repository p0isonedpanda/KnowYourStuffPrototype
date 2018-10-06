using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerMenu : MonoBehaviour
{
	private GameController gc;

	void Start ()
	{
		gc = GameController.instance;
	}

	public void Summary ()
	{
		gc.ChangePage(Page.Summary);
	}
}
