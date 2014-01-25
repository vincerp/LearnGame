using UnityEngine;
using System;
using System.Collections.Generic;

public class Dialog : ScriptableObject
{
	public List<Message> messages = new List<Message>();
}

[System.Serializable]
public class Message
{
	public string speaker;
	public string message;
}