//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GPPlatform.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stage()
        {
            this.History = new HashSet<History>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public byte[] StageData { get; set; }
        public string Type { get; set; }
        public string CreateUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> History { get; set; }
    }
}