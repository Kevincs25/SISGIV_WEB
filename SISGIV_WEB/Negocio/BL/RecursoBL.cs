using Datos.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.BL
{
    public class RecursoBL
    {
        RecursoDAL RecursosDAL = new RecursoDAL();

        // Get todos los recursos
        public List<Recurso> GetRecursoBL()
        {
            var Query = (from Re in RecursosDAL.GetRecursoDAL()
                         select Re).ToList();

            return Query;
        }


        // Get Recurso por ID
        public Recurso GetRecursoPorIDBL(int IdRecurso)
        {
            var Query = (from Re in RecursosDAL.GetRecursoDAL()
                         where Re.IdRecurso == IdRecurso
                         select Re).Last();
            return Query;
        }


        // Get Recurso por Nombre 
        public List<Recurso> GetRecursosPorNombreBL(string NombreRecurso)
        {
            var Query = (from Re in RecursosDAL.GetRecursoDAL()
                         where Re.Nombre.Contains(NombreRecurso)
                         select Re).ToList();

            return Query;
        }



        // Set Recurso
        public bool SetRecursoBL(Recurso NewRecurso)
        {
            bool Resultado = false;

            Resultado = RecursosDAL.SetRecursoDAL(NewRecurso);

            return Resultado;
        }



        // Update Recursos
        public bool UpdateRecursoBL(int IdUpdate, Recurso UpdateRecurso)
        {
            bool Resultado = false;

            Resultado = RecursosDAL.UpdateRecursoDAL(IdUpdate, UpdateRecurso);

            return Resultado;
        }


    }
}