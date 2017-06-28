<%@ Page Title="" Language="C#" MasterPageFile="~/master/finance.Master" AutoEventWireup="true" CodeBehind="Material_C.aspx.cs" Inherits="POS_ERP.pgs.inventory.Material_C" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>انشاء صنف جديد</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <center>
        <div style="height:50px"></div>
       <div style="width:600px;background-color:#D1E0E0">
       <h2>انشاء صنف جديد</h2><br/>
        <table dir="rtl">
         <tr style="text-align:right">
           <td>الشركة</td>
           <td><telerik:RadComboBox ID="lst_company" runat="server" 
                   onselectedindexchanged="lst_company_SelectedIndexChanged"></telerik:RadComboBox></td>
           <td>اسم الصنف</td>
           <td><telerik:RadTextBox ID="txt_materialname" runat="server"></telerik:RadTextBox></td>
         </tr>
          <tr style="text-align:right">
           <td>وصف الصنف</td>
           <td colspan="3">
               <telerik:RadTextBox ID="txt_material_longname" runat="server" 
                   Height="47px" Width="421px" TextMode="MultiLine"></telerik:RadTextBox ></td>
         </tr>
          <tr style="text-align:right">
           <td>فئة الصنف</td>
           <td><telerik:RadComboBox ID="lst_matr_grp" runat="server"></telerik:RadComboBox></td>
           <td>وحدة القياس</td>
           <td>
            <telerik:RadComboBox ID="lst_measure" runat="server">
            </telerik:RadComboBox></td>
         </tr>
          <tr style="text-align:right">
           <td>اقل كمية لاعادة الطلب</td>
           <td><telerik:RadTextBox ID="txt_mrp_low" runat="server"></telerik:RadTextBox></td>
           <td>اكبر كمية لمنع الطلب</td>
           <td><telerik:RadTextBox ID="txt_mrp_high" runat="server"></telerik:RadTextBox></td>
         </tr>
          <tr>
           <td colspan="2" style="text-align:left" ><telerik:RadButton ID="btn_create" 
                   runat="server" Text="انشاء الصنف" onclick="btn_create_Click">
              </telerik:RadButton></td>
           <td colspan="2" style="text-align:right"><telerik:RadButton ID="btn_reset" runat="server" Text="الغاء">
              </telerik:RadButton></td>
         </tr>
        </table>
      </div>
       </center>

</asp:Content>
