﻿#pragma checksum "C:\Users\Marios Kantharidis\source\repos\newcounter\newcounter\agonia.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A9E2EDFCBF0F0271034974D028FCECF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace newcounter
{
    partial class agonia : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.sumagonia1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.sumagonia2 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.agonia1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.agonia2 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.add = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\agonia.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.add).Click += this.add_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.undo = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 36 "..\..\..\agonia.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.undo).Click += this.undo_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.clear = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\agonia.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.clear).Click += this.clear_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.result = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.save = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 39 "..\..\..\agonia.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.save).Click += this.save_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.load = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 40 "..\..\..\agonia.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.load).Click += this.load_Click;
                    #line default
                }
                break;
            case 11:
                {
                    this.cheat1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

