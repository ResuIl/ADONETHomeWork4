using System.Data;
using System.Data.SqlClient;

namespace ADONETHomeWork4;

public partial class Form1 : Form
{
    SqlConnection? connection = null;
    string? connectionString = null;
    DataTable? table = null;

    public Form1()
    {
        InitializeComponent();

        connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        connection = new SqlConnection(connectionString);

        GetCategories();
    }

    private void GetCategories()
    {
        try
        {
            var connection = new SqlConnection(connectionString);
            connection?.Open();
            using SqlCommand comm = new SqlCommand("WAITFOR DELAY '00:00:05'; SELECT Name FROM Categories;");
            comm.Connection = connection;
            AsyncCallback callback = new AsyncCallback(GetData);
            comm.BeginExecuteReader(callback, comm);


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void GetData(IAsyncResult result)
    {
        if (result.AsyncState is SqlCommand command)
        {

            SqlDataReader? dataReader = null;

            try
            {
                dataReader = command.EndExecuteReader(result);
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                        cBox_Categories.Items.Add(dataReader[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection?.Close();
                if (dataReader is not null && !dataReader.IsClosed)
                    dataReader.Close();
            }
        }
    }

    private void cBox_Categories_SelectedIndexChanged(object sender, EventArgs e)
    {
        cBox_Authors.Enabled = true;
        cBox_Authors.Items.Clear();
        try
        {
            var connection = new SqlConnection(connectionString);
            connection?.Open();
            using SqlCommand comm = new SqlCommand("WAITFOR DELAY '00:00:05'; SELECT Authors.FirstName + ' ' + Authors.LastName AS Author FROM Books\r\nJOIN Categories ON Id_Category = Categories.Id\r\nJOIN Authors ON Id_Author = Authors.Id\r\nWHERE Categories.Name = @p1", connection);
            comm.Parameters.AddWithValue("@p1", cBox_Categories.SelectedItem.ToString());
            AsyncCallback callback = new AsyncCallback(GetAuthor);
            comm.BeginExecuteReader(callback, comm);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void GetAuthor(IAsyncResult result)
    {
        if (result.AsyncState is SqlCommand command)
        {

            SqlDataReader? dataReader = null;

            try
            {
                dataReader = command.EndExecuteReader(result);
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                        cBox_Authors.Items.Add(dataReader[i]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection?.Close();
                if (dataReader is not null && !dataReader.IsClosed)
                    dataReader.Close();
            }
        }
    }

    private void tBox_Search_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tBox_Search.Text))
            return;

        table?.Rows.Clear();
        try
        {
            var connection = new SqlConnection(connectionString);
            connection?.Open();

            using SqlCommand command = new SqlCommand($"WAITFOR DELAY '00:00:02'; SELECT * FROM Books\r\nWHERE Name LIKE '%{tBox_Search.Text}%'", connection);
            AsyncCallback callback = new AsyncCallback(Search);

            command.BeginExecuteReader(callback, command);


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Search(IAsyncResult result)
    {
        table = new DataTable();
        if (result.AsyncState is SqlCommand command)
        {
            SqlDataReader? reader = null;

            try
            {
                int line = 0;
                reader = command.EndExecuteReader(result);
                do
                {
                    while (reader?.Read() ?? false)
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }

                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }

                } while (reader?.NextResult() ?? false);
                dataGridView1.Invoke(() => dataGridView1.DataSource = table);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader?.Close();
            }
        }
    }

    private void cBox_Authors_SelectedIndexChanged(object sender, EventArgs e)
    {
        tBox_Search.Enabled = true;
        try
        {
            var connection = new SqlConnection(connectionString);
            connection?.Open();
            using SqlCommand comm2 = new SqlCommand("WAITFOR DELAY '00:00:04';SELECT Categories.Name, Authors.FirstName + ' ' + Authors.LastName AS Author FROM Books\r\nJOIN Categories ON Id_Category = Categories.Id\r\nJOIN Authors ON Id_Author = Authors.Id\r\nWHERE Categories.Name = @p1 AND Authors.FirstName + ' ' + Authors.LastName = @p2", connection);
            comm2.Parameters.AddWithValue("@p2", cBox_Authors.SelectedItem.ToString());
            comm2.Parameters.AddWithValue("@p1", cBox_Categories.SelectedItem.ToString());

            AsyncCallback callback = new AsyncCallback(Fill);

            comm2.BeginExecuteReader(callback, comm2);


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Fill(IAsyncResult result)
    {
        if (result.AsyncState is SqlCommand command)
        {
            SqlDataReader? dataReader = null;
            table = new DataTable();
            try
            {
                dataReader = command.EndExecuteReader(result);
                int line = 0;
                do
                {
                    while (dataReader?.Read() ?? false)
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                table.Columns.Add(dataReader.GetName(i));
                            }
                            line++;
                        }

                        DataRow row = table.NewRow();
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            row[i] = dataReader[i];
                        }
                        table.Rows.Add(row);
                    }

                } while (dataReader?.NextResult() ?? false);
                dataGridView1.Invoke(() => dataGridView1.DataSource = table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection?.Close();
                if (dataReader is not null && !dataReader.IsClosed)
                    dataReader.Close();
            }
        }
    }
}