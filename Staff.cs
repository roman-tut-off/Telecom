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
    
    public partial class Staff
    {
        public int StaffID { get; set; }
        public string SerialNumber { get; set; }
        public int TypeStaffID { get; set; }
        public int ModelID { get; set; }
        public int AdressID { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Adress Adress { get; set; }
        public virtual Model Model { get; set; }
        public virtual TypeStaff TypeStaff { get; set; }
    }
}