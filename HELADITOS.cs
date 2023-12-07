using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;

namespace HELADITO
{
    class HELADITOS
    {
        string cadena;
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        public HELADITOS()
        {
            cadena = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HELADITO.mdb";
            conector = new OleDbConnection(cadena);
            comando = new OleDbCommand();
            tabla = new DataTable();
        }

        public DataTable gustos()
        {
            string query = "SELECT DISTINCT gusto_id, nombre FROM Gustos";
            return Query(query);
        }

        public DataTable sucursales()
        {
            string query = "SELECT DISTINCT sucursal_id, nombre FROM Sucursales";
            return Query(query);
        }

        private DataTable Query(string query)
        {
            DataTable dataTable = new DataTable();
            using (adaptador = new OleDbDataAdapter(query, conector))
            {
                adaptador.Fill(dataTable);
            }
            return dataTable;
        }

        public DataTable GetVentasPorGusto(int gustoId)
        {

                string query = @"
                SELECT Ventas.fecha AS FECHA, Gustos.nombre AS [NOMBRE DEL GUSTO], Ventas.kilos AS KILOS
                FROM (Ventas
                INNER JOIN Gustos ON Ventas.gusto_id = Gustos.gusto_id)
                INNER JOIN Sucursales ON Sucursales.sucursal_id = Ventas.sucursal_id
            ";

                using (comando = new OleDbCommand(query, conector))
                {
                    comando.Parameters.AddWithValue("@gusto_id", gustoId);

                    using (adaptador = new OleDbDataAdapter(comando))
                    {
                        DataTable dataTable = new DataTable();
                        adaptador.Fill(dataTable);
                        return dataTable;
                    }
                }
        }
    }
}
