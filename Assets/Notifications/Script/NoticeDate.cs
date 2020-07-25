using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;


public class NoticeDate : MonoBehaviour {
	public Notice _Notice;
	[Header("获取公告日期的链接(*.json)")]
	public string url;
	int date;
	bool Done;

	// Use this for initialization
	void Start () {
		StartCoroutine(GetNotifications());
		//只在激活场景时读取一次
	}
	
	IEnumerator GetNotifications()
	{
	if(Done == false){
		using (UnityWebRequest getnotice = UnityWebRequest.Get (url)) 
			{
				Debug.Log("正在连接服务器...");
				getnotice.timeout = 10;
				yield return getnotice.SendWebRequest();
				if (getnotice.isHttpError||getnotice.isNetworkError)
                {
					Debug.LogError("错误：无法连接至服务器");
				} else {
					byte[] results = getnotice.downloadHandler.data;
					JsonData NoticeDate = JsonMapper.ToObject (getnotice.downloadHandler.text);
					date = (int)NoticeDate["date"]["cn"]; //获取公告时间
					if(!PlayerPrefs.HasKey("date")){
						PlayerPrefs.SetInt("date",date);
						_Notice.Take(true);
					}else{
						if(PlayerPrefs.GetInt("date") < date){
							Debug.Log("有新的公告");
							PlayerPrefs.SetInt("date",date);
							_Notice.Take(true);
							
						}else{
							Debug.Log("无新公告，读取本地缓存");
							_Notice.button.interactable = true;
						}
					}
					Done = true;
				}
			}
		}
	}
}
