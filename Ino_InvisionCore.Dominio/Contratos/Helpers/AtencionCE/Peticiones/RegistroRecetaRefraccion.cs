using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones
{
    public class RegistroRecetaRefraccion
    {
        public int IdCita { get; set; }

        public string LSignoOD1 { get; set; }
        public string LEsferaOD { get; set; }
        public string LSignoOD2 { get; set; }
        public string LCilindroOD { get; set; }
        public string LEjeOD { get; set; }

        public string LSignoOI1 { get; set; }
        public string LEsferaOI { get; set; }
        public string LSignoOI2 { get; set; }
        public string LCilindroOI { get; set; }
        public string LEjeOI { get; set; }

        public string Ldip { get; set; }
        public string Lprisma { get; set; }

        public string CSignoOD1 { get; set; }
        public string CEsferaOD { get; set; }
        public string CSignoOD2 { get; set; }
        public string CCilindroOD { get; set; }
        public string CEjeOD { get; set; }

        public string CSignoOI1 { get; set; }
        public string CEsferaOI { get; set; }
        public string CSignoOI2 { get; set; }
        public string CCilindroOI { get; set; }
        public string CEjeOI { get; set; }

        public string Cdip { get; set; }
        public string Cprisma { get; set; }

        public ComboBox Material { get; set; }
        public ComboBox Bifocal { get; set; }

        public bool AdicionalMas { get; set; }
        public bool AdicionalMenos { get; set; }

        public ComboBox Especificacion1 { get; set; }
        public ComboBox Especificacion2 { get; set; }
        public ComboBox Especificacion3 { get; set; }
        public ComboBox Especificacion4 { get; set; }
        public ComboBox Especificacion5 { get; set; }

        public string Paciente { get; set; }
        public string NroDocumento { get; set; }
        public string DxOD { get; set; }
        public string DxOI { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool EstaImpreso { get; set; }

        public RegistroRecetaRefraccion()
        {
            FechaCreacion = DateTime.Now;
            EstaImpreso = false;
        }

    }
}
