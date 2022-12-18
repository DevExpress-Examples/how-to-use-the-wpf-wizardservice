<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128657986/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T387258)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to: Use the WizardService


This example demonstrates how to use the <a href="https://documentation.devexpress.com/#WPF/CustomDocument116321">WizardService</a>. See Implementation Details for more information.<br><br>See also:<br><a href="https://www.devexpress.com/Support/Center/p/T415416">How to create a Wizard with pages defined in XAML</a><br><a href="https://www.devexpress.com/Support/Center/p/T415475">How to: Create a wizard based on a collection of view models</a>


<h3>Description</h3>

<p>Based on&nbsp;the template defined within PageGeneratorTemplate, WizardService generates WizardPage for every View in compliance&nbsp;with MVVM. It allows implementing navigation between pages at the level of a page's ViewModel.&nbsp;In this example, the Allow_ and Show_ (Next, Back, Cancel, Finish) &nbsp;properties of WizardPage are bound to a page's ViewModel properties, and are used to hide/disable specific navigation buttons based on a custom logic.<br><br>The Show_ and Allow_ properties are defined in both WizardPage and Wizard.<br><strong>The Wizard's properties have a higher priority than a corresponding WizardPage's properties.</strong><br><br>In addition, ViewModels in the project&nbsp;implement <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressMvvmISupportWizardNextCommandtopic">ISupportWizard_Command</a>&nbsp;interfaces&nbsp;that expose the Can_ and On_ methods. By invoking the Can_ method, the Wizard determines whether a corresponding navigation button is enabled. When a user presses that button, the On_ method is invoked, and the <a href="https://documentation.devexpress.com/WPF/DevExpressXpfControlsWizardService_Navigatetopic.aspx">WizardService.Navigate</a>&nbsp;method switches the Wizard to another page.<br><strong>The value returned by the Can_ method has a higher priority than the WizardPage's Allow_ property value.</strong></p>
<br><br>

<br/>


