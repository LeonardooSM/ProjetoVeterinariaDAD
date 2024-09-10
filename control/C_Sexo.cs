﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.model;
using Veterinaria.conection;
using System.Windows.Forms;

namespace Veterinaria.control
{
    internal class C_Sexo : I_Metodos_Comuns
    {
        //VARIAVEIS GLOBAIS DA CLASSE
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_sexo;
        SqlDataAdapter da_sexo;
        List<Sexo> lista_sexo = new List<Sexo>();


       public List<Sexo> DadosSexo()
        {

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_sexo;
            conn.Open();

            try
            {
                dr_sexo = cmd.ExecuteReader();
                while (dr_sexo.Read())
                {
                    Sexo aux = new Sexo();
                    aux.codsexo = Int32.Parse(dr_sexo["codsexo"].ToString());
                    aux.nomesexo = dr_sexo["nomesexo"].ToString();
                    lista_sexo.Add(aux);
                }
            }
            catch (Exception ex)
            {

            }

            return lista_sexo;

        }


        public List<Sexo> DadosSexoFiltro(String parametro)
        {
            //Cria uma lista do tipo sexo -Array


            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("pnomesexo", parametro + "%");


            SqlDataReader dr_raca;
            conn.Open();

            try
            {
                dr_raca = cmd.ExecuteReader();
                while (dr_raca.Read())
                {
                    Sexo aux = new Sexo();
                    aux.codsexo = Int32.Parse(dr_raca["codsexo"].ToString());
                    aux.nomesexo = dr_raca["nomesexo"].ToString();

                    lista_sexo.Add(aux);
                }
            }
            catch (Exception ex)
            {

            }


            return lista_sexo;
        }

        String sqlApaga = "delete from sexo where codsexo = @pcod";
        public void Apaga_Dados(int aux)
        {

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcod", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Apaguei");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }

        }

        String sqlAtualiza = "update sexo set nomesexo = @pnome where" +
            " codsexo= @pcod";
        public void Atualizar_Dados(object aux)
        {
           Sexo dados = new Sexo();
            dados = (Sexo)aux;


            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codsexo);
            cmd.Parameters.AddWithValue("@pnome", dados.nomesexo);

            // cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Atualizei");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            };
        }


        String sqlFiltro = "select * from sexo where nomesexo like @pnomesexo";
        public DataTable Buscar_Filtro(String psexo)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomesexo", psexo);
            //Abrir conexão
            conn.Open();

            //Criar o DataAdapter
            da_sexo = new SqlDataAdapter(cmd);

            dt_sexo = new DataTable();
            da_sexo.Fill(dt_sexo);

            //Finaliza a Conexão
            conn.Close();
            return dt_sexo;
        }

        public object Buscar_Id(int valor)
        {
            throw new NotImplementedException();
        }

        String sqlTodos = "select * from sexo";
        public DataTable Buscar_Todos()
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            conn.Open();
            da_sexo = new SqlDataAdapter(cmd);
            dt_sexo = new DataTable();
            da_sexo.Fill(dt_sexo); 


            return dt_sexo;
        }


        String sqlInsere = "insert into sexo(nomesexo) values (@pnome)";
        public void Insere_Dados(object aux)
        {
            Sexo sexo = new Sexo();
            sexo = (Sexo)aux; //casting

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", sexo.nomesexo);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Inseriu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
