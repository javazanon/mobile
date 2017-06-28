<%@ Page Title="" Language="C#" MasterPageFile="~/master/finance.Master" AutoEventWireup="true" CodeBehind="matr_mov.aspx.cs" Inherits="POS_ERP.pgs.inventory.matr_mov" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>حركة الاصناف</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <telerik:RadSkinManager ID="QsfSkinManager" runat="server" />
        <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" 
        DecoratedControls="All" EnableRoundedCorners="False" />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls/>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <center>
        <div style="height:50px"></div>
       <div style="width:600px;background-color:#D1E0E0">
       <h2>حركة الاصناف</h2><br/>
        <table dir="rtl">
        <tr style="text-align:center">
           <td>الشركة</td>
           <td ><telerik:RadComboBox ID="lst_company" runat="server"  AutoPostBack="true"
                   onselectedindexchanged="lst_company_SelectedIndexChanged"></telerik:RadComboBox></td>
           <td>المستودع</td>
           <td ><telerik:RadComboBox ID="lst_inventory" runat="server"  AutoPostBack="true"
                   ></telerik:RadComboBox></td>
         </tr>

         <tr style="text-align:right">
           <td>الفئة</td>
           <td><telerik:RadComboBox ID="lst_MATERIAL_GRP" runat="server" AutoPostBack="true"
                   onselectedindexchanged="lst_MATERIAL_GRP_SelectedIndexChanged"  ></telerik:RadComboBox></td>
           <td> الصنف</td>
           <td><telerik:RadComboBox ID="lst_material" runat="server" 
                   ></telerik:RadComboBox></td>
         </tr>
          <tr style="text-align:right">
           <td>الحركة</td>
           <td >
               <telerik:RadComboBox ID="lst_movmenet" runat="server" 
                   ></telerik:RadComboBox></td>
           <td>الكمية</td>
           <td >
               <telerik:RadTextBox ID="txt_qty" runat="server" ></telerik:RadTextBox ></td>
          
         </tr>
         <tr style="text-align:right">
         <td>الملاحظات</td>
           <td colspan="3">
               <telerik:RadTextBox ID="txt_description" runat="server" TextMode="MultiLine" 
                   Width="329px"></telerik:RadTextBox ></td>
         </tr>
          <tr>
           <td colspan="2" style="text-align:left" >
               <telerik:RadButton ID="btn_create" 
                   runat="server" Text="انشاء " onclick="btn_create_Click1" >
              </telerik:RadButton></td>
           <td colspan="2" style="text-align:right"><telerik:RadButton ID="btn_reset" runat="server" Text="الغاء">
              </telerik:RadButton></td>
         </tr>
        </table>
      </div>
   </center>   
</asp:Content>
