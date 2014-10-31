<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="Type.aspx.cs" Inherits="ExamSystemManager.Admin.Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Mesages" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="pnlMessage" runat="server" CssClass="informasi" Visible="False">
        <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
    </asp:Panel>

    <asp:Panel ID="pnlAddnew" runat="server" Visible="false">
        <div class="control">
            <asp:LinkButton ID="lbtSaveT" runat="server" CssClass="save" onclick="btnsave_Click">Save</asp:LinkButton>
            |<asp:LinkButton ID="lbtBackT" runat="server" CssClass="back" onclick="lbtBack_Click" CausesValidation="False" >Go Back</asp:LinkButton>
            |<asp:LinkButton ID="lblrefreshT" runat="server" CssClass="refresh" onclick="lblrefresh_Click" CausesValidation="False">Refresh</asp:LinkButton>
        </div>

        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        <table width="600px" style="margin:auto;">
                       
            <tr>
                <td>Cấp độ :</td><td><asp:TextBox ID="txtType" runat="server" CssClass="text" 
                    Width="242px"></asp:TextBox></td><td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtType" ErrorMessage="Bạn phải nhập Loại câu hỏi"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td>Mô tả :</td><td>
                <asp:TextBox ID="txtdes" runat="server" CssClass="text" Height="75px" 
                    TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                <td>
                               
                    
                </td>
            </tr>
        </table>

        <div class="control">
            <asp:LinkButton ID="lbtSaveB" runat="server" CssClass="save" onclick="btnsave_Click">Save</asp:LinkButton>
            |<asp:LinkButton ID="lbtBackB" runat="server" CssClass="back" onclick="lbtBack_Click" CausesValidation="False" >Go Back</asp:LinkButton>
            |<asp:LinkButton ID="lblrefreshB" runat="server" CssClass="refresh" onclick="lblrefresh_Click" CausesValidation="False">Refresh</asp:LinkButton>
        </div>
    </asp:Panel>


    <asp:Panel ID="pnlData" runat="server">
        <div class="control">
            <asp:LinkButton ID="lbtAddnewT" runat="server" CssClass="add" onclick="lbtAddnewT_Click" 
                >Add New</asp:LinkButton>
            |<asp:LinkButton ID="lbtDeleteT" runat="server" CssClass="delete" onclick="lbtDeleteT_Click" 
                >Delete</asp:LinkButton>
            |<asp:LinkButton ID="lbtRefreshT" runat="server" CssClass="refresh" onclick="lbtRefreshT_Click" 
                >Refresh</asp:LinkButton>
            |<a href="javascript:history.back();" id="lbtBackTV" Class="back" 
                >Go Back</a>
        </div>

        <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" CellPadding="4" CssClass="data" 
            ForeColor="#333333" GridLines="Vertical" onrowcommand="gridEmp_RowCommand" 
            AllowPaging="True" onpageindexchanging="gridEmp_PageIndexChanging" 
            onrowdatabound="gridEmp_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server" 
                          AutoPostBack="true" 
                          OnCheckedChanged="chkSelectAll_CheckedChanged"/>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="typ_ID" HeaderText="Mã" />
                <asp:BoundField DataField="Typ_Name" HeaderText="Loại câu hỏi" />
                <asp:BoundField DataField="Typ_Description" HeaderText="Mô tả" />
                <asp:TemplateField HeaderText="Thao tác">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtEdit" runat="server" CommandName="cmdEdit" 
                            ImageUrl="~/admin/IMG/icons/pencil.png" ToolTip="Edit" 
                            CommandArgument='<%# Eval("typ_ID") %>' />
                        <asp:ImageButton ID="ibtDelete" runat="server" CommandName="cmdDelete" 
                            ImageUrl="~/admin/IMG/icons/cross.png" 
                            onclientclick="javascript:return confirm('Are you sure ? ')" 
                            CommandArgument='<%# Eval("typ_ID") %>' />
                        <asp:ImageButton ID="ibtView" runat="server" CommandName="cmdView" 
                            ImageUrl="~/admin/IMG/icons/eye.png" ToolTip="View" 
                            CommandArgument='<%# Eval("typ_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>

        <div class="control">
        <asp:LinkButton ID="lbtAddnewB" runat="server" CssClass="add" onclick="lbtAddnewT_Click" 
            >Add New</asp:LinkButton>
        |<asp:LinkButton ID="lbtDeleteB" runat="server" CssClass="delete" onclick="lbtDeleteT_Click" 
            >Delete</asp:LinkButton>
        |<asp:LinkButton ID="lbtRefreshB" runat="server" CssClass="refresh" onclick="lbtRefreshT_Click" 
            >Refresh</asp:LinkButton>
        |<a href="javascript:history.back();" id="A1" Class="back" 
            >Go Back</a>
    </div>
    </asp:Panel>


</asp:Content>
