//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnacondaHotel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bronirovanie
    {
        public int Id_Бронь { get; set; }
        public Nullable<int> Id_Client { get; set; }
        public Nullable<int> Id_Номера { get; set; }
        public Nullable<System.DateTime> Дата_заезда { get; set; }
        public Nullable<System.DateTime> Дата_выезда { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Numbers Numbers { get; set; }
    }
}
