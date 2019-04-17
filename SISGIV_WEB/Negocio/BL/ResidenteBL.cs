using Datos.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.BL
{
    public class ResidenteBL
    {
        ResidenteDAL ResidentesDAL = new ResidenteDAL();

        // Get Todos los residentes
        public List<Residente> GetResidenteBL()
        {
            var Query = (from Re in ResidentesDAL.GetResidenteDAL()
                         select Re).ToList();

            return Query;
        }



        // Get Residente por ID
        public Residente GetResidentePorIDBL(int IdResidente) 
        {
        var Query = (from Re in ResidentesDAL.GetResidenteDAL()
                     where Re.IdResidente == IdResidente
                         select Re).Last();
        return Query;
        } 


        // Get Residente por Nombre 
        public List<Residente> GetResidentesPorNombreBL(string NombreResidente) 
        {
        var Query = (from Re in ResidentesDAL.GetResidenteDAL()
                         where Re.Nombres.Contains(NombreResidente)
                         select Re).ToList();

        return Query;
        }



        // Get Residente por Apellido
        public List<Residente> GetResidentesPorApellidoBL(string ApellidoResidente)
        {
            var Query = (from Re in ResidentesDAL.GetResidenteDAL()
                         where Re.Nombres.Contains(ApellidoResidente)
                         select Re).ToList();

            return Query;
        }
         


       // Set Residentes
        public bool SetResidenteBL(Residente NewResidente) 
        {
            bool Resultado = false;

            Resultado = ResidentesDAL.SetResidenteDAL(NewResidente);

            return Resultado;
        }



        // Update Residentes
        public bool UpdateResidenteBL(int IdUpdate, Residente UpdateResidente)
        {
            bool Resultado = false;

            Resultado = ResidentesDAL.UpdateResidenteDAL(IdUpdate, UpdateResidente);

            return Resultado;
        }
    }
}
