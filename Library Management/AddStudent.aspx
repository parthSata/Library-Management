<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Library_Management.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Student</title>
    <script src="https://cdn.tailwindcss.com"></script>

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

                <%-- <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-white rounded text-base mt-4 md:mt-0" />
                <asp:HiddenField ID="HiddenField1" runat="server" />--%>
            </div>
        </header>
        <div class="p-10">
            <h1 class="mb-8 font-extrabold text-4xl">Add New Student</h1>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-8">

                <div>
                    <label class="block font-semibold" for="name">Student Name</label>
                    <asp:TextBox ID="text_nm" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="email">Branch</label>
                    <asp:DropDownList ID="text_branch" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource1" DataTextField="BranchName" DataValueField="BranchName"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [BranchName] FROM [AddBranch]"></asp:SqlDataSource>
                    <%--<asp:TextBox ID="text_branch" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>--%>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">Gender</label>
                    <asp:DropDownList ID="text_gender" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:TextBox ID="text_gender" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>--%>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">Birthdate :</label>
                    <asp:TextBox ID="text_birthdate" runat="server" type="date" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">Mobile No :</label>
                    <asp:TextBox ID="text_mo" runat="server" autofocus="autofocus" MaxLength="10" type="number" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="text_mo" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                </div>

                <div>
                    <label class="block font-semibold" for="name">Address :</label>
                    <asp:TextBox ID="text_address" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">City :</label>
                    <%--<asp:DropDownList ID="text_city" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server"></asp:DropDownList>--%>
                    <asp:TextBox ID="text_city" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>

                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">Pincode :</label>
                    <asp:TextBox ID="text_pin" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">Email :</label>
                    <asp:TextBox ID="text_email" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="text_email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="password">Password :</label>
                    <asp:TextBox ID="text_pass" runat="server" autofocus="autofocus" type="password" MaxLength="20" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                </div>
                <div class="mt-4">
                    <label class="block font-semibold" for="password">Upload Photo :</label>
                    <asp:FileUpload ID="text_photo" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" />
                </div>

                <div class="flex items-center justify-between mt-8">
                    <asp:Button ID="Add_NewStudent" runat="server" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="Add Student" OnClick="Add_NewStudent_Click" />

                </div>
            </div>
        </div>
    </form>
</body>
</html>
