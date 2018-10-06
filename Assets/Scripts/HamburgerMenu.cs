using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerMenu : MonoBehaviour
{
	private GameController gc;
	private CommonControls cc;

	void Start ()
	{
		gc = GameController.instance;
		cc = CommonControls.instance;
	}

	public void ChangePage (string name)
	{
		// Switch to the appropriate page
	    switch (name)
		{
			case "Summary":
			    gc.ChangePage(Page.Summary);
				break;

			case "Rooms":
			    gc.ChangePage(Page.Rooms);
				break;

			case "Items":
			    gc.ChangePage(Page.Items);
				break;
			
			case "Receipts":
			    gc.ChangePage(Page.Receipts);
				break;

			case "Settings":
			    gc.ChangePage(Page.Settings);
				break;
		}

	    cc.CloseHamburgerMenu(); // Makes the hamburger menu slide away
	}
}
