using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static GameController instance { get; private set; }
	private AddItem ai;
	private RoomsControls rc;
	private ItemsControls ic;

	private GameObject welcomeScreen;

    [HideInInspector]
	public Color InterfaceColour;
	public Page CurrentPage { get; private set; }
	public Page PreviousPage { get; private set; }
	public Image[] InterfaceElements;

	private Dictionary<string, GameObject> Pages;

    [HideInInspector]
	public Dictionary<string, Room> Rooms;

    [SerializeField]
	private Text Heading;

	public float TotalValue
	{
		get
		{
			float output = 0.0f;

			foreach (KeyValuePair<string, Room> r in Rooms)
			{
				foreach (Item i in r.Value.Items)
				{
					output += i.Value;
				}
			}

			return output;
		}
	}

	public float RoomCount
	{
		get
		{
			return Rooms.Count;
		}
	}

	public float ItemCount
	{
		get
		{
			int output = 0;
			
			foreach (KeyValuePair<string, Room> r in Rooms)
			{
				output += r.Value.Items.Count;
			}

			return output;
		}
	}

    // Used for initialising the singleton
	void Awake ()
	{
        if (instance != null) throw new System.Exception();
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{
        ai = AddItem.instance;
		rc = RoomsControls.instance;
		ic = ItemsControls.instance;

		// Store pages in dictionary
		Pages = new Dictionary<string, GameObject>();
		Pages.Add("Summary", GameObject.FindWithTag("Summary"));
		Pages.Add("Rooms", GameObject.FindWithTag("Rooms"));
		Pages.Add("AddRoom", GameObject.FindWithTag("AddRoom"));
        Pages.Add("Items", GameObject.FindWithTag("Items"));
		Pages.Add("AddItem", GameObject.FindWithTag("AddItem"));
		Pages.Add("Receipts", GameObject.FindWithTag("Receipts"));
		Pages.Add("Settings", GameObject.FindWithTag("Settings"));

		InterfaceColour = new Color(0.27f, 0.72f, 1.0f);
		CurrentPage = Page.Summary;

		ChangePage(CurrentPage);

		// Make some dummy data for the start
		Rooms = new Dictionary<string, Room>();
		Room temp = new Room("Living room", "", RoomType.LivingSpace);
		temp.AddItem(new Item("Table", 75.0f, "Living room", ItemCategory.Furniture, ""));
		Rooms.Add(temp.ObjName, temp);

		temp = new Room("Kitchen", "", RoomType.Kitchen);
		temp.AddItem(new Item("Spaghetti", 13.5f, "Kitchen", ItemCategory.Spaghetti, ""));
		Rooms.Add(temp.ObjName, temp);
	}
	
	// Update is called once per frame
	void Update ()
	{
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
			case Page.AddRoom:
			    InterfaceColour = new Color(0.74f, 0.0f, 1.0f);
				Heading.text = "Rooms";
				rc.UpdateDisplay();
				break;

			case Page.Items:
			case Page.AddItem:
			    InterfaceColour = new Color(1.0f, 0.14f, 0.34f);
				Heading.text = "Items";
				ai.UpdateRooms();
				ic.UpdateDisplay();
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
	}
}
