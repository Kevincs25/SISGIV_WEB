using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class ResidenteDAL
    {
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



        // Set Residentes
        public bool SetResidenteDAL(Residente NewResidente) 
        {
            bool Resultado = false;

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                Re.Residente.Add(NewResidente);
                Re.SaveChanges();

                Resultado = true;
            }

            return Resultado;
        }



        // Update Residente
        public bool UpdateResidenteDAL(int IdUpdate , Residente UpdateResidente )
        {
            bool Resultado = false;

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                var Res = Re.Residente.Where(x => x.IdResidente == IdUpdate).ToList().Last();

                Res.Nombres = UpdateResidente.Nombres;
                Res.Apellidos = UpdateResidente.Apellidos;
                Res.Edad = UpdateResidente.Edad;
                Res.Telefono = UpdateResidente.Telefono;
                Res.Correo = UpdateResidente.Correo;
                Res.Estado = UpdateResidente.Estado;
                Res.Cedula = UpdateResidente.Cedula;

                Re.SaveChanges();

                Resultado = true;
            }

            return Resultado;
        }

    }
}
