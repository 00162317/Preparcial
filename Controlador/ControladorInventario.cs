﻿using Preparcial.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorInventario
    {
        public static DataTable GetProductosTable()
        {
            DataTable productos = null;

            try
            {
                productos = ConexionBD.EjecutarConsulta("SELECT * FROM INVENTARIO");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return productos;
        }

        public static List<Inventario> GetProductos()
        {
            var productos = new List<Inventario>();
            DataTable dt = null;

            try
            {
                dt = ConexionBD.EjecutarConsulta("SELECT * FROM INVENTARIO");
                foreach(DataRow dr in dt.Rows)
                {
                    productos.Add(new Inventario
                    (
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString()
                    )
                );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return productos;
        }

        public static void AnadirProducto(string nombre, string descripcion, string precio, string stock)
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO INVENTARIO(nombreArticulo, descripcion, precio, stock)" +
                    $" VALUES('{nombre}', '{descripcion}', {precio}, {stock})");

                MessageBox.Show("Se ha agregado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        public static void EliminarProducto(string id)
        {
            try
            {
                ConexionBD.EjecutarComando($"DELETE FROM INVENTARIO WHERE idArticulo = {id}");

                MessageBox.Show("Se ha eliminado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        public static void ActualizarProducto(string id, string stock)
        {
            try
            {
                ConexionBD.EjecutarComando($"UPDATE INVENTARIO SET stock = {stock} WHERE idArticulo = {id}");

                MessageBox.Show("Se ha actualizado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
