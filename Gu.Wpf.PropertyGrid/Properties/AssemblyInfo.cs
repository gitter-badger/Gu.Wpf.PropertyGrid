﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Gu.Wpf.PropertyGrid")]
[assembly: AssemblyDescription("Small project for creating property grids in wpf.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Johan Larsson")]
[assembly: AssemblyProduct("Gu.Wpf.PropertyGrid")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// In order to begin building localizable applications, set
// <UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
// inside a <PropertyGroup>.  For example, if you are using US english
// in your source files, set the <UICulture> to en-US.  Then uncomment
// the NeutralResourceLanguage attribute below.  Update the "en-US" in
// the line below to match the UICulture setting in the project file.

//// [assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]
[assembly:ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("3.0.0.0")]
[assembly: AssemblyFileVersion("3.0.0.0")]

[assembly: InternalsVisibleTo("Gu.Wpf.PropertyGrid.Tests", AllInternalsVisible = true)]
[assembly: InternalsVisibleTo("Gu.Wpf.PropertyGrid.NumericRows", AllInternalsVisible = true)]
[assembly: InternalsVisibleTo("Gu.Wpf.PropertyGrid.UnitRows", AllInternalsVisible = true)]
[assembly: InternalsVisibleTo("Gu.Wpf.PropertyGrid.UnitRows.Tests", AllInternalsVisible = true)]

[assembly: XmlnsDefinition("http://gu.se/PropertyGrid", "Gu.Wpf.PropertyGrid")]
[assembly: XmlnsPrefix("http://gu.se/PropertyGrid", "propertyGrid")]
