using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeActive : MonoBehaviour {
	public Animator Notifications;
	public GameObject notifications;
	public NoticeRead NoticeRead;

	public void OpenNotice()
	{
		notifications.SetActive(true);
		Notifications.Play("enter");
		NoticeRead.ReadTxt();
	}
	public void LeftNotice()
	{
		Notifications.Play("left");
		StartCoroutine(CloseActive(0.5f,notifications,false));
	}
	private IEnumerator CloseActive(float time,GameObject _object,bool _bool)
	{
		yield return new WaitForSeconds(time);
		_object.SetActive(_bool);
	}
}
