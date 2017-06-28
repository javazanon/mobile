<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="POS_ERP.pgs.account.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>نظام حورس لادارة المؤسسات </title>
    <link href="../../resx/css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="images/master.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="images/variant-creative.css" media="screen" />
    <link href="tooplate_style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tooplate_menu ul li a {
            font-family: 'DroidArabicKufiBold' !important;
        }

        .AllContent {
            margin-left: auto;
            margin-right: auto;
            width: 1100px;
            direction: rtl;
            box-shadow: 10px 10px 10px 10px;
        }

        .Content {
        }

        .InnerContent {
            min-height: 650px;
            padding: 10px;
        }

        .PageTitle {
            font-weight: bold;
            color: green;
            font-family: 'DroidArabicKufiBold' !important;
            font-size: 17px;
            text-align: right;
        }

        .gridTable1 {
            width: 100%;
        }

            .gridTable1 tr {
            }

                .gridTable1 tr:hover {
                    font-weight: bold;
                    color: green;
                }

            .gridTable1 td {
                border: hidden;
            }

            .gridTable1 th {
                text-align: center;
                padding: 5px;
            }

        .gridTable {
            width: 100%;
        }

            .gridTable tr {
            }

                .gridTable tr:hover {
                    font-weight: bold;
                    color: green;
                }

            .gridTable td {
                border: 1px solid #ccc;
            }

            .gridTable th {
                text-align: center;
                padding: 5px;
            }

        .MenuDivBar {
            background-color: #CECECE;
            text-align: center;
            height: 40px;
            padding-right: 50px;
        }

            .MenuDivBar .itemMen {
                padding: 5px;
                margin: 2px;
                padding-left: 15px;
                padding-right: 15px;
                float: right;
            }

        .itemMen:hover {
            background-color: #669C41 !important;
            color: white;
            text-decoration: none;
        }

            .itemMen:hover > a {
                color: white;
                text-decoration: none;
            }

        .divFooter {
            background-color: #808080;
            color: white;
            height: 30px;
            text-align: center;
            font-family: 'DroidArabicKufiBold' !important;
            font-size: 12px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="AllContent">
            <div class="Content">
                <div class="HeaderDiv" runat="server" id="trbannar">
                    <img alt="" src="../../resx/img/header.png" width="100%" />

                </div>
                <div class="InnerContent">
                  

                        <table border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td background="../../resx/img/1.png" height="251" colspan="3" style="width: 557px; text-align: center;">
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="wrongdata" runat="server" Font-Bold="true" ForeColor="Red" Style="font-size: large" Visible="false"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td background="../../resx/img/slogin_16.png" height="38" width="217"></td>
                                <td background="../../resx/img/slogin_15.bmp" height="38" width="181"></td>
                                <td background="../../resx/img/slogin_14.bmp" height="38" width="340"></td>
                            </tr>
                            <tr>
                                <td background="../../resx/img/slogin_22.png" height="38" width="217">&nbsp;</td>
                                <td background="../../resx/img/slogin_21.png" height="38" width="181" style="text-align: center">
                                    <asp:TextBox ID="userNameTxt" runat="server" Style="text-align: center" Width="145px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="userNameTxt" ErrorMessage="*" Style="color: #FF0000; font-family: Georgia, 'Times New Roman', Times, serif; font-size: 12pt"></asp:RequiredFieldValidator>
                                </td>
                                <td background="../../resx/img/slogin_20.png" height="38" width="217"></td>
                            </tr>
                            <tr>
                                <td background="../../resx/img/slogin_28.png" height="47" width="217">&nbsp;</td>
                                <td background="../../resx/img/slogin_27.png" height="47" width="181"></td>
                                <td background="../../resx/img/slogin_26.png" height="47" width="340"></td>
                            </tr>
                            <tr>
                                <td background="../../resx/img/slogin_34.png" height="41" width="217" style="text-align: center">&nbsp;</td>
                                <td background="../../resx/img/slogin_33.png" height="41" width="181" style="text-align: center">
                                    <asp:TextBox ID="password_txt" runat="server" Style="text-align: center" TextMode="Password" Width="145px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password_txt" ErrorMessage="*" Style="color: #FF0000; font-family: Georgia, 'Times New Roman', Times, serif; font-size: 12pt"></asp:RequiredFieldValidator>
                                </td>
                                <td background="../../resx/img/slogin_32.png" height="41" width="340">&nbsp;</td>
                            </tr>
                            <tr>
                                <td background="../../resx/img/slogin_40.png" height="104" width="217">&nbsp;</td>
                                <td background="../../resx/img/slogin_39.png" height="104" width="181" style="text-align: center">&nbsp;</td>
                                <td background="../../resx/img/slogin_38.png" height="104" width="340">&nbsp;</td>
                            </tr>
                            <tr>
                                <td background="../../resx/img/7.png" height="58" colspan="3" style="width: 557px; text-align: center;">&nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn-success" Height="47px" OnClick="Login_Click" Style="font-family: 'hacen Saudi Arabia'; font-size: large; background-color: #446630;" Text="تسجيل الدخول" Width="293px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <div align="center">

                            <b class="rbottom1"><b class="r444"></b><b class="r333"></b><b class="r222"></b><b class="r111"></b></b>
                        </div>




                        <style type="text/css">
                            .auto-style18 {
                                width: 435px;
                                background-color: #C3C3C2;
                            }

                            .auto-style23 {
                                background-color: #C3C3C2;
                            }

                            .auto-style28 {
                                font-size: x-large;
                                color: #44662f;
                            }

                            .auto-style29 {
                                color: #446630;
                                font-family: "hacen Saudi Arabia";
                            }

                            .auto-style31 {
                                width: 1179px;
                                background-color: #C3C3C2;
                                font-family: "hacen Saudi Arabia";
                            }
                        </style>
                </div>
            </div>

            <div class="divFooter">
                جميع الحقوق محفوظة     &copy;  نظام حورس لادارة موارد المؤسسة
              <%= DateTime.Now.Year %>
            </div>
            ة
        </div>
    </form>
</body>
</html>
