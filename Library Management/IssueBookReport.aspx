<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueBookReport.aspx.cs" Inherits="Library_Management.IssueBookReport" %>

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
                    <a class="mr-5 hover:t-gray-900 cursor-pointer" href="IssueBookReport.aspx">Issue BookReport</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="ReturnBook.aspx">Return Book</a>
                    <a class="mr-5 hover:text-gray-900 cursor-pointer" href="PenaltyAdmin.aspx">Penalty</a>
                </nav>
                <%--<asp:Button ID="Btn_login" runat="server" Text="Login" class="mr-2 inline-flex items-center cursor-pointer  bg-blue-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-black rounded text-base mt-4 md:mt-0" OnClick="Btn_login_Click" />--%>

                <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-white rounded text-base mt-4 md:mt-0" />
                <asp:HiddenField ID="HiddenField1" runat="server" />


            </div>
        </header>
        <div class="p-10">
            <h1 class="mb-8 font-extrabold text-4xl">Book Issue Report</h1>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
                <div>
                    <label class="block font-semibold" for="name">Select Branch</label>
                    <asp:DropDownList ID="Select_Branch" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource1" DataTextField="BranchName" DataValueField="BranchName"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT [BranchName] FROM [AddBranch]"></asp:SqlDataSource>
                </div>

                <div class="mt-4">
                    <label class="block font-semibold" for="email">Select Publication</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" DataSourceID="SqlDataSource2" DataTextField="Publication" DataValueField="Publication"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [Publication] FROM [AddBook]"></asp:SqlDataSource>
                    <asp:Button ID="Select" class=" mt-3 flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" runat="server" Text="Select" OnClick="Select_Click" />

                </div>
                <asp:Label ID="ErrorMsg" runat="server"></asp:Label>

            </div>
        </div>
        <tr>
            <td style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    BackColor="#EAEAEA" BorderColor="#D9D9D9" BorderWidth="1px"
                    CellPadding="2" ForeColor="Black" GridLines="None" Style="text-align: center"
                    Width="750px" OnRowCommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="lightgrey" />
                    <Columns>
                        <asp:BoundField DataField="BookName" HeaderText="BookName" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="AvailableQuantity" HeaderText="AvailableQuantity" />
                        <asp:BoundField DataField="Rent" HeaderText="Rent" />
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkview" Text="View" CommandArgument='<%#Eval("ID") %>' CssClass="lnk"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
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

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="False">
            <asp:View ID="View1" runat="server">
                <table class="flex justify-center border-1">
                    <tr>
                        <td class="text-gray-500 text-center text-4xl font-bold ">View Book Detail </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="style4">

                                <tr>
                                    <td class="text-xl mb-2" rowspan="2">
                                        <asp:Image ID="Image2"  class="mr-5" runat="server" Height="300px" Width="207px"
                                            BorderColor="#fff0" BorderStyle="Dotted" BorderWidth="1px" />


                                    </td>
                                    <td class="style8" valign="top">
                                        <div class="flex justify-center">
                                            <table>

                                                <tr>
                                                    <td class="text-xl mb-2" colspan="2">Book Id :
                                 <asp:Label ID="Book_Id" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2" colspan="2">Book Name :
                                 <asp:Label ID="Book_nm" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Detail :</td>
                                                    <td>
                                                        <asp:Label ID="Book_Detail" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Author :
                                                    </td>
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
                                                    <td class="text-xl mb-2">Branch :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Branch" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Price :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Price" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Quantity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Quantity" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Available Quantity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Available" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-xl mb-2">Rent Quantity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Book_Rent" class="text-xl" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Btn_Back" runat="server" class="mb-5 py-2.5 px-5 me-2 mb-2 mt-5 text-xl font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200 hover:bg-gray-100 hover:text-blue-700 focus:z-10 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-700 dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700" Text="Back" OnClick="Btn_Back_Click"  />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
            </asp:View>
        </asp:MultiView>

    </form>
</body>
</html>
