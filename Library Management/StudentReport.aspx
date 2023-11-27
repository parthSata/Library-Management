<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentReport.aspx.cs" Inherits="Library_Management.StudentReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdn.tailwindcss.com"></script>

</head>
<body>
    <form id="form1" runat="server">
        <header class="text-gray-600 body-font">
            <div class="container mx-auto flex flex-wrap p-5 flex-col md:flex-row items-center">
                <a class="flex title-font font-medium items-center text-gray-900 mb-4 md:mb-0">
                    <%--                <svg xmlns="https://previews.123rf.com/images/tvectoricons/tvectoricons1808/tvectoricons180806782/107778157-library-vector-icon-isolated-on-transparent-background-library-logo-concept.jpg" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="w-10 h-10 text-white p-2 bg-indigo-500 rounded-full" viewBox="0 0 24 24">
          <path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5"></path>
      </svg>--%>
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
            <h1 class="mb-8 font-extrabold text-4xl">Student Report</h1>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-8">

                <div>
                    <label class="block font-semibold" for="name">Select Branch</label>
                    <asp:DropDownList ID="DropDownList1" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource1" DataTextField="BranchName" DataValueField="BranchName"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [BranchName] FROM [AddBranch]"></asp:SqlDataSource>
                    <asp:Button ID="Button1" runat="server" class="mt-2 flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="View" OnClick="Button1_Click" />

                </div>

                <div>
                    <label class="block font-semibold" for="name">Student Name</label>
                    <asp:TextBox ID="text_Search" runat="server" autofocus="autofocus" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" class=" mt-2 flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="View" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
        <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="False">
            <asp:View ID="View1" runat="server">
                <table class="tbl">
                    <tr>
                        <td class="tblhead">
                            <asp:Label ID="lbl" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table class="tbl">
                    <tr>
                        <td class="tblhead">Student Details</td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" class="style4">
                                <tr>
                                    <td class="style5">Student ID : </td>
                                    <td>
                                        <asp:Label ID="Stud_Id" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">StudentName: </td>
                                    <td>
                                        <asp:Label ID="Stud_nm" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">Mobile :</td>
                                    <td>
                                        <asp:Label ID="Stud_Mo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">Address: </td>
                                    <td>
                                        <asp:Label ID="Stud_Address" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">City :</td>
                                    <td>
                                        <asp:Label ID="Stud_City" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">Pincode : </td>
                                    <td>
                                        <asp:Label ID="Stud_Pin" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">BirthDate : </td>
                                    <td>
                                        <asp:Label ID="Stud_Date" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">Branch : </td>
                                    <td>
                                        <asp:Label ID="Stud_Branch" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">Email :
                                    </td>
                                    <td>
                                        <asp:Label ID="Stud_Email" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl">Password&nbsp; :
                                    </td>
                                    <td>
                                        <asp:Label ID="Stud_Pass" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl">&nbsp;</td>
                                    <td>
                                        <asp:Button ID="Btn_Back" runat="server" Text="Back" OnClick="Btn_Back_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
