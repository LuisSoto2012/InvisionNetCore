using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Utils
{
    [System.AttributeUsage(
        System.AttributeTargets.Class |
        System.AttributeTargets.Property |
        System.AttributeTargets.Field |
                           System.AttributeTargets.Struct
                           )
    ]
    public class ObjectDumperAnnotation : System.Attribute
    {
        public string Preffix;
        public bool Excluir = false;
    }
}
