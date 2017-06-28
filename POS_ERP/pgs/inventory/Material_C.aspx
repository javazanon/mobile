<%@ Page Title="" Language="C#" MasterPageFile="~/pgs/master/finance.Master" AutoEventWireup="true" CodeBehind="Material_C.aspx.cs" Inherits="POS_ERP.pgs.inventory.Material_C" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>انشاء صنف جديد</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h3>انشاء صنف جديد</h3>
        <div class="row">
            <div class="col-sm-3">
                <asp:Label runat="server" Text="الشركة" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <telerik:RadComboBox ID="lst_company" runat="server"
                    OnSelectedIndexChanged="lst_company_SelectedIndexChanged">
                </telerik:RadComboBox>
            </div>
            <div class="col-sm-3">
                <asp:Label ID="Label1" runat="server" Text="اسم الصنف" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <telerik:RadTextBox ID="txt_materialname" runat="server"></telerik:RadTextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <asp:Label ID="Label2" runat="server" Text="وصف الصنف" CssClass="form-control" />
            </div>
            <div class="col-sm-9">
                <telerik:RadTextBox ID="txt_material_longname" runat="server"
                    Height="47px" Width="421px" TextMode="MultiLine">
                </telerik:RadTextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <asp:Label ID="Label4" runat="server" Text="فئة الصنف" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <telerik:RadComboBox ID="lst_matr_grp" runat="server"></telerik:RadComboBox>
            </div>
            <div class="col-sm-3">
                <asp:Label ID="Label5" runat="server" Text="وحدة القياس" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <telerik:RadComboBox ID="lst_measure" runat="server">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <asp:Label ID="Label3" runat="server" Text="اقل كمية لاعادة الطلب" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <telerik:RadTextBox ID="txt_mrp_low" runat="server"></telerik:RadTextBox>
            </div>
            <div class="col-sm-3">
                <asp:Label ID="Label6" runat="server" Text="اكبر كمية لمنع الطلب" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <telerik:RadTextBox ID="txt_mrp_high" runat="server"></telerik:RadTextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <telerik:RadButton ID="btn_create" runat="server" Text="انشاء الصنف" OnClick="btn_create_Click" />
                <telerik:RadButton ID="btn_reset" runat="server" Text="الغاء" />
            </div>
        </div>
    </div>



</asp:Content>
