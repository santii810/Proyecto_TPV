﻿#pragma checksum "..\..\VentanaSecundaria.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8ED2F9ABAA18F68F5D6A934549622491"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_TPV;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Proyecto_TPV {
    
    
    /// <summary>
    /// VentanaSecundaria
    /// </summary>
    public partial class VentanaSecundaria : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\VentanaSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelActualizarPrecio;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\VentanaSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNuevoPrecio;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\VentanaSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAceptarNuevoPrecio;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto_TPV;component/ventanasecundaria.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaSecundaria.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.panelActualizarPrecio = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.textBoxNuevoPrecio = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\VentanaSecundaria.xaml"
            this.textBoxNuevoPrecio.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBoxNuevoPrecio_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonAceptarNuevoPrecio = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\VentanaSecundaria.xaml"
            this.buttonAceptarNuevoPrecio.Click += new System.Windows.RoutedEventHandler(this.buttonAceptarNuevoPrecio_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

