﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Facturas;
using System.Data.SqlClient;
using System.Data;

namespace FrbaOfertas.Utils
{
    public class FacturaDAO
    {
        public void crearFactura(Factura factura)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].CrearFactura");

            sp.Parameters.AddWithValue("NroFactura", factura.nro_factura);
            sp.Parameters.AddWithValue("ImporteFactura", factura.importe_fact);
            sp.Parameters.AddWithValue("FechaInicio", factura.fecha_inicio);
            sp.Parameters.AddWithValue("FechaFin", factura.fecha_fin);
            sp.Parameters.AddWithValue("IdProveedor", factura.proveedor.id);


            SqlParameter text = new SqlParameter("@out", SqlDbType.VarChar, 1000);
            text.Direction = ParameterDirection.Output;
            sp.Parameters.Add(text);

            FrbaOfertas.Utils.Database.executeProcedure(sp);

            if (!String.IsNullOrEmpty(text.Value.ToString()))
            {
                throw new Exception(text.Value.ToString());
            }
        }
    }
}
