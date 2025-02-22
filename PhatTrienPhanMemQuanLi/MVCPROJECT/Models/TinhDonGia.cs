namespace MVCPROJECT.Models
{
    public class TinhDonGia
    {
        public string? ProductName { get; set; } 
        public int Quantity { get; set; } 
        public double UnitPrice { get; set; }
        public double Total { get; private set; } 

        public void CalculateTotal()
        {
            Total = Quantity * UnitPrice;
        }
    }
}