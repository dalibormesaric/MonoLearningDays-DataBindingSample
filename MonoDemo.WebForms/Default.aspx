<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MonoDemo.WebForms.Default" %>

<%@ Register Src="~/UserControls/UserModel.Control.ascx" TagPrefix="MD" TagName="UserModelControl" %>
<%@ Register Src="~/UserControls/UserModelList.Control.ascx" TagPrefix="MD" TagName="UserModelListControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.4.min.js"></script>
    <script src="Scripts/jquery.validate.min.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <MD:UserModelControl runat="server" id="userModelControl" />
        <MD:UserModelListControl runat="server" ID="userModelListControl" />
    </div>
    </form>
</body>
</html>
