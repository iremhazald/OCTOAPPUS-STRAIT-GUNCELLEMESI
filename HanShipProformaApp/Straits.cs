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
            
            // Set default tariff values
            tboxTT.Text = "0.045";  // Default Towage Tariff
            tboxMT.Text = "300";    // Default Mooring Tariff
            
            // Setup override controls
            chkManualAgencyFee.CheckedChanged += (s, e) => {
                numericManualAgencyFee.Enabled = chkManualAgencyFee.Checked;
            };
            
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
                    eurNode != null && eurNode.SelectSingleNode("ForexBuying")?.InnerText != null)
                {
                    string usdRateStr = usdNode.SelectSingleNode("ForexBuying").InnerText;
                    string eurRateStr = eurNode.SelectSingleNode("ForexBuying").InnerText;

                    if (decimal.TryParse(usdRateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal usdBuyingRate) &&
                        decimal.TryParse(eurRateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal eurBuyingRate) &&
                        usdBuyingRate != 0)
                    {
                        decimal eurUsdRate = eurBuyingRate / usdBuyingRate;

                        this.Invoke((MethodInvoker)delegate
                        {
                            labelDolarTL.Text = usdBuyingRate.ToString("F4", CultureInfo.InvariantCulture);
                            labelEuroDolar.Text = eurUsdRate.ToString("F4", CultureInfo.InvariantCulture);

                            if (string.IsNullOrWhiteSpace(tboxmanualdolar.Text))
                                tboxmanualdolar.Text = usdBuyingRate.ToString("F4", CultureInfo.InvariantCulture);
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

                if (!int.TryParse(tboxStraitFees.Text, out int tugboats) || tugboats < 0)
                {
                    MessageBox.Show("Please enter a valid number of Tugboats.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isTanker = checkIsTanker.Checked;
                string transitType = cmbTransitType.SelectedItem?.ToString() ?? string.Empty;
                if (string.IsNullOrEmpty(transitType))
                {
                    MessageBox.Show("Please select a Transit Type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal mooringRate = 0;
                if (!string.IsNullOrWhiteSpace(tboxMooringRate.Text))
                {
                    if (!decimal.TryParse(tboxMooringRate.Text, out mooringRate))
                    {
                        MessageBox.Show("Please enter a valid Mooring Rate.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                decimal duration = 0;
                if (!string.IsNullOrWhiteSpace(tboxDuration.Text))
                {
                    if (!decimal.TryParse(tboxDuration.Text, out duration))
                    {
                        MessageBox.Show("Please enter a valid Duration.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                decimal towageTariff = decimal.TryParse(tboxTT.Text, out decimal tt) ? tt : 0.045m;
                
                string shipName = tboxShipName.Text;
                string customerName = tboxCustomer.Text;
                
                StraitsResultPanel resultPanel = new StraitsResultPanel(
                    shipName, 
                    customerName, 
                    (double)gt, 
                    (double)nt, 
                    (double)exchangeRate,
                    tugboats, 
                    isTanker, 
                    transitType, 
                    (double)duration, 
                    (double)mooringRate,
                    garbageFee: 0,
                    eurUsdRate: (double)eurUsdRate,
                    loa: (double)loa,
                    nudPC: passageCount,
                    weekendPassages: weekendPassages,
                    sanitaryOverride: chkSanitaryOverride.Checked,
                    straitInformersDeleted: chkStraitInformersDeleted.Checked,
                    manualAgencyFee: chkManualAgencyFee.Checked,
                    forceEscortTug: chkForceEscortTug.Checked,
                    manualAgencyFeeValue: (double)numericManualAgencyFee.Value,
                    chkSB: chkSB.Checked,
                    chkNB: chkNB.Checked,
                    chkBosphorus: chkBosphorus.Checked,
                    chkDardanelles: chkDardanelles.Checked
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
            }
            else
            {
                MessageBox.Show("Bu IMO numarasına ait kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Lütfen gerekli bilgileri girin ve ardından 'Save' butonuna basın.", "Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btncheck.Visible = false;
                btnsave.Visible = true;
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
                    btnCalculate.Visible = true;
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
    }
}
