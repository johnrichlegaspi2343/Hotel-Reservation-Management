using System.Drawing.Printing;
using Model;

namespace HotelReservation
{
    public partial class PaymentReceipt : Form
    {
        private string receiptText = "";

        // Kailangan ng designer ito, huwag burahin
        public PaymentReceipt()
        {
            InitializeComponent();
        }

        // Ginagamit ng BillingPayment pagkatapos magbayad
        public PaymentReceipt(Payment payment, Model.Reservation r) : this()
        {
            lblTransactionId.Text = payment.TransactionId;
            lblDate.Text = payment.PaymentDate.ToString("MM/dd/yyyy hh:mm tt");
            lblGuest.Text = r.Guest?.FullName + " (" + r.Guest?.GuestCode + ")";
            lblReservationId.Text = r.ReservationCode;
            lblRoom.Text = r.Room?.RoomNumber + " (" + r.Room?.RoomTypeName + ")";
            lblRoomCharges.Text = "P" + r.TotalBill.ToString("N2");
            lblServiceCharges.Text = "P0.00";
            lblTotalBill.Text = "P" + r.TotalBill.ToString("N2");
            lblAmountPaid.Text = "P" + payment.Amount.ToString("N2");
            lblPaymentMethod.Text = payment.PaymentMethod;
            lblRemainingBalance.Text = "P" + r.Balance.ToString("N2");

            // Text na ipi-print
            receiptText = "HOTEL RESERVATION\n" +
                          "PAYMENT RECEIPT\n" +
                          "--------------------------------\n" +
                          "Transaction ID: " + lblTransactionId.Text + "\n" +
                          "Date: " + lblDate.Text + "\n" +
                          "Guest: " + lblGuest.Text + "\n" +
                          "Reservation ID: " + lblReservationId.Text + "\n" +
                          "Room: " + lblRoom.Text + "\n" +
                          "--------------------------------\n" +
                          "Room Charges: " + lblRoomCharges.Text + "\n" +
                          "Service Charges: " + lblServiceCharges.Text + "\n" +
                          "Total Bill: " + lblTotalBill.Text + "\n" +
                          "Amount Paid: " + lblAmountPaid.Text + "\n" +
                          "Payment Method: " + lblPaymentMethod.Text + "\n" +
                          "Remaining Balance: " + lblRemainingBalance.Text + "\n" +
                          "--------------------------------\n" +
                          "Thank you for your stay!";

            btnPrint.Click += btnPrint_Click;
            btnClose.Click += btnClose_Click;
        }

        // Print Preview ng resibo
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += Document_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = document;
            preview.Width = 800;
            preview.Height = 700;
            preview.ShowDialog();
        }

        // Ito ang isusulat sa papel
        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Consolas", 11);
            e.Graphics.DrawString(receiptText, font, Brushes.Black, 50, 50);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}