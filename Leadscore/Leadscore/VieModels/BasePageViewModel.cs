using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Xamvvm;

namespace Leadscore.ViewModels
{
    public abstract class BasePageViewModel : BasePageModelRxUI,
                                              IPageVisibilityChange,
                                              INavigationPushed,
                                              INavigationPopped
    {
        #region Fields

        protected CompositeDisposable SubscriptionDisposables = new CompositeDisposable();

        CompositeDisposable deactivateWith;
        protected CompositeDisposable DeactivateWith
        {
            get
            {
                if (this.deactivateWith == null)
                {
                    this.deactivateWith = new CompositeDisposable();
                }

                return this.deactivateWith;
            }
        }

        protected CompositeDisposable DestroyWith { get; } = new CompositeDisposable();

        #endregion

        #region Properties

        protected ObservableAsPropertyHelper<bool> isBusy;
        public bool IsBusy => isBusy.Value;

        [Reactive] public string Title { get; protected set; }

        #endregion

        #region Commands

        #endregion

        protected BasePageViewModel()
        {
            Observable.Merge(this.ThrownExceptions)
                      .Throttle(TimeSpan.FromMilliseconds(250), RxApp.MainThreadScheduler)
                      .Subscribe(ex =>
                      {
                          Console.WriteLine(ex.Message);
                      })
                      .DisposeWith(SubscriptionDisposables);
        }

        #region Methods

        /// <summary>
        /// Called whenever the page is revealed
        /// </summary>
        public virtual void OnAppearing()
        {
        }

        /// <summary>
        /// Called when the page is pushed onto the navigation stack
        /// </summary>
        public virtual void NavigationPushed()
        {
        }

        /// <summary>
        /// Called when the page is popped from the navigation stack
        /// </summary>
        public virtual void NavigationPopped()
        {
        }

        /// <summary>
        /// Called whenever the page is hidden
        /// </summary>
        public virtual void OnDisappearing()
        {
            this.deactivateWith?.Dispose();
            this.deactivateWith = null;
        }

        public virtual void Destroy()
        {
            this.DestroyWith?.Dispose();
        }

        #endregion
    }
}