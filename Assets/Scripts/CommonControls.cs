using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonControls : MonoBehaviour
{
    public static CommonControls instance { get; private set; }
	private GameController gc;

	[SerializeField]
	private RectTransform SlideOutMenu;
	[SerializeField]
	private RectTransform Pages;
	[SerializeField]
	private RectTransform Active, Inactive;
	private RectTransform Current;

    void Awake ()
	{
		if (instance != null) throw new System.Exception();
		instance = this;
	}

    void Start ()
	{
		Current = Inactive;
		gc = GameController.instance;
	}

	void Update ()
	{
		SlideOutMenu.localPosition = Vector3.Lerp(SlideOutMenu.localPosition, Current.localPosition, 0.1f);


        if (Current == Active)
		{
			GetComponent<RectTransform>().localPosition = new Vector3
		    (
		    	Mathf.Lerp(GetComponent<RectTransform>().localPosition.x, Current.localPosition.x + 635.4f, 0.1f),
		    	GetComponent<RectTransform>().localPosition.y,
		    	GetComponent<RectTransform>().localPosition.z
		    );

		    Pages.localPosition = new Vector3
		    (
		    	Mathf.Lerp(Pages.localPosition.x, Current.localPosition.x + 635.4f, 0.1f),
		    	Pages.localPosition.y,
		    	Pages.localPosition.z
		    );
		}
		else
		{
		    GetComponent<RectTransform>().localPosition = new Vector3
		    (
		    	Mathf.Lerp(GetComponent<RectTransform>().localPosition.x, Current.localPosition.x + 935.4f, 0.1f),
		    	GetComponent<RectTransform>().localPosition.y,
		    	GetComponent<RectTransform>().localPosition.z
		    );

		    Pages.localPosition = new Vector3
		    (
		    	Mathf.Lerp(Pages.localPosition.x, Current.localPosition.x + 935.4f, 0.1f),
		    	Pages.localPosition.y,
		    	Pages.localPosition.z
		    );
		}
	}

    // This should only be called to toggle on or off the menu
	public void HamburgerMenu ()
	{
		if (Current == Inactive)
		{
			Current = Active;
			gc.ChangePage(Page.Hamburger);
		}
		else
		{
			Current = Inactive;
			gc.ChangePage(gc.PreviousPage);
		}
	}

    // Use this to close the menu from an external script
	public void CloseHamburgerMenu ()
	{
		Current = Inactive;
	}
}
