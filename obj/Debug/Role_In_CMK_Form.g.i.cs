﻿#pragma checksum "..\..\Role_In_CMK_Form.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E38DA3A7EB29ADB34DA12E52B85204183738070661027AFBE01DB1F88FEB6264"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using NLP_Create;
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


namespace NLP_Create {
    
    
    /// <summary>
    /// Role_In_CMK_Form
    /// </summary>
    public partial class Role_In_CMK_Form : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgRole_In_CMK;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName_Role;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFindValue;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSearch;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btFilter;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancel;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btInsert;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdate;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Role_In_CMK_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/NLP_Create;component/role_in_cmk_form.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Role_In_CMK_Form.xaml"
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
            
            #line 16 "..\..\Role_In_CMK_Form.xaml"
            ((NLP_Create.Role_In_CMK_Form)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgRole_In_CMK = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\Role_In_CMK_Form.xaml"
            this.dgRole_In_CMK.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DgRole_In_CMK_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbName_Role = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\Role_In_CMK_Form.xaml"
            this.tbName_Role.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbName_Role_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbFindValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btSearch = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Role_In_CMK_Form.xaml"
            this.btSearch.Click += new System.Windows.RoutedEventHandler(this.btSearch_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btFilter = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Role_In_CMK_Form.xaml"
            this.btFilter.Click += new System.Windows.RoutedEventHandler(this.btFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btCancel = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Role_In_CMK_Form.xaml"
            this.btCancel.Click += new System.Windows.RoutedEventHandler(this.btCancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btInsert = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Role_In_CMK_Form.xaml"
            this.btInsert.Click += new System.Windows.RoutedEventHandler(this.btInsert_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Role_In_CMK_Form.xaml"
            this.btUpdate.Click += new System.Windows.RoutedEventHandler(this.btUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btDelete = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Role_In_CMK_Form.xaml"
            this.btDelete.Click += new System.Windows.RoutedEventHandler(this.btDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

