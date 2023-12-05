<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookReport.aspx.cs" Inherits="Library_Management.BookReport" %>

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
                <asp:Button ID="Btn_login" runat="server" Text="Login" class="mr-2 inline-flex items-center cursor-pointer  bg-blue-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-black rounded text-base mt-4 md:mt-0" OnClick="Btn_login_Click" />

                <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-white rounded text-base mt-4 md:mt-0" OnClick="btn_logout_Click" />
                <asp:HiddenField ID="HiddenField1" runat="server" />


            </div>
        </header>
        <div class="p-10">
            <h1 class="mb-8 font-extrabold text-4xl">Book Report</h1>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-8">

                <div>
                    <label class="block font-semibold" for="name">Select Branch</label>
                    <asp:DropDownList ID="DropDownList1" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource1" DataTextField="Branch" DataValueField="Branch"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [Branch] FROM [Addstudent]"></asp:SqlDataSource>
                    <asp:Button ID="Button1" runat="server" class="mt-2 flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="View" OnClick="Button1_Click" />

                </div>

                <div>
                    <label class="block font-semibold" for="name">Select Publication</label>
                    <asp:DropDownList ID="DropDownList2" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource2" DataTextField="Publication" DataValueField="Publication"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [Publication] FROM [AddPublication]"></asp:SqlDataSource>
                    <asp:Button ID="Button2" runat="server" class="mt-2 flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="View" OnClick="Button2_Click" />
                </div>

                <%--                <div class="flex items-center justify-between mt-8">
                    <asp:Button ID="Add_Publication" runat="server" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="Add Publication" />
                </div>--%>
            </div>
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="False">
            <asp:View ID="View1" runat="server">
                <table class="tbl">
                    <tr>
                        <td class="tblhead">
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                Width="748px" BackColor="#EAEAEA" BorderColor="#D9D9D9"
                                BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"
                                OnRowCommand="GridView1_RowCommand" Style="text-align: center">
                                <AlternatingRowStyle BackColor="#cecece" />
                                <Columns>
                                    <asp:BoundField DataField="bookname" HeaderText="BookName" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:BoundField DataField="Quantities" HeaderText="Qnt" />
                                    <asp:BoundField DataField="Availableqnt" HeaderText="Availabale" />
                                    <asp:BoundField DataField="RentQnt" HeaderText="Rent" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="#C1C1C1" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue"
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                                            <asp:LinkButton runat="server" ID="lnkview" Text="View" CommandArgument='<%#Eval("Bookid") %>' CssClass="lnk" OnClick="lnkview_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table class="tbl">
                    <tr>
                        <td class="tblhead">View Book Detail </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="style4">
                                <tr>
                                    <td class="style5" colspan="2">Book Name :
                                            <asp:Label ID="lblbname" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style6">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style6" rowspan="3">
                                        <asp:Image ID="Image2" runat="server" Height="228px" Width="207px" />
                                    </td>
                                    <td class="style8" valign="top">
                                        <table class="style7">
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Autor :</td>
                                                <td>
                                                    <asp:Label ID="lblauthor" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Publication :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblpub" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Branch :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblbran" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Price :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblprice" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Total Qnt :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblqnt" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Available Qnt :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblaqnt" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="font-size: medium">Rent Qnt :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrqnt" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style9" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Detail :
                                            <asp:Label ID="lbldetail" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style9" valign="top">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button11" runat="server" CssClass="btn"
                                OnClick="Button11_Click" Text="Back" Width="80px" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
