﻿#pragma checksum "..\..\..\WPF\Start.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2D0BBC28747CD104A434D4A54ADFE6E53919F0B48491D171B8B5B071FB01339B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CHESS;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace CHESS {
    
    
    /// <summary>
    /// Start
    /// </summary>
    public partial class Start : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock startBG;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ComputerStart;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button computerS;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HumanStart;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button humanS;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid computerBG;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button computerB;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid humanBG;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\WPF\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button humanB;
        
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
            System.Uri resourceLocater = new System.Uri("/CHESS;component/wpf/start.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WPF\Start.xaml"
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
            this.startBG = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ComputerStart = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.computerS = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\WPF\Start.xaml"
            this.computerS.Click += new System.Windows.RoutedEventHandler(this.Computer_Start_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HumanStart = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.humanS = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\WPF\Start.xaml"
            this.humanS.Click += new System.Windows.RoutedEventHandler(this.Human_Start_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.computerBG = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.computerB = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\WPF\Start.xaml"
            this.computerB.Click += new System.Windows.RoutedEventHandler(this.Computer_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.humanBG = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.humanB = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\WPF\Start.xaml"
            this.humanB.Click += new System.Windows.RoutedEventHandler(this.Human_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 75 "..\..\..\WPF\Start.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Next_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
