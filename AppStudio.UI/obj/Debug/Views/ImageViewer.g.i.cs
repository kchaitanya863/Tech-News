﻿#pragma checksum "C:\Users\Krishna\Desktop\TN Universal\APP-NEw\AppStudio.UI\Views\ImageViewer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "14DE691EF7A81F52540C1D4EB8CC9D13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace AppStudio {
    
    
    public partial class ImageViewer : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Primitives.ViewportControl viewport;
        
        internal System.Windows.Controls.Canvas canvas;
        
        internal System.Windows.Controls.Image image;
        
        internal System.Windows.Media.ScaleTransform transform;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/AppStudio;component/Views/ImageViewer.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.viewport = ((System.Windows.Controls.Primitives.ViewportControl)(this.FindName("viewport")));
            this.canvas = ((System.Windows.Controls.Canvas)(this.FindName("canvas")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
            this.transform = ((System.Windows.Media.ScaleTransform)(this.FindName("transform")));
        }
    }
}

