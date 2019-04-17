using Datos.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.BL
{
    public class CasaBL
    {
        CasaDAL CasasDAL = new CasaDAL();

        // Get todas las casas
        public List<Casa> GetCasaBL()
        {
            var Query = (from Ca in CasasDAL.GetCasaDAL()
                         select Ca).ToList();

            return Query;
        }


        // Get Recurso por ID
        public Casa GetCasaPorIDBL(int IdCasa)
        {
            var Query = (from Ca in CasasDAL.GetCasaDAL()
                         where Ca.IdCasa == IdCasa
                         select Ca).Last();
            return Query;
        }


        // Get Recurso por Nombre 
        //public List<Recurso> GetRecursosPorNombreBL(string NombreRecurso)
        //{
        //    var Query = (from Re in RecursosDAL.GetRecursoDAL()
        //                 where Re.Nombre.Contains(NombreRecurso)
        //                 select Re).ToList();

        //    return Query;
        //}



        // Set Recurso
        public bool SetCasaBL(Casa NewCasa)
        {
            bool Resultado = false;

            Resultado = CasasDAL.SetCasaDAL(NewCasa);

            return Resultado;
        }



        // Update Recursos
        public bool UpdateCasaBL(int IdUpdate, Casa UpdateCasa)
        {
            bool Resultado = false;

            Resultado = CasasDAL.UpdateCasaDAL(IdUpdate, UpdateCasa);

            return Resultado;
        }




        // Get Todos los residentes
        public List<Residente> GetResidenteBL()
        {
            var Query = (from Re in CasasDAL.GetResidenteDAL()
                         select Re).ToList();

            return Query;
        }



        // Get Residente por ID
        public Residente GetResidentePorIDBL(int IdResidente)
        {
            var Query = (from Re in CasasDAL.GetResidenteDAL()
                         where Re.IdResidente == IdResidente
                         select Re).Last();
            return Query;
        } 


    }
}
