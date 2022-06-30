using FEAGROPilot_v22.Controladores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace pruebaUserControl
{
   
    sealed partial class App : Application
    {
        public static SolidColorBrush blanco = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        public static SolidColorBrush verdeclaro = new SolidColorBrush(Color.FromArgb(255, 116, 255, 0));
        public static SolidColorBrush verde = new SolidColorBrush(Windows.UI.Colors.Green);
        public static SolidColorBrush amarillo = new SolidColorBrush(Windows.UI.Colors.Yellow);
        public static SolidColorBrush naranja = new SolidColorBrush(Color.FromArgb(255, 243, 97, 41));
        public static SolidColorBrush rojo = new SolidColorBrush(Windows.UI.Colors.Red);
        public static SolidColorBrush negro = new SolidColorBrush(Windows.UI.Colors.Black);
        public static SolidColorBrush gris = new SolidColorBrush(Windows.UI.Colors.Gray);
        public static SolidColorBrush transparente = new SolidColorBrush(Windows.UI.Colors.Transparent);
        public static SolidColorBrush medioNegro = new SolidColorBrush(Windows.UI.Color.FromArgb(125, 0, 0, 0));
        public static SolidColorBrush fondo = new SolidColorBrush(Color.FromArgb(200, 180, 180, 180));// = "#CCB4B4B4";
        public static SolidColorBrush azul = new SolidColorBrush(Color.FromArgb(255, 12, 26, 171));
        public static SolidColorBrush agua = new SolidColorBrush(Windows.UI.Colors.Aqua);
        public static App Corriente;
        public App()
        {
            this.InitializeComponent();
            Corriente = this;
            this.Suspending += OnSuspending;
            GPIO.IniciarGpio();
            Mcp2515.arrancarMcp2515();
        }

        /// <summary>
        /// Se invoca cuando la aplicación la inicia normalmente el usuario final. Se usarán otros puntos
        /// de entrada cuando la aplicación se inicie para abrir un archivo específico, por ejemplo.
        /// </summary>
        /// <param name="e">Información detallada acerca de la solicitud y el proceso de inicio.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // No repetir la inicialización de la aplicación si la ventana tiene contenido todavía,
            // solo asegurarse de que la ventana está activa.
            if (rootFrame == null)
            {
                // Crear un marco para que actúe como contexto de navegación y navegar a la primera página.
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Cargar el estado de la aplicación suspendida previamente
                }

                // Poner el marco en la ventana actual.
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // Cuando no se restaura la pila de navegación, navegar a la primera página,
                    // configurando la nueva página pasándole la información requerida como
                    //parámetro de navegación
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Asegurarse de que la ventana actual está activa.
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Se invoca cuando la aplicación la inicia normalmente el usuario final. Se usarán otros puntos
        /// </summary>
        /// <param name="sender">Marco que produjo el error de navegación</param>
        /// <param name="e">Detalles sobre el error de navegación</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Se invoca al suspender la ejecución de la aplicación. El estado de la aplicación se guarda
        /// sin saber si la aplicación se terminará o se reanudará con el contenido
        /// de la memoria aún intacto.
        /// </summary>
        /// <param name="sender">Origen de la solicitud de suspensión.</param>
        /// <param name="e">Detalles sobre la solicitud de suspensión.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Guardar el estado de la aplicación y detener toda actividad en segundo plano
            deferral.Complete();
        }
    }
}
