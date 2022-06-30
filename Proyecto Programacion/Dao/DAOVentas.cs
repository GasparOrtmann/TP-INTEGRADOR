﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOVentas
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable getTablaVentasPorIDVenta(string campo)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas WHERE ID_Venta_V LIKE '" + campo + "' ORDER BY ABS(ID_Venta_V)");
            return tabla;
        }
        public DataTable cantidadVentas()
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT COUNT(ID_Venta_V) AS [CANTIDAD] FROM Ventas");
            return tabla;
        }
        public DataTable dineroGanado()
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT SUM (Monto_Final_V) AS [TOTAL] FROM Ventas");
            return tabla;
        }
        

        public DataTable getTablaVentasPorIDUsuario(string campo)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas WHERE ID_Usuario_V LIKE '" + campo + "' ORDER BY ABS(ID_Venta_V)");
            return tabla;
        }
        public DataTable getTablaVentasPorFecha(string campo)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas WHERE Fecha_V LIKE '%" + campo + "%' ORDER BY ABS(ID_Venta_V)");
            return tabla;
        }
        public DataTable getTablaVentasPorMetodoDePago(string campo)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas WHERE Metodo_Pago_V LIKE '%" + campo + "%' ORDER BY ABS(ID_Venta_V)");
            return tabla;
        }
        public DataTable getTablaVentasPorMontoFinalMayorA(string campo)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas WHERE Monto_Final_V >" + campo);
            return tabla;
        }
        public DataTable getTablaVentasPorMontoFinalMenorA(string campo)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas WHERE Monto_Final_V <" + campo);
            return tabla;
        }
        public DataTable getTablaVentas()
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT ID_Venta_V AS [IDVenta], ID_Usuario_V AS [IDUsuario], Fecha_V AS [Fecha], Metodo_Pago_V AS [MetodoPago], Monto_Final_V AS [MontoFinal] FROM Ventas");
            return tabla;
        }
        public DataTable getTablaVentas2()
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "SELECT format (Fecha_V,'dd/MM/yyyy') AS [FECHA] FROM Ventas");
            return tabla;
        }
        public DataTable getTablaFecha(string Inicio, string Final)
        {
            DataTable tabla = ds.ObtenerTabla("Ventas", "DECLARE @INICIO Date = CAST('"+Inicio+"' as date) DECLARE @FINAL Date = CAST('"+Final+ "' as date) SELECT SUM (Monto_Final_V) AS [TOTAL], COUNT (ID_Venta_V) AS [CANTIDAD_VENTA] FROM Ventas WHERE CAST(Fecha_V as date) >= @INICIO AND CAST(Fecha_V as date) <= @FINAL");
            return tabla;
        }

        public int buscarProximaVenta()
        {

          return  ds.ObtenerMaximo("select max(id_venta_v)  from ventas");
        }
    }
}
