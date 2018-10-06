using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftButtons : MonoBehaviour
{
	private GameController gc;
	private CommonControls cc;

	void Start ()
	{
		gc = GameController.instance;
		cc = CommonControls.instance;
	}

	public void Back ()
	{
		if (gc.CurrentPage == Page.Hamburger)
		{
			cc.HamburgerMenu(); // This will deactivate the hamburger menu
		}
	}
}
