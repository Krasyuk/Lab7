﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CodeListeners.aspx.cs" Inherits="LanguageCoursesWebApp.CodeListeners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
<table border="0">
    <tr>
    <td>
    <asp:Label ID="LabelFindListener" runat="server" Text="Label">Слушатель</asp:Label><asp:TextBox ID="TextBoxFindListener" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonFindListener" runat="server" Text="Найти" OnClick="ButtonFindListener_Click" />
    <br />        
        <asp:GridView ID="GridViewListener" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" 
            AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" 
            OnRowCancelingEdit="GridViewListener_RowCancelingEdit" 
            OnRowDeleting="GridViewListener_RowDeleting" 
            OnRowEditing="GridViewListener_RowEditing" 
            OnRowUpdating="GridViewListener_RowUpdating" PageSize="15" 
            OnPageIndexChanging="GridViewListener_PageIndexChanging"
            Caption="Слушатели" 
            EmptyDataText="Нет данных" CaptionAlign="Top" PageIndex="0">
            <Columns>
                <asp:BoundField DataField="ListenerId" HeaderText="Код" SortExpression="ListenerId" />
                <asp:BoundField DataField="NameOfListener" HeaderText="Имя" SortExpression="NameOfListener" />
                <asp:BoundField DataField="Surname" HeaderText="Фамилия" SortExpression="Surname" />
                <asp:BoundField DataField="MiddleName" HeaderText="Отчество" SortExpression="MiddleName" />
                <asp:TemplateField HeaderText="Дата рождения" SortExpression="DatOfBirth">
                    <EditItemTemplate>
                        <asp:Calendar ID="DateOfBirthCalendar" runat="server" SelectedDate='<%# Bind("DateOfBirth") %>'></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="DateOfBirth" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Address" HeaderText="Адрес" SortExpression="Address" />
                <asp:BoundField DataField="Phone" HeaderText="Номер" SortExpression="Phone" />
                <asp:BoundField DataField="PassportData" HeaderText="Данные паспорта" SortExpression="PassportData" />
            </Columns>
            
    </asp:GridView>
        </td>
        <td>
        <strong>Добавить нового слушателя:</strong>
            <br />
            <asp:label runat="server">Имя:</asp:label><asp:TextBox ID="TextBoxNameOfListener" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Фамилия:</asp:label><asp:TextBox ID="TextBoxSurName" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Отчество:</asp:label><asp:TextBox ID="TextBoxMiddleName" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Дата рождения:</asp:label><asp:Calendar ID="TextBoxDateOfBirth" runat="server"></asp:Calendar>
            <br />
            <asp:label runat="server">Адрес:</asp:label><asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Номер телефона:</asp:label><asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Паспортные данные:</asp:label><asp:TextBox ID="TextBoxPassportData" runat="server"></asp:TextBox>
            <br />
        </td>
        <td>
            <asp:Button ID="ButtonAddListener" runat="server" Text="Добавить" OnClick="ButtonAddListener_Click" />

        </td>
</tr>
</table>
    </asp:Content>



