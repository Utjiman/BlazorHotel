class BookingMethods
{
    public static string PrintBooking(List<Bookings>bookings, List<Customer>customers)
    {
        List<Bookings> sortBookings = new List<Bookings>();
        string htmlout = "<p> Bookings<p>";
        //sortBookings = SortBooking(bookings);
        foreach (Bookings b in bookings)
        {
            string checkedInOut = b.CheckedInOut ? "Yes" : "No";
            htmlout += "<p>------------------------</p>";
            htmlout += $"<p>|  Booking ID: {b.BookingId}  |</p>";
            htmlout += "<p>------------------------</p>";
            //CustomerMethods.FindCustomer(customers, b.Customerid);
            htmlout += $"<p> -> Date to check in: {b.DateIn}</p>";
            htmlout += $"<p> <- Date to check out: {b.DateOut}<p>";
            htmlout += $"<p> - Customer Checked in ?: {checkedInOut}</p>";
            
            foreach(Room c in b.Bookedrooms)
            {
                htmlout += $"<p> - Number of beds: {c.NrOfBeds}</p>";
            }
            htmlout += $"<p> - Booked rooms: {b.Bookedrooms.Count()}</p>";
            htmlout += "<p>------------------------<p>"; 
            
        }
        return htmlout;
    }
}