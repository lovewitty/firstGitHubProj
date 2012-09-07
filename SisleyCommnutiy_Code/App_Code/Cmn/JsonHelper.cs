using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;


    /**/
    /// <summary>
    /// JSONHelper 的摘要说明
    /// </summary>
public class JsonHelper
{
    /// <summary>
    /// 把对象转换为json字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string GetJson<T>(T obj)
    {
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            json.WriteObject(ms, obj);
            string szJson = Encoding.UTF8.GetString(ms.ToArray());
            return szJson;
        }
    }

    /// 把json字符串还原为对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="szJson"></param>
    /// <returns></returns>
    public static T ParseFormJson<T>(string szJson)
    {
        T obj = Activator.CreateInstance<T>();
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
        {
            DataContractJsonSerializer dcj = new DataContractJsonSerializer(typeof(T));
            return (T)dcj.ReadObject(ms);
        }
    }
}
