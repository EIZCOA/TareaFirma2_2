using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace TareaFirma2_2.Models
{
    public class Signatures
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }

        [MaxLength(20)]
        public String Nombre { get; set; }

        [MaxLength(150)]
        public String Descripcion { get; set; }

        public Byte[] Imagen { get; set; }
    }
}
