using System;

namespace SimpleCRUD.Model.Helpers
{
    public interface IFullAuditedEntity
    {
        int Id { get; set; }
        DateTime CreationTime { get; set; }
        long? CreatorUserId { get; set; }
        DateTime? LastModificationTime { get; set; }
        long? LastModifierUserId { get; set; }
        bool IsDeleted { get; set; }
        long? DeleterUserId { get; set; }
        DateTime? DeletionTime { get; set; }
    }
}
