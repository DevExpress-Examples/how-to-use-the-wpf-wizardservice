<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/VM-DrivenWizard/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/VM-DrivenWizard/MainWindow.xaml))**
* [Model.cs](./CS/VM-DrivenWizard/Model/Model.cs) (VB: [Model.vb](./VB/VM-DrivenWizard/Model/Model.vb))
* [CongratulationsPageViewModel.cs](./CS/VM-DrivenWizard/ViewModels/CongratulationsPageViewModel.cs) (VB: [CongratulationsPageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/CongratulationsPageViewModel.vb))
* [MainWindowViewModel.cs](./CS/VM-DrivenWizard/ViewModels/MainWindowViewModel.cs) (VB: [MainWindowViewModel.vb](./VB/VM-DrivenWizard/ViewModels/MainWindowViewModel.vb))
* [PlayTunePageViewModel.cs](./CS/VM-DrivenWizard/ViewModels/PlayTunePageViewModel.cs) (VB: [PlayTunePageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/PlayTunePageViewModel.vb))
* [WelcomePageViewModel.cs](./CS/VM-DrivenWizard/ViewModels/WelcomePageViewModel.cs) (VB: [WelcomePageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/WelcomePageViewModel.vb))
* [WizardPageViewModel.cs](./CS/VM-DrivenWizard/ViewModels/WizardPageViewModel.cs) (VB: [WizardPageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/WizardPageViewModel.vb))
* [CongratulationsPage.xaml](./CS/VM-DrivenWizard/Views/CongratulationsPage.xaml) (VB: [CongratulationsPage.xaml](./VB/VM-DrivenWizard/Views/CongratulationsPage.xaml))
* [PlayTunePage.xaml](./CS/VM-DrivenWizard/Views/PlayTunePage.xaml) (VB: [PlayTunePage.xaml](./VB/VM-DrivenWizard/Views/PlayTunePage.xaml))
* [WelcomePage.xaml](./CS/VM-DrivenWizard/Views/WelcomePage.xaml) (VB: [WelcomePage.xaml](./VB/VM-DrivenWizard/Views/WelcomePage.xaml))
<!-- default file list end -->
# How to: Use the WizardService


This example demonstrates how to use the <a href="https://documentation.devexpress.com/#WPF/CustomDocument116321">WizardService</a>. See Implementation Details for more information.<br><br>See also:<br><a href="https://www.devexpress.com/Support/Center/p/T415416">How to create a Wizard with pages defined in XAML</a><br><a href="https://www.devexpress.com/Support/Center/p/T415475">How to: Create a wizard based on a collection of view models</a>


<h3>Description</h3>

In this example, WizardService is attached to the Wizard control. It injects navigation methods (GoBack, GoForward, Navigate) to a page's ViewModel&nbsp;in compliance with MVVM. Navigation between pages is implemented at the ViewModel level.

<br/>


