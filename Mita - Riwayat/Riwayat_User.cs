using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using Npgsql;

namespace Mita___Riwayat
{
    public partial class RIwayat_User : Form
    {
        //private Login.User user;
        public RIwayat_User(/*Login.User user*/)
        {
            InitializeComponent();
            //this.user = User;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=Jecation; User Id=postgres; Password="))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT id_riwayat_penginapan, id_kamar, jumlah_malam, jumlah_kamar, total_harga, id_akun FROM riwayat_penginapan WHERE id_akun = @id_akun ORDER BY id_riwayat_penginapan";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@id_akun", user.id_user);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Menghubungkan DataTable dengan BindingSource
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                // Menghubungkan BindingSource dengan DataGridView
                guna2DataGridView1.DataSource = bindingSource;

                reader.Close();
                cmd.Dispose();
                connection.Close();
            }

            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=Jecation; User Id=postgres; Password="))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT id_riwayat_tiket, tiket_anak, tiket_dewasa, total_harga, id_akun FROM riwayat_tiket ORDER BY id_riwayat_tiket where id_akun = @id_akun ORDER BY id_riwayat_penginapan";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@id_akun", user.id_user);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Menghubungkan DataTable dengan BindingSource
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                // Menghubungkan BindingSource dengan DataGridView
                guna2DataGridView2.DataSource = bindingSource;

                reader.Close();
                cmd.Dispose();
                connection.Close();
            }
        }
    }
}