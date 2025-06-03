using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Xml;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Data.SqlClient;
namespace HanShipProformaApp
{
    public partial class ProformaPanel : Form
    {
        private readonly HttpClient _httpClient;
        private System.Windows.Forms.Timer _exchangeRateTimer;
        private MainPanel _mainPanel;
        public ProformaPanel()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

            // Timer'ı ayarla
            _exchangeRateTimer = new System.Windows.Forms.Timer();
            _exchangeRateTimer.Interval = 60000; // Her 1 dakikada bir güncelle
            _exchangeRateTimer.Tick += async (s, e) => await UpdateExchangeRates();
        }
        public ProformaPanel(MainPanel mainPanel) : this()
        {
            _mainPanel = mainPanel;
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

                if (usdNode != null && eurNode != null)
                {
                    decimal usdBuyingRate = decimal.Parse(usdNode.SelectSingleNode("ForexBuying").InnerText.Replace(".", ","));
                    decimal eurBuyingRate = decimal.Parse(eurNode.SelectSingleNode("ForexBuying").InnerText.Replace(".", ","));
                    decimal eurUsdRate = eurBuyingRate / usdBuyingRate;

                    // Thread-safe UI güncelleme
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelDolarTL.Text = $"USD/TRY: {usdBuyingRate:N4}";
                        labelEuroDolar.Text = $"EUR/USD: {eurUsdRate:N4}";
                    });
                    tboxmanualeuro.Visible = false;
                    Lblmanual.Visible = false;
                    Lblmanual2.Visible = false;
                    tboxmanualdolar.Visible = false;
                }
                else
                {
                    decimal usdBuyingRate = decimal.Parse(usdNode.SelectSingleNode("ForexBuying").InnerText.Replace(".", ","));
                    decimal eurBuyingRate = decimal.Parse(eurNode.SelectSingleNode("ForexBuying").InnerText.Replace(".", ","));
                    decimal eurUsdRate = eurBuyingRate / usdBuyingRate;

                    this.Invoke((MethodInvoker)delegate
                    {
                        labelDolarTL.Text = $"USD/TRY: {usdBuyingRate:N4}";
                        labelEuroDolar.Text = $"EUR/USD: {eurUsdRate:N4}";
                    });
                    // Eğer API verisi yoksa, manuel kurlar devreye girmeli
                    string euroInput = tboxmanualeuro.Text.Trim();
                    string dolarInput = tboxmanualdolar.Text.Trim();

                    // Euro kuru için geçerli format kontrolü (1-2 rakam + virgül + 4 ondalık basamak)
                    string euroPattern = @"^\d{1,2},\d{4}$";
                    Regex euroRegex = new Regex(euroPattern);
                    bool isEuroValid = euroRegex.IsMatch(euroInput);

                    // Dolar kuru için geçerli format kontrolü
                    string dolarPattern = @"^\d{1,2},\d{4}$";
                    Regex dolarRegex = new Regex(dolarPattern);
                    bool isDolarValid = dolarRegex.IsMatch(dolarInput);

                    if (isEuroValid && isDolarValid)
                    {
                        // Euro ve Dolar geçerliyse, manuel kurlar aktif hale gelsin
                        this.Invoke((MethodInvoker)delegate
                        {
                            tboxmanualeuro.Visible = true;
                            Lblmanual.Visible = true;
                            tboxmanualdolar.Visible = true;
                            Lblmanual2.Visible = true;

                            // Kurlar etiketlere yansıtılsın
                            labelDolarTL.Text = tboxmanualdolar.Text;
                            labelEuroDolar.Text = tboxmanualeuro.Text;
                        });
                    }
                    else
                    {
                        // Eğer geçerli bir giriş yapılmadıysa, hata mesajı gösterelim
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Lütfen geçerli döviz kurlarını girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    labelDolarTL.Text = "USD/TRY: Error";
                    labelEuroDolar.Text = "EUR/USD: Error";
                });
            }
        }
        private void ProformaPanel_Load(object sender, EventArgs e)
        {


            // Flag İçin
            cmbBoxFlag.Items.Add("Turkey");
            cmbBoxFlag.Items.Add("Foreign");
            cmbBoxFlag.DropDownStyle = ComboBoxStyle.DropDownList;


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

            ////Strait İçin   burası strait ekranına taşınacak :)
            //cmbBoxStrait.Items.Add("No Strait Selected");
            //cmbBoxStrait.Items.Add("Bosphorus");
            //cmbBoxStrait.Items.Add("Dardanelles");
            //cmbBoxStrait.SelectedIndex = 0;

            // Ana Port Kısmı İçin
            cmbBoxPortCity.Items.Add("İzmit");
            cmbBoxPortCity.Items.Add("Mersin");
            cmbBoxPortCity.Items.Add("Marmara Ereğlisi & Tekirdağ");
            cmbBoxPortCity.Items.Add("Trabzon");
            cmbBoxPortCity.Items.Add("Samsun");
            cmbBoxPortCity.Items.Add("Aliağa");
            cmbBoxPortCity.Items.Add("İskenderun/Ceyhan");
            cmbBoxPortCity.DropDownStyle = ComboBoxStyle.DropDownList;


            // Operation İçin
            cmbBoxOperation.Items.Add("Loading");
            cmbBoxOperation.Items.Add("Discharge");
            cmbBoxOperation.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargo Type İçin
            cmbBoxCargoType.Items.Add("Dry Cargo");
            cmbBoxCargoType.Items.Add("Grains and Seeds");
            cmbBoxCargoType.Items.Add("Pulses");
            cmbBoxCargoType.Items.Add("Crude oil and petroleum products");
            cmbBoxCargoType.Items.Add("LPG and LNG gasses");
            cmbBoxCargoType.Items.Add("Chemical products");
            cmbBoxCargoType.Items.Add("Other");
            cmbBoxCargoType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxCargoType.SelectedIndex = 0;
            cmbBoxCargoType.SelectedIndexChanged += cmbBoxCargoType_SelectedIndexChanged;

            cmbBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add butonu için event handler
            cmbBoxFlag.SelectedIndex = 1;
            cmbBoxInBound.SelectedIndex = 2;
            cmbBoxOutBound.SelectedIndex = 2;
            cmbBoxCargoType.SelectedIndex = 3;

            tboxSundries.Text = "550";
            tboxAgencyStaffCarExpenses.Text = "350";
            tboxCommunicationExpenses.Text = "150";
            btnCalculate.Visible = false;
            btnsave.Visible = false;


            _ = UpdateExchangeRates();
            _exchangeRateTimer.Start();

            // Add event handlers for TextChanged to reset field appearance
            tboxShipName.TextChanged += TextBox_TextChanged;
            tboxCustomer.TextChanged += TextBox_TextChanged;
            tboxNetTonage.TextChanged += TextBox_TextChanged;
            tboxGrossTonage.TextChanged += TextBox_TextChanged;
            tboxLOA.TextChanged += TextBox_TextChanged;
            tboxBeam.TextChanged += TextBox_TextChanged;
            tboxIMO.TextChanged += TextBox_TextChanged;
            tboxCargoWeight.TextChanged += TextBox_TextChanged;
            tboxAnchorageDay.TextChanged += TextBox_TextChanged;
            
            // Add event handlers for SelectedIndexChanged to reset combobox appearance
            cmbBoxFlag.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbBoxPortCity.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbBoxPort.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbBoxInBound.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbBoxOutBound.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbBoxOperation.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbBoxCargoType.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _exchangeRateTimer.Stop();
            _httpClient.Dispose();
        }

        private void cmbBoxPortCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxPortCity.SelectedItem.ToString().Contains("İzmit"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("Tutunciftlik");
                cmbBoxPort.Items.Add("Yilport Terminal");
                cmbBoxPort.Items.Add("Poliport");
                cmbBoxPort.Items.Add("Altinel Terminal");
                cmbBoxPort.Items.Add("Solventas");
                cmbBoxPort.Items.Add("POAS Terminal");
                cmbBoxPort.Items.Add("Aksa Yalova");
                cmbBoxPort.Items.Add("Koruma Derince");
                cmbBoxPort.Items.Add("Limas Terminal");
                cmbBoxPort.Items.Add("Ak-tas Terminal");
                cmbBoxPort.Items.Add("Safi Port");
                cmbBoxPort.Items.Add("Belde Port");

            }
            else if (cmbBoxPortCity.SelectedItem.ToString().Contains("Aliağa"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("Petkim");
                cmbBoxPort.Items.Add("Guzel Enerji");
                cmbBoxPort.Items.Add("Star Refinery");
                cmbBoxPort.Items.Add("Ege Gubre Jetty");
                cmbBoxPort.Items.Add("STAD");
                cmbBoxPort.Items.Add("Nemrut Platform");
                cmbBoxPort.Items.Add("Alpet Buoys");
                cmbBoxPort.Items.Add("Tupras");

            }
            else if (cmbBoxPortCity.SelectedItem.ToString().Contains("Ceyhan"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("Dortyol GTS");
                cmbBoxPort.Items.Add("Toros Terminal");
                cmbBoxPort.Items.Add("İskenderun Port");
                cmbBoxPort.Items.Add("BOTAS");
                cmbBoxPort.Items.Add("POAS");

            }
            else if (cmbBoxPortCity.SelectedItem.ToString().Contains("Marmara"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("OPET");
                cmbBoxPort.Items.Add("MDH Buoy");
                cmbBoxPort.Items.Add("Likit Dolphin");
                cmbBoxPort.Items.Add("MARTAS");
                cmbBoxPort.Items.Add("Ceyport");
                cmbBoxPort.Items.Add("Asyaport");
                cmbBoxPort.Items.Add("Argaz & Butan Buoys");
                cmbBoxPort.Items.Add("BOTAS");

            }
            else if (cmbBoxPortCity.SelectedItem.ToString().Contains("Mersin"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("Atas Refinery");
                cmbBoxPort.Items.Add("BP Gaz LPG Terminal");
                cmbBoxPort.Items.Add("OPET Terminal");
                cmbBoxPort.Items.Add("Turkis Enerji Buoy");
                cmbBoxPort.Items.Add("Alpet Buoy");
                cmbBoxPort.Items.Add("Nergis Buoy");
                cmbBoxPort.Items.Add("Enerji Buoy");
                cmbBoxPort.Items.Add("Akpet Buoy");
                cmbBoxPort.Items.Add("Euroil Buoy");
                cmbBoxPort.Items.Add("Savka Platform");

            }
            else if (cmbBoxPortCity.SelectedItem.ToString().Contains("Samsun"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("Alpet Buoys");
                cmbBoxPort.Items.Add("Lukoil Buoys");
                cmbBoxPort.Items.Add("Guzel Enerji Buoy");

            }
            else if (cmbBoxPortCity.SelectedItem.ToString().Contains("Trabzon"))
            {
                cmbBoxPort.Items.Clear();
                cmbBoxPort.Items.Add("POAS Buoy");

            }

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Required fields validation
            List<string> emptyRequiredFields = new List<string>();
            bool hasEmptyFields = false;
            
            // Reset all borders first
            ResetAllBorders();
            
            // Check required fields - DWT and Draft can be empty
            if (string.IsNullOrWhiteSpace(tboxShipName.Text)) { MarkErrorField(tboxShipName); emptyRequiredFields.Add("Ship Name"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxCustomer.Text)) { MarkErrorField(tboxCustomer); emptyRequiredFields.Add("Customer"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxNetTonage.Text)) { MarkErrorField(tboxNetTonage); emptyRequiredFields.Add("Net Tonage"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxGrossTonage.Text)) { MarkErrorField(tboxGrossTonage); emptyRequiredFields.Add("Gross Tonage"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxLOA.Text)) { MarkErrorField(tboxLOA); emptyRequiredFields.Add("LOA"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxBeam.Text)) { MarkErrorField(tboxBeam); emptyRequiredFields.Add("Beam"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxIMO.Text)) { MarkErrorField(tboxIMO); emptyRequiredFields.Add("IMO"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxCargoWeight.Text)) { MarkErrorField(tboxCargoWeight); emptyRequiredFields.Add("Cargo Weight"); hasEmptyFields = true; }
            if (string.IsNullOrWhiteSpace(tboxAnchorageDay.Text)) { MarkErrorField(tboxAnchorageDay); emptyRequiredFields.Add("Anchorage Day"); hasEmptyFields = true; }
            
            // Check combo boxes
            if (cmbBoxFlag.SelectedItem == null) { MarkErrorField(cmbBoxFlag); emptyRequiredFields.Add("Flag"); hasEmptyFields = true; }
            if (cmbBoxPortCity.SelectedItem == null) { MarkErrorField(cmbBoxPortCity); emptyRequiredFields.Add("Port City"); hasEmptyFields = true; }
            if (cmbBoxPort.SelectedItem == null) { MarkErrorField(cmbBoxPort); emptyRequiredFields.Add("Port"); hasEmptyFields = true; }
            if (cmbBoxInBound.SelectedItem == null) { MarkErrorField(cmbBoxInBound); emptyRequiredFields.Add("InBound"); hasEmptyFields = true; }
            if (cmbBoxOutBound.SelectedItem == null) { MarkErrorField(cmbBoxOutBound); emptyRequiredFields.Add("OutBound"); hasEmptyFields = true; }
            if (cmbBoxOperation.SelectedItem == null) { MarkErrorField(cmbBoxOperation); emptyRequiredFields.Add("Operation"); hasEmptyFields = true; }
            if (cmbBoxCargoType.SelectedItem == null) { MarkErrorField(cmbBoxCargoType); emptyRequiredFields.Add("Cargo Type"); hasEmptyFields = true; }
            
            // Display error if any required fields are empty
            if (hasEmptyFields)
            {
                // Force redraw of all controls to ensure red borders are visible
                this.Refresh();
                Application.DoEvents();
                
                MessageBox.Show("Please fill in all required fields highlighted in red.\nEmpty fields are not allowed except DWT, Draft and additional costs.", 
                    "Required Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double netTonage, grossTonage, LOA, beam, draft = 0, IMO, DWT = 0, cargoWeight, dolarTL, euroDolar;
            double notaryPublicFee = 0, sundries = 0, agencyStaffCarExpenses = 0, launchboatServices = 0, communicationExpenses = 0;
            double Postage = 0, Fiscalstamps = 0, pervious = 0;
            int anchorageDay;
            double mauneldolar = 0, maunelEuro = 0;

            string dolarTLText = labelDolarTL.Text.Replace("USD/TRY: ", "").Trim();
            string euroDolarText = labelEuroDolar.Text.Replace("EUR/USD: ", "").Trim();

            // Virgül varsa, noktaya çevirelim
            dolarTLText = dolarTLText.Replace(",", ".");
            euroDolarText = euroDolarText.Replace(",", ".");

            // Sayıları doğrudan double olarak almak için CultureInfo.InvariantCulture kullanıyoruz
            if (!double.TryParse(dolarTLText, NumberStyles.Any, CultureInfo.InvariantCulture, out dolarTL))
            {
                MessageBox.Show("Dolar TL değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(euroDolarText, NumberStyles.Any, CultureInfo.InvariantCulture, out euroDolar))
            {
                MessageBox.Show("Euro Dolar değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse values with error handling
            if (!double.TryParse(tboxNetTonage.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out netTonage))
            {
                MessageBox.Show("Net Tonage değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!double.TryParse(tboxGrossTonage.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out grossTonage))
            {
                MessageBox.Show("Gross Tonage değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!double.TryParse(tboxLOA.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out LOA))
            {
                MessageBox.Show("LOA değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!double.TryParse(tboxBeam.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out beam))
            {
                MessageBox.Show("Beam değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Draft and DWT can be empty
            if (!string.IsNullOrWhiteSpace(tboxDraft.Text) && 
                !double.TryParse(tboxDraft.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out draft))
            {
                MessageBox.Show("Draft değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!double.TryParse(tboxIMO.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out IMO))
            {
                MessageBox.Show("IMO değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // DWT can be empty
            if (!string.IsNullOrWhiteSpace(tboxDWT.Text) && 
                !double.TryParse(tboxDWT.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out DWT))
            {
                MessageBox.Show("DWT değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!double.TryParse(tboxCargoWeight.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out cargoWeight))
            {
                MessageBox.Show("Cargo Weight değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!int.TryParse(tboxAnchorageDay.Text, out anchorageDay))
            {
                MessageBox.Show("Anchorage Day değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Additional costs - these can be empty
            double.TryParse(tboxNotaryPublicFee.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out notaryPublicFee);
            double.TryParse(tboxSundries.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out sundries);
            double.TryParse(tboxAgencyStaffCarExpenses.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out agencyStaffCarExpenses);
            double.TryParse(tboxLaunchboatServices.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out launchboatServices);
            double.TryParse(tboxCommunicationExpenses.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out communicationExpenses);
            double.TryParse(tboxpostage.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out Postage);
            double.TryParse(tboxfiscal.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out Fiscalstamps);
            double.TryParse(tboxPrevious.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out pervious);
            double.TryParse(tboxmanualdolar.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out mauneldolar);
            double.TryParse(tboxmanualeuro.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out maunelEuro);

            // Cargo tipinin kontrolü
            string cargoType = cmbBoxCargoType.SelectedItem.ToString();
            if (cargoType == "Other" && string.IsNullOrEmpty(tboxOtherCargoType.Text))
            {
                MessageBox.Show("Lütfen kargo tipini belirtin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Format operation string
            string operationType = cmbBoxOperation.SelectedItem.ToString() == "Loading" ? "Load" : "Discharge";
            string finalCargoType = cargoType == "Other" ? tboxOtherCargoType.Text : cargoType;
            string operation = $"{operationType}  {cargoWeight} MT {tboxOtherCargoType.Text}";
            // Sonuç panelini oluştur
            ResultPanel window = new ResultPanel(
                tboxShipName.Text,
                tboxCustomer.Text,
                cmbBoxFlag.SelectedItem?.ToString() ?? "",  // Seçili değilse boş string
                flagname.Text,
                netTonage,
                grossTonage,
                LOA,
                beam,
                draft,
                cmbBoxPort.SelectedItem?.ToString() ?? "",
                cmbBoxPortCity.SelectedItem?.ToString() ?? "",
                cmbBoxInBound.SelectedItem?.ToString() ?? "",
                cmbBoxOutBound.SelectedItem?.ToString() ?? "",
                dolarTL,
                euroDolar,
                IMO,
                DWT,
                operation,
                cmbBoxOperation.SelectedItem?.ToString() ?? "",
                anchorageDay,
                cmbBoxCargoType.SelectedItem?.ToString() ?? "",
                tboxOtherCargoType.Text,
                cargoWeight,
                notaryPublicFee,
                sundries,
                agencyStaffCarExpenses,
                launchboatServices,
                communicationExpenses,
                Postage,
                Fiscalstamps,
                pervious,
                mauneldolar,
                maunelEuro,
                this // Kendisini ResultPanel'e gönder, böylece geri dönüş mümkün olsun
            );

            this.Hide();
            window.Show();

        }
        // Flag İçin Textbox Enabled Kısmı  Foreign Seçildiğinde Flagname Enabled Olacak 
        private void cmbBoxFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxFlag.SelectedItem.ToString().Contains("Foreign"))
            {
                flagname.Enabled = true;

            }
            else
            {
                flagname.Enabled = false;
            }
        }

        private void cmbBoxCargoType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void tboxmanualeuro_TextChanged_1(object sender, EventArgs e)
        {
            string input = tboxmanualeuro.Text.Trim();

            // 7 karakteri aşarsa hemen hata göster ve temizle
            if (input.Length > 7)
            {
                MessageBox.Show("Toplamda 7 karakteri geçemezsiniz. (Örnek: 37,4444)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxmanualeuro.Clear(); // TextBox'ı temizle
                return;
            }

            // Eğer 7 karakter yazılmadıysa, kontrol yapmıyoruz
            if (input.Length < 7)
            {
                return;
            }

            // Regex deseni: 1-2 basamaktan sonra virgül ve 4 basamaktan oluşan giriş
            string pattern = @"^\d{1,2},\d{4}$"; // 1-2 rakam + virgül + 4 ondalık basamak

            // Regex ile eşleşme kontrolü
            Regex regex = new Regex(pattern);

            // Eğer eşleşme yoksa, geçersiz giriş yapılmıştır
            if (!regex.IsMatch(input))
            {
                MessageBox.Show("Lütfen geçerli bir değer girin. (Örnek: 37,4444)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxmanualeuro.Clear(); // Geçersiz giriş yapıldığında TextBox'ı temizle
            }
            if (decimal.TryParse(tboxmanualeuro.Text, out decimal eurUsdRate))
            {
                labelEuroDolar.Text = $"EUR/USD: {eurUsdRate:N4}";
            }
            else
            {
                labelEuroDolar.Text = "EUR/USD: Geçersiz Değer";
            }

        }

        private void tboxmanualdolar_TextChanged_1(object sender, EventArgs e)
        {
            string input = tboxmanualdolar.Text.Trim();

            // 7 karakteri aşarsa hemen hata göster ve temizle
            if (input.Length > 7)
            {
                MessageBox.Show("Toplamda 7 karakteri geçemezsiniz. (Örnek: 37,4444)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxmanualdolar.Clear(); // TextBox'ı temizle
                return;
            }

            // Eğer 7 karakter yazılmadıysa, kontrol yapmıyoruz
            if (input.Length < 7)
            {
                return;
            }

            // Regex deseni: 1-2 basamaktan sonra virgül ve 4 basamaktan oluşan giriş
            string pattern = @"^\d{1,2},\d{4}$"; // 1-2 rakam + virgül + 4 ondalık basamak

            // Regex ile eşleşme kontrolü
            Regex regex = new Regex(pattern);

            // Eğer eşleşme yoksa, geçersiz giriş yapılmıştır
            if (!regex.IsMatch(input))
            {
                MessageBox.Show("Lütfen geçerli bir değer girin. (Örnek: 37,4444)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxmanualdolar.Clear(); // Geçersiz giriş yapıldığında TextBox'ı temizle
            }
            if (decimal.TryParse(tboxmanualdolar.Text, out decimal usdBuyingRate))
            {
                labelDolarTL.Text = $"USD/TRY: {usdBuyingRate:N4}";
            }
            else
            {
                labelDolarTL.Text = "USD/TRY: Geçersiz Değer";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (tboxIMO.Text == "")
            {
                MessageBox.Show("Lütfen bir değer giriniz");
            }
            else
            {
                MyConnection.checkmyconnetion();
                SqlCommand command = new SqlCommand("SELECT * FROM Proforma WHERE IMO=@pımo", MyConnection.connection);
                command.Parameters.AddWithValue("@pımo", tboxIMO.Text);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        // Veritabanından gelen verileri kullanarak işlemler yapabilirsiniz
                        tboxShipName.Text = sqlDataReader["Shipname"].ToString();
                        tboxCustomer.Text = sqlDataReader["Customer"].ToString();
                        tboxNetTonage.Text = sqlDataReader["NetTonage"].ToString();
                        tboxGrossTonage.Text = sqlDataReader["GrossTonage"].ToString();
                        tboxLOA.Text = sqlDataReader["LOA"].ToString();
                        tboxBeam.Text = sqlDataReader["BEAM"].ToString();
                        tboxDraft.Text = sqlDataReader["Draft"].ToString();
                    }
                    btncheck.Visible = false;
                    btnCalculate.Visible = true;
                    sqlDataReader.Close();
                }
                else
                {
                    MessageBox.Show("Bu IMO numarasına ait kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult result = DialogResult.Yes;

                    // Eğer "Yes" seçeneği otomatik olarak seçilmişse, işlem yapılacak
                    if (result == DialogResult.Yes)
                    {
                        // Kullanıcıya bilgi mesajı ver
                        MessageBox.Show("Lütfen gerekli bilgileri girin ve ardından 'save' butonuna basın.",
                                          "Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // btncheck butonunu gizle, btnsave butonunu görünür yap
                        btncheck.Visible = false;
                        btnsave.Visible = true;
                    }
                    sqlDataReader.Close();
                }
            }
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
                return; // Fonksiyondan çık, işlem yapılmasın
            }
            else
            {
                try
                {
                    // Veritabanı bağlantısı sağla
                    MyConnection.checkmyconnetion();

                    // SQL komutunu oluştur
                    SqlCommand sqlCommand = new SqlCommand(
                        "INSERT INTO Proforma (IMO,Shipname, Customer, NetTonage, GrossTonage, LOA, BEAM, Draft) " +
                        "VALUES (@pımo,@shipname, @customer, @nettonage, @grosstonage, @loa, @beam, @draft)",
                        MyConnection.connection);

                    // Parametreleri ekle
                    sqlCommand.Parameters.AddWithValue("@pımo", tboxIMO.Text);
                    sqlCommand.Parameters.AddWithValue("@shipname", tboxShipName.Text);
                    sqlCommand.Parameters.AddWithValue("@customer", tboxCustomer.Text);
                    sqlCommand.Parameters.AddWithValue("@nettonage", tboxNetTonage.Text);
                    sqlCommand.Parameters.AddWithValue("@grosstonage", tboxGrossTonage.Text);
                    sqlCommand.Parameters.AddWithValue("@loa", tboxLOA.Text);
                    sqlCommand.Parameters.AddWithValue("@beam", tboxBeam.Text);
                    sqlCommand.Parameters.AddWithValue("@draft", tboxDraft.Text);

                    // Veritabanına sorguyu gönder
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Yeni kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Kaydet işlemi başarılı olduğunda btnCalculate butonunu görünür yap
                        btnsave.Visible = false; // btnsave butonunu gizle
                        btnCalculate.Visible = true; // btnCalculate butonunu görünür yap

                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_mainPanel != null)
            {
                this.Hide();
                _mainPanel.Show();
            }
            else
            {
                MainPanel mp = new MainPanel();
                this.Hide();
                mp.Show();
            }
        }

        private void ResetAllBorders()
        {
            // Reset textboxes
            ResetControlBorder(tboxShipName);
            ResetControlBorder(tboxCustomer);
            ResetControlBorder(tboxNetTonage);
            ResetControlBorder(tboxGrossTonage);
            ResetControlBorder(tboxLOA);
            ResetControlBorder(tboxBeam);
            ResetControlBorder(tboxIMO);
            ResetControlBorder(tboxCargoWeight);
            ResetControlBorder(tboxAnchorageDay);
            
            // Reset comboboxes
            ResetControlBorder(cmbBoxFlag);
            ResetControlBorder(cmbBoxPortCity);
            ResetControlBorder(cmbBoxPort);
            ResetControlBorder(cmbBoxInBound);
            ResetControlBorder(cmbBoxOutBound);
            ResetControlBorder(cmbBoxOperation);
            ResetControlBorder(cmbBoxCargoType);
        }
        
        private void ResetControlBorder(Control control)
        {
            control.Tag = null;
            control.BackColor = SystemColors.Window;
            
            // Remove error border if it exists
            var errorBorder = control.Controls.OfType<PictureBox>().FirstOrDefault(p => p.Name == "errorBorder");
            if (errorBorder != null)
            {
                control.Controls.Remove(errorBorder);
                errorBorder.Dispose();
            }
            
            // Özel olarak işlenen kontrollerin stilini geri yükle
            if (control == tboxAnchorageDay || control == tboxCargoWeight)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            else if (control is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.Fixed3D;
            }
            
            control.Refresh();
        }

        // Helper method to highlight textbox with red border
        private void HighlightTextBox(TextBox textBox)
        {
            // Remove this direct drawing method since it's unreliable
            // Keep the normal style but mark for drawing a red border
            textBox.BorderStyle = BorderStyle.Fixed3D;
            textBox.BackColor = SystemColors.Window;
            textBox.Tag = "error"; // Mark as having an error
            
            // Force redraw immediately
            textBox.Refresh();
        }

        // Helper method to highlight combobox with red border
        private void HighlightComboBox(ComboBox comboBox)
        {
            // Remove this direct drawing method since it's unreliable
            comboBox.BackColor = SystemColors.Window;
            comboBox.Tag = "error"; // Mark as having an error
            
            // Force redraw immediately
            comboBox.Refresh();
        }

        // New unified method to mark fields with error
        private void MarkErrorField(Control control)
        {
            control.Tag = "error";
            control.BackColor = SystemColors.Window;
            
            // Özel işlem: Anchorage Day ve Cargo Weight için altındaki gri çizgiyi gizle
            if (control == tboxAnchorageDay || control == tboxCargoWeight)
            {
                // TextBox olduğu için çerçeveyi kaldır, sadece kırmızı çerçeve görünecek
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }
            
            // Draw red border immediately using a custom PictureBox border
            if (!control.Controls.OfType<PictureBox>().Any(p => p.Name == "errorBorder"))
            {
                PictureBox border = new PictureBox();
                border.Name = "errorBorder";
                border.BackColor = Color.Transparent;
                border.BorderStyle = BorderStyle.None;
                border.Dock = DockStyle.Fill;
                border.Paint += (sender, e) => {
                    using (Pen redPen = new Pen(Color.Red, 1))
                    {
                        e.Graphics.DrawRectangle(redPen, 0, 0, border.Width - 1, border.Height - 1);
                    }
                };
                
                // Make the PictureBox clickable but not capture input
                border.Enabled = false;
                
                // Set to back so it doesn't block input
                control.Controls.Add(border);
                border.SendToBack();
            }
            
            control.Refresh();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Reset the appearance of the TextBox when text is entered
            if (sender is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                ResetControlBorder(textBox);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset the appearance of the ComboBox when an item is selected
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                ResetControlBorder(comboBox);
            }
        }

        // Add this override to ensure borders are redrawn when form is updated
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Draw red borders for any controls marked with error
            DrawRedBordersForErrorControls();
        }
        
        // Method to draw red borders for all controls marked with error
        private void DrawRedBordersForErrorControls()
        {
            // Draw for top-level controls
            foreach (Control control in this.Controls)
            {
                DrawRedBorderIfNeeded(control);
                
                // Also check child controls (for panels, groupboxes, etc.)
                foreach (Control childControl in control.Controls)
                {
                    DrawRedBorderIfNeeded(childControl);
                }
            }
        }
        
        // Helper method to draw red border for a control if needed
        private void DrawRedBorderIfNeeded(Control control)
        {
            if (control.Tag != null && control.Tag.ToString() == "error")
            {
                using (Graphics g = control.CreateGraphics())
                using (Pen redPen = new Pen(Color.Red, 2))
                {
                    g.DrawRectangle(redPen, 0, 0, control.Width - 1, control.Height - 1);
                }
            }
        }
        
        // Override to ensure red borders persist during resizing or when covered by other windows
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            DrawRedBordersForErrorControls();
        }
        
        // Add this to ensure red borders are redrawn if form is activated
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            DrawRedBordersForErrorControls();
        }
    }
}
