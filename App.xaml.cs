using Lambda.ViewModels;
using Lambda.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Lambda
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LambdaBasics>();
            containerRegistry.RegisterForNavigation<LinqAdvanced>();
        }
    }
}
