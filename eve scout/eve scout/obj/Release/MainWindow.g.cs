﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B0FC77D63003167CA8C4865BCC8EF31A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hardcodet.Wpf.TaskbarNotification;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;
using eve_scout;


namespace eve_scout {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal eve_scout.MainWindow mainWindow;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu Menu;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miExit;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miOptions;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miSystem;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miXML;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miHotlist;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miStartLog;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miStartEve;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miClearSystem;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gdMain;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal eve_scout.ColumnDefinitionExtended colOptions;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal eve_scout.ColumnDefinitionExtended colSystem;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal eve_scout.ColumnDefinitionExtended colXML;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal eve_scout.ColumnDefinitionExtended colHotlist;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.AutoCompleteBox acEveFolder;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbAutoLog;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbAutoEve;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbPlaySound;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbHotlist;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbAutoSave;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown udLocal;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btEveFolder;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridSplitter gsOne;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMonitor;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbXML;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbHotlist;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBarItem sbInfo;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hardcodet.Wpf.TaskbarNotification.TaskbarIcon myNotify;
        
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
            System.Uri resourceLocater = new System.Uri("/eve scout;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.mainWindow = ((eve_scout.MainWindow)(target));
            
            #line 8 "..\..\MainWindow.xaml"
            this.mainWindow.Closing += new System.ComponentModel.CancelEventHandler(this.mainWindow_Closing);
            
            #line default
            #line hidden
            
            #line 8 "..\..\MainWindow.xaml"
            this.mainWindow.SizeChanged += new System.Windows.SizeChangedEventHandler(this.mainWindow_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            this.miExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.miExit.Click += new System.Windows.RoutedEventHandler(this.miExit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.miOptions = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.miOptions.Checked += new System.Windows.RoutedEventHandler(this.miOptions_Checked);
            
            #line default
            #line hidden
            
            #line 15 "..\..\MainWindow.xaml"
            this.miOptions.Unchecked += new System.Windows.RoutedEventHandler(this.miOptions_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.miSystem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.miSystem.Checked += new System.Windows.RoutedEventHandler(this.miSystem_Checked);
            
            #line default
            #line hidden
            
            #line 16 "..\..\MainWindow.xaml"
            this.miSystem.Unchecked += new System.Windows.RoutedEventHandler(this.miSystem_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.miXML = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.miXML.Checked += new System.Windows.RoutedEventHandler(this.miXML_Checked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\MainWindow.xaml"
            this.miXML.Unchecked += new System.Windows.RoutedEventHandler(this.miXML_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.miHotlist = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.miHotlist.Checked += new System.Windows.RoutedEventHandler(this.miHotlist_Checked);
            
            #line default
            #line hidden
            
            #line 18 "..\..\MainWindow.xaml"
            this.miHotlist.Unchecked += new System.Windows.RoutedEventHandler(this.miHotlist_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.miStartLog = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.miStartLog.Click += new System.Windows.RoutedEventHandler(this.miStartLog_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.miStartEve = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.miStartEve.Click += new System.Windows.RoutedEventHandler(this.miStartEve_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.miClearSystem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.miClearSystem.Click += new System.Windows.RoutedEventHandler(this.miClearSystem_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.gdMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.colOptions = ((eve_scout.ColumnDefinitionExtended)(target));
            return;
            case 13:
            this.colSystem = ((eve_scout.ColumnDefinitionExtended)(target));
            return;
            case 14:
            this.colXML = ((eve_scout.ColumnDefinitionExtended)(target));
            return;
            case 15:
            this.colHotlist = ((eve_scout.ColumnDefinitionExtended)(target));
            return;
            case 16:
            this.acEveFolder = ((System.Windows.Controls.AutoCompleteBox)(target));
            return;
            case 17:
            this.cbAutoLog = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 18:
            this.cbAutoEve = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 19:
            this.cbPlaySound = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 20:
            this.cbHotlist = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 21:
            this.cbAutoSave = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 22:
            this.udLocal = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            
            #line 45 "..\..\MainWindow.xaml"
            this.udLocal.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.udLocal_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 49 "..\..\MainWindow.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 24:
            this.btEveFolder = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\MainWindow.xaml"
            this.btEveFolder.Click += new System.Windows.RoutedEventHandler(this.btEveFolder_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.gsOne = ((System.Windows.Controls.GridSplitter)(target));
            return;
            case 26:
            this.dgMonitor = ((System.Windows.Controls.DataGrid)(target));
            
            #line 57 "..\..\MainWindow.xaml"
            this.dgMonitor.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgMonitor_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 27:
            this.tbXML = ((System.Windows.Controls.TextBox)(target));
            return;
            case 28:
            this.tbHotlist = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\MainWindow.xaml"
            this.tbHotlist.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbHotlist_TextChanged);
            
            #line default
            #line hidden
            return;
            case 29:
            this.sbInfo = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 30:
            this.myNotify = ((Hardcodet.Wpf.TaskbarNotification.TaskbarIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

