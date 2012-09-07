using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///AdHelper 的摘要说明
/// </summary>
public class AdHelper
{
	public AdHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 根据广告位获取广告的信息
    /// </summary>
    /// <param name="adPostion"></param>
    /// <returns>实体</returns>
    public static DBEntity.Tab_Advertisement GetAd(string adPostion)
    {
        DBEntity.Tab_Advertisement ent = new DBEntity.Tab_Advertisement();
        ent =ent.GetByPostionName(adPostion);
        return ent;
    }
}