﻿#pragma checksum "..\..\..\Main\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBFD3F524F19A4CE84B771FBA85A85DFBEE9432D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Poli.Makro.States.Clipboard;
using Poli.Makro.States.Code;
using Poli.Makro.States.JSONXMLXAMLRSS;
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


namespace Poli.Makro.Main {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\Main\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl SideBarTabControl;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/main/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Main\MainWindow.xaml"
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
            
            #line 14 "..\..\..\Main\MainWindow.xaml"
            ((Poli.Makro.Main.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MainWindow_OnLoaded);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Main\MainWindow.xaml"
            ((Poli.Makro.Main.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_OnClosing);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Main\MainWindow.xaml"
            ((Poli.Makro.Main.MainWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.AnaPencere1_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SideBarTabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            
            #line 73 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 77 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 81 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 85 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 93 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 97 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 128 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 132 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 140 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 144 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 152 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 156 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 164 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 168 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 176 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 180 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 215 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 219 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 223 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 228 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 232 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.MenuButtonIsChecked);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 271 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.side);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 277 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_FareSolTıkBasıldığında);
            
            #line default
            #line hidden
            
            #line 277 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Border_ÖnizlemeFareSolTıkKalktığında);
            
            #line default
            #line hidden
            
            #line 277 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_ÖnizlemeFareSolTıkBastığında);
            
            #line default
            #line hidden
            
            #line 277 "..\..\..\Main\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Border_ÖnizlemeFareyleTaşıma);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
