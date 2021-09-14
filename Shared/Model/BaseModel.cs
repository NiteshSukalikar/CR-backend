using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Model
{
    public class BaseModel<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        public byte ActiveStatusId { get; set; }

        public long CreatedBy { get; set; }

        public long CreatedOn { get; set; }

        public long UpdatedBy { get; set; }

        public long UpdatedOn { get; set; }

        public long DeletedBy { get; set; }

        public long DeletedOn { get; set; }
    }
}
