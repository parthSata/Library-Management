﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="Library_Management.AddBranch" %>

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
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="AddPublication.aspx">Add Publication</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="AddBook.aspx">Add Book</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="BookReport.aspx">Book Report</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="AddBranch.aspx">Add Branch</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="AddStudent.aspx">Add Student</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="StudentReport.aspx">Student Report</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="IssueBook.aspx">Issue Book</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="IssueBookReport.aspx">Issue BookReport</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="ReturnBook.aspx">Return Book</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="PenaltyAdmin.aspx">Penalty</a>
                </nav>
                <%--<asp:Button ID="Btn_login" runat="server" Text="Login" class="mr-2 inline-flex items-center cursor-pointer  bg-blue-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-black rounded text-base mt-4 md:mt-0" OnClick="Btn_login_Click" />--%>

                <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-white rounded text-base mt-4 md:mt-0" />
                <asp:HiddenField ID="HiddenField1" runat="server" />


            </div>
        </header>
        <div class="p-10">
            <h1 class="mb-8 font-extrabold text-4xl">Add New Branch</h1>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-8">

                <div>
                    <label class="block font-semibold" for="name">Branch Name</label>
                    <asp:TextBox ID="text_Branch" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                </div>


                <div class="flex items-center justify-between mt-8">
                    <asp:Button ID="Add_NewBranch" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" runat="server" Text="Add Branch" OnClick="Add_NewBranch_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="BranchName" HeaderText="BranchName" SortExpression="BranchName" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [AddBranch]"></asp:SqlDataSource>
    </form>
</body>
</html>
