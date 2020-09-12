namespace RoadModes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;



    public partial class Roadez : DbContext
    {
        public int SEG_ID { get; set; }
        public int? BEGIN_DIST { get; set; }
        public int? END_DIST { get; set; }
        public DateTime? BUILD_DATE { get; set; }
        public int? LAYER_THICK { get; set; }
        public string LAYER_MAT { get; set; }
        public DateTime? CURDATE { get; set; }


        public int Insert(int SEG_ID, int BEGIN_DIST, int END_DIST, DateTime BUILD_DATE, int LAYER_THICK, string LAYER_MAT)
        {
            var conn = new Roadez();
            
            conn.Database.Connection.Open();
            var inserts = @"insert into Road_LAYERZ Values('"+SEG_ID+ "' ,'"+BEGIN_DIST+"' ,'"+END_DIST+"' ,'"+BUILD_DATE+"' ,'"+LAYER_THICK+"' ,'"+LAYER_MAT+"')";

            SqlCommand cmd = new SqlCommand(inserts);
           
            return cmd.ExecuteNonQuery();
        }


        public int Update(int BEGIN_DIST, int END_DIST, DateTime BUILD_DATE, int LAYER_THICK, string LAYER_MAT)
        {
            var conn = new Roadez();
            SqlCommand cmd = new SqlCommand();
            conn.Database.Connection.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            var conn = new Roadez();
            SqlCommand cmd = new SqlCommand();
            conn.Database.Connection.Open();
            return cmd.ExecuteNonQuery();
        }


        public Roadez()
            : base("name=Roadez")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
