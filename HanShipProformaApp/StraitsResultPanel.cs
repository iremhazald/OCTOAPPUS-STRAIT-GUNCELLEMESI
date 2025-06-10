using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HanShipProformaApp
{
    public partial class StraitsResultPanel : Form
    {
        private readonly string _shipName;
        private readonly string _customerName;
        private readonly decimal _gt, _nt, _exchangeRate, _duration, _mooringRate, _garbageFee, _eurUsdRate, _loa;
        private readonly int _tugboats, _weekendPassages;
        private readonly string _transitType;
        private readonly List<string> _straits = new List<string>();
        private readonly string _inboundPort;
        private readonly string _firstDirection;
        private readonly string _secondDirection;
        private readonly bool _isWeekend;

        // Escort Tug Checkboxes
        private CheckBox chkETB = new CheckBox();    // Bosphorus için escort tug
        private CheckBox chkETBSB = new CheckBox();  // Bosphorus SB için escort tug
        private CheckBox chkETBNB = new CheckBox();  // Bosphorus NB için escort tug
        private CheckBox chkETD = new CheckBox();    // Dardanelles için escort tug
        private CheckBox chkETDSB = new CheckBox();  // Dardanelles SB için escort tug
        private CheckBox chkETDNB = new CheckBox();  // Dardanelles NB için escort tug

        // Direction and strait checkboxes
        private readonly bool _chkSB;
        private readonly bool _chkNB;
        private readonly bool _chkBosphorus;
        private readonly bool _chkDardanelles;

        // Currency choice
        private readonly bool _showEuro;

        // Numeric controls
        private readonly int _nudPC;

        // Override values
        private readonly bool _sanitaryOverride;
        private readonly bool _straitInformersDeleted;
        private readonly bool _manualAgencyFee;
        private readonly bool _forceEscortTug;
        private readonly bool _skipLightDues;
        private readonly decimal _manualAgencyFeeValue;

        // Dictionary to store remarks for each fee type
        private readonly Dictionary<string, string> _remarks = new Dictionary<string, string>();

        // Escort Tug Settings
        private readonly bool _escortTugBosphorus;
        private readonly bool _escortTugBosphorusSB;
        private readonly bool _escortTugBosphorusNB;
        private readonly bool _escortTugDardanelles;
        private readonly bool _escortTugDardanellesSB;
        private readonly bool _escortTugDardanellesNB;

        public StraitsResultPanel(string? shipName, string? customerName, double gt, double nt, double exchangeRate,
            int tugboats, string? transitType, double duration, double mooringRate,
            string? firstDirection, string? secondDirection,
            double garbageFee = 0, double eurUsdRate = 0, double loa = 0, int weekendPassages = 1,
            bool sanitaryOverride = false, bool straitInformersDeleted = false, bool manualAgencyFee = false,
            bool forceEscortTug = false, double manualAgencyFeeValue = 0, List<string>? straits = null, bool skipLightDues = false,
            bool chkSB = false, bool chkNB = false, bool chkBosphorus = false, bool chkDardanelles = false, bool isWeekend = false,
            int nudPC = 2, bool showEuro = false, string? inboundPort = "",
            bool escortTugBosphorus = false, bool escortTugBosphorusSB = false, bool escortTugBosphorusNB = false,
            bool escortTugDardanelles = false, bool escortTugDardanellesSB = false, bool escortTugDardanellesNB = false)
        {
            InitializeComponent();

            // Initialize Escort Tug Checkboxes
            InitializeEscortTugCheckboxes();

            // Store escort tug settings
            _escortTugBosphorus = escortTugBosphorus;
            _escortTugBosphorusSB = escortTugBosphorusSB;
            _escortTugBosphorusNB = escortTugBosphorusNB;
            _escortTugDardanelles = escortTugDardanelles;
            _escortTugDardanellesSB = escortTugDardanellesSB;
            _escortTugDardanellesNB = escortTugDardanellesNB;

            // Configure NumericUpDown controls
            ConfigureNumericUpDown(nudSD);
            ConfigureNumericUpDown(nudLLS);
            ConfigureNumericUpDown(nudPS);
            ConfigureNumericUpDown(nudETF);
            ConfigureNumericUpDown(nudSI);
            ConfigureNumericUpDown(nudAAF);

            // Set initial visibility of NumericUpDown controls
            nudSD.Visible = false;
            nudLLS.Visible = false;
            nudPS.Visible = false;
            nudETF.Visible = false;
            nudSI.Visible = false;
            nudAAF.Visible = false;

            // Wire up button click events
            btnSD.Click += (s, e) =>
            {
                nudSD.Visible = true;
                btnSD.Visible = false;
                UpdateTotalAmount();
            };

            btnLLS.Click += (s, e) =>
            {
                nudLLS.Visible = true;
                btnLLS.Visible = false;
                UpdateTotalAmount();
            };

            btnPS.Click += (s, e) =>
            {
                nudPS.Visible = true;
                btnPS.Visible = false;
                UpdateTotalAmount();
            };

            btnETF.Click += (s, e) =>
            {
                nudETF.Visible = true;
                btnETF.Visible = false;
                UpdateTotalAmount();
            };

            btnSI.Click += (s, e) =>
            {
                nudSI.Visible = true;
                btnSI.Visible = false;
                UpdateTotalAmount();
            };

            btnAAF.Click += (s, e) =>
            {
                nudAAF.Visible = true;
                btnAAF.Visible = false;
                UpdateTotalAmount();
            };

            // Rest of the existing initialization code
            _shipName = shipName ?? string.Empty;
            _customerName = customerName ?? string.Empty;
            _isWeekend = isWeekend;
            _gt = Convert.ToDecimal(gt);
            _nt = Convert.ToDecimal(nt);
            _exchangeRate = Convert.ToDecimal(exchangeRate);
            _tugboats = tugboats;
            _transitType = transitType ?? "FULL TRANSIT";
            _duration = Convert.ToDecimal(duration);
            _mooringRate = Convert.ToDecimal(mooringRate);
            _garbageFee = Convert.ToDecimal(garbageFee);
            _eurUsdRate = Convert.ToDecimal(eurUsdRate);
            _loa = Convert.ToDecimal(loa);
            _weekendPassages = weekendPassages;
            _straits = straits ?? new List<string>();
            _showEuro = showEuro;
            _inboundPort = inboundPort ?? string.Empty;
            _firstDirection = firstDirection ?? string.Empty;
            _secondDirection = secondDirection ?? string.Empty;

            // Set direction and strait checkboxes
            _chkSB = chkSB;
            _chkNB = chkNB;
            _chkBosphorus = chkBosphorus;
            _chkDardanelles = chkDardanelles;

            // Initialize Euro-related controls visibility
            if (tboxTotalEURO != null) tboxTotalEURO.Visible = _showEuro;
            if (tboxRemarkTOTALEURO != null) tboxRemarkTOTALEURO.Visible = _showEuro;

            // Set numeric control values
            _nudPC = nudPC;
            
            // Debug check for _nudPC
            MessageBox.Show($"Constructor _nudPC value: {_nudPC}", "Debug - Constructor");

            // Set override values
            _sanitaryOverride = sanitaryOverride;
            _straitInformersDeleted = straitInformersDeleted;
            _manualAgencyFee = manualAgencyFee;
            _forceEscortTug = forceEscortTug;
            _skipLightDues = skipLightDues;
            _manualAgencyFeeValue = Convert.ToDecimal(manualAgencyFeeValue);

            // Initialize checkboxes
            chkETB.Checked = _escortTugBosphorus;
            chkETBSB.Checked = _escortTugBosphorusSB;
            chkETBNB.Checked = _escortTugBosphorusNB;

            this.Load += StraitsResultPanel_Load;
            this.btnBack.Click += btnBack_Click;
            this.btnGeneratePDF.Click += btnGeneratePDF_Click;
        }

        private void InitializeEscortTugCheckboxes()
        {
            // Bosphorus Escort Tug Group
            GroupBox grpBosphorus = new GroupBox
            {
                Text = "Bosphorus Escort Tug",
                Location = new Point(20, 300),
                Size = new Size(200, 100)
            };

            chkETB.Text = "Apply Escort Tug";
            chkETB.Location = new Point(10, 20);
            chkETBSB.Text = "SB";
            chkETBSB.Location = new Point(30, 50);
            chkETBNB.Text = "NB";
            chkETBNB.Location = new Point(100, 50);

            grpBosphorus.Controls.AddRange(new Control[] { chkETB, chkETBSB, chkETBNB });

            // Dardanelles Escort Tug Group
            GroupBox grpDardanelles = new GroupBox
            {
                Text = "Dardanelles Escort Tug",
                Location = new Point(240, 300),
                Size = new Size(200, 100)
            };

            chkETD.Text = "Apply Escort Tug";
            chkETD.Location = new Point(10, 20);
            chkETDSB.Text = "SB";
            chkETDSB.Location = new Point(30, 50);
            chkETDNB.Text = "NB";
            chkETDNB.Location = new Point(100, 50);

            grpDardanelles.Controls.AddRange(new Control[] { chkETD, chkETDSB, chkETDNB });

            // Add groups to form
            this.Controls.Add(grpBosphorus);
            this.Controls.Add(grpDardanelles);

            // Event handlers
            chkETB.CheckedChanged += (s, e) =>
            {
                chkETBSB.Enabled = chkETB.Checked;
                chkETBNB.Enabled = chkETB.Checked;
            };

            chkETD.CheckedChanged += (s, e) =>
            {
                chkETDSB.Enabled = chkETD.Checked;
                chkETDNB.Enabled = chkETD.Checked;
            };

            // Initial state
            chkETBSB.Enabled = false;
            chkETBNB.Enabled = false;
            chkETDSB.Enabled = false;
            chkETDNB.Enabled = false;
        }

        private void ConfigureNumericUpDown(NumericUpDown nud)
        {
            nud.DecimalPlaces = 2;
            nud.Minimum = 0;
            nud.Maximum = 100;
            nud.Increment = 0.01M;
            nud.ThousandsSeparator = true;
            nud.ValueChanged += (s, e) => UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            try
            {
                decimal totalUSD = nudSD.Value + nudLLS.Value + nudPS.Value + 
                                 nudETF.Value + nudSI.Value + nudAAF.Value;

                string format = "#,##0.00";
                tboxTotal.Text = "$ " + totalUSD.ToString(format);

                if (_showEuro)
                {
                    decimal totalEUR = Math.Round(totalUSD * _eurUsdRate, 2);
                    tboxTotalEURO.Text = "€ " + totalEUR.ToString(format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNumericUpDownValue(NumericUpDown nud, decimal value)
        {
            if (value >= nud.Minimum && value <= nud.Maximum)
            {
                nud.Value = value;
            }
            else if (value < nud.Minimum)
            {
                nud.Value = nud.Minimum;
            }
            else
            {
                nud.Value = nud.Maximum;
            }
        }

        private void StraitsResultPanel_Load(object? sender, EventArgs e)
        {
            try
            {
                lblResultShipInfo.Text = _shipName;
                lblResultCustomerInfo.Text = _customerName;

                // Debug information
                string debugInfo = $"NT (Original): {Convert.ToDecimal(_nt):N3}\n" +
                                 $"NT (Converted): {_nt:N3}\n" +
                                 $"GT (Original): {Convert.ToDecimal(_gt):N3}\n" +
                                 $"GT (Converted): {_gt:N3}\n" +
                                 $"Transit Type: {_transitType}\n" +
                                 $"Calculated Passages: {GetTotalPassages()}\n" +
                                 $"Skip Light Dues: {_skipLightDues}";
                MessageBox.Show(debugInfo, "Debug Values");

                // Calculate all fees
                decimal sanitary = _inboundPort.ToUpper() == "TURKEY" ? 0 : Math.Round(CalculateSanitaryDues(_nt, _exchangeRate, _transitType));
                decimal light = _skipLightDues ? 0 : Math.Round(CalculateLightAndLifeSavingDues(_nt, _transitType, GetTotalPassages()));
                decimal pilotage = CalculatePilotage(_gt, _transitType);
                decimal escortTug = CalculateEscortTugFee();
                decimal straitInformers = _straitInformersDeleted ? 0 : Math.Round(CalculateStraitInformers(GetTotalPassages()));

                // Show which EUR/USD rate is being used
                MessageBox.Show($"EUR/USD rate used for Agency Attendance Fee: {_eurUsdRate}", "Debug - EUR/USD Rate");

                decimal agency = _manualAgencyFee ? _manualAgencyFeeValue : Math.Round(CalculateAgencyAttendanceFeeEURTariffToUSD(_nt, _nudPC, _eurUsdRate), 0);

                // Set remarks using the dedicated methods
                tboxRemarkSD.Text = GetSanitaryRemark();
                tboxRemarkLLS.Text = GetLightDuesRemark();
                tboxRemarkPS.Text = GetPilotageRemark();
                tboxRemarkETF.Text = GetEscortTugRemark();
                tboxRemarkSI.Text = GetStraitInformersRemark();
                tboxRemarkAAF.Text = GetAgencyRemark();

                // Initialize NumericUpDown controls with calculated values
                UpdateNumericUpDownValue(nudSD, sanitary);
                UpdateNumericUpDownValue(nudLLS, light);
                UpdateNumericUpDownValue(nudPS, pilotage);
                UpdateNumericUpDownValue(nudETF, escortTug);
                UpdateNumericUpDownValue(nudSI, straitInformers);
                UpdateNumericUpDownValue(nudAAF, agency);

                // Format USD values
                string format = "#,##0.00";
                lblResultSD.Text = "$ " + sanitary.ToString(format);
                lblResultLLS.Text = "$ " + light.ToString(format);
                lblResultPS.Text = "$ " + pilotage.ToString(format);
                lblResultETF.Text = "$ " + escortTug.ToString(format);
                lblResultSI.Text = "$ " + straitInformers.ToString(format);
                lblResultAAF.Text = "$ " + agency.ToString(format);

                // Calculate and display total
                UpdateTotalAmount();

                // Handle Euro calculations if enabled
                if (_showEuro)
                {
                    decimal totalUSD = decimal.Parse(tboxTotal.Text.Replace("$ ", ""));
                    decimal totalEUR = Math.Round(totalUSD * _eurUsdRate, 2);
                    tboxTotalEURO.Text = "€ " + totalEUR.ToString(format);
                    tboxRemarkTOTALEURO.Text = $"EUR As per ROE {_eurUsdRate:F4}";
                    tboxTotalEURO.Visible = true;
                    tboxRemarkTOTALEURO.Visible = true;
                }
                else
                {
                    if (tboxTotalEURO != null) tboxTotalEURO.Visible = false;
                    if (tboxRemarkTOTALEURO != null) tboxRemarkTOTALEURO.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating fees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Remark generation methods
        private string GetSanitaryRemark()
        {
            if (_inboundPort.ToUpper() == "TURKEY")
                return "To be paid at Limas";

            switch (_transitType.ToUpper())
            {
                case "FULL TRANSIT":
                    return $"TS Full Transit (Bosphorus & Dardanelles passages {_firstDirection} & {_secondDirection})";

                case "HALF TRANSIT":
                    return $"Bosphorus & Dardanelles passages SB & NB";

                case "NON TRANSIT":
                    return $"Bosphorus & Dardanelles passages SB & NB";
                
                default:
                    return "Transit type not specified";
            }
        }

        private string GetFormattedStraitsAndDirections()
        {
            // Get selected straits
            var selectedStraits = new List<string>();
            if (_chkBosphorus) selectedStraits.Add("Bosphorus");
            if (_chkDardanelles) selectedStraits.Add("Dardanelles");

            // Get direction
            string direction = "";
            if (_chkSB && !_chkNB) direction = "SB";
            else if (!_chkSB && _chkNB) direction = "NB";
            else if (_chkSB && _chkNB) direction = "SB & NB";

            // If nothing is selected, return default
            if (!selectedStraits.Any() || string.IsNullOrEmpty(direction))
                return "";

            // Format the output
            string straitsText = selectedStraits.Count == 1 ? selectedStraits[0] : "Bosphorus & Dardanelles";
            return $"{straitsText} {direction}";
        }

        private string GetLightDuesRemark()
        {
            if (_skipLightDues)
                return "Deleted";

            switch (_transitType.ToUpper())
            {
                case "FULL TRANSIT":
                    return $"Bosphorus & Dardanelles {_firstDirection} & {_secondDirection}";

                case "HALF TRANSIT":
                 string strait = "";
                    if (_chkBosphorus && !_chkDardanelles)
                        strait = "Bosphorus";
                    else if (!_chkBosphorus && _chkDardanelles)
                        strait = "Dardanelles";
                    else if (_chkBosphorus && _chkDardanelles)
                        strait = "Bosphorus & Dardanelles";
                    else
                        return "No strait selected";

                    // If second direction is not selected, only show first direction
                    if (string.IsNullOrEmpty(_secondDirection))
                        return $"{strait} {_firstDirection}";
                    else
                        return $"{strait} {_firstDirection} & {_secondDirection}";
                case "NON TRANSIT":
                    
                    if (_chkBosphorus && !_chkDardanelles)
                        strait = "Bosphorus";
                    else if (!_chkBosphorus && _chkDardanelles)
                        strait = "Dardanelles";
                    else if (_chkBosphorus && _chkDardanelles)
                        strait = "Bosphorus & Dardanelles";
                    else
                        return "No strait selected";

                    // If second direction is not selected, only show first direction
                    if (string.IsNullOrEmpty(_secondDirection))
                        return $"{strait} {_firstDirection}";
                    else
                        return $"{strait} {_firstDirection} & {_secondDirection}";
                

                default:
                    return "Transit type not specified";
            }
        }

        private string GetPilotageRemark()
        {
            string strait;

    switch (_transitType.ToUpper())
    {
        case "FULL TRANSIT":
            return $"For TS {_firstDirection} + {_secondDirection} / 4 straits";

        case "HALF TRANSIT":
            if (_chkBosphorus && !_chkDardanelles)
                strait = "Bosphorus";
            else if (!_chkBosphorus && _chkDardanelles)
                strait = "Dardanelles";
            else if (_chkBosphorus && _chkDardanelles)
                strait = "Bosphorus & Dardanelles";
            else
                return "No strait selected";

            if (string.IsNullOrEmpty(_secondDirection))
                return $"{strait} {_firstDirection}";
            else
                return $"{strait} {_firstDirection} & {_secondDirection}";

        case "NON TRANSIT":
            if (_chkBosphorus && !_chkDardanelles)
                strait = "Bosphorus";
            else if (!_chkBosphorus && _chkDardanelles)
                strait = "Dardanelles";
            else if (_chkBosphorus && _chkDardanelles)
                strait = "Bosphorus & Dardanelles";
            else
                return "No strait selected";

            if (string.IsNullOrEmpty(_secondDirection))
                return $"{strait} {_firstDirection}";
            else
                return $"{strait} {_firstDirection} & {_secondDirection}";

        default:
            return "Transit type not specified";
    }
        }

        private string GetEscortTugRemark()
        {
            // Non-Transit ise escort uygulanmaz
            if (_transitType.ToUpper() == "NON TRANSIT")
                return "N/A";

            // LOA < 150 ve force escort yoksa uygulanmaz
            if (_loa < 150 && !_forceEscortTug)
                return "N/A";

            // Boğaz ve yön bazlı açıklama üret
            List<string> remarks = new();

            if (_escortTugBosphorus)
            {
                if (_escortTugBosphorusSB) remarks.Add("Bosphorus SB");
                if (_escortTugBosphorusNB) remarks.Add("Bosphorus NB");
            }

            if (_escortTugDardanelles)
            {
                if (_escortTugDardanellesSB) remarks.Add("Dardanelles SB");
                if (_escortTugDardanellesNB) remarks.Add("Dardanelles NB");
            }

            // Eğer hiç seçim yapılmamışsa, yine "N/A" döndür
            if (!remarks.Any())
                return "N/A";

            string directions = string.Join(" & ", remarks);
            
            if (_forceEscortTug && _loa < 150)
            {
                return $"Escort tug manually applied for {directions} for LOA {_loa}m vessel (under standard limit)";
            }
            else
            {
                string loaText = _loa >= 200 ? "200 m" : "150 m";
                return $"Compulsory escort tug for {directions} for vessels with LOA over {loaText}";
            }
        }

        private string GetStraitInformersRemark()
        {
            if (!_chkBosphorus && !_chkDardanelles)
        return "No strait passage";

    decimal originalAmount = Math.Round(GetTotalPassages() * 100m, 2);

    if (_straitInformersDeleted)
        return $"Deleted - {originalAmount:#,##0.00} USD";

    return $"As per official tariff - For {_nudPC} strait passages {_firstDirection} & {_secondDirection}";
        }

        private string GetAgencyRemark()
        {
            string direction = "";
            if (!string.IsNullOrEmpty(_firstDirection) && !string.IsNullOrEmpty(_secondDirection))
                direction = $"{_firstDirection} & {_secondDirection}";
            else if (!string.IsNullOrEmpty(_firstDirection))
                direction = _firstDirection;
            else if (!string.IsNullOrEmpty(_secondDirection))
                direction = _secondDirection;

            return $"As per official tariff - For {_nudPC} strait passages{(string.IsNullOrEmpty(direction) ? "" : " " + direction)}";
        }

        // Calculation methods
        public decimal CalculateSanitaryDues(decimal netTonnage, decimal usdTryRate, string transitType)
        {
            // Only check if inbound port is Turkey
            if (_inboundPort.ToUpper() == "TURKEY") 
            {
                return 0;
            }

            // Coefficient for Sanitary Dues is 0.3803
            decimal total = netTonnage * 0.3803m;

            // Round to 2 decimal places using MidpointRounding.ToZero for consistency
            return Math.Round(total, 2, MidpointRounding.ToZero);
        }

        private int GetTotalPassages()
        {
            int count = 0;

            if (_chkBosphorus)
            {
                if (!string.IsNullOrEmpty(_firstDirection)) count++;
                if (!string.IsNullOrEmpty(_secondDirection)) count++;
            }

            if (_chkDardanelles)
            {
                if (!string.IsNullOrEmpty(_firstDirection)) count++;
                if (!string.IsNullOrEmpty(_secondDirection)) count++;
            }

            return count;
        }

        public decimal CalculateLightAndLifeSavingDues(decimal netTonnage, string transitType, int totalPassages)
        {
            decimal light = 0;
            decimal life = 0;

            decimal baseLightCoeff, over800LightCoeff, lifeSavingCoeff;

            // Set coefficients based on transit type
            switch (transitType.ToUpper())
            {
                case "FULL TRANSIT":
                    baseLightCoeff = 2.1294m;
                    over800LightCoeff = 1.0647m;
                    lifeSavingCoeff = 0.5070m;
                    break;

                case "HALF TRANSIT":  // HALF TRANSIT uses same coefficients as FULL TRANSIT but for single direction
                    baseLightCoeff = 2.1294m;
                    over800LightCoeff = 1.0647m;
                    lifeSavingCoeff = 0.5070m;
                    break;

                case "NON TRANSIT":  // NON TRANSIT uses same coefficients as BOSPHORUS/DARDANELLES
                case "BOSPHORUS":
                case "DARDANELLES":
                    baseLightCoeff = 0.2376m;
                    over800LightCoeff = 0.1188m;
                    lifeSavingCoeff = 0.1188m;
                    break;

                
                default:
                    return 0;
            }

            // Light dues calculation
            if (netTonnage <= 800)
            {
                light = netTonnage * baseLightCoeff;
            }
            else
            {
                light = (800 * baseLightCoeff) + ((netTonnage - 800) * over800LightCoeff);
            }

            // Life saving dues calculation
            life = netTonnage * lifeSavingCoeff;

            // Calculate total
            decimal total = light + life;

            // For HALF TRANSIT, we only charge for one direction
            if (transitType.ToUpper() == "HALF TRANSIT")
            {
                total = total / 2;
            }
            // For NON TRANSIT, we charge for both directions (SB & NB)
            else if (transitType.ToUpper() == "NON TRANSIT")
            {
                total = total * 2;
            }

            // Round to 2 decimal places using MidpointRounding.ToZero for consistency
            return Math.Round(total, 2, MidpointRounding.ToZero);
        }

        public decimal CalculatePilotage(decimal gt, string transitType)
{
    decimal baseFee = Math.Floor(gt / 1000) * 100;

    if (gt % 1000 != 0)
        baseFee += 550;

    int passages = transitType.ToUpper() switch
    {
        "FULL TRANSIT" => 4,
        "HALF TRANSIT" => 2,
        "NON TRANSIT" => 2,
        _ => 0
    };

    decimal total = baseFee * passages * 1.3m;

    return Math.Round(total, 2, MidpointRounding.ToZero);
}


        public decimal CalculateEscortTugFee()
        {
            // Non-Transit ise escort uygulanmaz
            if (_transitType.ToUpper() == "NON TRANSIT")
                return 0;

            bool escortRequired = false;

            // Force Escort seçiliyse her durumda uygula
            if (_forceEscortTug)
            {
                escortRequired = true;
            }
            // LOA > 150 ise escort zorunlu (tanker veya değil)
            else if (_loa > 150)
            {
                escortRequired = true;
            }

            if (!escortRequired)
                return 0;

            decimal totalFee = 0;

            // BOSPHORUS geçişleri
            if (_escortTugBosphorus)
            {
                if (_escortTugBosphorusSB) totalFee += 8500m;
                if (_escortTugBosphorusNB) totalFee += 8500m;
            }

            // DARDANELLES geçişleri
            if (_escortTugDardanelles)
            {
                if (_escortTugDardanellesSB) totalFee += 10500m;
                if (_escortTugDardanellesNB) totalFee += 10500m;
            }

            return Math.Round(totalFee, 2, MidpointRounding.ToZero);
        }

        public decimal CalculateStraitInformers(int passageCount)
        {
            if (_straitInformersDeleted)
                return 0;

            if (!_chkBosphorus && !_chkDardanelles)
                return 0; // Hiç boğaz geçilmiyorsa ücret alınmaz

            return Math.Round(GetTotalPassages() * 100m, 2);
        }

        public decimal CalculateAgencyAttendanceFeeEURTariffToUSD(decimal netTonnage, int passageCount, decimal eurUsdRate)
        {
            decimal baseFee = 0;

            // Fixed fee table
            if (netTonnage <= 1000) baseFee = 200;
            else if (netTonnage <= 2000) baseFee = 290;
            else if (netTonnage <= 3000) baseFee = 340;
            else if (netTonnage <= 4000) baseFee = 400;
            else if (netTonnage <= 5000) baseFee = 460;
            else if (netTonnage <= 7500) baseFee = 560;
            else if (netTonnage <= 10000) baseFee = 640;
            else
            {
                baseFee = 640;
                decimal remainingNT = netTonnage - 10000;

                if (netTonnage <= 20000)
                {
                    baseFee += Math.Ceiling(remainingNT / 1000) * 30;
                }
                else if (netTonnage <= 30000)
                {
                    baseFee += 10 * 30; // 10,001–20,000
                    remainingNT -= 10000;
                    baseFee += Math.Ceiling(remainingNT / 1000) * 20;
                }
                else
                {
                    baseFee += 10 * 30 + 10 * 20; // 10,001–30,000
                    remainingNT -= 20000;
                    baseFee += Math.Ceiling(remainingNT / 1000) * 10;
                }
            }

            decimal totalEUR = baseFee * passageCount;
            decimal totalUSD = totalEUR * eurUsdRate;
            return Math.Round(totalUSD, 2);
        }

        public decimal CalculateTotal(params decimal[] items) => items.Sum();

        private void btnBack_Click(object? sender, EventArgs e) => this.Close();

        private void btnGenerate_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Generate Word functionality not yet implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGeneratePDF_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Generate PDF functionality not yet implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Public method to get remarks for external use (e.g., PDF/Word generation)
        public string GetRemark(string feeType)
        {
            return _remarks.TryGetValue(feeType, out string remark) ? remark : string.Empty;
        }
    }
}
