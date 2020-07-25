using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class NoticeRead : MonoBehaviour {
	public Notice _Notice;
	public GameObject Prefab,content;
	string[] title,_text;
	JsonData js;
	string text;
	int length;
	bool ok,first;

	public void ReadTxt(){
		string dataPath = Application.persistentDataPath + "/notice.json";
        string infoPath = Application.persistentDataPath + "/Info.txt";
		if (File.Exists(dataPath)&&File.Exists(infoPath)){ //验证文件是否存在
			string info = MD5HashFromFile.GetMD5HashFromFile(dataPath);
			string readinfo = File.ReadAllText(infoPath);
			if(info == readinfo)//验证MD5是否一致
			{
				var txt = File.ReadAllText(dataPath);
				ReadJson(txt);
			}else{
				Debug.Log("文件被修改，重新从服务器拉取");
				_Notice.Take(false);
			}
		}else{
			Debug.Log("文件不存在，重新从服务器拉取");
			_Notice.Take(false);
		}
	}
	public void ReadJson(string txt){
		js = JsonMapper.ToObject(txt);
		length = (int)js["data"][0]["length"];
		ReadMessage(0);
	}
	void ReadMessage(int a){ //解析公告内容
		if(!ok){
		title = new string[length];
		_text = new string[length];
		for (int i = 0; i < length; i++)
		{
			title[i] = (string)js["data"][a]["notice"][i]["title"];
			_text[i] = (string)js["data"][a]["notice"][i]["text"];
		}
		for(int s = 0; s < length; s++)
		{
			var create = Instantiate(Prefab,content.transform);
			var cs = create.GetComponent<NoticeButton>();
			cs.Text(title[s],_text[s]);
			if(!first){ //自动选中第一个公告
				cs.ReadMessage();
				first = true;
			}
		}
		}
		ok = true;
	}
}
