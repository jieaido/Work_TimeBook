//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuEntities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuEntities()
        {
            this.PermissEntities = new HashSet<PermissEntities>();
        }
    
        public int MenuEntityId { get; set; }
        public int ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDisplayName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int SortId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissEntities> PermissEntities { get; set; }
    }
}
