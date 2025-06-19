using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;

namespace HanShipProformaApp
{
    public partial class Straits : Form
    {
        private readonly HttpClient _httpClient;
        private readonly System.Windows.Forms.Timer _exchangeRateTimer;
        private decimal loa = 0;
        private int weekendPassages = 1;

        public Straits()
        {
            InitializeComponent();


            // Set NumericUpDown settings
            nudPC.Minimum = 1;
            nudPC.Maximum = 4;
            nudPC.Value = 2; // default value
            nudPC.Increment = 1;

            // Hide passage count controls while keeping functionality
            labelPassangeCount.Visible = false;
            nudPC.Visible = false;

            // Initialize husbandry controls visibility - hide by default
            tboxHusbandryName.Visible = false;
            tboxHusbandryPrices.Visible = false;

            // Initialize flag name textbox visibility
            tboxFlagName.Visible = false;
            lblFlagName.Visible = false;

            // Setup nation and flag interaction
            cmboxNation.SelectedIndexChanged += (s, e) =>
            {
                if (cmboxNation.SelectedItem != null)
                {
                    string selectedNation = cmboxNation.SelectedItem.ToString();
                    if (selectedNation == "Turkey")
                    {
                        cmbBoxFlag.SelectedItem = "Turkish";
                        tboxFlagName.Visible = false;
                        lblFlagName.Visible = false;
                    }
                    else if (selectedNation == "Foreign")
                    {
                        cmbBoxFlag.SelectedItem = "Non-Turkish";
                        tboxFlagName.Visible = true;
                        lblFlagName.Visible = true;
                    }
                }
            };

            cmbBoxFlag.SelectedIndexChanged += (s, e) =>
            {
                if (cmbBoxFlag.SelectedItem != null)
                {
                    string selectedFlag = cmbBoxFlag.SelectedItem.ToString();
                    if (selectedFlag == "Turkish")
                    {
                        cmboxNation.SelectedItem = "Turkey";
                        tboxFlagName.Visible = false;
                    }
                    else if (selectedFlag == "Non-Turkish")
                    {
                        cmboxNation.SelectedItem = "Foreign";
                        tboxFlagName.Visible = true;
                    }
                }
            };

         

            // Setup currency choice
            chkUSD.Checked = true;
            chkUSD.Enabled = false; // User cannot uncheck USD

            chkEURO.CheckedChanged += (s, e) =>
            {
                labelEuroRate.Visible = chkEURO.Checked;
                if (chkEURO.Checked)
                {
                    labelEuroRate.Text = $"EUR/USD Rate: {labelEuroDolar.Text}";
                }
            };

            // Initialize Euro rate visibility
            labelEuroRate.Visible = chkEURO.Checked;

            // Setup husbandry checkbox change handler
            chkHusbandry.CheckedChanged += (s, e) =>
            {
                tboxHusbandryName.Visible = chkHusbandry.Checked;
                tboxHusbandryPrices.Visible = chkHusbandry.Checked;
            };

            // Setup transit type change handler
            cmbTransitType.SelectedIndexChanged += CmbTransitType_SelectedIndexChanged;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            _exchangeRateTimer = new System.Windows.Forms.Timer();
            _exchangeRateTimer.Interval = 60000;
            _exchangeRateTimer.Tick += async (s, e) => await UpdateExchangeRates();

            if (this.Controls.Find("groupBox1", true).FirstOrDefault() is GroupBox groupBox1 &&
                groupBox1.Controls.Find("groupBox2", true).FirstOrDefault() is GroupBox groupBox2)
            {
                if (groupBox2.Controls.Find("tboxmanualeuro", true).FirstOrDefault() is TextBox tbEuro)
                {
                    tbEuro.TextChanged += tboxmanualeuro_TextChanged;
                }
                if (groupBox2.Controls.Find("tboxmanualdolar", true).FirstOrDefault() is TextBox tbDolar)
                {
                    tbDolar.TextChanged += tboxmanualdolar_TextChanged;
                }
            }

            _ = UpdateExchangeRates();
            _exchangeRateTimer.Start();

            // Add event handler for Calculate button
            btnCalculate.Click += HandleCalculateClick;

           

            // Inbound/Outbound logic: show textboxes only if "Pls Advise" is selected
            cmbBoxInBound.SelectedIndexChanged += (s, e) =>
            {
                tboxInbound.Visible = cmbBoxInBound.SelectedItem?.ToString() == "Pls Advise";
            };
            cmbBoxOutBound.SelectedIndexChanged += (s, e) =>
            {
                tboxOutbound.Visible = cmbBoxOutBound.SelectedItem?.ToString() == "Pls Advise";
            };
            // Set initial visibility
            tboxInbound.Visible = cmbBoxInBound.SelectedItem?.ToString() == "Pls Advise";
            tboxOutbound.Visible = cmbBoxOutBound.SelectedItem?.ToString() == "Pls Advise";

           
           

            // Set initial visibility for Weekend Passage checkbox
            chkWP.Visible = false;
        }

