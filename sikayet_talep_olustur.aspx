<%@ Page Title="" Language="C#" MasterPageFile="~/Ana_tasiyici.Master" AutoEventWireup="true" CodeBehind="sikayet_talep_olustur.aspx.cs" Inherits="sikayet_sistemi_deneme_1.sikayet_talep_olustur" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="form-group">
    <label>Bildirim Türü:</label>

   <asp:DropDownList ID="ddlTur" runat="server" CssClass="form-control">
    <asp:ListItem Text="seçiniz..." Value="" />
    <asp:ListItem Text="Şikayet" Value="Sikayet" />
    <asp:ListItem Text="Talep" Value="Talep" />

       </asp:DropDownList>
</div>

    <div class="form-group">
        <asp:TextBox
            ID="txtBaslik" runat="server" CssClass="form-control">
            </asp:TextBox>
        <asp:Button ID="btnGonder" runat="server" Text="Gönder" CssClass="btn btn-primary" />
     <asp:TextBox ID="txtAciklama" runat="server" TextMode= "MultiLine" Rows="5" CssClass="btn btn-primary" > </asp:TextBox>
    </div>

</asp:Content>
