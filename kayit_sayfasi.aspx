<%@ Page Title="" Language="C#" MasterPageFile="~/Ana_tasiyici.Master" AutoEventWireup="true" CodeBehind="kayit_sayfasi.aspx.cs" Inherits="sikayet_sistemi_deneme_1.kayit_sayfasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class ="form-group">
        <label>Adınız:</label>
        <asp:TextBox ID="txtAd" runat="server" cssClass="form-control" >

        </asp:TextBox>
        <label>Soyadınız</label>
        <asp:TextBox ID="txtSoyad" runat="server" CssClass="form-control"> </asp:TextBox>
        <label>Email adresiniz</label>
        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" TextMode="Email"> </asp:TextBox>
        <label>şifreniz</label>
        <asp:TextBox ID="txtSifre" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

        <asp:Button ID="btnKayitOl" runat="server" text="Kayit Ol" CssClass="btn btn-primary" OnClick="btnKayitOl_Click" /> <br /><br />
        <asp:Label ID="lblMesaj" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <p>
</p>
</asp:Content>
