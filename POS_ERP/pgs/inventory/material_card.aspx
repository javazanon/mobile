<%@ Page Title="" Language="C#" MasterPageFile="~/pgs/master/finance.Master" AutoEventWireup="true" CodeBehind="material_card.aspx.cs" Inherits="POS_ERP.pgs.inventory.material_card" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>كارتة الاصناف</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
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
       <div style="width:700px;background-color:#D1E0E0">
       <h2>كارتة الاصناف</h2><br/>
      <table dir="rtl">
        <tr style="text-align:center">
           <td>الشركة</td>
           <td ><telerik:RadComboBox ID="lst_company" runat="server"  AutoPostBack="true"
                   ></telerik:RadComboBox></td>
          <td> المستودع</td>
           <td><telerik:RadComboBox ID="lst_storage" runat="server" AutoPostBack="true"
                   ></telerik:RadComboBox></td>
           <td>الفئة</td>
           <td><telerik:RadComboBox ID="lst_MATERIAL_GRP" runat="server" AutoPostBack="true"
                    ></telerik:RadComboBox></td>
         </tr>
         <tr style="text-align:center">
          <td colspan="6" ><telerik:RadButton ID="btn_create" 
                   runat="server" Text="عرض كارتة الصنف " ></telerik:RadButton></td>
         </tr>
        </table>
      </div>
      <br /><br /><br />
      <div style="overflow:auto;width:700px;height:300">
    
    <telerik:RadGrid ID="grid_item_cards" runat="server" Width="95%" 
       ShowStatusBar="True" AutoGenerateColumns="False"
        PageSize="25" AllowSorting="True" AllowPaging="True"  
         CellSpacing="0" GridLines="None"  >
        <PagerStyle Mode="NumericPages"></PagerStyle>
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Animation AllowColumnReorderAnimation="true" />
            <Scrolling FrozenColumnsCount="1" />
        </ClientSettings>
        <MasterTableView Width="100%"  AllowMultiColumnSorting="True" AllowFilteringByColumn="true"
        CommandItemDisplay="TopAndBottom"> 
        
			<EditFormSettings>
			<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
			</EditFormSettings>
        
         <CommandItemTemplate>
                <div style="text-align:right">
                 </div>
         </CommandItemTemplate>
            <Columns>
                         <telerik:GridBoundColumn SortExpression="MATERIAL_name" HeaderText="الصنف" HeaderButtonType="TextButton"
                            DataField="MATERIAL_name" UniqueName="MATERIAL_name">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn SortExpression="INITIAL_QNTY" HeaderText="رصيد مرحل" HeaderButtonType="TextButton"
                            DataField="INITIAL_QNTY" UniqueName="INITIAL_QNTY">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn SortExpression="CURRENT_QNTY" HeaderText="رصيد حالى" HeaderButtonType="TextButton"
                            DataField="CURRENT_QNTY" UniqueName="CURRENT_QNTY">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn SortExpression="MRP_LOW" HeaderText="اقل كمية" HeaderButtonType="TextButton"
                            DataField="MRP_LOW">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn SortExpression="MRP_HIGH" HeaderText="اعلى كمية" HeaderButtonType="TextButton"
                            DataField="MRP_HIGH" UniqueName="MRP_HIGH">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn SortExpression="lastupdate" HeaderText="اخر تحديث" HeaderButtonType="TextButton"
                            DataField="lastupdate" UniqueName="lastupdate">
                        </telerik:GridBoundColumn>
                        
                        
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    </div>
   </center>   
</asp:Content>
