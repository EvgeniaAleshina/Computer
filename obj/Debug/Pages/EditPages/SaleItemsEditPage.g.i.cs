﻿#pragma checksum "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C9A5D38D3D9FA7C2CE6CE114B2F6DDBF664D87DD3F0D3235556B2763A7442404"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Computer.Pages.EditPages {
    
    
    /// <summary>
    /// SaleItemsEditPage
    /// </summary>
    public partial class SaleItemsEditPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbItems;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbSeller;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbCustomer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbCount;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TbSum;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/Computer;component/pages/editpages/saleitemseditpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
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
            
            #line 9 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
            ((Computer.Pages.EditPages.SaleItemsEditPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.SaleItemsEditPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CbItems = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
            this.CbItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbItems_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CbSeller = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.CbCustomer = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.TbCount = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
            this.TbCount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbCount_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TbSum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Pages\EditPages\SaleItemsEditPage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

