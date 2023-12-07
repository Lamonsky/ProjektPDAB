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
                new CommandViewModel("Pracownik",new BaseCommand(CreatePracownik)),
                new CommandViewModel("Pracownicy",new BaseCommand(ShowPracownicy)),
                new CommandViewModel("Serwis",new BaseCommand(CreateSerwis)),
                new CommandViewModel("Serwisy",new BaseCommand(ShowSerwisy)),
            };
        }
        private void open(string name)
        {
            switch (name)
            {
                case "DostawyAdd":
                    CreateDostawa();
                    break;
            }
        }
        #endregion

        #region Komendy do Buttonow
        public ICommand WszyscyDostawcyCommand
        {
            get
            {
                return new BaseCommand(ShowDostawcy);
            }
        }
        public ICommand NowyDostawcaCommand
        {
            get
            {
                return new BaseCommand(CreateDostawca);
            }
        }
        public ICommand WszystkieSposobyPlatnosciCommand
        {
            get
            {
                return new BaseCommand(ShowSposobPlatnosci);
            }
        }
        public ICommand SposobPlatnosciDodajCommand
        {
            get
            {
                return new BaseCommand(CreateSposobPlatnosci);
            }
        }
        public ICommand WszystkieSerwisyCommand
        {
            get
            {
                return new BaseCommand(ShowSerwisy);
            }
        }
        public ICommand NowySerwisCommand
        {
            get
            {
                return new BaseCommand(CreateSerwis);
            }
        }
        public ICommand NowyPracownikCommand
        {
            get
            {
                return new BaseCommand(CreatePracownik);
            }
        }
        public ICommand WszyscyPracownicyCommand
        {
            get
            {
                return new BaseCommand(ShowPracownicy);
            }
        }
        public ICommand WszyscyKlienciCommand
        {
            get
            {
                return new BaseCommand(ShowKlienci);
            }
        }
        public ICommand NowyKlientCommand
        {
            get
            {
                return new BaseCommand(CreateKlient);
            }
        }
        public ICommand WszystkieKategorieCommand
        {
            get
            {
                return new BaseCommand(ShowKategorie);
            }
        }
        public ICommand NowaKategoriaCommand
        {
            get
            {
                return new BaseCommand(CreateKategoria);
            }
        }
        public ICommand WszystkieAdresyCommand
        {
            get
            {
                return new BaseCommand(ShowAdresy);
            }
        }
        public ICommand NowyAdresCommand
        {
            get
            {
                return new BaseCommand(CreateAdres);
            }
        }
        public ICommand WszystkieDostawyCommand
        {
            get
            {
                return new BaseCommand(ShowDostawy);
            }
        }
        public ICommand NowaDostawaCommand
        {
            get
            {
                return new BaseCommand(CreateDostawa);
            }
        }
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
        private void ShowSposobPlatnosci()
        {
            ShowAllWorkspace<WszystkieSposobyPlatnosciViewModel>();
        }
        private void CreateSposobPlatnosci()
        {
            CreateWorkspace<NowySposobPlatnosciViewModel>();
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
        private void ShowKategorie()
        {
            ShowAllWorkspace<WszystkieKategorieViewModel>();
        }
        private void CreateKategoria()
        {
            CreateWorkspace<NowaKategoriaViewModel>();
        }
        private void ShowAdresy()
        {
            ShowAllWorkspace<WszystkieAdresyViewModel>();
        }
        private void CreateAdres()
        {
            CreateWorkspace<NowyAdresViewModel>();
        }
        private void ShowDostawy()
        {
            ShowAllWorkspace<WszystkieDostawyViewModel>();
        }
        private void CreateDostawa()
        {
            CreateWorkspace<NowaDostawaViewModel>();
        }
        #endregion
    }
}
