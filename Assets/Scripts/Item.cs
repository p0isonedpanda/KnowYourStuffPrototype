using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : BaseObject
{
	public float Value;
	public string Room;
	public ItemCategory Category;

	public Item (string _name, float _value, string _room, ItemCategory _category, string _notes) : base (_name, _notes)
	{
        Value = _value;
		Room = _room;
		Category = _category;
	}

    // Constructor overload if there's images to add
	public Item (string _name, float _value, string _room, ItemCategory _category, string _notes, List<Sprite> _images)
	: this (_name, _value, _room, _category, _notes)
	{
		Images = _images;
	}
}
