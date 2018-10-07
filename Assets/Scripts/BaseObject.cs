using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{
	public string Name;
	public string Notes;
	public List<Sprite> Images;

	public BaseObject (string _name, string _notes)
	{
		Name = _name;
		Notes = _notes;
		Images = new List<Sprite>();
	}
}
