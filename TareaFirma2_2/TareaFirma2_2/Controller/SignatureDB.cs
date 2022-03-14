using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using TareaFirma2_2.Models;


namespace TareaFirma2_2.Controller
{
    public class SignatureDB
    {
        readonly SQLiteAsyncConnection db;

        //Constructor vacio
        public SignatureDB()
        {
        }

        //Constructor Parametros
        public SignatureDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            //Creacion de la tabla
            db.CreateTableAsync<Signatures>();
        }

        // Procedures & functions CRUD

        // Return the table signatures like list
        public Task<List<Signatures>> ListSignatures()
        {
            return db.Table<Signatures>().ToListAsync();
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        // Save or update sings
        public Task<Int32> SaveSignatures(Signatures signature)
        {
            if (signature.Codigo != 0)
            {
                return db.UpdateAsync(signature);
            }
            else
            {
                return db.InsertAsync(signature);
            }
        }
        // BFind by id
        public Task<Signatures> SearchSign(int scode)
        {
            return db.Table<Signatures>()
                .Where(i => i.Codigo == scode)
                .FirstOrDefaultAsync();
        }
        // Delete Sign
        public Task<Int32> DeleteSign(Signatures signature)
        {
            return db.DeleteAsync(signature);
        }
    }
}
