﻿#pragma checksum "C:\Users\Joel\Documents\GitHub\tictactoe\TicTacToe\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAB8F286A64770418E9FBD8F176ED4D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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


namespace TicTacToe {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button UL;
        
        internal System.Windows.Controls.Button UC;
        
        internal System.Windows.Controls.Button UR;
        
        internal System.Windows.Controls.Button ML;
        
        internal System.Windows.Controls.Button MC;
        
        internal System.Windows.Controls.Button MR;
        
        internal System.Windows.Controls.Button DL;
        
        internal System.Windows.Controls.Button DC;
        
        internal System.Windows.Controls.Button DR;
        
        internal System.Windows.Controls.Primitives.Popup winner_popup;
        
        internal System.Windows.Controls.Button new_game;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/TicTacToe;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.UL = ((System.Windows.Controls.Button)(this.FindName("UL")));
            this.UC = ((System.Windows.Controls.Button)(this.FindName("UC")));
            this.UR = ((System.Windows.Controls.Button)(this.FindName("UR")));
            this.ML = ((System.Windows.Controls.Button)(this.FindName("ML")));
            this.MC = ((System.Windows.Controls.Button)(this.FindName("MC")));
            this.MR = ((System.Windows.Controls.Button)(this.FindName("MR")));
            this.DL = ((System.Windows.Controls.Button)(this.FindName("DL")));
            this.DC = ((System.Windows.Controls.Button)(this.FindName("DC")));
            this.DR = ((System.Windows.Controls.Button)(this.FindName("DR")));
            this.winner_popup = ((System.Windows.Controls.Primitives.Popup)(this.FindName("winner_popup")));
            this.new_game = ((System.Windows.Controls.Button)(this.FindName("new_game")));
        }
    }
}

