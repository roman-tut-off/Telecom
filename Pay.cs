//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TutoffCursach
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pay
    {
        public int PayID { get; set; }
        public decimal Cost { get; set; }
        public decimal BalanceAfter { get; set; }
        public System.DateTime DatePay { get; set; }
        public int EmployID { get; set; }
        public int ClientID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employ Employ { get; set; }
    }
}
