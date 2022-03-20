using LiteDB;
using System.Data;
using System.Text;

namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
{
    public partial class ConfigurationForm : Form
    {
        private readonly ICollection<ControllerConfiguration> _controllers;
        private readonly LiteDatabase _database;

        public ConfigurationForm(LiteDatabase database)
        {
            InitializeComponent();
            _database = database;
        }

        private void OnStartStopServer_Click(object sender, EventArgs e)
        {
            if (btnStartStopServer.Text == "Start Server")
            {
                foreach (DataGridViewRow row in ConfigurationGrid.Rows)
                {
                    if (row.Index < ConfigurationGrid.Rows.Count - 1)
                    {
                        var configuration = GetFromRow(row);
                        var driver = new AutomaticDriver(configuration);
                        driver.StartAsync();
                    }
                }
                btnStartStopServer.Text = "Stop Server";
            }
            else
            {
                btnStartStopServer.Text = "Start Server";
            }
        }

        private void OnConfigurationForm_Load(object sender, EventArgs e)
        {
            var collection = _database.GetCollection<ControllerConfiguration>();
            var configurations = collection.FindAll();
            if (configurations == null || !configurations.Any())
            {
                collection.Insert(new ControllerConfiguration()
                {
                    ControllerName = "Controller 1",
                    Port = 4545,
                    TighteningStrategy = Strategy.Random,
                    JobStrategy = Strategy.Random,
                    MinTighteningDelay = 3000,
                    MaxTighteningDelay = 10000,
                    Enabled = false,
                });
                configurations = collection.FindAll();
            }

            var rows = configurations.Select(x =>
            {
                var row = new DataGridViewRow();
                row.CreateCells(ConfigurationGrid, x.ControllerName, x.Port, x.TighteningStrategy.ToString(), x.JobStrategy.ToString(), x.MinTighteningDelay, x.MaxTighteningDelay, x.Enabled, "View Logs");
                return row;
            }).ToArray();
            ConfigurationGrid.Rows.AddRange(rows);
        }

        private ControllerConfiguration GetFromRow(DataGridViewRow row)
        {
            return new ControllerConfiguration()
            {
                ControllerName = row.Cells.GetString("ControllerName"),
                Port = row.Cells.GetInt("Port"),
                TighteningStrategy = row.Cells.GetEnum<Strategy>("TighteningStrategy"),
                JobStrategy = row.Cells.GetEnum<Strategy>("JobStrategy"),
                MinTighteningDelay = row.Cells.GetInt("MinTighteningDelay"),
                MaxTighteningDelay = row.Cells.GetInt("MaxTighteningDelay"),
                Enabled = row.Cells.GetBool("Enabled")
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var collection = _database.GetCollection<ControllerConfiguration>();
            collection.DeleteAll();

            foreach (DataGridViewRow row in ConfigurationGrid.Rows)
            {
                if (row.Index < ConfigurationGrid.Rows.Count - 1)
                {
                    var configuration = GetFromRow(row);
                    collection.Insert(configuration);
                }
            }
        }

        private async void OnAutoCreateControllers_Click(object sender, EventArgs e)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            };

            var dcController = new
            {
                Hostname = "TDCT118M2",
                FtpFolder = "/",

                Enabled = true
            };

            var r = await client.PostAsync("/v1/dc-controller", GetContent(dcController));
            ConfigurationGrid.Rows.Clear();
            var defaultPort = 4545;
            var rdn = new Random();
            for (int i = 0; i < numericTotalControllers.Value; i++)
            {
                var minDelay = rdn.Next(100, 10000);
                var maxDelay = rdn.Next(minDelay, 10000);
                ConfigurationGrid.Rows.Add(
                    $"Controller {i}",
                    defaultPort + i,
                    Strategy.Random.ToString(),
                    Strategy.OnlyOk.ToString(),
                    minDelay,
                    maxDelay,
                    true,
                    "View Logs");
                var vs = new
                {
                    VirtualStationNumber = $"TDCT118M2-VS{(i + 1).ToString().PadLeft(2, '0')}",
                    IpOrHostname = "127.0.0.1",
                    Port = defaultPort + i,
                    InTryOut = true,
                    Enabled = true
                };
                var response = await client.PostAsync("/v1/dc-controller/TDCT118M2/virtual-station", GetContent(vs));
            }
        }

        private StringContent GetContent(object obj)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
