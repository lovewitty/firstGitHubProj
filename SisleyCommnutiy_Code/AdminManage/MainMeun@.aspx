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
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(2)" href="javascript:void(0);">�μ�����</a></td>
        </tr>
      </table>
      <table id="child2" style="display: none" cellspacing="0" cellpadding="0" width="150" border="0">
       
       
       
       <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainAdd.aspx" target="main">��ӿμ�</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainManage.aspx" target="main">�鿴�μ�</a></td>
        </tr>

               <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainTypeAddNew.aspx" target="main">��ӿμ����</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseMainTypeManage.aspx" target="main">�鿴�μ����</a></td>
        </tr>
      </table>
     
       <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(21)" href="javascript:void(0);">�μ���ϸ����</a></td>
        </tr>
      </table>
      <table id="child21" style="display: none" cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseDetailAddNew.aspx" target="main">��ӿμ���ϸ</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseDetailManage.aspx" target="main">�鿴�μ���ϸ</a></td>
        </tr>
      </table>


      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(3)" href="javascript:void(0);">�μ����Թ���</a></td>
        </tr>

      </table>
      <table id="child3" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
                    <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseTestTopic_DetailAddnew.aspx" target="main">��Ӳ��Ծ�</a></td>
        </tr>   
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="CourseTestTopic_DetailManage.aspx" target="main">�鿴���Ծ�</a></td>
        </tr>
        
            
      </table>
      <hr />
   <!-- 4 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(4)" href="javascript:void(0);">��ҳ΢����¼</a></td>
        </tr>

      </table>
      <table id="child4" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="weiboHomeAdd.aspx" target="main">���΢����¼</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="weiboHomeManage.aspx" target="main">�鿴΢����¼</a></td>
        </tr>               
      </table>
   <!-- 4 End -->
   <!-- 9 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(9)" href="javascript:void(0);">�����</a></td>
        </tr>

      </table>
      <table id="child9" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ActivityAddNew.aspx" target="main">��ӻ</a></td>
        </tr>
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ActivityManage.aspx" target="main">���¼</a></td>
        </tr>
         
      </table>
   <!-- 9 End -->
  <!-- 5 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(5)" href="javascript:void(0);">���λ����</a></td>
        </tr>

      </table>
      <table id="child5" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="AdvertisementAdd.aspx" target="main">��ӹ��λ</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="AdvertisementManage.aspx" target="main">�鿴���λ</a></td>
        </tr>   
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="AdvertisementEditMagazine.aspx" target="main">��ҳ��־���</a></td>
        </tr>                
      </table>
   <!-- 5 End -->
   <!-- 6 Begin-->  
   
   <!-- ��־���� --  
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(6)" href="javascript:void(0);">��־����</a></td>
        </tr>

      </table>
      <table id="child6" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">�����־</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">��־�鿴</a></td>
        </tr>
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">��־��ϸҳ��¼</a></td>
        </tr>    
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">��־�����־</a></td>
        </tr>                
      </table>
   ---->
   <!-- 6 End -->
   <hr />
   <!-- 7 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(7)" href="javascript:void(0);">ѫ�¹���</a></td>
        </tr>
        <tr height="4">

      </table>
      <table id="child7" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">ѫ���û���־</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoAdd.aspx" target="main">ѫ�»�������</a></td>
        </tr>               
      </table>
      
   <!-- 7 End -->

    <!-- 17 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(17)" href="javascript:void(0);">ϵͳ���¹���</a></td>
        </tr>

      </table>
      <table id="child17" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ArticleSisleyAddNew.aspx" target="main">����Sisley����</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ArticleSisleyManage.aspx" target="main">�鿴Sisley����</a></td>
        </tr>               
      </table>
   <!-- 17 End -->
      <!--2 7 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(27)" href="javascript:void(0);">���ò�Ʒ����</a></td>
        </tr>

      </table>
      <table id="child27" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="productTryEdit.aspx" target="main">�������ò�Ʒ</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="productTryManage.aspx" target="main">�鿴���ò�Ʒ</a></td>
        </tr>               
      </table>
   <!-- 27 End -->
     <!-- 17 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(37)" href="javascript:void(0);">���˷������</a></td>
        </tr>

      </table>
      <table id="child37" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ProductTypeManage.aspx" target="main">��Ʒ������</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="ProductManage.aspx" target="main">��Ʒ����</a></td>
        </tr>  

         
      </table>
   <!-- 17 End -->
    <!-- 27 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(27)" href="javascript:void(0);">�������Q&A</a></td>
        </tr>

      </table>
      <table id="child27" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">                  
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="SmartPerson_QA_Manage.aspx" target="main">�鿴���ʼ�¼</a></td>
        </tr>   

        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="SmartPerson_QA_TypeAddNew.aspx" target="main">������������������</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="SmartPerson_QA_TypeManage.aspx" target="main">�鿴�������</a></td>
        </tr>   
                        
      </table>
   <!-- 27 End -->

       <!-- 37 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(40)" href="javascript:void(0);">�ʴ�����01</a></td>
        </tr>

      </table>
      <table id="child40" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">                  
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="QATypeAdd.aspx" target="main">����������</a></td>
          
        </tr>             
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="QATypeManage.aspx" target="main">����������</a></td>
          
        </tr>     
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>              
        <td><a class="menuChild" href="QAManage.aspx" target="main">�������</a></td>
        </tr>   
      </table>
   <!-- 37 End -->




     <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(81)" href="javascript:void(0);">�������</a></td>
        </tr>

      </table>
      <table id="child81" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">

        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order1_CounterManage.aspx" target="main">��̨��Ϣ����</a></td>
        </tr>
                <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order2_GiftManage.aspx" target="main">������Ʒ����</a></td>
        </tr>
                <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order3_DetailManage.aspx" target="main">��ϸ��������</a></td>
        </tr>
           <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="Order4_TotalManage.aspx" target="main">�ܶ�������</a></td>
        </tr>
         
      </table>

   
   <!-- 10 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(10)" href="javascript:void(0);">���ֹ���</a></td>
        </tr>

      </table>
      <table id="child10" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">�鿴������־</a></td>
        </tr>        
         
      </table>
   <!-- 10 End -->



   <!-- ���ǲ�Ʒ -->
   <!-- ���Ǵ���-->
   <!-- ���˲���-->
   <!-- ���˷���-->
     <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(1)" href="javascript:void(0);">�û�����</a></td>
        </tr>

      </table>
      <table id="child1" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="userAdd.aspx" target="main">����û�</a></td>
        </tr>
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="userManage.aspx" target="main">�鿴�û�</a></td>
        </tr>
      </table>
    <!-- 9 Begin-->    
      <table cellspacing="0" cellpadding="0" width="150" border="0">
        <tr height="22">
          <td style="padding-left: 30px" background="images/menu_bt.jpg"><a class="menuParent" onClick="expand(20)" href="javascript:void(0);">ϵͳ�˻�����</a></td>
        </tr>
        <tr height="4">
          <td></td>
        </tr>
      </table>
      <table id="child20" style="display: none" cellspacing="0" cellpadding="0" width="150"
                    border="0">
        <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">����˻�</a></td>
        </tr>
         <tr height="20">
          <td align="middle" width="30"><img height="9" src="images/menu_icon.gif" width="9"></td>
          <td><a class="menuChild" href="VideoManage.aspx" target="main">�˻��鿴</a></td>
        </tr>
         
      </table>
   <!-- 9 End -->
   
   </td>
    <td width="1" bgcolor="#d1e6f7"></td>
  </tr>
</table>
</body>
</html>
