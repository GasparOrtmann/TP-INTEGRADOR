﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMAsientos.aspx.cs" Inherits="Vistas.ABMAsientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asientos ADMIN</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        body {
            font-family: 'Roboto', sans-serif;
            text-align: center;
            font-weight: 500;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:ScriptManager runat="server">
                <Scripts>
                    <asp:ScriptReference Path="Scripts/bootstrap.min.js" />
                    <asp:ScriptReference Path="Scripts/bootstrap.min.js" />
                </Scripts>
            </asp:ScriptManager>
            <nav class="auto-style22" style="background-color: #10179B; padding: 10px 0; display: flex; flex-direction: row; justify-content: space-between; align-items: center;">
                <a class="" href="PantallaInicial.aspx" style="margin-left: 30px;">
                    <img src="Imagenes/Pagina/logo-piola.png" style="width: 120px; height: 70px;" />
                </a>
                <asp:Button runat="server" onclick="desloguear" class="btn" style="height: 50px; color: white; font-weight: 700; font-size: 20px; margin-right: 30px;" Text="Cerrar sesion">
                </asp:Button>
            </nav>
            <div>
                <h1 style="text-align: center; background-color: #343434; padding: 10px 0; color: white;">ASIENTOS</h1>
            </div>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button class="btn btn-secondary" ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button class="btn btn-secondary" ID="btnFiltrarTodo" runat="server" Text="Quitar filtro" OnClick="btnFiltrarTodo_Click" />
                    </td>
                </tr>
            </table>
            <div style="display: flex; flex-direction: row; margin-top: 20px;">
                <a style="width: 20%;text-decoration:none;color:black;" href="PaginaAdmin.aspx">
                <div style=" display: flex; flex-direction: column; justify-content: start; align-items: center;">
                    
                    <img style="width: 100px; height: 100px;" src="Imagenes/Pagina/Persona.png" alt="Alternate Text" />
                        <asp:Label Style="font-size: 20px; font-weight: 700;" ID="LBL_NOMBREUSUARIO" Text="Nombre" runat="server" />
                        <asp:Label Style="font-size: 20px; font-weight: 700;" ID="LBL_APELLIDOUSUARIO" Text="Apellido" runat="server" />
                    
                </div>
                </a>
                <div style="width: 80%">
                    <asp:GridView Style="width: 80%;" ID="gvAsientos" runat="server" AutoGenerateDeleteButton="True" Width="734px" AutoGenerateColumns="False" OnPageIndexChanging="gvAsientos_PageIndexChanging" OnRowDeleting="gvAsientos_RowDeleting" AllowPaging="True" AutoGenerateEditButton="True" OnRowCancelingEdit="gvAsientos_RowCancelingEdit" OnRowEditing="gvAsientos_RowEditing" OnRowUpdating="gvAsientos_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:TemplateField HeaderText="ID ASIENTO">
                                <EditItemTemplate>
                                    <asp:Label ID="LBL_EDT_IDASIENTO" runat="server" Text='<%# Bind("IDASIENTO") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LBL_IT_IDASIENTO" runat="server" Text='<%# Bind("IDASIENTO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID SALA">
                                <EditItemTemplate>
                                    <asp:Label ID="LBL_EDT_IDSALA" runat="server" Text='<%# Bind("IDSALA") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LBL_IT_IDSALA" runat="server" Text='<%# Bind("IDSALA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID COMPLEJO">
                                <EditItemTemplate>
                                    <asp:Label ID="LBL_EDT_IDCOMPLEJO" runat="server" Text='<%# Bind("IDCOMPLEJO") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LBL_IT_IDCOMPLEJO" runat="server" Text='<%# Bind("IDCOMPLEJO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ESTADO">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="TXT_EDT_ESTADO" runat="server" Checked='True' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LBL_IT_ESTADO" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />

                    </asp:GridView>
                </div>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <div style="width: 100%; display: flex; flex-direction: row;">
                <div class="list-group" style="width: 20%;">
                    <asp:Label CssClass="auto-style23 font-weight-bolder" ID="Label5" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Text="MODIFICACION"></asp:Label>

                    <asp:HyperLink CssClass="list-group-item" ID="hlComplejos" runat="server" NavigateUrl="~/ABMComplejo.aspx">Complejos</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlSalas" runat="server" NavigateUrl="~/ABMSalas.aspx">Salas</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlPeliculas" runat="server" NavigateUrl="~/ABMPeliculas.aspx">Peliculas</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlFunciones" runat="server" NavigateUrl="~/ABMFunciones.aspx">Funciones</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlAsientos" runat="server" NavigateUrl="~/ABMAsientos.aspx">Asientos</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlAsientosComprados" runat="server" NavigateUrl="~/ABMAsientosComprados.aspx">Asientos Comprados</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlVentas" runat="server" NavigateUrl="~/Ventas.aspx">Ventas</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlDV" runat="server" NavigateUrl="~/ABMDetalleVentas.aspx">Detalle de Ventas</asp:HyperLink>
                    <asp:HyperLink CssClass="list-group-item" ID="hlUsuarios" runat="server" NavigateUrl="~/ABMUsuario.aspx">Usuarios</asp:HyperLink>
                </div>
                <div style="width: 60%; display: flex; flex-direction: column; gap: 15px;">
                    <h4>AGREGAR ASIENTOS</h4>
                    <div style="display:flex;justify-content:center;flex-direction:row;">
                        <asp:TextBox ID="txtIDAsiento" runat="server" ValidationGroup="Grupo1" placeholder="ID" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIDAsiento" ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="display:flex;justify-content:center;flex-direction:row;">
                        <asp:TextBox ID="txtIDSala" runat="server" ValidationGroup="Grupo1" placeholder="ID SALA" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIDSala" ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="display:flex;justify-content:center;flex-direction:row;">
                        <asp:TextBox ID="txtIDComplejo" runat="server" placeholder="ID COMPLEJO" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIDComplejo" ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="display:flex;justify-content:center;flex-direction:row;gap:20px;">
                        <label>Estado</label>
                        <asp:CheckBox placeholder="Estado" ID="cbEstado" runat="server" />
                    </div>
                    <div style="display:flex;justify-content:center;flex-direction:row;">
                        <asp:Button CssClass="btn btn-primary" ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Guardar" ValidationGroup="Grupo1" />
                    </div>
                    <div style="display:flex;justify-content:center;flex-direction:row;">
                        <asp:Label ID="lblResultadoGuardar" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
