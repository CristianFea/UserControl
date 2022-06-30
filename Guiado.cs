using System;
using System.Threading.Tasks;

using FEAGROPilot_v22.Controladores;

namespace FEAGROPilot_v22.CodigoGeneral
{
    class Guiado
    {
        public static void Act_Desac()
        {
            //Task.Run(() => GPIO.Beep(1));
            Avisos.Mostrar("Acerquese a la linea", "Rombo", 2);
        }
    } 
}
