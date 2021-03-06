﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CodeCourses.aspx.cs" Inherits="LanguageCoursesWebApp.CodeCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
<table border="0">
    <tr>
    <td>
    <asp:Label ID="LabelFindCourse" runat="server" Text="Label">Курс</asp:Label><asp:TextBox ID="TextBoxFindCourse" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonFindCourse" runat="server" Text="Найти" OnClick="ButtonFindCourse_Click" />
    <br />        
        <asp:GridView ID="GridViewCourse" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" 
            AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" 
            OnRowCancelingEdit="GridViewCourse_RowCancelingEdit" 
            OnRowDeleting="GridViewCourse_RowDeleting" 
            OnRowEditing="GridViewCourse_RowEditing" 
            OnRowUpdating="GridViewCourse_RowUpdating" PageSize="15" 
            OnPageIndexChanging="GridViewCourse_PageIndexChanging"
            Caption="Наименования курсов" 
            EmptyDataText="Нет данных" CaptionAlign="Top" PageIndex="0">
            <Columns>
                <asp:BoundField DataField="CourseId" HeaderText="Код" SortExpression="CourseId" />
                <asp:BoundField DataField="NameOfCourse" HeaderText="Наименование" SortExpression="NameOfCourse" />
                <asp:BoundField DataField="TrainingProgram" HeaderText="Программа" SortExpression="TrainingProgram" />
                <asp:BoundField DataField="Description" HeaderText="Описание" SortExpression="Description" />
                <asp:BoundField DataField="IntensityOfClasses" HeaderText="Интенсивность занятий" SortExpression="IntensityOfClasses" />
                <asp:BoundField DataField="GroupSize" HeaderText="Размер группы" SortExpression="GroupSize" />
                <asp:BoundField DataField="FreePlaces" HeaderText="Сводобные места" SortExpression="FreePlaces" />
                <asp:BoundField DataField="NumberOfHours" HeaderText="Количество часов" SortExpression="NumberOfHours" />
                <asp:BoundField DataField="Cost" HeaderText="Стоимость" SortExpression="Cost" />
                <asp:TemplateField HeaderText="Преподаватель" SortExpression="TeacherId">
                <EditItemTemplate>
                    <asp:DropDownList ID="TeacherDropDownList" runat="server" DataSourceID="SqlDataSourceTeacher" DataTextField="name" DataValueField="teacherId" SelectedValue='<%# Bind("teacherId") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                 <asp:Label ID="TeacherId" runat="server"  Text='<%# Eval("Teacher.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            
    </asp:GridView>
        </td>
        <td>
        <strong>Добавить:</strong>
            <br />
            <asp:label runat="server">Наименование:</asp:label><asp:TextBox ID="TextBoxNameOfCourse" runat="server"></asp:TextBox>
            <br />
           <asp:label runat="server">Программа:</asp:label><asp:TextBox ID="TextBoxProgram" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Описание:</asp:label><asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Интенсивнось занятий:</asp:label><asp:TextBox ID="TextBoxIntensityOfClasses" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Размер группы:</asp:label><asp:TextBox ID="TextBoxGroupSize" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Свободные места:</asp:label><asp:TextBox ID="TextBoxFreePlaces" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Количество часов:</asp:label><asp:TextBox ID="TextBoxNumberOfHours" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Стоимость:</asp:label><asp:TextBox ID="TextBoxCost" runat="server"></asp:TextBox>
            <br />
            Учитель
           <asp:DropDownList ID="TeacherDropDownList" DataSourceID="SqlDataSourceTeacher" DataValueField="teacherId" DataTextField="name" runat="server"></asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="ButtonAddCourse" runat="server" Text="Добавить" OnClick="ButtonAddCourse_Click" />

        </td>
</tr>
</table>
    <asp:SqlDataSource ID="SqlDataSourceTeacher" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LanguageConnectionString %>" 
        SelectCommand="SELECT [teacherId], [name] FROM [Teachers]">
    </asp:SqlDataSource>
    </asp:Content>

