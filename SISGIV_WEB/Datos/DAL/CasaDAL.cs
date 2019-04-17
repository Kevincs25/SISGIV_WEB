using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class CasaDAL
    {
        // Get todos las casas
        public List<Casa> GetCasaDAL() 
        {
            List<Casa> Casas = new List<Casa>();

            using (SISGIV_Entities Ca = new SISGIV_Entities()) 
            {
                Casas = Ca.Casa.ToList<Casa>();
            }
            return Casas;
        }


        // Set casa
        public bool SetCasaDAL(Casa NewCasa)
        {
            bool Resultado = false;

            using (SISGIV_Entities Ca = new SISGIV_Entities())
            {
                Ca.Casa.Add(NewCasa);
                Ca.SaveChanges();

                Resultado = true;
            }

            return Resultado;
        }




        // Update Casa
        public bool UpdateCasaDAL(int IdUpdate, Casa UpdateCasa)
        {
            bool Resultado = false;

            using (SISGIV_Entities Ca = new SISGIV_Entities())
            {
                var Cas = Ca.Casa.Where(x => x.IdCasa == IdUpdate).ToList().Last();

                Cas.IdArea = UpdateCasa.IdArea;
                Cas.IdResidente = UpdateCasa.IdResidente;
                Cas.NumeroDeHabitantes = UpdateCasa.NumeroDeHabitantes;
                Cas.Telefono = UpdateCasa.Telefono;
                Cas.Descripcion = UpdateCasa.Descripcion;
                Cas.Letra = UpdateCasa.Letra;
                Cas.Estado = UpdateCasa.Estado;
                
                Ca.SaveChanges();

                Resultado = true;
            }

            return Resultado;
        }



         // Get todos los residententes
        public List<Residente> GetResidenteDAL()
        {
            List<Residente> Recursos = new List<Residente>();

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                Recursos = Re.Residente.ToList<Residente>();
            }
            return Recursos;
        }
    }
}