using LiteDB;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Emulator.Drivers;
using OpenProtocolInterpreter.Emulator.Drivers.Events;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Vin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(btnStartStopServer.Text == "Start Server")
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

        private void OnAutoCreateControllers_Click(object sender, EventArgs e)
        {
            ConfigurationGrid.Rows.Clear();
            var defaultPort = 4545;
            var rdn = new Random();
            for(int i = 0; i < numericTotalControllers.Value; i++)
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
            }
        }
    }
}
