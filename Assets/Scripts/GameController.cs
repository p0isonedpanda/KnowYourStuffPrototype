using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static GameController instance { get; private set; }

    [HideInInspector]
	public Color InterfaceColour;
	public Page CurrentPage { get; private set; }
	public Page PreviousPage { get; private set; }
	public Image[] InterfaceElements;

    [SerializeField]
	private Text Heading;

    // Used for initialising the singleton
	void Awake ()
	{
        if (instance != null) throw new System.Exception();
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		InterfaceColour = new Color(0.27f, 0.72f, 1.0f);
		CurrentPage = Page.Summary;
	}
	
	// Update is called once per frame
	void Update ()
	{
        switch (CurrentPage)
		{
			case Page.Summary:
                InterfaceColour = new Color(0.27f, 0.72f, 1.0f);
			    break;

			case Page.Hamburger:
                InterfaceColour = new Color(0.5f, 0.5f, 0.5f);
			    break;
		}

		foreach (Image i in InterfaceElements)
		{
			i.color = Color.Lerp(i.color, InterfaceColour, 0.1f);
		}

		Heading.text = CurrentPage.ToString();
	}

	public void ChangePage (Page newPage)
	{
		PreviousPage = CurrentPage;
        CurrentPage = newPage;
	}
}
