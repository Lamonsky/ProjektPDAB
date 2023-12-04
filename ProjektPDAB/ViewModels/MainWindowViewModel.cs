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
using ProjektPDAB.Helpers;

namespace ProjektPDAB.ViewModels
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
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
            //tworze....
            return new List<CommandViewModel>
            {
                //tu decyduje 
                new CommandViewModel("Dodaj",new BaseCommand(CreateWindow)),
                new CommandViewModel("Wyswietl",new BaseCommand(ShowWindow)),
            };
        }
        #endregion
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
        #region Funkcje wywolujace okna
        private void CreateWindow()
        {
            CreateWorkspace<NowyTowarViewModel>();
        }
        private void ShowWindow()
        {
            ShowAllWorkspace<NowyTowarViewModel>();
        }
        #endregion

    }
}
