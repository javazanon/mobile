<%@ Page Title="" Language="C#" MasterPageFile="~/pgs/master/finance.Master" AutoEventWireup="true" CodeBehind="OrderRequest.aspx.cs" Inherits="POS_ERP.pgs.order.OrderRequest" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>المبيعات</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <telerik:RadDockZone runat="server" ID="RadDockZoneHorizontal1" Orientation="Vertical"
               Height="450px" Width="100%" >
    <telerik:RadDock runat="server" ID="RadDock1" Title="بيانات العميل والمخزن" Text="RadDock1">
     <ContentTemplate>
      <table dir="rtl" style="width:100%">
         <tr style="text-align:center">
               <td>الشركة</td>
               <td ><telerik:RadComboBox ID="lst_company" runat="server"  AutoPostBack="true"
                       ></telerik:RadComboBox></td>
               <td> المستودع</td>
               <td>
                  <telerik:RadComboBox ID="lst_storage" runat="server" AutoPostBack="true">
                  </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="Validator1" Runat="server"
                       ControlToValidate="lst_storage" Display="Static" Text="اختر المستودع">
                       </asp:RequiredFieldValidator>
                </td>
                
               <td> طريقة التسليم</td>
               <td><telerik:RadComboBox ID="lst_delivery_method" runat="server" AutoPostBack="true">
                   </telerik:RadComboBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Runat="server"
                       ControlToValidate="lst_delivery_method" Display="Static" Text="اختر طريقة التسليم">
                       </asp:RequiredFieldValidator> 
               </td>
           </tr>
           <tr>
             <td> فئة العميل</td>
               <td><telerik:RadComboBox ID="lst_cust_grp" runat="server" AutoPostBack="true"
                       ></telerik:RadComboBox></td>
             <td> العميل</td>
               <td><telerik:RadComboBox ID="lst_customer" runat="server" AutoPostBack="true">
                       </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Runat="server"
                       ControlToValidate="lst_customer" Display="Static" Text="اختر العميل">
                       </asp:RequiredFieldValidator> 
               </td>
           </tr>
           <tr>
               <td> رقم مرجعى</td>
               <td><telerik:RadTextBox ID="txt_refernce" runat="server" AutoPostBack="true"
                       ></telerik:RadTextBox></td>
               <td > ملاحظات</td>
               <td colspan="5" align="right">
                   <telerik:RadTextBox ID="txt_header" runat="server" AutoPostBack="true"
                        TextMode="MultiLine" Width="485px" ></telerik:RadTextBox></td>
           </tr>
          </table>
        </ContentTemplate>
      </telerik:RadDock>
      <telerik:RadDock runat="server" ID="RadDock2" Title="الاصناف" Text="RadDock1">
       <ContentTemplate>
         <table>
          <tr> 
              <td>المجموعه</td>
               <td ><telerik:RadComboBox ID="lst_MATERIAL_GRP" runat="server"  AutoPostBack="true"
                       ></telerik:RadComboBox></td>
               <td> الصنف</td>
               <td><telerik:RadComboBox ID="lst_MATERIAL" runat="server" AutoPostBack="true" >
                       </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Runat="server"
                       ControlToValidate="lst_MATERIAL" Display="Static" Text="اختر الصنف">
                       </asp:RequiredFieldValidator> 
                </td>
               <td> الكمية</td>
               <td><telerik:RadTextBox ID="txt_qnty" runat="server" AutoPostBack="true">
                       </telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Runat="server"
                       ControlToValidate="txt_qnty" Display="Static" Text="اختر الكمية">
                       </asp:RequiredFieldValidator> 
               </td>
               <td> التخفيض</td>
               <td><telerik:RadTextBox ID="txt_deduction" runat="server" AutoPostBack="true">
                       </telerik:RadTextBox></td>
          </tr>
          <tr>
            <td colspan="8" align="center"> 
            <telerik:RadButton ID="btn_AddItem_to_shoppingcart" 
                    Text=" اضافةالصنف" runat="server" onclick="btn_AddItem_to_shoppingcart_Click"></telerik:RadButton>
                    ____________
                    <telerik:RadButton ID="btn_checkStock" 
                    Text="مخزون الصنف" runat="server" onclick="btn_checkStock_Click"></telerik:RadButton>
                     </td>
          </tr>
         </table>
       </ContentTemplate>
      </telerik:RadDock>
       <telerik:RadDock runat="server" ID="RadDock3" Title="تفاصيل الفاتورة" Text="RadDock1">
        <ContentTemplate>
          <telerik:RadGrid ID="grid_ShoppingLineItems" runat="server" Width="700px" Height="200px"
               ShowStatusBar="True" AutoGenerateColumns="False" 
                 CellSpacing="0" GridLines="None"  OnNeedDataSource="ShoppingCartLineItemsNeedDataSource">
                <PagerStyle Mode="NumericPages"></PagerStyle>
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView Width="100%"  AllowMultiColumnSorting="True" 
                CommandItemDisplay="TopAndBottom" DataKeyNames="Material_id"> 
                 <CommandItemTemplate >
                        <div style="text-align:right">
                         <telerik:RadButton Text="حذف صنف" ID="btn_delete_row" runat="server" OnClick="deleteRowFromShoopingCard_Click" />
                         </div>
                 </CommandItemTemplate>
                    <Columns>
                     <telerik:GridBoundColumn SortExpression="Material_id" HeaderText="رقم الصنف" HeaderButtonType="TextButton"
                                    DataField="Material_id" UniqueName="Material_id">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn SortExpression="Material_name" HeaderText="الصنف" HeaderButtonType="TextButton"
                                    DataField="Material_name" UniqueName="Material_name">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn SortExpression="qnty" HeaderText="الكمية" HeaderButtonType="TextButton"
                                    DataField="qnty" UniqueName="qnty">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn SortExpression="unit_price" HeaderText="سعر الوحدة" HeaderButtonType="TextButton"
                                    DataField="unit_price" UniqueName="unit_price">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn SortExpression="totla_before_deduction" HeaderText="الاجمالى" HeaderButtonType="TextButton"
                                    DataField="totla_before_deduction">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn SortExpression="deduction" HeaderText="التخفيض" HeaderButtonType="TextButton"
                                    DataField="deduction" UniqueName="deduction">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn SortExpression="totla_after_deduction" HeaderText="الاجمالى بعد التخفيض" HeaderButtonType="TextButton"
                                    DataField="totla_after_deduction" UniqueName="totla_after_deduction">
                                </telerik:GridBoundColumn>
                     </Columns>
                  </MasterTableView>
             </telerik:RadGrid>
         </ContentTemplate>
    </telerik:RadDock>
   </telerik:RadDockZone>
   <table width="100%">
      <tr>
        <td><telerik:RadButton id="btnSaveBill" Text="تسجيل الفاتورة" runat="server" OnClick="btnsaveBill_clicked"/></td>
      </tr>
   </table>
</center> 
</asp:Content>
