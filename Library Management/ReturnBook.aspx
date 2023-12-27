<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnBook.aspx.cs" Inherits="Library_Management.ReturnBook" %>

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
            <h1 class="mb-8 font-extrabold text-4xl">Book Return Form</h1>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-8">

                <div>
                    <label class="block font-semibold" for="name">Select Student</label>
                    <asp:DropDownList ID="Select_Student" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource1" DataTextField="StudentName" DataValueField="StudentName" OnSelectedIndexChanged="Select_Student_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [StudentName] FROM [Addstudent]"></asp:SqlDataSource>
                </div>

                <div>
                    <label class="block font-semibold" for="name">Select Book</label>
                    <asp:DropDownList ID="Select_Book" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource2" DataTextField="BookName" DataValueField="BookName"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [BookName] FROM [AddBook]"></asp:SqlDataSource>
                </div>

            </div>
            <div class="flex justify-center mt-8">
                <asp:Button ID="Select" runat="server" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="Select" OnClick="Select_Click" />
            </div>
            <asp:Label ID="ErrorMsg" runat="server"></asp:Label>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="False">
            <div class="container">
                <asp:View ID="View1" runat="server">
                    <table class="flex justify-center border-1">
                        <tr>
                            <td class="text-gray-500 text-center text-4xl font-bold ">View Book Detail </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style4">
                                    <tr>
                                        <td class="text-xl mb-2">
                                            <asp:Image ID="Image2" runat="server" Height="211px" Width="207px"
                                                BorderColor="#009933" BorderStyle="Dotted" BorderWidth="1px" />
                                        </td>
                                        <td class="style8" valign="top">
                                            <table class="style7">
                                                <tr>
                                                    <td class="style5" colspan="2">Book Name :
                                                        <asp:Label ID="Book_nm" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Author :</td>
                                                    <td>
                                                        <asp:Label ID="Book_Author" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Publication :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Publication" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">Branch :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Branch" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">Price :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Price" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">Student Name : </td>
                                                    <td>
                                                        <asp:Label ID="Stud_nm" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">Days :</td>
                                                    <td>
                                                        <asp:Label ID="text_days" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">Issue Date :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_IssueDate" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">Penalty Status :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Stud_Penalty" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2 ">&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="Book_Return" runat="server" class=" mt-7 fex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="Return Book" OnClick="Book_Return_Click" />
                                                    </td>
                                                    <td>&nbsp;<asp:Label ID="lblbook" runat="server" Font-Size="10pt"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                </asp:View>
            </div>
        </asp:MultiView>
    </form>
</body>
</html>
