<%@ Page Title="Pagina Inicial" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Apolice._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="~/Scripts/Validacao.js" type="text/javascript" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="font-weight:bold">Criar Apólice</div>    
    <span style="height:20px; vertical-align:top">Número apólice :</span> 
    <asp:TextBox ID="txtNumeroApolice" runat="server" TextMode="Number" MaxLength="9"></asp:TextBox>

    <span style="height:20px; vertical-align:top">CPF/CNPJ do segurado :</span> 
    <asp:TextBox ID="txtCpfCnpj" runat="server" TextMode="Number" MaxLength="14"></asp:TextBox>
    <br />
    <span style="height:20px; vertical-align:top">Placa do veículo :</span> 
    <asp:TextBox ID="txtPlacaVeiculo" runat="server" MaxLength="7"></asp:TextBox>

    <span style="height:20px; vertical-align:top">Valor do prêmio :</span> 
    <asp:TextBox ID="txtValorPremio" runat="server" MaxLength="12"></asp:TextBox>

    <asp:Button ID="btnCriar" runat="server" Text="Criar" onclick="Criar_Click" />    
    
    <hr />
    <div style="font-weight:bold">Excluir Apólice por Número</div>
    <span style="height:20px; vertical-align:top">Apólice número :</span>
    <asp:TextBox ID="txtExcluirNumeroApolice" runat="server" MaxLength="9" TextMode="Number"></asp:TextBox>
    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" onclick="Excluir_Click" />
    <hr />

    <div style="font-weight:bold">Pesquisar Apólice</div>
    <span style="height:20px; vertical-align:top">Número apólice :</span>
    <asp:TextBox ID="txtPesquisarNumeroApolice" runat="server" TextMode="Number" MaxLength="9"></asp:TextBox>
    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" onclick="Pesquisar_Click" />
    <asp:GridView ID="gvApolice" runat="server" OnRowDataBound="gvApolice_RowDataBound">
    </asp:GridView>    
    <hr />

    <div style="font-weight:bold">Alterar Apólice</div>
    <span style="height:20px; vertical-align:top">Apólice Número :</span>
    <asp:DropDownList ID="ddlApolice" runat="server" AutoPostBack="True" onselectedindexchanged="Apolice_SelectedIndexChanged">    
    </asp:DropDownList>        
    <br />
    <span style="height:20px; vertical-align:top">Número apólice :</span>
    <asp:TextBox ID="txtAlterarNumeroApolice" runat="server" MaxLength="9" TextMode="Number"></asp:TextBox>

    <span style="height:20px; vertical-align:top">CPF/CNPJ do segurado :</span> 
    <asp:TextBox ID="txtAlterarCpfCnpj" runat="server" MaxLength="14" TextMode="Number"></asp:TextBox>
    <br />
    <span style="height:20px; vertical-align:top">Placa do veículo :</span> 
    <asp:TextBox ID="txtAlterarPlacaVeiculo" runat="server" MaxLength="7"></asp:TextBox>

    <span style="height:20px; vertical-align:top">Valor do prêmio :</span> 
    <asp:TextBox ID="txtAlterarValorPremio" runat="server" MaxLength="12">
    </asp:TextBox>
    <asp:RegularExpressionValidator runat="server" ErrorMessage="Somente números" ID="txtregpre" ValidationGroup="Insert"
      ForeColor="Red" ControlToValidate="txtAlterarValorPremio" ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>

    <asp:Button ID="btnAlterarApolice" runat="server" Text="Alterar Apolice" onclick="AlterarApolice_Click" />
    <hr />

    <span id="aviso" class="failureNotification" runat="server"></span>
</asp:Content>
