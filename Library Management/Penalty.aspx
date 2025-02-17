﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Penalty.aspx.cs" Inherits="Library_Management.Penalty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdn.tailwindcss.com"></script>
        <meta charset="utf-8" name="viewport" content="width=device-width, initial-scale=1.0" />

</head>
<body>
    <form id="form1" runat="server">
        <header class="text-gray-600 body-font">
            <div class="container mx-auto flex flex-wrap p-5 flex-col md:flex-row items-center">
                <a class="flex title-font font-medium items-center text-gray-900 mb-4 md:mb-0">


                    <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 448 512">
                        <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                        <style>
                            svg {
                                fill: #1b0808
                            }
                        </style><path d="M96 0C43 0 0 43 0 96V416c0 53 43 96 96 96H384h32c17.7 0 32-14.3 32-32s-14.3-32-32-32V384c17.7 0 32-14.3 32-32V32c0-17.7-14.3-32-32-32H384 96zm0 384H352v64H96c-17.7 0-32-14.3-32-32s14.3-32 32-32zm32-240c0-8.8 7.2-16 16-16H336c8.8 0 16 7.2 16 16s-7.2 16-16 16H144c-8.8 0-16-7.2-16-16zm16 48H336c8.8 0 16 7.2 16 16s-7.2 16-16 16H144c-8.8 0-16-7.2-16-16s7.2-16 16-16z" /></svg>
                    <span class="ml-3 text-xl">Library Management System 
                    </span>
                </a>
                <nav class="md:mr-auto md:ml-4 md:py-1 md:pl-4 md:border-l md:border-gray-400	flex flex-wrap items-center text-base justify-center">
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="MyAccount.aspx">My Account</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="myreport.aspx">My Report</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="Penalty.aspx">Penalty Report</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="BookReportClient.aspx">Book Report</a>
                </nav>




                <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-white rounded text-base mt-4 md:mt-0" OnClick="btn_logout_Click" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </header>
        <table class="tbl">
            
            <tr>
                <td style="text-align: center"></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
                        BackColor="#EAEAEA" BorderColor="#D9D9D9" BorderWidth="1px"
                        CellPadding="2" ForeColor="Black" GridLines="None" Width="668px">
                        <AlternatingRowStyle BackColor="lightgrey" />
                        <Columns>
                            <asp:BoundField DataField="BookName" HeaderText="BookName" />
                            <asp:BoundField DataField="price" HeaderText="Price">
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Panalty" HeaderText="Panalty Amount">
                                <ItemStyle Width="110px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Detail" HeaderText="Detail" />
                            <asp:BoundField DataField="Entrydate" HeaderText="Date" />
                        </Columns>
                        <FooterStyle BackColor="lightgrey" />
                        <HeaderStyle BackColor="lightgrey" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue"
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
