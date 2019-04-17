using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class RecursoDAL
    {
        // Gat todos los recursos
        public List<Recurso> GetRecursoDAL()
        {
            List<Recurso> Recursos = new List<Recurso>();

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                Recursos = Re.Recurso.ToList<Recurso>();
            }
            return Recursos;
        }



        // Set Recurso
        public bool SetRecursoDAL(Recurso NewRecurso)
        {
            bool Resultado = false;

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                Re.Recurso.Add(NewRecurso);
                Re.SaveChanges();

                Resultado = true;
            }

            return Resultado;
        }



        // Update Recurso
        public bool UpdateRecursoDAL(int IdUpdate, Recurso UpdateRecurso)
        {
            bool Resultado = false;

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                var Rec = Re.Recurso.Where(x => x.IdRecurso == IdUpdate).ToList().Last();

                Rec.Nombre = UpdateRecurso.Nombre;
                Rec.Estado = UpdateRecurso.Estado;
                Rec.Tipo = UpdateRecurso.Tipo;

                Re.SaveChanges();

                Resultado = true;
            }

            return Resultado;
        }
    }
}
