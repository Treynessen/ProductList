using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public partial class Form1 : Form
{
    private void SerializeToFile()
    {
        dataFile.Position = 0;
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(dataFile, data);
        }
        catch (SerializationException)
        {
            MessageBox.Show("Ошибка записи данных в файл", "Ошибка");
            throw;
        }
    }
}