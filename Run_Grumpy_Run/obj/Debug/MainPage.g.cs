﻿#pragma checksum "C:\Users\Karegan\Documents\Run_Grumpy_Run\Run_Grumpy_Run\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C7C26B90C82C8C261091F5E93D94788D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Run_Grumpy_Run;
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
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal Run_Grumpy_Run.player x_player;
        
        internal System.Windows.Controls.TextBlock DebugBox;
        
        internal System.Windows.Shapes.Rectangle gameOver;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Run_Grumpy_Run;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.x_player = ((Run_Grumpy_Run.player)(this.FindName("x_player")));
            this.DebugBox = ((System.Windows.Controls.TextBlock)(this.FindName("DebugBox")));
            this.gameOver = ((System.Windows.Shapes.Rectangle)(this.FindName("gameOver")));
        }
    }
}

