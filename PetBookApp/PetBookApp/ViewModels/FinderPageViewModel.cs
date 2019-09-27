using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.ViewModels
{
    public class FinderPageViewModel : BaseViewModel, IDestructible
    {
        public FinderPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public void Destroy()
        {
            
        }
    }
}
