//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GPLib.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DefaultStage
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public Nullable<int> StageId { get; set; }
    
        public virtual Stage Stage { get; set; }
        public virtual UserInfoSet UserInfoSet { get; set; }
    }
}