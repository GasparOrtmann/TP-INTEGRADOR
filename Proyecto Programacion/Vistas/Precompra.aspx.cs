﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocios;
using ZXing;
using System.Drawing;
using System.IO;
using System.Text;
using System.Drawing.Imaging;

namespace Vistas
{
    public partial class Precompra : System.Web.UI.Page
    {
        NegocioPeliculas Pel = new NegocioPeliculas();
        NegocioFunciones Fun = new NegocioFunciones();
        NegocioComplejos Com = new NegocioComplejos();
        NegocioVentas Ven = new NegocioVentas();
        private static string codigoRetiro;

        public static string CodigoRetiro { get => codigoRetiro; set => codigoRetiro = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string datosTicket = (string)Session["DATOSTICKET"];
            string[] separador = new string[] { " ", "$" };
            string[] datos = datosTicket.Split(separador, StringSplitOptions.RemoveEmptyEntries);

            DataTable peliculas = Pel.getListaPeliculasPorID(datos[1]);
            DataTable complejos = Com.getListaComplejosPorID(datos[2]);
            DataTable formato = Fun.getTablaPorFuncionid(datos[0]);
            DataTable idioma = Fun.getTablaPoridioma(datos[1],datos[2],formato.Rows[0]["FORMATO"].ToString());
            DataTable fecha = Fun.getTablaPorFecha2(datos[1], datos[2], formato.Rows[0]["FORMATO"].ToString(), idioma.Rows[0]["IDIOMA"].ToString());
            DataTable horario = Fun.getTablaPorHorario2(datos[1], datos[2], formato.Rows[0]["FORMATO"].ToString(), idioma.Rows[0]["IDIOMA"].ToString(), fecha.Rows[0]["FECHA"].ToString()+"/2022");
            DataTable portada = Pel.getPortadaPorID(datos[1]);
            string sala = Request.QueryString["idSala"];
            string costo = Request.QueryString["subtotal"];
            string asientos = Request.QueryString["asientos"];
            string cantidadAsientos = Request.QueryString["cantidadAsientos"];

            lblNombrePelicula.Text = peliculas.Rows[0]["Titulo"].ToString();
            lblSala.Text = sala;
            lblComplejo.Text = complejos.Rows[0]["NOMBRE"].ToString();
            lblIdioma.Text = idioma.Rows[0]["IDIOMA"].ToString();
           lblFormato.Text = formato.Rows[0]["FORMATO"].ToString();
           
            lblFecha.Text = fecha.Rows[0]["FECHA"].ToString();
            lblHorario.Text = horario.Rows[0]["HORARIO"].ToString();
            lblCosto.Text = "$" + costo;
            lblAsientos.Text = asientos;
            codigoRetiro = generadorCodigoRetiro();
            lblCodigoRetiro.Text = codigoRetiro;
            generarQR(peliculas.Rows[0]["Titulo"].ToString());
        }
        protected void generarQR(string nombre)
        {
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var result = writer.Write(nombre);
            string path = Server.MapPath("~/Imagenes/QR/" + codigoRetiro + ".jpg");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            imagenQR.Visible = true;
            imagenQR.ImageUrl = "~/Imagenes/QR/"+codigoRetiro+".jpg";
            int IDVenta = Ven.buscarUltimaVenta();
            int resultado = Ven.setQR(IDVenta, codigoRetiro);

        }
        static string generadorCodigoRetiro()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var codigo = new String(Charsarr);
            return codigo;
        }

        public void desloguear(object sender, EventArgs e)
        {
            Session["DATOSUSUARIO"] = null;
            Response.Redirect("PantallaInicial.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaInicial.aspx");
        }


    }
}