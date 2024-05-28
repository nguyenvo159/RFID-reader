using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace WindowsFormsAppRFID
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private string DispString;
        private MySqlConnection connection;
        private StringBuilder dataBuffer = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Đặt giá trị mặc định cho ComboBox BaudRate
            cbBaudRate.SelectedItem = "9600";
            txtPortName.Text = "COM4";
            try
            {
                //Kết nối DB
                string server = "localhost";
                string database = "rfid_reader";
                string uid = "root";
                string password = "2518700146";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
                txtRFIDData.AppendText("Kết nối database thành công." + Environment.NewLine);
            }
            catch (MySqlException ex)
            {
                txtRFIDData.AppendText("Kết nối database thất bại. Vui lòng kiểm tra lại." + ex.Message + Environment.NewLine);

            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                if (string.IsNullOrEmpty(txtPortName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên cổng COM.");
                    return;
                }

                try
                {
                    // Khởi tạo cổng serial với các giá trị đã chọn
                    serialPort = new SerialPort
                    {
                        PortName = txtPortName.Text,
                        BaudRate = int.Parse(cbBaudRate.SelectedItem.ToString()),
                        Parity = Parity.None,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Handshake = Handshake.None
                    };

                    // Gán event handler cho sự kiện DataReceived
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                    serialPort.Open();

                    btnConnect.Text = "Disconnect";
                    //MessageBox.Show("Đã kết nối thành công với đầu đọc thẻ RFID.");
                    txtRFIDData.AppendText("Đã kết nối thành công với đầu đọc thẻ RFID." + Environment.NewLine);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể kết nối với đầu đọc thẻ RFID: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    // Đóng kết nối serial port
                    serialPort.Close();
                    serialPort = null;

                    btnConnect.Text = "Connect";
                    txtRFIDData.AppendText("Đã tắt kết nối với đầu đọc thẻ RFID." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể ngắt kết nối với đầu đọc thẻ RFID: {ex.Message}");
                }
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadExisting();
                dataBuffer.Append(data);

                // Nếu chuỗi trong buffer có độ dài mong muốn (10 ký tự số)
                if (dataBuffer.Length >= 10)
                {
                    string filteredData = new string(dataBuffer.ToString().Where(char.IsDigit).ToArray());
                    if (filteredData.Length == 10)
                    {
                        this.Invoke(new Action(() =>
                        {
                            DisplayText(filteredData);
                        }));
                        dataBuffer.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu từ đầu đọc thẻ RFID: {ex.Message}");
            }
        }

        private void DisplayText(string data)
        {
            txtRFIDData.AppendText(data + Environment.NewLine);
            verifyUser(data);
        }

        private void verifyUser(string uid)
        {
            try
            {
                string query = "SELECT fullname, role FROM users WHERE rfid = @uid";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullname = reader["fullname"].ToString();
                            int role = Convert.ToInt32(reader["role"]);

                            if (role == 10)
                            {
                                txtRFIDData.AppendText($"{fullname} được phép truy cập" + Environment.NewLine);
                            }
                            else
                            {
                                txtRFIDData.AppendText($"{fullname} không được phép truy cập" + Environment.NewLine);
                            }
                        }
                        else
                        {
                            txtRFIDData.AppendText("Không tìm thấy người dùng với UID này" + Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra người dùng: {ex.Message}");
            }
        }
    }
}
