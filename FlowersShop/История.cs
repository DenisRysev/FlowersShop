//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowersShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class История
    {
        public int Код_истории { get; set; }
        public string Логин { get; set; }
        public string Время { get; set; }
        public Nullable<int> Код_пользователя { get; set; }
        public Nullable<bool> Статус { get; set; }
    
        public virtual Пользователь Пользователь { get; set; }
    }
}
