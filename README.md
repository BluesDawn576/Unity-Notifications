# Unity联网公告栏 (Unity-Notifications)
**一个可以快速配置的开源公告插件**

使用前需要熟悉Json结构

![预览图](https://www.bluesdawn.top/img/20200725190143.png "预览图")
### 本项目用到的第三方库
[LitJson](https://github.com/LitJSON/litjson "LitJson"): A .Net library to handle conversions from and to JSON (JavaScript Object Notation) strings.

### 注意
本项目利用UnityWebRequest进行网络请求

使用本插件时请遵守相关法律法规和[MIT开源协议](https://github.com/BluesDawn576/Unity-Notifications/blob/master/LICENSE)

## 开发环境
本项目保存的Unity版本为**2017.4.2f2**

在2018.4.11c1、2019.4.1f1测试通过

## 使用
下载源码或下载`.unitypackage`包导入你的项目

将`Assets\Notifications\Prefab`中的`Manager.prefab`拖入你的场景中即可进行配置

----

起重要作用的是`date.json`和`notice.json`（在`Assets\Notifications\Json`可找到样本）

可用的辅助工具：<https://www.sojson.com/editor.html>

把他们放进静态服务器，或者是github page

#### `date.json`的结构
```javascript
{
    "date": {
        "cn": 202007251 //最新公告版本号，key的值"cn"已在代码中写死（NoticeDate.cs第35行）
    }    
}
```
本文件的作用是判断公告的版本，与本地已有的版本号对比，小于服务端版本号即弹出公告栏

范例中的版本号仅为建议格式（时间+序号），只能为**整数**，且不能超过2147483647

#### `notice.json`的结构
```javascript
{
  "data": [
    {
      "language": "cn", //预留的多语言配置，但是插件本体并不支持多语言，有需要请自行修改插件本体
      "length": 3,  //公告数量
      "notice": [
        {
          "title": "你好", //标题
          "text": "这是一条测试公告" //内容
        },
        {
          "title": "富文本测试",
          "text": "标准\n<b>粗体</b>\n<i>斜体</i>\n<size=50>大小</size>测试\n<color=red>红色</color>"
        },
        {
          "title": "Json部分特殊符号转义",
          "text": "\\\" -- 英文双引号\n\\\\ -- 反斜杠\n\\\/ -- 斜杠\n\\n -- 换行\n\\r -- 回车符"
        }
      ]
    }
  ]
}
```
> ***Json并不支持添加注释，此处仅为帮助说明***

### 需要手动配置的内容
`Prefab(Manager\NoticeManager)`

![需要配置的内容](https://www.bluesdawn.top/img/20200725195048.jpg?v=2 "需要配置的内容")

①、③分别为获取`date.json`和`notice.json`的链接

②为可手动打开公告栏的按钮，将按钮`Interactable`改为`false`，

并调用`NoticeActive`脚本的`.OpenNotice()`函数，

![按钮](https://www.bluesdawn.top/img/20200725200652.jpg "图")

## 如何使用UGUI Text原生支持的富文本(Rich Text)
> 参考文章 <https://docs.unity3d.com/Manual/StyledText.html>

|作用|标签|例子|效果|
|----|----|----|----|
|加粗|b|\<b>Test\</b>|<b>Test</b>|
|倾斜|i|\<i>Test\</i>|<i>Test</i>|
|大小|size|\<size=40>Test\</size>|<font size=40>Test</font>|
|颜色|color|\<color=#ff0000>Test\</color>|<font color=#ff0000>Test</font>|

## Json部分特殊符号转义

在Json中，有些特殊符号会造成Json格式错误，因此我们需要进行转义

转义也非常简单，只需在特殊字符前加一个`\`即可
|转义|备注|
|----|----|
|\\"|英文双引号|
|\\\\\ |斜杠|
|\\/|反斜杠|
|\\n|换行|
|\\r|回车符|

## 写在最后

本项目由个人自行开发，如遇bug请提交issue

许可证：[MIT License](https://github.com/BluesDawn576/Unity-Notifications/blob/master/LICENSE)

如果本项目对你有帮助的话，可以给个`Star`支持一下~
