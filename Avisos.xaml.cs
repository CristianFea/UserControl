using FEAGROPilot_v22.Controladores;
using pruebaUserControl;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace FEAGROPilot_v22
{
    public sealed partial class Avisos : UserControl
    {
        public enum Aviso
        {
            Info,
            Aviso,
            _Aviso,
            Advertencia,
            Atencion,
            Cuidado,
            Peligro
        }
        public Aviso aviso;
        public string strImagen = "";
        public string strMsj = "";
        SolidColorBrush letrasSup;
        SolidColorBrush color;
        SolidColorBrush colorInf;
        private  Popup popup;

        public static async void Mostrar(string MensajeError, string ImgAlerta, int numErr)
        {
            try
            {
                var s = new Avisos();
                s.aviso = (Aviso)numErr;
                s.strImagen = "ms-appx:///Imagenes/Advertencias/" + ImgAlerta + ".png";
                s.strMsj = MensajeError;                
                s.popup.IsOpen = true;
                await Task.Delay(5000);
                s.popup.IsOpen = false;
            }
            catch {  }
        }
        public Avisos()
        {            
            color = Color((int)aviso);
            if ((int)aviso == 3 || (int)aviso == 4)
            {
                colorInf = App.amarillo;
                letrasSup = App.negro;
            }
            else
            {
                colorInf = App.fondo;
                letrasSup = App.blanco;
            }
            beep((int)aviso);
            InitializeComponent();
            popup = new Popup();
            popup.Child = this;
        }      
        void beep(int valor)
        {
            switch (valor)
            {
                case 0:
                case 1:
                case 2:
                    GPIO.Beep(2);
                    GPIO.LedAlerta(2);
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    GPIO.Beep(3);
                    GPIO.LedAlerta(3);
                    break;
            }
        }
        public SolidColorBrush Color(int Valor)
        {
            switch (Valor)
            {
                case 0:
                case 1:
                    return App.verde;
                case 2:
                    return App.azul;
                case 3:
                case 4:
                    return App.amarillo;
                case 5:
                case 6:
                    return App.rojo;
                default:
                    return App.verde;
            }
        }
    }
}
