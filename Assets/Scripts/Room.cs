using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : BaseObject
{
	public RoomType Type;
	public List<Item> Items;
	public float Value
	{
        get
		{
			float output = 0.0f;

            foreach (Item i in Items)
			{
				output += i.Value;
			}

			return output;
		}
	}

	public Room (string _name, string _notes, RoomType _type) : base (_name, _notes)
	{
		Type = _type;
		Items = new List<Item>();
	}
}
