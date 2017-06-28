<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="POS_ERP.pgs.home.login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>نظام المشتريات</title>
<link href="../../css/singin.css" rel="stylesheet" type="text/css"/>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server" class="form-signin">
      <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
</telerik:RadStyleSheetManager>
<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server"  />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" 
    DecoratedControls="All" EnableRoundedCorners="False" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <center>
    <div  >
        <center>
            <table dir="rtl" width="350px">
              <tr>
               <td>اسم المستخدم</td>
               <td align="right"><telerik:RadTextBox ID="userNameTxt" runat="server"> </telerik:RadTextBox ></td>
                <td><asp:RequiredFieldValidator ID="TextBoxRequiredFieldValidator" runat="server" Display="Dynamic"
                            ControlToValidate="userNameTxt" ErrorMessage="ادخل اسم المستخدم"></asp:RequiredFieldValidator></td>
              </tr>
                
               <tr>
               <td>كلمة المرور</td>
               <td align="right"><telerik:RadTextBox ID="password_txt" runat="server" TextMode="Password" ></telerik:RadTextBox></td>
               <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="password_txt" ErrorMessage="ادخل كلمة المرور"></asp:RequiredFieldValidator></td>
                
              </tr>
               <tr style="height:20px">
               <td></td>
               </tr>
               <tr>
               <td colspan="3">
                   <telerik:RadButton ID="Login" runat="server" Text="تسجيل الدخول" 
                       onclick="Login_Click">
                   </telerik:RadButton>
                   &nbsp;&nbsp;
                  <telerik:RadButton ID="ResetBtn" runat="server" Text="اعادة الادخال">
                   </telerik:RadButton>
               </td>
              </tr>
            </table>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="<% =ResultMessage %>"></asp:Label>
        </center>
    </div>
    </center>
    </form>
</body>
</html>
