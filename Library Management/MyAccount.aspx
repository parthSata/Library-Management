<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="Library_Management.MyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

                <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-red-200 text-white rounded text-base mt-4 md:mt-0" OnClick="btn_logout_Click" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </header>
        <div class="flex justify-evenly  justify-items-center">
            <asp:Button ID="Btn_View" class="inline-flex pl-3 items-center cursor-pointer  bg-blue-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-black rounded text-base  mt-4 md:mt-0" runat="server" Text="View Account" OnClick="Btn_View_Click" />
            <asp:Button ID="Btn_Edit" class="inline-flex pl-3 items-center cursor-pointer  bg-blue-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-black rounded text-base  mt-4 md:mt-0" runat="server" Text="Edit Account" OnClick="Btn_Edit_Click" />
            <%--<asp:Button ID="Btn_change" runat="server" Text="Change Password" />--%>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="False">

            <asp:View ID="View2" runat="server">
                <section class="text-gray-400 bg-white-900 body-font overflow-hidden">
                    <div class="container px-5 py-24 mx-auto">
                        <div class="lg:w-2/3 mx-auto flex flex-wrap">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "images/" + Eval("Image") %>' class=" rounded-full w-96 h-96 lg:w-1/2 w-full lg:h-auto h-64 object-cover object-center " />

                            <div class="lg:w-1/2 w-full lg:pl-10 lg:py-6 mt-6 lg:mt-0">
                                <div class="flex mb-4">
                                </div>
                                <div class="flex mt-6 items-center pb-5 border-b-2 border-gray-800 mb-5">

                                    <div class="flex ml-6 items-center">
                                        <h1 class="text-black text-3xl title-font font-medium mb-1">Hello ,</h1>
                                        <asp:Label ID="Label1" runat="server" class="block text-black text-3xl pl-2 font-extrabold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Name"></asp:Label>

                                    </div>
                                </div>
                                <div class="flex pb-5">
                                    <asp:Label ID="Label2" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Student Name :"></asp:Label>
                                    <asp:Label ID="lbl_nm" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Student Name :"></asp:Label>
                                </div>
                                <div class="flex pb-5">
                                    <asp:Label ID="Label3" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Mobile No :"></asp:Label>
                                    <asp:Label ID="lbl_mo" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Mobile No :"></asp:Label>
                                </div>
                                <div class="flex pb-5">
                                    <asp:Label ID="Label4" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Address :"></asp:Label>
                                    <asp:Label ID="lbl_Address" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Address :"></asp:Label>
                                </div>
                                <div class="flex pb-5">
                                    <asp:Label ID="Label5" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="City :"></asp:Label>
                                    <asp:Label ID="lbl_City" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="City :"></asp:Label>
                                </div>
                                <div class="flex pb-5">
                                    <asp:Label ID="Label6" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Pincode :"></asp:Label>
                                    <asp:Label ID="lbl_Pin" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Pincode :"></asp:Label>
                                </div>
                                <div class="flex pb-5">
                                    <asp:Label ID="Label7" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Email :"></asp:Label>
                                    <asp:Label ID="lbl_Email" runat="server" class="block text-black-700 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name" Text="Email :"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>

                </section>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="p-10">
                    <h1 class="mb-8 font-extrabold text-4xl">Update Student Data</h1>
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
                            <asp:TextBox ID="text_mo" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
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
                        </div>

                        <div class="mt-4">
                            <label class="block font-semibold" for="password">Password :</label>
                            <asp:TextBox ID="text_pass" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                        </div>
                        <div class="flex items-center justify-between mt-8">
                            <asp:Button ID="Btn_Update" runat="server" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="Update" OnClick="Btn_Update_Click" />
                        </div>
                    </div>
                </div>
            </asp:View>

        </asp:MultiView>
    </form>
</body>
</html>
