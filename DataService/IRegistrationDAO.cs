using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IRegistrationDAO
    {
        RentRegistration? Get(int id);
        void Add(RentRegistration rentRegistration); //надо как-то передавать пассажира тоже, типо там, где у меня будет арендоваться авто через AddTo
        //я буду создавать элемент типа регистрации, части его значений буду назначать из элемента авто, а часть надо из элемента клиента, но в тех методах
        //и близко нет клиента
        //кажется, я придумал, думаю, мне надо будет извлекать данные об авто и клиенте из окон, которые я буду заполнять при указании аренды
        //я считаю из полей эти значения, создам новый элемент регистрации, присвою ей значения и передам этот элемент в метод, который добавляет регистрацию
        //в список регистраций
        int IndexOf(RentRegistration rentRegistration);
        RentRegistration this[int i] { get; set; }
        IEnumerable<RentRegistration> GetList();
    }
}
