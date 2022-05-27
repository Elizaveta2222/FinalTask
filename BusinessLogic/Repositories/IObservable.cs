using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    public interface IObservable<TypeDefinition> // издатель
    {
        void Notify(TypeDefinition data, IObserver<TypeDefinition> observer); // уведомление одного подписчика

        void Subscribe(IObserver<TypeDefinition> observer); //подписка
        void Unsubscribe(IObserver<TypeDefinition> observer); //отписка
    }
}
