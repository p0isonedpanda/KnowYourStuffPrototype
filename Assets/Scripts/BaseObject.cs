using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject
{
	public string ObjName;
	public string Notes;
	public List<Sprite> Images;

	public BaseObject (string _objName, string _notes)
	{
		ObjName = _objName;
		Notes = _notes;
		Images = new List<Sprite>();
	}
}
