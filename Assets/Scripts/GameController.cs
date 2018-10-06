using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static GameController instance { get; private set; }

    [HideInInspector]
	public Color InterfaceColour;
	public string PageName;
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
		PageName = "Summary";
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Image i in InterfaceElements)
		{
			i.color = InterfaceColour;
		}

		Heading.text = PageName;
	}
}
