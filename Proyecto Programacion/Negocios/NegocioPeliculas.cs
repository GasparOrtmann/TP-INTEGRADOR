﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades;

namespace Negocios
{
    public class NegocioPeliculas
    {

        public DataTable getListaPeliculas()
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculas();
        }

        public DataTable getListaPeliculasPorID(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorID(campo);
        }

        public DataTable getListaPeliculasPorTitulo(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorTitulo(campo);
        }

        public DataTable getListaPeliculasPorDescripcion(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorDescripcion(campo);
        }

        public DataTable getListaPeliculasPorDuracion(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorDuracion(campo);
        }

        public DataTable getListaPeliculasPorClasificacion(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorClasificacion(campo);
        }

        public DataTable getListaPeliculasPorGenero(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorGenero(campo);
        }

        public DataTable getListaPeliculasPorFormato(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorFormato(campo);
        }

        public DataTable getListaPeliculasPorPortada(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorPortada(campo);
        }

        public DataTable getListaPeliculasPorEstado(string campo)
        {
            DAOPeliculas dao = new DAOPeliculas();
            return dao.getTablaPeliculaPorEstado(campo);
        }





        public DataTable CrearTablaSession()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID_Pelicula_P", typeof(string));
            tabla.Columns.Add("Titulo_P", typeof(string));
            tabla.Columns.Add("Descripcion_P", typeof(string));
            tabla.Columns.Add("Duracion_P", typeof(string));
            tabla.Columns.Add("Clasificacion_P", typeof(string));
            tabla.Columns.Add("Genero_P", typeof(string));
            tabla.Columns.Add("Formato_P ", typeof(string));
            tabla.Columns.Add("Estado_P", typeof(bool));
            return tabla;
        }
        public bool EliminarPelicula(string id)
        {
            DAOPeliculas dao = new DAOPeliculas();
            Peliculas pel= new Peliculas();
            pel.ID_Pelicula = id;
            int op = dao.EliminarPeliculas(pel);
            if (op == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AgregarPelicula(Peliculas Pel)
        {
            int cantFilas = 0;
            DAOPeliculas daoPel = new DAOPeliculas();

            cantFilas = daoPel.AgregarPeliculas(Pel);

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarPelicula(Peliculas com)
        {
            int cantFilas = 0;
            DAOPeliculas daoCom = new DAOPeliculas();

            cantFilas = daoCom.ModificarPeliculas(com);

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}