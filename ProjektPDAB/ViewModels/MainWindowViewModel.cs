using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Entities;
using ProjektPDAB.Views;

namespace ProjektPDAB.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Workspaces
        //
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        #endregion
        #region Zakładki
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region Funkcje
        private void CreateWorkspace<T>() where T : WorkspaceViewModel, new()
        {
            T workspace = new T();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllWorkspace<T>() where T : WorkspaceViewModel, new()
        {
            T workspace = Workspaces.FirstOrDefault(vm => vm is T) as T;
            if(workspace == null)
            {
                workspace = new T();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
        #region Commands
        private ReadOnlyCollection<CommandViewModel> _Commands;
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    //
                    List<CommandViewModel> cmds = CreateCommands();
                    //i ...
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);
            //tworze....
            return new List<CommandViewModel>
            {
                //tu decyduje 
                new CommandViewModel("Dostawy", new BaseCommand(ShowDostawy)),
                new CommandViewModel("Pracownicy",new BaseCommand(ShowPracownicy)),
                new CommandViewModel("Serwisy",new BaseCommand(ShowSerwisy)),
                new CommandViewModel("Faktury",new BaseCommand(ShowFaktury)),
                new CommandViewModel("Naprawy",new BaseCommand(ShowNaprawy)),
                new CommandViewModel("Dostawcy",new BaseCommand(ShowDostawcy)),
                new CommandViewModel("Klienci",new BaseCommand(ShowKlienci)),

            };
        }
        private void open(string name)
        {
            switch (name)
            {
                case "DostawyAdd":
                    CreateDostawa();
                    break;
                case "FakturyAdd":
                    CreateFaktura();
                    break;
                case "NaprawyAdd":
                    CreateNaprawa();
                    break;
                case "SerwisyAdd":
                    CreateSerwis();
                    break;
                case "PracownicyAdd":
                    CreatePracownik();
                    break;
                case "DostawcyAdd":
                    CreateDostawca();
                    break;
                case "KlienciAdd":
                    CreateKlient();
                    break;
            }
        }
        #endregion

        #region Komendy do Buttonow
       
        #endregion
        #region Funkcje wywolujace okna
        private void CreateDostawca()
        {
            CreateWorkspace<NowyDostawcaViewModel>();
        }
        private void ShowDostawcy()
        {
            ShowAllWorkspace<WszyscyDostawcyViewModel>();
        }
        private void ShowSerwisy()
        {
            ShowAllWorkspace<WszystkieSerwisyViewModel>();
        }
        private void CreateSerwis()
        {
            CreateWorkspace<NowySerwisViewModel>();
        }
        private void CreatePracownik()
        {
            CreateWorkspace<NowyPracownikViewModel>();
        }
        private void ShowPracownicy()
        {
            ShowAllWorkspace<WszyscyPracownicyViewModel>();
        }
        private void ShowKlienci()
        {
            ShowAllWorkspace<WszyscyKlienciViewModel>();
        }
        private void CreateKlient()
        {
            CreateWorkspace<NowyKlientViewModel>();
        }
        private void ShowDostawy()
        {
            ShowAllWorkspace<WszystkieDostawyViewModel>();
        }
        private void CreateDostawa()
        {
            CreateWorkspace<NowaDostawaViewModel>();
        }
        private void ShowFaktury()
        {
            ShowAllWorkspace<WszystkieFakturyViewModel>();
        }
        private void CreateFaktura()
        {
            CreateWorkspace<NowaFakturaViewModel>();
        }
        private void ShowNaprawy()
        {
            ShowAllWorkspace<WszystkieNaprawyViewModel>();
        }
        private void CreateNaprawa()
        {
            CreateWorkspace<NowaNaprawaViewModel>();
        }
        #endregion
    }
}
