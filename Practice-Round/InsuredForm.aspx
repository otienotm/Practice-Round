<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsuredForm.aspx.cs" Inherits="InsuredForm" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style7 {
        width: 278px;
        height: 23px;
    }
    .auto-style12 {
        width: 41%;
        height: 19px;
    }
    .auto-style13 {
        height: 19px;
    }
    .auto-style14 {
        width: 41%;
        height: 66px;
    }
    .auto-style15 {
        height: 524px;
    }
    .auto-style23 {
        width: 41%;
        height: 28px;
    }
    .auto-style24 {
        height: 28px;
    }
    .auto-style25 {
        width: 41%;
        height: 21px;
    }
    .auto-style26 {
        height: 21px;
    }
    .auto-style27 {
        width: 41%;
        height: 66px;
        text-align: right;
    }
    .auto-style33 {
        height: 19px;
        width: 128px;
    }
    .auto-style34 {
        height: 28px;
        width: 128px;
    }
    .auto-style35 {
        height: 21px;
        width: 128px;
    }
    .auto-style37 {
        height: 12px;
    }
    .auto-style38 {
        width: 41%;
        height: 29px;
    }
    .auto-style39 {
        height: 29px;
        width: 128px;
    }
    .auto-style40 {
        height: 29px;
    }
    .auto-style41 {
        width: 41%;
        height: 22px;
    }
    .auto-style42 {
        height: 22px;
        width: 128px;
    }
    .auto-style43 {
        height: 22px;
    }
    .auto-style44 {
        width: 41%;
        height: 39px;
    }
    .auto-style45 {
        width: 128px;
        height: 39px;
    }
    .auto-style46 {
        height: 39px;
    }
    .auto-style47 {
        border-style: none;
        padding: 0;
    }
    .auto-style48 {
        width: 135px;
        height: 23px;
    }
        .auto-style49 {
            width: 41%;
            height: 43px;
        }
        .auto-style50 {
            width: 128px;
            height: 43px;
        }
        .auto-style51 {
            height: 43px;
        }
        .auto-style52 {
            width: 41%;
            height: 116px;
            text-align: right;
        }
        .auto-style53 {
            width: 41%;
            height: 116px;
        }
        .auto-style54 {
            width: 41%;
            height: 32px;
            text-align: right;
        }
        .auto-style55 {
            width: 41%;
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id ="InsuredForm" class="auto-style15">
            <tr>
                <td colspan="2" class="auto-style37">
                    <h2 class="auto-style48">Insure<span class="auto-style47">d</span></h2>
                </td>
                <td class="auto-style37">
                    </td>
            </tr>
            <tr>
                <td class="auto-style38">First Name:</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="20"></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:RequiredFieldValidator ID="ValidatorFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="CommitButton"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style41">Last Name:</td>
                <td class="auto-style42">
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td class="auto-style43">
                    <asp:RequiredFieldValidator ID="ValidatorLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="CommitButton"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Middle Initial:</td>
                <td class="auto-style33">
                    <asp:TextBox ID="txtMiddle" runat="server" MaxLength="1"></asp:TextBox>
                </td>
                <td class="auto-style13">
                    <asp:RegularExpressionValidator ID="ValidatorMiddle" runat="server" ControlToValidate="txtMiddle" ErrorMessage="Must be an alphabetical letter" ForeColor="Red" ValidationExpression="[a-zA-Z]" ValidationGroup="CommitButton"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style44">Date of Birth:</td>
                <td class="auto-style45">
                    <asp:TextBox ID="txtDateOfBirth" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td class="auto-style46">
                    <asp:RequiredFieldValidator ID="ValidatorDOB" runat="server" ControlToValidate="txtDateOfBirth" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="CommitButton"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ExpressionDOB" runat="server" ControlToValidate="txtDateOfBirth" ErrorMessage="Enter Date in Format (mm/dd/yyyy)" ForeColor="Red" ValidationExpression="((0[1-9]|1[0-2])\/((0|1)[0-9]|2[0-9]|3[0-1])\/((17|18|19|20)\d\d))$" ValidationGroup="CommitButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Credit Score: </td>
                <td class="auto-style33">
                    <asp:TextBox ID="txtCreditScore" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style13">
                    <asp:RangeValidator ID="RangeCredit" runat="server" ControlToValidate="txtCreditScore" ErrorMessage="Score must be between 0-800" ForeColor="Red" MaximumValue="800" MinimumValue="0" Type="Integer" ValidationGroup="CommitButton"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="ValidatorCredit" runat="server" ControlToValidate="txtCreditScore" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="CommitButton"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style23">Address ID:</td>
                <td class="auto-style34">
                    <asp:DropDownList ID="drpInsuredAddressID" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style24">
                    <asp:RequiredFieldValidator ID="ValidatorInsuredAddress" runat="server" ControlToValidate="drpInsuredAddressID" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="CommitButton"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style25">Driver&#39;s License Number:</td>
                <td class="auto-style35">
                    <asp:TextBox ID="txtLicense" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td class="auto-style26">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style23">Last Updated By:</td>
                <td class="auto-style34">
                    <asp:TextBox ID="txtInsuredUpdatedBy" runat="server" ReadOnly="True">Tracy Otieno</asp:TextBox>
                </td>
                <td class="auto-style24">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style49">Last Updated:</td>
                <td class="auto-style50">
                    <asp:TextBox ID="txtInsuredLastUpdated" runat="server" ReadOnly="True"></asp:TextBox> 
                </td>
                <td class="auto-style51">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style27" colspan="2">
                    <br />
                    <asp:Button ID="BtnInsuredCommit" runat="server" OnClick="BtnInsuredCommit_Click" Text="Commit to Database" ValidationGroup="CommitButton" />
                </td>
                <td class="auto-style14">
                    </td>
            </tr>
            <tr>
                <td class="auto-style52" colspan="2">
                    <asp:GridView ID="GridViewInsured" runat="server" OnSelectedIndexChanged="GridViewInsured_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#00FF99" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style53">
                    </td>
            </tr>
            <tr>
                <td class="auto-style54" colspan="2">
                    <asp:Button ID="BtnDelete" runat="server" Enabled="False" OnClick="BtnDelete_Click1" Text="Delete" />
                    <asp:Button ID="BtnUpdate" runat="server" Enabled="False" OnClick="BtnUpdate_Click" Text="Update" />
                </td>
                <td class="auto-style55">
                    </td>
            </tr>
        </table>

        </asp:Content>

