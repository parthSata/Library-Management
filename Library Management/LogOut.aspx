﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="Library_Management.LogOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta charset="utf-8" name="viewport" content="width=device-width, initial-scale=1.0" />
     <script src="https://cdn.tailwindcss.com"></script>
 <script>
     function dialog() {
         var flag = confirm('Do You Want To Log Out ?');
         var hdnfld = document.getElementById('<%= HiddenField1.ClientID %>');
         hdnfld.value = flag ? '1' : '0';
     }
 </script>
     <meta charset="utf-8" name="viewport" content="width=device-width, initial-scale=1.0" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
                            <asp:HiddenField ID="HiddenField1" runat="server" />

        </div>
    </form>
</body>
</html>
