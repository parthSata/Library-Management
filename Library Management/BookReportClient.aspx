<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookReportClient.aspx.cs" Inherits="Library_Management.BookReportClient" %>

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




                <asp:Button ID="btn_logout" runat="server" Text="Log Out" OnClientClick="dialog()" class="inline-flex items-center cursor-pointer  bg-gray-500  border-0 py-1 px-3 focus:outline-none hover:bg-gray-200 text-white rounded text-base mt-4 md:mt-0" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </header>
        <div class=" container grid grid-cols-1 md:grid-cols-2 gap-8">

            <div>
                <label class="block font-semibold" for="name">Select Branch</label>
                <asp:DropDownList ID="DropDownList1" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource1" DataTextField="BranchName" DataValueField="BranchName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT [BranchName] FROM [AddBranch]"></asp:SqlDataSource>
                <asp:Button ID="Btn_ViewBranch" runat="server" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="View" OnClick="Btn_ViewBranch_Click" />

            </div>

            <div>
                <label class="block font-semibold" for="name">Select Publication</label>
                <asp:DropDownList ID="DropDownList2" class="w-full shadow-inner bg-gray-100 rounded-lg placeholder-black text-2xl p-4 border-none block mt-1 w-full" runat="server" DataSourceID="SqlDataSource2" DataTextField="Publication" DataValueField="Publication"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [Publication] FROM [AddPublication]"></asp:SqlDataSource>
                <asp:Button ID="Btn_ViewPublication" runat="server" class="flex items-center justify-center px-8 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 md:py-4 md:text-lg md:px-10" Text="View" OnClick="Btn_ViewPublication_Click" />
            </div>
            <asp:Label ID="ErrorMsg" runat="server"></asp:Label>
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
                                Style="text-align: center" OnRowCommand="GridView1_RowCommand">
                                <AlternatingRowStyle BackColor="#cecece" />
                                <Columns>
                                    <asp:BoundField DataField="BookName" HeaderText="BookName" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Qnt" />
                                    <asp:BoundField DataField="AvailableQuantity" HeaderText="Availabale" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:Button ID="Btn_View" CommandArgument='<%#Eval("ID") %>' class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-4 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800" runat="server" Text="View" />
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
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table class="flex justify-center text-4xl rounded-lg font-bold text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <tr>
                        <td class="text-gray-500 text-center  font-bold">View Book Detail </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="flex text-sm   text-left rtl:text-right text-gray-500 dark:text-black-400">
                                <%-- <tr>
                                    <td class="text-xl mb-2" colspan="2">Book Name :
                                            <asp:Label ID="Book_nm" class="text-xl" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="text-xl mb-2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="text-xl mb-2" rowspan="3">
                                        <asp:Image ID="Image2" runat="server" Height="228px" Width="207px" />
                                    </td>
                                    <td class="text-xl mb-2" valign="top">
                                        <table class="flex text-sm   text-left rtl:text-right text-gray-500 dark:text-black-400">
                                            <tr>
                                                <td class="text-xl mb-2" colspan="2">Book Name :
                                                     <asp:Label ID="Book_nm" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">Author :</td>
                                                <td>
                                                    <asp:Label ID="Book_Author" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">Publication :
                                                </td>
                                                <td>
                                                    <asp:Label ID="Book_Publication" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">Branch :
                                                </td>
                                                <td>
                                                    <asp:Label ID="Book_Branch" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">Price :
                                                </td>
                                                <td>
                                                    <asp:Label ID="Book_Price" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">Total Quantity :
                                                </td>
                                                <td>
                                                    <asp:Label ID="Book_Quantity" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text-xl mb-2" style="font-size: medium">Available Qnt :
                                                </td>
                                                <td>
                                                    <asp:Label ID="Book_Available" class="text-xl" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style9" valign="top">&nbsp;Detail :
                                            <asp:Label ID="Book_Detail" class="text-xl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-xl mb-2" valign="top">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Btn_Back" class="py-2.5 px-5 me-2 mb-2 mt-2 text-xl font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200 hover:bg-gray-100 hover:text-blue-700 focus:z-10 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-700 dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700" runat="server" Text="Back" Width="80px" OnClick="Btn_Back_Click" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
