<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserModelList.Control.ascx.cs" Inherits="MonoDemo.WebForms.UserControls.UserModelList" %>

<asp:ListView ID="lvUserModelList" runat="server" ItemType="MonoDemo.Models.UserModel" 
    SelectMethod="lvUserModelList_GetData" OnCallingDataMethods="lvUserModelList_CallingDataMethods">
    <ItemTemplate>
        <asp:LinkButton ID="btnUser" runat="server" Text='<%# string.Format("{0} {1}", Item.FirstName, Item.LastName) %>' CommandArgument="<%# Item.Id %>" OnClick="btnUser_Click" />
    </ItemTemplate>
</asp:ListView>