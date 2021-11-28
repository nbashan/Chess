using CHESS.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CHESS.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {


        public ObservableCollection<string> images;
        public Game game;

        private RelayCommand _ChessSquareClickCommand;
        public RelayCommand ChessSquareClickCommand
        {
            get
            {
                return _ChessSquareClickCommand ??
                       (_ChessSquareClickCommand = new RelayCommand(obj =>
                       {
                       }));
            }
        }


        private string _ButtonImage;

        public string ButtonImage
        {
            get { return _ButtonImage; }
            set
            {
                _ButtonImage = value;
                OnPropertyChanged("ButtonImage");
            }
        }



        private string _GridImage;

        public string GridImage
        {
            get { return _GridImage; }
            set
            {
                _GridImage = value;
                OnPropertyChanged("GridImage");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
