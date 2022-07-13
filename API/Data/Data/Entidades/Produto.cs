using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades {
    [Table("Produto")]
    public class Produto {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public int Nome { get; set; }
    }
}