        private async Task UpdateExchangeRates()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://www.tcmb.gov.tr/kurlar/today.xml");
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response);
                var usdNode = xmlDoc.SelectSingleNode("//Currency[@Kod='USD']");
                var eurNode = xmlDoc.SelectSingleNode("//Currency[@Kod='EUR']");

                if (usdNode != null && usdNode.SelectSingleNode("ForexBuying")?.InnerText != null &&
                    usdNode.SelectSingleNode("ForexSelling")?.InnerText != null &&
                    eurNode != null && eurNode.SelectSingleNode("ForexBuying")?.InnerText != null)
                {
                    string usdBuyingRateStr = usdNode.SelectSingleNode("ForexBuying").InnerText;
                    string usdSellingRateStr = usdNode.SelectSingleNode("ForexSelling").InnerText;
                    string eurRateStr = eurNode.SelectSingleNode("ForexBuying").InnerText;

                    if (decimal.TryParse(usdBuyingRateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal usdBuyingRate) &&
                        decimal.TryParse(usdSellingRateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal usdSellingRate) &&
                        decimal.TryParse(eurRateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal eurBuyingRate))
                    {
                        // USD için alış ve satış ortalaması
                        decimal usdAverageRate = (usdBuyingRate + usdSellingRate) / 2;
                        
                        // EUR için sadece alış değeri (orijinal mantık)
                        decimal eurUsdRate = eurBuyingRate / usdBuyingRate;

                        this.Invoke((MethodInvoker)delegate
                        {
                            // USD için tam hesaplama sonucunu göster (5 decimal)
                            string[] parts = usdAverageRate.ToString(CultureInfo.InvariantCulture).Split('.');
                            string decimalPart = parts.Length > 1 ? parts[1] : "00000";
                            if (decimalPart.Length > 5) decimalPart = decimalPart.Substring(0, 5);
                            if (decimalPart.Length < 5) decimalPart = decimalPart.PadRight(5, '0');
                            string usdFormatted = $"{parts[0]},{decimalPart}";

                            labelDolarTL.Text = usdFormatted;
                            labelEuroDolar.Text = eurUsdRate.ToString("F4", CultureInfo.InvariantCulture);

                            if (string.IsNullOrWhiteSpace(tboxmanualdolar.Text))
                                tboxmanualdolar.Text = usdFormatted;
                            if (string.IsNullOrWhiteSpace(tboxmanualeuro.Text))
                                tboxmanualeuro.Text = eurUsdRate.ToString("F4", CultureInfo.InvariantCulture);
                        });
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            labelDolarTL.Text = "Parse Err";
                            labelEuroDolar.Text = "Parse Err";
                        });
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelDolarTL.Text = "No Data";
                        labelEuroDolar.Text = "No Data";
                    });
                }
            }
            catch (Exception)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    labelDolarTL.Text = "API Error";
                    labelEuroDolar.Text = "API Error";
                });
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Lblmanual.Visible = true;
                    tboxmanualeuro.Visible = true;
                    Lblmanual2.Visible = true;
                    tboxmanualdolar.Visible = true;
                });
            }
        }

        private void tboxmanualeuro_TextChanged(object sender, EventArgs e)
        {
            string input = tboxmanualeuro.Text.Trim();
            string standardizedInput = input.Replace(".", ",");

            if (string.IsNullOrWhiteSpace(input))
            {
                _ = UpdateExchangeRates();
                return;
            }

            string pattern = @"^\d{1,2}(,\d{1,4})?$";
            if (Regex.IsMatch(standardizedInput, pattern) && decimal.TryParse(standardizedInput, NumberStyles.Any, CultureInfo.GetCultureInfo("tr-TR"), out decimal eurUsdRate))
            {
                labelEuroDolar.Text = eurUsdRate.ToString("F4", CultureInfo.InvariantCulture);
            }
        }

        private void tboxmanualdolar_TextChanged(object sender, EventArgs e)
        {
            string input = tboxmanualdolar.Text.Trim();
            string standardizedInput = input.Replace(".", ",");

            if (string.IsNullOrWhiteSpace(input))
            {
                _ = UpdateExchangeRates();
                return;
            }

            string pattern = @"^\d{1,2}(,\d{1,4})?$";
            if (Regex.IsMatch(standardizedInput, pattern) && decimal.TryParse(standardizedInput, NumberStyles.Any, CultureInfo.GetCultureInfo("tr-TR"), out decimal usdTryRate))
            {
                labelDolarTL.Text = usdTryRate.ToString("F4", CultureInfo.InvariantCulture);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _exchangeRateTimer?.Stop();
            _exchangeRateTimer?.Dispose();
            _httpClient?.Dispose();
        }

        private void HandleCalculateClick(object sender, EventArgs e)
        {
            try
            {
                // Husbandry validation
                if (chkHusbandry.Checked)
                {
             

                    if (string.IsNullOrWhiteSpace(tboxHusbandryName.Text))
                    {
                        MessageBox.Show("Please enter Husbandry Name.", "Husbandry Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(tboxHusbandryPrices.Text))
                    {
                        MessageBox.Show("Please enter Husbandry Prices.", "Husbandry Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (cmbTransitType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Transit Type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string transitType = cmbTransitType.SelectedItem?.ToString() ?? string.Empty;

                if (cmbFirstDirection.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select First Direction.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // For FULL TRANSIT, require Second Direction
                if (transitType == "FULL TRANSIT" && (cmbSecondDirection.SelectedIndex == -1 || string.IsNullOrEmpty(cmbSecondDirection.SelectedItem?.ToString())))
                {
                    MessageBox.Show("For FULL TRANSIT, Second Direction must be selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(tboxGrossTonage.Text, out decimal gt) || gt <= 0)
                {
                    MessageBox.Show("Please enter a valid Gross Tonnage.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(tboxNetTonage.Text, out decimal nt) || nt <= 0)
                {
                    MessageBox.Show("Please enter a valid Net Tonnage.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbFirstDirection.SelectedItem == null)
                {
                    MessageBox.Show("Please select First Direction.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string firstDirection = cmbFirstDirection.SelectedItem.ToString() ?? string.Empty;
                string secondDirection = cmbSecondDirection.SelectedItem?.ToString() ?? string.Empty;

                decimal exchangeRate;
                decimal eurUsdRate;

                if (!string.IsNullOrWhiteSpace(tboxmanualdolar.Text) &&
                    decimal.TryParse(tboxmanualdolar.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out exchangeRate))
                {
                    // Manuel USD/TRY kuru kullan
                }
                else if (!string.IsNullOrWhiteSpace(labelDolarTL.Text) &&
                         decimal.TryParse(labelDolarTL.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out exchangeRate))
                {
                    // TCMB USD/TRY kuru kullan
                }
                else
                {
                    MessageBox.Show("Valid USD/TRY Exchange Rate is not available.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(tboxmanualeuro.Text) &&
                    decimal.TryParse(tboxmanualeuro.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out eurUsdRate))
                {
                    // Manuel EUR/USD kuru kullan
                }
                else if (!string.IsNullOrWhiteSpace(labelEuroDolar.Text) &&
                         decimal.TryParse(labelEuroDolar.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out eurUsdRate))
                {
                    // TCMB EUR/USD kuru kullan
                }
                else
                {
                    MessageBox.Show("Valid EUR/USD Exchange Rate is not available.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                
                if (string.IsNullOrEmpty(transitType))
                {
                    MessageBox.Show("Please select a Transit Type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               


                if (!decimal.TryParse(tboxLOA.Text, out loa) || loa <= 0)
                {
                    MessageBox.Show("Please enter a valid LOA.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get passage count from NumericUpDown
                int passageCount = (int)nudPC.Value;
                weekendPassages = 1; // Default value, you might want to add UI control for this

                // Get towage tariff, default to 0.045 if not valid
            

                string shipName = tboxShipName.Text;
                string customerName = tboxCustomer.Text;
                string inboundSelection = cmbBoxInBound.SelectedItem?.ToString() ?? string.Empty;
                string outboundSelection = cmbBoxOutBound.SelectedItem?.ToString() ?? string.Empty;
                string nationSelection = cmboxNation.SelectedItem?.ToString() ?? string.Empty;

                // Get husbandry values if enabled
                bool showHusbandry = chkHusbandry.Checked;
                string husbandryName = showHusbandry ? tboxHusbandryName.Text : string.Empty;
                double husbandryPrice = 0;
                if (showHusbandry && !string.IsNullOrWhiteSpace(tboxHusbandryPrices.Text))
                {
                    if (!double.TryParse(tboxHusbandryPrices.Text, out husbandryPrice))
                    {
                        MessageBox.Show("Please enter a valid Husbandry Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                StraitsResultPanel resultPanel = new StraitsResultPanel(
                    shipName,
                    customerName,
                    (double)gt,
                    (double)nt,
                    (double)exchangeRate,
                    0, // tugboats parameter
                    transitType,
                    0, // duration parameter
                    0, // mooringRate parameter
                    firstDirection,
                    secondDirection,
                    garbageFee: 0,
                    eurUsdRate: (double)eurUsdRate,
                    loa: (double)loa,
                    weekendPassages: weekendPassages,
                    isWeekendPassage: chkWP.Checked,
                    sanitaryOverride: false,
                    straitInformersDeleted: chkStraitInformersDeleted.Checked,              
                    straits: null,
                    skipLightDues: false,
                    chkSB: false,
                    chkNB: false,
                    chkBosphorus: chkBosphorus.Checked,
                    chkDardanelles: chkDardanelles.Checked,
                  
                    nudPC: passageCount,
                    showEuro: chkEURO.Checked,
                    inboundPort: inboundSelection,
                    outboundPort: outboundSelection,
                    escortTugBosphorus: chkBosphorus.Checked,
                    escortTugBosphorusSB: chkBosphorus.Checked && (firstDirection == "SB" || secondDirection == "SB"),
                    escortTugBosphorusNB: chkBosphorus.Checked && (firstDirection == "NB" || secondDirection == "NB"),
                    escortTugDardanelles: chkDardanelles.Checked,
                    escortTugDardanellesSB: chkDardanelles.Checked && (firstDirection == "SB" || secondDirection == "SB"),
                    escortTugDardanellesNB: chkDardanelles.Checked && (firstDirection == "NB" || secondDirection == "NB"),
                    nation: nationSelection,
                    showHusbandry: showHusbandry,
                    husbandryName: husbandryName,
                    husbandryPrice: husbandryPrice
                );
                resultPanel.ShowDialog();
            }
            catch (DivideByZeroException dbzEx)
            {
                MessageBox.Show("Error: " + dbzEx.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tboxIMO.Text))
            {
                MessageBox.Show("Lütfen bir IMO numarası giriniz.");
                return;
            }

            MyConnection.checkmyconnetion();

            SqlCommand command = new SqlCommand("SELECT * FROM Proforma WHERE IMO=@pımo", MyConnection.connection);
            command.Parameters.AddWithValue("@pımo", tboxIMO.Text);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tboxShipName.Text = reader["Shipname"].ToString();
                    tboxCustomer.Text = reader["Customer"].ToString();
                    tboxNetTonage.Text = reader["NetTonage"].ToString();
                    tboxGrossTonage.Text = reader["GrossTonage"].ToString();
                    tboxLOA.Text = reader["LOA"].ToString();
                    tboxBeam.Text = reader["BEAM"].ToString();
                    tboxDraft.Text = reader["Draft"].ToString();
                }
                btncheck.Visible = false;
                btnCalculate.Visible = true;
                btnCalculate.Enabled = true;  // Enable the button by default
            }
            else
            {
                MessageBox.Show("Bu IMO numarasına ait kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Lütfen gerekli bilgileri girin ve ardından 'Save' butonuna basın.", "Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btncheck.Visible = false;
                btnsave.Visible = true;
                btnCalculate.Visible = true;  // Keep calculate button visible
            }

            reader.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tboxShipName.Text) ||
                string.IsNullOrWhiteSpace(tboxCustomer.Text) ||
                string.IsNullOrWhiteSpace(tboxNetTonage.Text) ||
                string.IsNullOrWhiteSpace(tboxGrossTonage.Text) ||
                string.IsNullOrWhiteSpace(tboxLOA.Text) ||
                string.IsNullOrWhiteSpace(tboxBeam.Text) ||
                string.IsNullOrWhiteSpace(tboxDraft.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MyConnection.checkmyconnetion();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Proforma (IMO, Shipname, Customer, NetTonage, GrossTonage, LOA, BEAM, Draft) " +
                    "VALUES (@pımo, @shipname, @customer, @nettonage, @grosstonage, @loa, @beam, @draft)", MyConnection.connection);

                cmd.Parameters.AddWithValue("@pımo", tboxIMO.Text);
                cmd.Parameters.AddWithValue("@shipname", tboxShipName.Text);
                cmd.Parameters.AddWithValue("@customer", tboxCustomer.Text);
                cmd.Parameters.AddWithValue("@nettonage", tboxNetTonage.Text);
                cmd.Parameters.AddWithValue("@grosstonage", tboxGrossTonage.Text);
                cmd.Parameters.AddWithValue("@loa", tboxLOA.Text);
                cmd.Parameters.AddWithValue("@beam", tboxBeam.Text);
                cmd.Parameters.AddWithValue("@draft", tboxDraft.Text);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnsave.Visible = false;
                    btnCalculate.Visible = true;  // Keep calculate button visible
                    btnCalculate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Kayıt eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Straits_Load(object sender, EventArgs e)
        {
            // InBound İçin
            cmbBoxInBound.Items.Add("Turkey");
            cmbBoxInBound.Items.Add("Foreign");
            cmbBoxInBound.Items.Add("Pls Advise");
            cmbBoxInBound.DropDownStyle = ComboBoxStyle.DropDownList;

            // OutBound İçin
            cmbBoxOutBound.Items.Add("Turkey");
            cmbBoxOutBound.Items.Add("Foreign");
            cmbBoxOutBound.Items.Add("Pls Advise");
            cmbBoxOutBound.DropDownStyle = ComboBoxStyle.DropDownList;

            // Flag İçin
            cmbBoxFlag.Items.Add("Turkish");
            cmbBoxFlag.Items.Add("Non-Turkish");
            cmbBoxFlag.DropDownStyle = ComboBoxStyle.DropDownList;

            //Nation İçin
            cmboxNation.Items.Add("Turkey");
            cmboxNation.Items.Add("Foreign");
            cmboxNation.DropDownStyle = ComboBoxStyle.DropDownList;

            // Transit Type için
            cmbTransitType.Items.Clear();
            cmbTransitType.Items.Add("FULL TRANSIT");
            cmbTransitType.Items.Add("HALF TRANSIT");
            cmbTransitType.Items.Add("NON TRANSIT");
            cmbTransitType.DropDownStyle = ComboBoxStyle.DropDownList;

            //First Direction İçin
            cmbFirstDirection.Items.Clear();
            cmbFirstDirection.Items.Add(""); // Boş seçenek
            cmbFirstDirection.Items.Add("NB");
            cmbFirstDirection.Items.Add("SB");
            cmbFirstDirection.DropDownStyle = ComboBoxStyle.DropDownList;

            //Second Direction İçin
            cmbSecondDirection.Items.Clear();
            cmbSecondDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSecondDirection.Enabled = false;



            // Add event handler for First Direction selection
            cmbFirstDirection.SelectedIndexChanged += CmbFirstDirection_SelectedIndexChanged;

            // Set initial button states
            btnCalculate.Visible = true;   // Always show the calculate button
            btnCalculate.Enabled = true;   // Enable the button
            btnsave.Visible = false;       // Initially hide the save button
            btncheck.Visible = true;       // Show the check button

            // Add event handler for Transit Type selection
            cmbTransitType.SelectedIndexChanged += (s, e) =>
            {
                btnCalculate.Enabled = true;  // Always enable the button
                CmbTransitType_SelectedIndexChanged(s, e);
            };

            
        }

        private void CmbFirstDirection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            cmbSecondDirection.Items.Clear();
            
            if (cmbFirstDirection.SelectedItem != null && !string.IsNullOrEmpty(cmbFirstDirection.SelectedItem.ToString()))
            {
                string? firstDirection = cmbFirstDirection.SelectedItem.ToString();
                string transitType = cmbTransitType.SelectedItem?.ToString() ?? string.Empty;

                if (transitType == "FULL TRANSIT")
                {
                    // For FULL TRANSIT, second direction is required and opposite of first
                    cmbSecondDirection.Enabled = true;
                    if (firstDirection == "NB")
                    {
                        cmbSecondDirection.Items.Add("SB");
                        cmbSecondDirection.SelectedIndex = 0; // Automatically select SB
                    }
                    else if (firstDirection == "SB")
                    {
                        cmbSecondDirection.Items.Add("NB");
                        cmbSecondDirection.SelectedIndex = 0; // Automatically select NB
                    }
                }
                else
                {
                    // For HALF TRANSIT and NON TRANSIT, second direction is optional
                    cmbSecondDirection.Enabled = true;
                    cmbSecondDirection.Items.Add("");
                    if (firstDirection == "NB")
                    {
                        cmbSecondDirection.Items.Add("SB");
                    }
                    else if (firstDirection == "SB")
                    {
                        cmbSecondDirection.Items.Add("NB");
                    }
                }
            }
            else
            {
                cmbSecondDirection.Enabled = false;
            }
        }

        private void CmbTransitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTransitType = cmbTransitType.SelectedItem?.ToString() ?? string.Empty;

            // Set visibility of Weekend Passage checkbox
            chkWP.Visible = (selectedTransitType == "FULL TRANSIT");
            if (!chkWP.Visible)
            {
                chkWP.Checked = false;
            }

            // Reset direction selections
            cmbFirstDirection.SelectedIndex = -1;
            cmbSecondDirection.Items.Clear();
            cmbSecondDirection.Enabled = false;

            if (selectedTransitType == "FULL TRANSIT")
            {
                chkBosphorus.Checked = true;
                chkDardanelles.Checked = true;
                chkBosphorus.Enabled = false;
                chkDardanelles.Enabled = false;
                nudPC.Value = 4;

                // First Direction is required
                cmbFirstDirection.Items.Clear();
                cmbFirstDirection.Items.Add("NB");
                cmbFirstDirection.Items.Add("SB");
                
                // Second Direction will be required and set automatically based on First Direction
            }
            else if (selectedTransitType == "HALF TRANSIT" || selectedTransitType == "NON TRANSIT")
            {
                chkBosphorus.Checked = false;
                chkDardanelles.Checked = false;
                chkBosphorus.Enabled = true;
                chkDardanelles.Enabled = true;
                nudPC.Value = 2;

                // First Direction is required
                cmbFirstDirection.Items.Clear();
                cmbFirstDirection.Items.Add("NB");
                cmbFirstDirection.Items.Add("SB");
            }

            // Hide escort tug controls if NON TRANSIT is selected
           

            // Enable Calculate button only if transit type is selected
            btnCalculate.Enabled = !string.IsNullOrEmpty(selectedTransitType);
        }

    }
}
