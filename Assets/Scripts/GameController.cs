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

	private Dictionary<string, GameObject> Pages;

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

		// Store pages in dictionary
		Pages = new Dictionary<string, GameObject>();
		Pages.Add("Summary", GameObject.FindWithTag("Summary"));
		Pages.Add("Rooms", GameObject.FindWithTag("Rooms"));
        Pages.Add("Items", GameObject.FindWithTag("Items"));
		Pages.Add("Receipts", GameObject.FindWithTag("Receipts"));
		Pages.Add("Settings", GameObject.FindWithTag("Settings"));
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Display the correct page
		if (CurrentPage != Page.Hamburger)
		{
		    foreach (KeyValuePair<string, GameObject> p in Pages)
		    {
		    	p.Value.SetActive(false);
		    }
    
		    Pages[CurrentPage.ToString()].SetActive(true);
		    Heading.text = CurrentPage.ToString();
		}

        switch (CurrentPage)
		{
			case Page.Summary:
                InterfaceColour = new Color(0.27f, 0.72f, 1.0f);
			    break;

			case Page.Rooms:
			    InterfaceColour = new Color(0.74f, 0.0f, 1.0f);
				break;

			case Page.Items:
			    InterfaceColour = new Color(1.0f, 0.14f, 0.34f);
				break;

			case Page.Receipts:
			    InterfaceColour = new Color(0.0f, 0.41f, 1.0f);
				break;
			
			case Page.Settings:
			    InterfaceColour = new Color(1.0f, 0.59f, 0.0f);
				break;

			case Page.Hamburger:
                InterfaceColour = new Color(0.5f, 0.5f, 0.5f);
			    break;
		}

        // Make sure that the interface elements are the same uniform colour
		foreach (Image i in InterfaceElements)
		{
			i.color = Color.Lerp(i.color, InterfaceColour, 0.1f);
		}

	}

    // Use this to change the current page through an external script
	public void ChangePage (Page newPage)
	{
		PreviousPage = CurrentPage;
        CurrentPage = newPage;
	}
}
