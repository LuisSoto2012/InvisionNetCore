using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones
{
    public class RegistroRecetaRefraccion
    {
        public int IdCita { get; set; }

        public ComboBox LSignoOD1 { get; set; }
        public string LEsferaOD { get; set; }
        public ComboBox LSignoOD2 { get; set; }
        public string LCilindroOD { get; set; }
        public string LEjeOD { get; set; }
        public string LAVOD { get; set; }

        public ComboBox LSignoOI1 { get; set; }
        public string LEsferaOI { get; set; }
        public ComboBox LSignoOI2 { get; set; }
        public string LCilindroOI { get; set; }
        public string LEjeOI { get; set; }
        public string LAVOI { get; set; }

        public string Ldip { get; set; }
        public string Lprisma { get; set; }

        public ComboBox CSignoOD1 { get; set; }
        public string CEsferaOD { get; set; }
        public ComboBox CSignoOD2 { get; set; }
        public string CCilindroOD { get; set; }
        public string CEjeOD { get; set; }
        public string CAVOD { get; set; }

        public ComboBox CSignoOI1 { get; set; }
        public string CEsferaOI { get; set; }
        public ComboBox CSignoOI2 { get; set; }
        public string CCilindroOI { get; set; }
        public string CEjeOI { get; set; }
        public string CAVOI { get; set; }

        public string Cdip { get; set; }
        public string Cprisma { get; set; }

        public string ADD { get; set; }
        public string Observaciones { get; set; }

        //public ComboBox Material { get; set; }
        //public ComboBox Bifocal { get; set; }

        //public bool AdicionalMas { get; set; }
        //public bool AdicionalMenos { get; set; }

        public List<ComboBox> Material { get; set; }
        public List<ComboBox> Diseno { get; set; }
        public List<ComboBox> Tratamiento { get; set; }
        public List<ComboBox> Servicio { get; set; }
        //public ComboBox Especificacion5 { get; set; }

        public string Paciente { get; set; }
        public string NroDocumento { get; set; }
        public string DxOD { get; set; }
        public string DxOI { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool EstaImpreso { get; set; }

        public string[] ListaDeDx { get; set; }

        public string LNSPD { get; set; }
        public string LNSPI { get; set; }
        public string CNSPD { get; set; }
        public string CNSPI { get; set; }

        public RegistroRecetaRefraccion()
        {
            FechaCreacion = DateTime.Now;
            EstaImpreso = false;
        }

    }
}
