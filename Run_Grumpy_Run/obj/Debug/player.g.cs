<<<<<<< HEAD
﻿#pragma checksum "C:\Users\Florian\Documents\GitHub\Run_Grumpy_Run\Run_Grumpy_Run\player.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EFFEBAC994F93CC8E102A78E8FD03C83"
=======
﻿#pragma checksum "C:\Users\Karegan\Documents\Run_Grumpy_Run\Run_Grumpy_Run\player.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EFFEBAC994F93CC8E102A78E8FD03C83"
>>>>>>> 785d7a8d721b63ea5a28674b4ce46d772ec2a7af
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Run_Grumpy_Run {
    
    
    public partial class player : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal System.Windows.Shapes.Rectangle rect;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Run_Grumpy_Run;component/player.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.rect = ((System.Windows.Shapes.Rectangle)(this.FindName("rect")));
        }
    }
}

