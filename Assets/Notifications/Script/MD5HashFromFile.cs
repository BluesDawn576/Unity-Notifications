﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class MD5HashFromFile {

	public static string GetMD5HashFromFile(string fileName)
    {
    try
    {
    	FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] retVal = md5.ComputeHash(file);
        file.Close();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < retVal.Length; i++)
        {
            sb.Append(retVal[i].ToString("x2"));
        }
        return sb.ToString();
    }
    catch (Exception ex)
    {
        throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
    }
	}
}
