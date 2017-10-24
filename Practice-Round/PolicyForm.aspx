<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PolicyForm.aspx.cs" Inherits="PolicyForm" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style9 {
        width: 231px;
            margin-left: 80px;
            height: 46px;
            text-align: right;
        }
        .auto-style18 {
            height: 16px;
        }
        .auto-style19 {
            width: 578px;
            height: 624px;
        }
        .auto-style33 {
            height: 13px;
            width: 277px;
            text-align: left;
        }
        .auto-style57 {
            height: 46px;
            width: 161px;
        }
        .auto-style63 {
            height: 46px;
            width: 277px;
        }
        .auto-style65 {
        width: 161px;
        height: 13px;
    }
        .auto-style66 {
            width: 277px;
            height: 13px;
        }
        .auto-style69 {
            width: 277px;
            height: 16px;
        }
        .auto-style71 {
            width: 161px;
            height: 11px;
        }
        .auto-style72 {
            width: 277px;
            height: 11px;
        }
        .auto-style74 {
            width: 161px;
            height: 5px;
        }
        .auto-style75 {
            width: 277px;
            height: 5px;
        }
        .auto-style77 {
            width: 161px;
            height: 8px;
        }
        .auto-style78 {
            width: 277px;
            height: 8px;
        }
        .auto-style80 {
            width: 161px;
            height: 4px;
        }
        .auto-style81 {
            width: 277px;
            height: 4px;
        }
        .auto-style83 {
            width: 161px;
            height: 10px;
        }
        .auto-style84 {
            width: 277px;
            height: 10px;
        }
    .auto-style85 {
        width: 231px;
        height: 13px;
    }
    .auto-style86 {
        width: 231px;
        height: 16px;
    }
    .auto-style87 {
        width: 231px;
        height: 11px;
    }
    .auto-style88 {
        width: 231px;
        height: 5px;
    }
    .auto-style89 {
        width: 231px;
        height: 8px;
    }
    .auto-style90 {
        width: 231px;
        height: 4px;
    }
    .auto-style91 {
        width: 231px;
        height: 10px;
    }
    .auto-style92 {
        height: 46px;
        width: 231px;
    }
    .auto-style93 {
        height: 16px;
        width: 161px;
    }
        .auto-style94 {
            width: 100%;
        }
        .auto-style95 {
            width: 178px;
        }
        .auto-style96 {
            height: 23px;
        }
        .auto-style97 {
            height: 23px;
            width: 185px;
        }
        .auto-style98 {
            width: 185px;
        }
        .auto-style102 {
            width: 95%;
        }
        .auto-style103 {
            width: 158px;
            text-align: right;
        }
        .auto-style104 {
            width: 158px;
        }
        .auto-style105 {
            height: 23px;
            width: 147px;
        }
        .auto-style106 {
            width: 147px;
        }
        .auto-style107 {
            width: 147px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id ="PolicyForm" class="auto-style19">
            <tr>
                <td colspan="3" class="auto-style18">
                    <h2>Policy</h2>
                </td>
            </tr>
            <tr>
                <td class="auto-style85">Effective Date:</td>
                <td class="auto-style65">
                    <asp:textbox id="txtEffectiveDate" runat="server" maxlength="10"></asp:textbox>
                </td>
                <td class="auto-style66">
                    <asp:RequiredFieldValidator ID="ValidatorEffectiveDate" runat="server" ControlToValidate="txtEffectiveDate" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="PolicyBtnContinue"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ExpressionEffectiveDate" runat="server" ControlToValidate="txtEffectiveDate" ErrorMessage="Enter Date in Format(mm/dd/yyyy)" ForeColor="Red" ValidationExpression="((0[1-9]|1[0-2])\/((0|1)[0-9]|2[0-9]|3[0-1])\/((19|20)\d\d))$" ValidationGroup="PolicyBtnContinue"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style86">Termination Date:</td>
                <td class="auto-style93">
                    <asp:TextBox ID="txtTerminationDate" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td class="auto-style69">
                    <asp:RequiredFieldValidator ID="ValidatorTerminationDate" runat="server" ControlToValidate="txtTerminationDate" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="PolicyBtnContinue"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ExpressionTerminationDate" runat="server" ControlToValidate="txtTerminationDate" ErrorMessage="Enter Date in Format(mm/dd/yyyy)" ForeColor="Red" ValidationExpression="((0[1-9]|1[0-2])\/((0|1)[0-9]|2[0-9]|3[0-1])\/((19|20)\d\d))$" ValidationGroup="PolicyBtnContinue"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style87">Amount:</td>
                <td class="auto-style71">
                    <asp:TextBox ID="txtAmount" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td class="auto-style72">
                    <asp:RequiredFieldValidator ID="ValidatorAmount" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txtAmount" ValidationGroup="PolicyBtnContinue"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ExpressionAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Can Only Input Dollar Amount" ForeColor="Red" ValidationExpression="^(([0-9]*)|(([0-9]*)\.([0-9]*)))$" ValidationGroup="PolicyBtnContinue"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style88">Policy Year:</td>
                <td class="auto-style74">
                    <asp:TextBox ID="txtPolicyYear" runat="server" MaxLength="4"></asp:TextBox>
                </td>
                <td class="auto-style75">
                    <asp:RequiredFieldValidator ID="ValidatorPolicyYear" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txtPolicyYear" ValidationGroup="PolicyBtnContinue"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ExpressionPolicyYear" runat="server" ControlToValidate="txtPolicyYear" ErrorMessage="Can Only Input Numbers(yyyy)" ForeColor="Red" ValidationExpression="^0|[1-9]\d*$" ValidationGroup="PolicyBtnContinue"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style89">Policy Type:</td>
                <td class="auto-style77">
                    <asp:DropDownList ID="drpPolicyType" runat="server">
                        <asp:ListItem>Auto</asp:ListItem>
                        <asp:ListItem>Home</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style78">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style85">Insured ID:</td>
                <td class="auto-style65">
                    <asp:DropDownList ID="drpPolicyInsuredID" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style33">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style90">Address ID:</td>
                <td class="auto-style80">
                    <asp:DropDownList ID="drpPolicyAddressID" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style81">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style85">Last Updated By:</td>
                <td class="auto-style65">
                    <asp:TextBox ID="txtPolicyUpdatedBy" runat="server" ReadOnly="True">Tracy Otieno</asp:TextBox>
                </td>
                <td class="auto-style66">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style91">Last Updated:</td>
                <td class="auto-style83">
                    <asp:TextBox ID="txtPolicyLastUpdated" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style84">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style92">
                    <asp:Button ID="BtndisplayAmounts" runat="server" Text="Display Total Amounts" OnClick="BtndisplayAmounts_Click" />
                </td>
                <td class="auto-style57">
                    <asp:TextBox ID="txtPolicyAmounts" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style63">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="2">
                    <asp:Button ID="BtnContinue" runat="server" Text="Continue" OnClick="BtnContinue_Click" ValidationGroup="PolicyBtnContinue" />
                    <br />
                </td>
            </tr>
        </table>
        <br />
    <table class="auto-style102">
        <tr>
            <td colspan="3">
                <h2>Auto</h2>
            </td>
        </tr>
        <tr>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style104">
                <asp:TextBox ID="txtAutoPolicyID" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style95">Vin Number:</td>
            <td class="auto-style104">
                <asp:TextBox ID="txtVinNumber" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredVin" runat="server" ControlToValidate="txtVinNumber" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="autoCommit"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style95">Make:</td>
            <td class="auto-style104">
                <asp:TextBox ID="txtMake" runat="server" MaxLength="15"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredMake" runat="server" ControlToValidate="txtMake" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="autoCommit"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style95">Model:</td>
            <td class="auto-style104">
                <asp:TextBox ID="txtModel" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredModel" runat="server" ControlToValidate="txtModel" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="autoCommit"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style95">MilesPerYear:</td>
            <td class="auto-style104">
                <asp:TextBox ID="txtMiles" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredMiles" runat="server" ControlToValidate="txtMiles" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="autoCommit"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="ValidatorMiles" runat="server" ControlToValidate="txtMiles" ErrorMessage="Can Only Input Numbers" ForeColor="Red" ValidationExpression="^0|[1-9]\d*$" ValidationGroup="autoCommit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style103">
                <asp:Button ID="BtnAutoCommit" runat="server" Text="Commit Policy" ValidationGroup="autoCommit" Enabled="False" OnClick="BtnAutoCommit_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="overflow-x:auto;width:800px">
                    <br />
                    <asp:GridView ID="GridViewAuto" runat="server" OnSelectedIndexChanged="GridViewAuto_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#00FF99" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                    <br />
                </div>       
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style103">
                <asp:Button ID="BtnUpdateAuto" runat="server" Text="Update" OnClick="BtnUpdateAuto_Click" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <table class="auto-style94">
        <tr>
            <td colspan="3">
                <h2>Home</h2>
            </td>
        </tr>
        <tr>
            <td class="auto-style97">&nbsp;</td>
            <td class="auto-style105">
                <asp:TextBox ID="txtHomePolicyID" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            </td>
            <td class="auto-style96">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style98">Exterior Type:</td>
            <td class="auto-style106">
                <asp:DropDownList ID="DropExteriorType" runat="server">
                    <asp:ListItem >Select</asp:ListItem>
                    <asp:ListItem>Vinyl</asp:ListItem>
                    <asp:ListItem>Stone</asp:ListItem>
                    <asp:ListItem>Wood</asp:ListItem>
                    <asp:ListItem>Brick</asp:ListItem>
                    <asp:ListItem>Stucco</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style98">Alarm:</td>
            <td class="auto-style106">
                <asp:DropDownList ID="DropAlarm" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style98">Distance to Fire Station:</td>
            <td class="auto-style106">
                <asp:TextBox ID="txtDistance" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredDistance" runat="server" ControlToValidate="txtDistance" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="homeCommit"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style98">&nbsp;</td>
            <td class="auto-style107">
                <asp:Button ID="BtnHomeCommit" runat="server" Text="Commit Policy" Enabled="False" OnClick="BtnHomeCommit_Click" ValidationGroup="homeCommit" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="overflow-x:auto;width:800px">
                    <br />
                    <asp:GridView ID="GridViewHome" runat="server" OnSelectedIndexChanged="GridViewHome_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#00FF99" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                    <br />
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style98">&nbsp;</td>
            <td class="auto-style107">
                <asp:Button ID="BtnUpdateHome" runat="server" Text="Update" OnClick="BtnUpdateHome_Click" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
        <br />
        <asp:Button ID="BtnPolicyDisplay" runat="server" CausesValidation="False" OnClick="BtnPolicyDisplay_Click" Text="Display Policies" />
        <br />
    <asp:GridView ID="GridViewPolicy" runat="server">
        <AlternatingRowStyle BackColor="#00FF99" />
    </asp:GridView>
</asp:Content>

