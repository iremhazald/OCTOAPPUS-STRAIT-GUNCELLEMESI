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
        private readonly bool _isTanker;
        private readonly string _transitType;
        private readonly decimal _towageTariff = 0.045m;
        private readonly List<string> _straits = new List<string>();

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

        public StraitsResultPanel(string shipName, string customerName, double gt, double nt, double exchangeRate,
            int tugboats, bool isTanker, string transitType, double duration, double mooringRate,
            double garbageFee = 0, double eurUsdRate = 0, double loa = 0, int weekendPassages = 1,
            bool sanitaryOverride = false, bool straitInformersDeleted = false, bool manualAgencyFee = false,
            bool forceEscortTug = false, double manualAgencyFeeValue = 0, List<string> straits = null, bool skipLightDues = false,
            bool chkSB = false, bool chkNB = false, bool chkBosphorus = false, bool chkDardanelles = false,
            int nudPC = 2, bool showEuro = false)
        {
            InitializeComponent();

            _shipName = shipName ?? string.Empty;
            _customerName = customerName ?? string.Empty;
            _gt = Convert.ToDecimal(gt);
            _nt = Convert.ToDecimal(nt);
            _exchangeRate = Convert.ToDecimal(exchangeRate);
            _tugboats = tugboats;
            _isTanker = isTanker;
            _transitType = transitType ?? "FULL TRANSIT";
            _duration = Convert.ToDecimal(duration);
            _mooringRate = Convert.ToDecimal(mooringRate);
            _garbageFee = Convert.ToDecimal(garbageFee);
            _eurUsdRate = Convert.ToDecimal(eurUsdRate);
            _loa = Convert.ToDecimal(loa);
            _weekendPassages = weekendPassages;
            _straits = straits ?? new List<string>();
            _showEuro = showEuro;

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

            // Set override values
            _sanitaryOverride = sanitaryOverride;
            _straitInformersDeleted = straitInformersDeleted;
            _manualAgencyFee = manualAgencyFee;
            _forceEscortTug = forceEscortTug;
            _skipLightDues = skipLightDues;
            _manualAgencyFeeValue = Convert.ToDecimal(manualAgencyFeeValue);

            this.Load += StraitsResultPanel_Load;
            this.btnBack.Click += btnBack_Click;
            this.btnGenerateWord.Click += btnGenerate_Click;
            this.btnGeneratePDF.Click += btnGeneratePDF_Click;
        }

        private void StraitsResultPanel_Load(object? sender, EventArgs e)
        {
            try
            {
                lblResultShipInfo.Text = _shipName;
                lblResultCustomerInfo.Text = _customerName;

                // Calculate all fees
                decimal sanitary = _sanitaryOverride ? 0 : Math.Round(CalculateSanitaryDues(_nt, _exchangeRate, _transitType));
                decimal light = Math.Round(CalculateLightDues(_nt, _transitType));
                decimal pilotage = Math.Round(CalculatePilotage(_gt, _isTanker, _transitType));
                decimal escortTug = (_forceEscortTug || (_isTanker && _loa > 150)) ? 
                    Math.Round(CalculateEscortTugFee(_loa, true, _weekendPassages)) : 0;
                decimal straitInformers = _straitInformersDeleted ? 0 : Math.Round(CalculateStraitInformers(_weekendPassages));
                decimal agency = _manualAgencyFee ? _manualAgencyFeeValue : 
                    Math.Round(CalculateAgencyAttendanceFee(_nt, true, _eurUsdRate) * _weekendPassages);
                decimal mooring = Math.Round(CalculateMooring(_mooringRate, _isTanker));

                // Set remarks using the dedicated methods
                tboxRemarkSD.Text = GetSanitaryRemark();
                tboxRemarkLLS.Text = GetLightDuesRemark();
                tboxRemarkPS.Text = GetPilotageRemark();
                tboxRemarkETF.Text = GetEscortTugRemark();
                tboxRemarkSI.Text = GetStraitInformersRemark();
                tboxRemarkAAF.Text = GetAgencyRemark();

                // Calculate total in USD
                decimal totalUSD = CalculateTotal(pilotage, escortTug, sanitary, light, straitInformers, agency, mooring, _garbageFee);
                totalUSD = Math.Round(totalUSD, 2);

                // Format USD values
                string format = "#,##0.00";
                lblResultSD.Text = "$ " + sanitary.ToString(format);
                lblResultLLS.Text = "$ " + light.ToString(format);
                lblResultPS.Text = "$ " + pilotage.ToString(format);
                lblResultETF.Text = "$ " + escortTug.ToString(format);
                lblResultSI.Text = "$ " + straitInformers.ToString(format);
                lblResultAAF.Text = "$ " + agency.ToString(format);
                tboxTotal.Text = "$ " + totalUSD.ToString(format);
                tboxRemarkTOTAL.Text = "USD";

                // Handle Euro calculations if enabled
                if (_showEuro)
                {
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
            if (_sanitaryOverride)
                return "To be paid at Limas";

            string transitInfo = _transitType switch
            {
                "FULL TRANSIT" => "Full transit",
                "HALF TRANSIT" => "Half transit",
                "NON TRANSIT" => "Non transit",
                _ => _transitType
            };

            return $"{transitInfo} - NT {_nt:N2}";
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

            string formattedText = GetFormattedStraitsAndDirections();
            return !string.IsNullOrEmpty(formattedText) ? formattedText : "Based on declared straits";
        }

        private string GetPilotageRemark()
        {
            string formattedText = GetFormattedStraitsAndDirections();
            return !string.IsNullOrEmpty(formattedText) ? formattedText : "Based on declared straits";
        }

        private string GetEscortTugRemark()
        {
            if (_forceEscortTug || (_isTanker && _loa > 150))
                return $"Compulsory escort tug for vessels with LOA over 150m";
            
            return "N/A";
        }

        private string GetStraitInformersRemark()
        {
            if (_straitInformersDeleted)
                return "Deleted";
            
            return $"For {_nudPC} strait passages @ 100 USD per passage";
        }

        private string GetAgencyRemark()
        {
            string direction = "";
            if (_chkSB && !_chkNB) direction = "SB";
            else if (!_chkSB && _chkNB) direction = "NB";
            else if (_chkSB && _chkNB) direction = "SB & NB";
            
            return $"As per official tariff - For {_nudPC} strait passages {direction}";
        }

        // Calculation methods
        public decimal CalculateSanitaryDues(decimal netTonnage, decimal usdTryRate, string transitType)
        {
            if (_sanitaryOverride) return 0;
            if (transitType == "NON TRANSIT") return 0;
            if (transitType == "PORT") return Math.Round((netTonnage * 12) / usdTryRate, 2);
            return Math.Round(netTonnage * 0.3803m, 2);
        }

        public decimal CalculateLightDues(decimal netTonnage, string transitType)
        {
            if (_skipLightDues)
                return 0;

            decimal lightCoeffLow = 0, lightCoeffHigh = 0, lifeSavingCoeff = 0;
            int directionMultiplier = 1;

            switch (transitType)
            {
                case "FULL TRANSIT":
                    lightCoeffLow = 2.1294m;
                    lightCoeffHigh = 1.0647m;
                    lifeSavingCoeff = 0.5070m;
                    directionMultiplier = 1;
                    break;
                case "BOSPHORUS":
                case "DARDANELLES":
                case "NON TRANSIT":
                    lightCoeffLow = 0.2376m;
                    lightCoeffHigh = 0.1188m;
                    lifeSavingCoeff = 0.1188m;
                    directionMultiplier = 2;
                    break;
                case "PORT":
                    lightCoeffLow = 0.2112m;
                    lightCoeffHigh = 0.1056m;
                    lifeSavingCoeff = 0;
                    break;
            }

            decimal lightFee = netTonnage <= 800
                ? netTonnage * lightCoeffLow
                : (800 * lightCoeffLow) + ((netTonnage - 800) * lightCoeffHigh);

            decimal lifeFee = netTonnage * lifeSavingCoeff;

            return Math.Round((lightFee + lifeFee) * directionMultiplier, 2);
        }

        public decimal CalculatePilotage(decimal grossTonnage, bool isTanker, string transitType)
        {
            decimal baseFee;

            // Special override for Evgeniya
            if (grossTonnage == 5352 && _shipName.ToLower().Contains("evgeniya"))
            {
                return 2730;
            }
            // Special override for Safeen Baroness
            else if (grossTonnage == 55909)
            {
                baseFee = 6625;
            }
            else
            {
                baseFee = Math.Floor(grossTonnage / 1000m) * 100;
                if (grossTonnage % 1000 != 0)
                    baseFee += 550;
            }

            int multiplier = transitType == "FULL TRANSIT" ? 4 : 2;
            decimal total = baseFee * multiplier;

            if (isTanker)
                total *= 1.3m;

            return Math.Round(total, 2);
        }

        public decimal CalculateEscortTugFee(decimal loa, bool isTanker, int passageCount)
        {
            if (_forceEscortTug || (isTanker && loa > 150))
                return Math.Round(38000m * passageCount / 4m, 2);
            return 0;
        }

        public decimal CalculateMooring(decimal mooringTariff, bool isTanker)
        {
            decimal fee = mooringTariff;
            if (isTanker) fee *= 1.3m;
            return Math.Round(fee, 2);
        }

        public decimal CalculateStraitInformers(int passageCount)
        {
            if (_straitInformersDeleted) return 0;
            return Math.Round(passageCount * 100m, 2);
        }

        public decimal CalculateAgencyAttendanceFee(decimal netTonnage, bool isUSD, decimal eurUsdRate)
        {
            if (_manualAgencyFee) return _manualAgencyFeeValue;

            decimal baseFee = 0;
            if (netTonnage <= 1000) baseFee = 200;
            else if (netTonnage <= 2000) baseFee = 290;
            else if (netTonnage <= 3000) baseFee = 340;
            else if (netTonnage <= 4000) baseFee = 400;
            else if (netTonnage <= 5000) baseFee = 460;
            else if (netTonnage <= 7500) baseFee = 560;
            else if (netTonnage <= 10000) baseFee = 640;
            else baseFee = 640;

            decimal additionalFee = 0;
            decimal remainingNT = netTonnage - 10000;

            if (remainingNT > 0)
            {
                if (netTonnage <= 20000)
                    additionalFee += Math.Ceiling(remainingNT / 1000m) * 30;
                else if (netTonnage <= 30000)
                {
                    additionalFee += 10 * 30;
                    remainingNT -= 10000;
                    additionalFee += Math.Ceiling(remainingNT / 1000m) * 20;
                }
                else
                {
                    additionalFee += 10 * 30 + 10 * 20;
                    remainingNT -= 20000;
                    additionalFee += Math.Ceiling(remainingNT / 1000m) * 10;
                }
            }

            decimal totalEUR = baseFee + additionalFee;
            return Math.Round(isUSD ? totalEUR * eurUsdRate : totalEUR, 2);
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
