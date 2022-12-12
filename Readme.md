<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128657986/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T387258)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to Use the WPF WizardService

This example demonstrates how to use the [WizardService](https://docs.devexpress.com/WPF/116321/mvvm-framework/services/predefined-set/wizardservice).

![image](https://user-images.githubusercontent.com/65009440/206715286-6b5d21f8-330a-4c48-a1ae-01589f6ae9ea.png)

## Implementation Details

The **WizardService** generates [WizardPages](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage) based on the template defined by the [PageGeneratorTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardService.PageGeneratorTemplate) property. This template allows you to implement navigation between pages at the ViewModel level. In this example, the [WizardPage](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage)'s Allow_ and Show_ properties are bound to the page's ViewModel properties. Use these properties to hide and disable specific navigation buttons.

You can specify Show_ and Allow_ properties in both [WizardPage](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage) and [Wizard](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.Wizard). The **Wizard**'s properties have a higher priority than corresponding **WizardPage**'s properties.

ViewModels in this project implement ISupportWizard_Command interfaces that expose the Can_ property and the On_ method. Use the Can_ property to enable/disable the corresponding navigation button. When a user clicks the button, the **Wizard** executes the On_ method, and the [WizardService.Navigate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardService.Navigate(System.String-System.Object-System.Object-System.Object)) method switches the Wizard to the specified page. The ISupportWizard_Command's properties have a higher priority than corresponding **WizardPage**'s properties.

The ISupportWizard_Command's Can_ property value has a higher priority than the **WizardPage**'s Allow_ property value.

The following table lists Wizard buttons and API used to customize their behavior:

| Button | WizardPage.Allow_ | WizardPage.Show_ | Interface | Can_ Property | On_ Method |
|---|---|---|---|---|---|
| Next | [AllowNext](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage.AllowNext) | [ShowNext](DevExpress.Xpf.Controls.WizardPage.ShowNext) | [ISupportWizardNextCommand](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardNextCommand) | [CanGoForward](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardNextCommand.CanGoForward) | [OnGoForward](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardNextCommand.OnGoForward(System.ComponentModel.CancelEventArgs)) |
| Back | [AllowBack](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage.AllowBack) | [ShowBack](DevExpress.Xpf.Controls.WizardPage.ShowBack) | [ISupportWizardBackCommand](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardBackCommand) | [CanGoBack](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardBackCommand.CanGoBack) | [OnGoBack](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardBackCommand.OnGoBack(System.ComponentModel.CancelEventArgs)) |
| Cancel | [AllowCancel](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage.AllowCancel) | [ShowCancel](DevExpress.Xpf.Controls.WizardPage.ShowCancel) | [ISupportWizardCancelCommand](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardCancelCommand) | [CanCancel](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardCancelCommand.CanCancel) | [OnCancel](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardCancelCommand.OnCancel(System.ComponentModel.CancelEventArgs)) |
| Finish | [AllowFinish](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.WizardPage.AllowFinish) | [ShowFinish](DevExpress.Xpf.Controls.WizardPage.ShowFinish) | [ISupportWizardFinishCommand](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardFinishCommand) | [CanFinish](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardFinishCommand.CanFinish) | [OnFinish](https://docs.devexpress.com/CoreLibraries/DevExpress.Mvvm.ISupportWizardFinishCommand.OnFinish(System.ComponentModel.CancelEventArgs)) |

This example uses the DevExpress [ThemedWindow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Core.ThemedWindow) as a dialog container. In this case, set the `ThemedWindowOptions.UseCustomDialogFooter` attached property to `true` to remove the duplicated dialog footer:

```xaml
<dx:DialogService.DialogStyle>
    <Style TargetType="dx:ThemedWindow">
        <!-- ... -->
        <Setter Property="dxi:ThemedWindowOptions.UseCustomDialogFooter" Value="True"/>
    </Style>
</dx:DialogService.DialogStyle>
```

## Files to Review

* [MainWindow.xaml](./CS/VM-DrivenWizard/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/VM-DrivenWizard/MainWindow.xaml))
* [WelcomePage.xaml](./CS/VM-DrivenWizard/Views/WelcomePage.xaml) (VB: [WelcomePage.xaml](./VB/VM-DrivenWizard/Views/WelcomePage.xaml))
* [PlayTunePage.xaml](./CS/VM-DrivenWizard/Views/PlayTunePage.xaml) (VB: [PlayTunePage.xaml](./VB/VM-DrivenWizard/Views/PlayTunePage.xaml))
* [CongratulationsPage.xaml](./CS/VM-DrivenWizard/Views/CongratulationsPage.xaml) (VB: [CongratulationsPage.xaml](./VB/VM-DrivenWizard/Views/CongratulationsPage.xaml))
* [MainWindowViewModel.cs](./CS/VM-DrivenWizard/ViewModels/MainWindowViewModel.cs) (VB: [MainWindowViewModel.vb](./VB/VM-DrivenWizard/ViewModels/MainWindowViewModel.vb))
* [WizardViewModelBase.cs](./CS/VM-DrivenWizard/ViewModels/WizardViewModelBase.cs) (VB: [WizardViewModelBase.vb](./VB/VM-DrivenWizard/ViewModels/WizardViewModelBase.vb))
* [WelcomePageViewModel.vb](./CS/VM-DrivenWizard/ViewModels/WelcomePageViewModel.cs) (VB: [WelcomePageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/WelcomePageViewModel.vb))
* [PlayTunePageViewModel.cs](./CS/VM-DrivenWizard/ViewModels/PlayTunePageViewModel.cs) (VB: [PlayTunePageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/PlayTunePageViewModel.vb))
* [CongratulationsPageViewModel.cs](./CS/VM-DrivenWizard/ViewModels/CongratulationsPageViewModel.cs) (VB: [CongratulationsPageViewModel.vb](./VB/VM-DrivenWizard/ViewModels/CongratulationsPageViewModel.vb))

## Documentation

* [WizardService](https://docs.devexpress.com/WPF/116321/mvvm-framework/services/predefined-set/wizardservice)
* [Wizard Control](https://docs.devexpress.com/WPF/115979/controls-and-libraries/navigation-controls/wizard-control)
* [Wizard Pages](https://docs.devexpress.com/WPF/115997/controls-and-libraries/navigation-controls/wizard-control/pages)
* [Wizard Buttons](https://docs.devexpress.com/WPF/115998/controls-and-libraries/navigation-controls/wizard-control/buttons)

## More Examples

* [Create a Wizard with Pages Defined in XAML](https://github.com/DevExpress-Examples/wpf-create-a-wizard-with-pages-defined-in-xaml)
* [Create a Wizard Based on a Collection of View Models](https://github.com/DevExpress-Examples/how-to-create-a-wizard-based-on-a-collection-of-view-models-t415475)
