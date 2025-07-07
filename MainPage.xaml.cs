namespace Ylaya_Splitter_MOBAPP
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }
        decimal bill;
        int tip;
        int noPersons = 1;
        decimal custoptip;

        private void txtBill_Completed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBill.Text))
            {
                txtBill.Text = "";
                lblTotal.Text = "0.00";
                return;
            }

            bill = decimal.Parse(txtBill.Text);
            CalculateBill();
        }
        private void CalculateBill()
        {
            //Total Tip
            var totalTip = (bill * tip) / 100;

            //Tip by Person
            var tipByPerson = (totalTip + custoptip) / noPersons;
            lblTipPerPerson.Text = "P" + tipByPerson.ToString("0.00");

            //Custom Tip
            //var CustomTip = (totalTip / noPersons);
            //lblTipPerPerson.Text = "P" + CustomTip.ToString("0.00");

            //Subtotal
            var subtotal = (bill / noPersons);
            lblSubtotal.Text = "P" + subtotal.ToString("0.00");

            //Total
            var totalPerPerson = (bill + totalTip + custoptip) / noPersons;
            lblTotal.Text =totalPerPerson.ToString("0.00");


            /////////////////////////////////////////////////////////

            ////TOTAL TIP
            //var totalTip = (bill * tip) / 100;

            //var CustomTip = totalTip + custoptip;

            ////TOTAL
            //var TotalPay = (bill + totalTip) / noPersons;
            //lblTotal.Text = TotalPay.ToString("0.00");

            ////SUBTOTAL
            //var SubtotalPay = bill / noPersons;
            //lblSubtotal.Text = SubtotalPay.ToString("0.00");

            ////TIP PER PERSON
            //var TipPerPerson = totalTip / noPersons;
            //lblTipPerPerson.Text = TipPerPerson.ToString("0.00");



            ////total tip


            ////tip by person
            //var tipByPerson = (totalTip / noPersons);
            //lblTipPerPerson.Text =tipByPerson.ToString("0.00");

            ////Subtotal
            //var subtotal = bill;
            //lblSubtotal.Text =subtotal.ToString("0.00");

            ////total
            //var totalPerPerson = (bill + totalTip);
            //lblTotal.Text =totalPerPerson.ToString("0.00");

        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = percentage;
            }
        }
        private void sldTip_ValueChanged(object sender, EventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTip.Text =tip + "%";
            CalculateBill();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 1)
            {
                noPersons--;
            }
            lblNoPersons.Text = noPersons.ToString();
            CalculateBill();
        }
        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            lblNoPersons.Text = noPersons.ToString();
            CalculateBill();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            TipSelector.IsVisible = false;
            SliderPanel.IsVisible = false;
            CustomPanel.IsVisible = true;
            sldTip.Value = 0;
            CalculateBill();
        }

        private void btnReturn_Clicked(object sender, EventArgs e)
        {
            TipSelector.IsVisible = true;
            SliderPanel.IsVisible = true;
            CustomPanel.IsVisible = false;
            custoptip = 0;
            TipCustom.Text = "";
            CalculateBill();
        }

        private void TipCustom_Completed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TipCustom.Text))
            {
                TipCustom.Text = "";
                return;
            }
            custoptip = decimal.Parse(TipCustom.Text);
            CalculateBill();
        }

        private void lblNoPersons_Completed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblNoPersons.Text))
            {
                lblNoPersons.Text = "";
                return; 
            }
            if (!int.TryParse(lblNoPersons.Text, out noPersons) || noPersons <= 0)
            {
                noPersons = 1; // Default to 1 if parsing fails or number is <= 0
                noPersons = int.Parse(lblNoPersons.Text);
                CalculateBill();
            }
            noPersons = int.Parse(lblNoPersons.Text);
            CalculateBill();
        }
    }




}



