<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Products management</h1>

    <table>
        <tr>
            <td>Code</td>
            <td><asp:TextBox ID="txtCode" runat="server" MaxLength="16"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtName" runat="server" MaxLength="32"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Amount</td>
            <td><asp:TextBox ID="txtAmount" runat="server" MaxLength="4"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Price</td>
            <td><asp:TextBox ID="txtPrice" runat="server" MaxLength="7"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Creation Date</td>
            <td><asp:TextBox ID="txtCreationDate" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
                <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" />
                <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" />
                <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>