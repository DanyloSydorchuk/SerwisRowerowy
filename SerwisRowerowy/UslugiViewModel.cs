using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisRowerowy
{
    public class UslugiViewModel
    {
        public ObservableCollection<Uslugi> Uslugi { get; set; }
        private UslugiRepository UslugiRepository { get; set; }

        public UslugiViewModel()
        {
            UslugiRepository = new UslugiRepository();
            Uslugi = new ObservableCollection<Uslugi>(UslugiRepository.uslugiRepository);
            Uslugi.CollectionChanged += Uslugi_CollectionChanged;
        }

        private void Uslugi_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
