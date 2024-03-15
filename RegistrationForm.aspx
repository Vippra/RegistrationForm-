<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="RegistrationForm_.RegistrationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <table>
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server" ></asp:TextBox></td>
        </tr>

         <tr>
            <td>Salary :</td>
            <td><asp:TextBox ID="txtsalary" runat="server" ></asp:TextBox></td>
        </tr>

         <tr>
            <td>Gender :</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3" ></asp:RadioButtonList></td>
        </tr>

         <tr>
            <td>Country :</td>
            <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>

         <tr>
            <td>State :</td>
            <td><asp:DropDownList ID="ddlstate" runat="server" ></asp:DropDownList></td>
        </tr>
        </center>
         <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
        </tr>

         <tr>
            <td></td>
            <td>
                <asp:GridView ID="gvregister" runat="server" AutoGenerateColumns="false" OnRowCommand="gvregister_RowCommand" ForeColor="Blue" BorderColor="Red">
                <Columns>
                    <asp:TemplateField HeaderText="Student_id">
                        <ItemTemplate>
                            <%#Eval("id") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Student_name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Student_salary">
                        <ItemTemplate>
                            <%#Eval("salary") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Student_gender">
                        <ItemTemplate>
                            <%#Eval("gendername") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Student_country">
                        <ItemTemplate>
                            <%#Eval("countryname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Student_state">
                        <ItemTemplate>
                            <%#Eval("statename") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:Button ID="btndelete" runat="server" BackColor="Red" ForeColor="White" Text="Delete" CommandName="A" CommandArgument='<%#Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:Button ID="btnedit" runat="server" BackColor="ForestGreen" ForeColor="Black" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                </asp:GridView>

            </td>
        </tr>
    </table>
</asp:Content>
