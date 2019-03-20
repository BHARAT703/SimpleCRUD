using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD.Model.Helpers
{
    public class FullAuditedEntity: IFullAuditedEntity
    {
        public FullAuditedEntity()
        {

        }

        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// Creation time of this entity.
        /// </summary>        
        public virtual DateTime CreationTime { get; set; }
       
        /// <summary>
        /// Creator of this entity.
        /// </summary>
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// Last modification date of this entity.
        /// </summary>        
        public virtual DateTime? LastModificationTime { get; set; }
         
        /// <summary>
        /// Last modifier user of this entity.
        /// </summary>
        public virtual long? LastModifierUserId { get; set; }

        /// <summary>
        /// Is this entity Deleted?
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Which user deleted this entity?
        /// </summary>
        public virtual long? DeleterUserId { get; set; }

        /// <summary>
        ///  Deletion time of this entity.
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
    }
}
