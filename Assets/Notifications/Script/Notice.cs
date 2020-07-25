using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class Notice : MonoBehaviour {
	public NoticeRead _NoticeRead;
	public GameObject notifications;
	public Button button;

	[Header("获取公告内容的链接(*.json)")]
	public string url;


	public void Take(bool New){
		StartCoroutine(Notifications(New));
	}

	IEnumerator Notifications(bool New)
	{
		using (UnityWebRequest getnotice = UnityWebRequest.Get (url)) 
			{
				getnotice.timeout = 10;
				yield return getnotice.SendWebRequest();
				if (getnotice.isHttpError||getnotice.isNetworkError)
                {
					Debug.LogError("错误：无法连接至服务器");
				} else {
					byte[] results = getnotice.downloadHandler.data;
					string dataPath = Application.persistentDataPath + "/notice.json"; //公告缓存路径
        			string infoPath = Application.persistentDataPath + "/Info.txt"; //MD5储存路径，对比时用
					Debug.Log("正在处理内容，请稍等");
        		    File.WriteAllText(dataPath, getnotice.downloadHandler.text); //写入文件
					string info = MD5HashFromFile.GetMD5HashFromFile(dataPath); //获取文件MD5
					Debug.Log("该公告MD5为："+info);
					File.WriteAllText(infoPath, info);
					button.interactable = true;
					if(New){
						notifications.SetActive(true);
						_NoticeRead.ReadTxt();
					}
					Debug.Log("公告读取完成");
				}
			}
	}
}
