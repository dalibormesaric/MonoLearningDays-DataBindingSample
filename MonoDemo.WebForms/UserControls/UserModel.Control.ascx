<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserModel.Control.ascx.cs" Inherits="MonoDemo.WebForms.UserControls.UserModel_Control" %>

<asp:HiddenField ID="fldUserId" runat="server" />

<asp:ValidationSummary runat="server" ShowModelStateErrors="true" ValidationGroup="vgUserModel" />

<asp:FormView ID="fvUserModel" runat="server" ItemType="MonoDemo.Models.UserModel" SelectMethod="fvUserModel_GetItem" UpdateMethod="fvUserModel_UpdateItem" DeleteMethod="fvUserModel_DeleteItem"
    EnableModelValidation="true" OnCallingDataMethods="fvUserModel_CallingDataMethods" RenderOuterTable="false" DefaultMode="Edit" OnItemUpdated="fvUserModel_ItemUpdated" OnItemDeleted="fvUserModel_ItemDeleted">
    <EditItemTemplate>
        <asp:TextBox ID="txtFirstName" runat="server" Text="<%# BindItem.FirstName %>" />
        <asp:RequiredFieldValidator ID="vldFirstNameRequired" runat="server" ControlToValidate="txtFirstName" Display="Static" Text="*" ValidationGroup="vgUserModel" 
            ErrorMessage='<%# typeof(MonoDemo.Models.UserModel).GetProperty("FirstName").GetCustomAttributes(typeof(RequiredAttribute), false).Cast<RequiredAttribute>().Single().FormatErrorMessage(string.Empty) %>' />
        <asp:TextBox ID="txtLastName" runat="server" Text="<%# BindItem.LastName %>" />
        <asp:RequiredFieldValidator ID="vldLastNameRequired" runat="server" ControlToValidate="txtLastName" Display="Static" Text="*" ValidationGroup="vgUserModel" 
            ErrorMessage='<%# typeof(MonoDemo.Models.UserModel).GetProperty("LastName").GetCustomAttributes(typeof(RequiredAttribute), false).Cast<RequiredAttribute>().Single().FormatErrorMessage(string.Empty) %>' />
        <asp:Button ID="btnSave" runat="server" CommandName="Update" Text='<%# UserId == 0 ? "Save" : "Update" %>' ValidationGroup="vgUserModel" />
        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" Enabled="<%# UserId != 0 %>" />
    </EditItemTemplate>
</asp:FormView>

<asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New" />