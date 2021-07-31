// FechaProgramacionView.cs21:3021:30

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class FechaProgramacionView
    {
        [Key] public DateTime Fecha { get; set; }
    }
}