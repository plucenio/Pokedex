using System;
using System.Net.Http;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace Pokedex.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        protected async Task<bool> SafelyExecute(Func<Task> method, string genericErrorMessage = null)
        {
            try
            {
                await method.Invoke();
                return true;
            }
            catch (HttpRequestException)
            {
                await PageDialogService.DisplayAlertAsync("Error", "A stable internet connection required", "Ok");
                return false;
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken.IsCancellationRequested)
                    await PageDialogService.DisplayAlertAsync("Error", "Task cancelled by user", "Ok");
                else
                    await PageDialogService.DisplayAlertAsync("Error", "Unstable internet connection", "Ok");

                return false;
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Error", genericErrorMessage ?? ex.Message, "Ok");
                return false;
            }
        }

        protected async Task<bool> SafelyExecute(Func<Task<bool>> method, string genericErrorMessage = null)
        {
            try
            {
                return await method.Invoke();
            }
            catch (HttpRequestException ex)
            {
                await PageDialogService.DisplayAlertAsync("Error", "A stable internet connection required", "Ok");
                return false;
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken.IsCancellationRequested)
                    await PageDialogService.DisplayAlertAsync("Error", "Task cancelled by user", "Ok");
                else
                    await PageDialogService.DisplayAlertAsync("Error", "Unstable internet connection", "Ok");

                return false;
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Error", genericErrorMessage ?? ex.Message, "Ok");
                return false;
            }
        }
    }
}
