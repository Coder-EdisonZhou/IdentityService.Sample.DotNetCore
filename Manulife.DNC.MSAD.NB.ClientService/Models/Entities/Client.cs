using System.ComponentModel.DataAnnotations.Schema;

namespace Manulife.DNC.MSAD.NB.ClientService.Models
{
    [Table("TClientDetails")]
    public class Client
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Sex")]
        public string Sex { get; set; }
    }
}
