using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_TipoAnimal
    {

        //VARIAVEIS GLOBAIS DA CLASSE
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_tipoAnimal;
        SqlDataAdapter da_tipoAnimal;
        List<Tipoanimal> lista_TipoAnimal = new List<Tipoanimal>();
    }
}
