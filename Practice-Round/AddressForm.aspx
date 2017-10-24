<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddressForm.aspx.cs" Inherits="AddressForm" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            margin-left: 0px;
        }
        .auto-style8 {
            width: 134px;
        }
        .auto-style9 {
            width: 99%;
        }
        .auto-style10 {
            height: 114px;
    }
        .auto-style12 {
            width: 108px;
            height: 26px;
        }
        .auto-style14 {
            width: 138px;
        }
        .auto-style15 {
            width: 138px;
            height: 26px;
        }
        .auto-style16 {
            width: 20px;
            text-align: right;
        }
        .auto-style19 {
        width: 108px;
    }
    .auto-style22 {
        width: 138px;
        height: 114px;
    }
        .auto-style23 {
            width: 20px;
        }
        .auto-style24 {
            width: 20px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Address Information</h2>
    <table class="auto-style9">
        <tr>
            <td class="auto-style19">House Number:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtHouseNumber" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style14">
                <asp:RequiredFieldValidator ID="RequiredFieldHouseNumber" runat="server" ControlToValidate="txtHouseNumber" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="homeCommit"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="ValidatorHouseNumber" runat="server" ControlToValidate="txtHouseNumber" ErrorMessage="Must be a number" ForeColor="Red" ValidationExpression="[0-9]*" ValidationGroup="homeCommit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Street:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtStreet" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td class="auto-style14">
                <asp:RequiredFieldValidator ID="RequiredFieldStreet" runat="server" ControlToValidate="txtStreet" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="homeCommit"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12">City/County:</td>
            <td class="auto-style24">
                <asp:TextBox ID="txtCityCounty" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td class="auto-style15">
                <asp:RequiredFieldValidator ID="RequiredFieldCityCounty" runat="server" ControlToValidate="txtCityCounty" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="homeCommit"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style19">StateAbb:</td>
            <td class="auto-style23">
                <asp:DropDownList ID="DropStateAbb" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AK</asp:ListItem>
                    <asp:ListItem>AZ</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CO</asp:ListItem>
                    <asp:ListItem>CT</asp:ListItem>
                    <asp:ListItem>DE</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>GA</asp:ListItem>
                    <asp:ListItem>HI</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>IL</asp:ListItem>
                    <asp:ListItem>IN</asp:ListItem>
                    <asp:ListItem>IA</asp:ListItem>
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>
                    <asp:ListItem>LA</asp:ListItem>
                    <asp:ListItem>ME</asp:ListItem>
                    <asp:ListItem>MD</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MI</asp:ListItem>
                    <asp:ListItem>MN</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MO</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem>
                    <asp:ListItem>NV</asp:ListItem>
                    <asp:ListItem>NH</asp:ListItem>
                    <asp:ListItem>NJ</asp:ListItem>
                    <asp:ListItem>NM</asp:ListItem>
                    <asp:ListItem>NY</asp:ListItem>
                    <asp:ListItem>NC</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>OH</asp:ListItem>
                    <asp:ListItem>OK</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>RI</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SD</asp:ListItem>
                    <asp:ListItem>TN</asp:ListItem>
                    <asp:ListItem>TX</asp:ListItem>
                    <asp:ListItem>UT</asp:ListItem>
                    <asp:ListItem>VT</asp:ListItem>
                    <asp:ListItem>VA</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>WV</asp:ListItem>
                    <asp:ListItem>WI</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style14">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style19">CountryAbb:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtCountryAbb" runat="server" MaxLength="2"></asp:TextBox>
            </td>
            <td class="auto-style14">
                <asp:RequiredFieldValidator ID="RequiredFieldCountryAbb" runat="server" ControlToValidate="txtCountryAbb" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="homeCommit"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="ValidatorCountry" runat="server" ControlToValidate="txtCountryAbb" ErrorMessage="Must be alphabetical letters" ForeColor="Red" ValidationExpression="[a-zA-Z]*" ValidationGroup="homeCommit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Zip:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtZip" runat="server" MaxLength="5"></asp:TextBox>
            </td>
            <td class="auto-style14">
                <asp:RequiredFieldValidator ID="RequiredFieldZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Required Field" ForeColor="Red" ValidationGroup="homeCommit"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="ValidatorZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Must be a 5 digit number" ForeColor="Red" ValidationExpression="[0-9]*" ValidationGroup="homeCommit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Last Updated By:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtUpdatedBy" runat="server" ReadOnly="True">Tracy Otieno</asp:TextBox>
            </td>
            <td class="auto-style14">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Last Updated:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtLastUpdated" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="auto-style14">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style16">
                <asp:Button ID="BtnAddressCommit" runat="server" OnClick="BtnAddressCommit_Click" Text="Commit" ValidationGroup="homeCommit" />
            </td>
            <td class="auto-style14">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
                <asp:GridView ID="GridViewAddress" runat="server" OnSelectedIndexChanged="GridViewAddress_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#00FF99" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style16">
                <asp:Button ID="BtnUpdate" runat="server" Enabled="False" OnClick="BtnUpdate_Click" Text="Update" />
            </td>
            <td class="auto-style14">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

