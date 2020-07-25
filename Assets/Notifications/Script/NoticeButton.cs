using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeButton : MonoBehaviour {
	string title,message;
	public Text _text;

	public void Text(string _title,string text){
		title = _title;
		message = text;
		_text.text = _title;
	}
	public void ReadMessage(){
		GameObject.Find("Title").GetComponent<Text>().text = title;
		GameObject.Find("Message").GetComponent<Text>().text = message;
	}
}
