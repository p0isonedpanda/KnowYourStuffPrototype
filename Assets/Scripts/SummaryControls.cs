using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryControls : MonoBehaviour
{
	private GameController gc;

    [SerializeField]
    private Text totalValue, roomCount, itemCount;
	void Start ()
	{
		gc = GameController.instance;
	}

	void Update ()
	{
		totalValue.text = "Total Value:\n$" + gc.TotalValue.ToString();
		roomCount.text = "Room Count:\n" + gc.RoomCount.ToString();
		itemCount.text = "Item Count:\n" + gc.ItemCount.ToString();
	}
}
