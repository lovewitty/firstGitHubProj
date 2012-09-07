<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MainMeun.aspx.cs" Inherits="Admin_MainMeun" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>

<link href="css/admin.css" type="text/css" rel="stylesheet">
<script language="javascript">
        function expand(el) {
            childObj = document.getElementById("child" + el);

            if (childObj.style.display == 'none') {
                childObj.style.display = 'block';
            }
            else {
                childObj.style.display = 'none';
            }
            return;
        }
    </script>
</head>
<body>
<table height="100%" cellspacing="0" cellpadding="0" width="170" background="images/menu_bg.jpg"
        border="0">
  <tr>
    <td valign="top" align="middle"><table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
          <td height="10"></td>
        </tr>
      </table>
    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(2)" href="javascript:void(0);">课件管理</a></td>
        </tr>
      </table>
      <table id="child2" style="display: none" cellspacing="0" cellpadding="0" width="150" border="0">
       
       
       
       <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainAdd.aspx" target="main">添加课件</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainManage.aspx" target="main">查看课件</a></td>
        </tr>

               <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainTypeAddNew.aspx" target="main">添加课件类别</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainTypeManage.aspx" target="main">查看课件类别</a></td>
        </tr>
      </table>
     
       <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(21)" href="javascript:void(0);">课件详细管理</a></td>
        </tr>
      </table>
      <table id="child21" style="display: none" cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseDetailAddNew.aspx" target="main">添加课件详细</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseDetailManage.aspx" target="main">查看课件详细</a></td>
        </tr>
      </table>


      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(3)" href="javascript:void(0);">课件测试管理</a></td>
        </tr>

      </table>
      <table id="child3" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
                    <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseTestTopic_DetailAddnew.aspx" target="main">添加测试卷</a></td>
        </tr>   
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseTestTopic_DetailManage.aspx" target="main">查看测试卷</a></td>
        </tr>
        
            
      </table>
      <hr />
   <!-- 4 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(4)" href="javascript:void(0);">首页微博记录</a></td>
        </tr>

      </table>
      <table id="child4" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="weiboHomeAdd.aspx" target="main">添加微博记录</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="weiboHomeManage.aspx" target="main">查看微博记录</a></td>
        </tr>               
      </table>
   <!-- 4 End -->
   <!-- 9 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(9)" href="javascript:void(0);">活动管理</a></td>
        </tr>

      </table>
      <table id="child9" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ActivityAddNew.aspx" target="main">添加活动</a></td>
        </tr>
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ActivityManage.aspx" target="main">活动记录</a></td>
        </tr>
         
      </table>
   <!-- 9 End -->
  <!-- 5 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(5)" href="javascript:void(0);">广告位管理</a></td>
        </tr>

      </table>
      <table id="child5" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="AdvertisementAdd.aspx" target="main">添加广告位</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="AdvertisementManage.aspx" target="main">查看广告位</a></td>
        </tr>   
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="AdvertisementEditMagazine.aspx" target="main">首页杂志广告</a></td>
        </tr>                
      </table>
   <!-- 5 End -->
   <!-- 6 Begin-->  
   
   <!-- 杂志管理 --  
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(6)" href="javascript:void(0);">杂志管理</a></td>
        </tr>

      </table>
      <table id="child6" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">添加杂志</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">杂志查看</a></td>
        </tr>
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">杂志详细页记录</a></td>
        </tr>    
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">杂志浏览日志</a></td>
        </tr>                
      </table>
   ---->
   <!-- 6 End -->
   <hr />
   <!-- 7 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(7)" href="javascript:void(0);">勋章管理</a></td>
        </tr>
        <tr height="4">

      </table>
      <table id="child7" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">勋章用户日志</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">勋章基础数据</a></td>
        </tr>               
      </table>
      
   <!-- 7 End -->

    <!-- 17 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(17)" href="javascript:void(0);">系统文章管理</a></td>
        </tr>

      </table>
      <table id="child17" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ArticleSisleyAddNew.aspx" target="main">新增Sisley文章</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ArticleSisleyManage.aspx" target="main">查看Sisley文章</a></td>
        </tr>               
      </table>
   <!-- 17 End -->
      <!--2 7 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(27)" href="javascript:void(0);">试用产品管理</a></td>
        </tr>

      </table>
      <table id="child27" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="productTryEdit.aspx" target="main">新增试用产品</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="productTryManage.aspx" target="main">查看试用产品</a></td>
        </tr>               
      </table>
   <!-- 27 End -->
     <!-- 17 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(37)" href="javascript:void(0);">达人分享管理</a></td>
        </tr>

      </table>
      <table id="child37" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ProductTypeManage.aspx" target="main">产品类别管理</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ProductManage.aspx" target="main">产品管理</a></td>
        </tr>  

         
      </table>
   <!-- 17 End -->
    <!-- 27 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(27)" href="javascript:void(0);">贴身达人Q&A</a></td>
        </tr>

      </table>
      <table id="child27" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">                  
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="SmartPerson_QA_Manage.aspx" target="main">查看提问记录</a></td>
        </tr>   

        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="SmartPerson_QA_TypeAddNew.aspx" target="main">新增贴身达人提问类别</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="SmartPerson_QA_TypeManage.aspx" target="main">查看提问类别</a></td>
        </tr>   
                        
      </table>
   <!-- 27 End -->

       <!-- 37 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(40)" href="javascript:void(0);">问答表管理01</a></td>
        </tr>

      </table>
      <table id="child40" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">                  
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="QATypeAdd.aspx" target="main">添加问题类别</a></td>
          
        </tr>             
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="QATypeManage.aspx" target="main">问题类别管理</a></td>
          
        </tr>     
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>              
        <td><a class="menuChild" href="QAManage.aspx" target="main">问题管理</a></td>
        </tr>   
      </table>
   <!-- 37 End -->




     <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(81)" href="javascript:void(0);">订单相关</a></td>
        </tr>

      </table>
      <table id="child81" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">

        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order1_CounterManage.aspx" target="main">柜台信息管理</a></td>
        </tr>
                <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order2_GiftManage.aspx" target="main">积分礼品管理</a></td>
        </tr>
                <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order3_DetailManage.aspx" target="main">详细订单管理</a></td>
        </tr>
           <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order4_TotalManage.aspx" target="main">总订单管理</a></td>
        </tr>
         
      </table>

   
   <!-- 10 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(10)" href="javascript:void(0);">积分管理</a></td>
        </tr>

      </table>
      <table id="child10" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">查看积分日志</a></td>
        </tr>        
         
      </table>
   <!-- 10 End -->



   <!-- 明星产品 -->
   <!-- 明星达人-->
   <!-- 达人测评-->
   <!-- 达人分享-->
     <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(1)" href="javascript:void(0);">用户管理</a></td>
        </tr>

      </table>
      <table id="child1" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="userAdd.aspx" target="main">添加用户</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="userManage.aspx" target="main">查看用户</a></td>
        </tr>
      </table>
    <!-- 9 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(20)" href="javascript:void(0);">系统账户管理</a></td>
        </tr>
        <tr height="4">
          <td></td>
        </tr>
      </table>
      <table id="child20" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">添加账户</a></td>
        </tr>
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">账户查看</a></td>
        </tr>
         
      </table>
   <!-- 9 End -->
   
   </td>
    <td width="1" bgcolor="#d1e6f7"></td>
  </tr>
</table>
</body>
</html>
