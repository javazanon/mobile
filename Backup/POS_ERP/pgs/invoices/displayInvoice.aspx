<%@ Page Title="" Language="C#" MasterPageFile="~/master/finance.Master" AutoEventWireup="true" CodeBehind="displayInvoice.aspx.cs" Inherits="POS_ERP.pgs.invoices.displayInvoice" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js" > </script>
<script type="text/javascript">


function printdiv(printpage)
{
var headstr = "<html><head><title></title></head><body>";
var footstr = "</body>";
var newstr = document.getElementById("myDiv").innerHTML;
var oldstr = document.body.innerHTML;
document.body.innerHTML = headstr+newstr+footstr;
window.print();
document.body.innerHTML = oldstr;
return false;
}

</script>
 <title>طباعه الفاتورة</title>
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
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
 <% 
      POS_ERP.com.zanon.ERP.beans.ShoppingCart shopCart =(POS_ERP.com.zanon.ERP.beans.ShoppingCart)  Session[POS_ERP.com.zanon.ERP.config.SessionKeys.shoppingCart] ; 
  %>
<center style="width:800px">
    <div style="width:800px" id="myDiv">
      <center>
      <table style="width:800px" dir="rtl">
        <tr>
         <td align="right"><%= shopCart.company.cmp_lng_nme %></td>
         <td align="left">التاريخ : <%= shopCart.shoppingGregDate %></td>
        </tr>
        <tr>
            <td align="right">جدة شارع التحلية</td>
            <td align="left">الموافق :  /  /  14هــ</td>
        </tr>
        <tr>
            <td colspan="2" align="right">ت:<%= shopCart.company.telephone %></td>
        </tr>
        <tr>
            <td colspan="2" align="right">جوال : <%= shopCart.company.mobile %></td>
        </tr>
      </table>

      <table style="background-color:Gray;font-size:18;font-weight:bold">
      <tr>
        <td> فاتورة </td>
      </tr>
       <tr>
        <td> رقم : <%= shopCart.orderID %> </td>
      </tr>
      </table>


      <table style="width:800px" dir="rtl">
      <tr>
        <td align="right" class="style2"> المطلوب من المكرم : / </td>
        <td align="right"><%= shopCart.customer.LONG_NAME %>  </td>
        <td align="right">المحترم </td>
      </tr>
      </table>
      <br />
      <table  border="1" style="width:800px;height:200px;" dir="rtl">
         <thead style="background-color:Gray">
           <th>الصنف</th>
           <th>الكمية</th>
           <th>الوحدة</th>
           <th>سعر افرادى</th>
           <th>اجمالى</th>
         </thead>
         <tbody >         
           <% 
               float total = 0;
               for(int i=0;i<shopCart.items.Count;i++){
               POS_ERP.com.zanon.ERP.beans.ShoppingLineItemBean lineItem =    shopCart.items[i];
                   total+=lineItem.totla_after_deduction ;
                  %>
                  <tr valign="top">
                    <td><%= lineItem.Material_name %></td>
                    <td><%= lineItem.qnty %></td>
                    <td>-</td>
                    <td><%= lineItem.unit_price %></td>
                    <td><%= lineItem.totla_after_deduction %></td>
                  </tr>
                  <%
              } %>
         </tbody>
      </table>
      <table style="width:800px">
         <tr>
            <td style="text-align:left">المبلغ المطلوب   <%= total %>  ريال سعودى</td>
         </tr>
      </table>
      <br /><br />
      <table style="width:800px">
        <tr>
          <td style="text-align:left">
                   التوقيع : <%= shopCart.company.cmp_lng_nme %>
          </td>
        </tr>
      </table>
      </center>
    </div>
    <table style="width:800px">
    <tr>
      <td><input type="button" value="طباعه"  onclick="printdiv('myDiv')" /></td>
    </tr>
    </table>
</center>
</asp:Content>
