public class BookingMethods
{
    public static void AvailableRooms(List<Room>rooms,List<Bookings>bookings)
{
    
    Console.WriteLine("State the in date");
    DateOnly CustIn = DateOnly.Parse(""+ Console.ReadLine());
    Console.WriteLine("State the out date");
    DateOnly CustOut = DateOnly.Parse(""+ Console.ReadLine());
    foreach (Room a in rooms)
    {
        Console.Write($"|Room number: {a.RoomNr} | Number of beds: {a.NrOfBeds}|");
        if(FindBooking(bookings, a.RoomNr, CustIn, CustOut)) // Check if the room is available during the specified dates
        {
            Console.WriteLine(" Available!");
        }
        else
        {
            Console.WriteLine(" Booked!");
        }
    }
    

}

public static void RemoveBooking(List<Bookings>bookings, List<Customer>customers)
{
    Console.WriteLine("Active bookings");
    for (int i = 0; i < bookings.Count; i++)
    {
        Customer customer = customers.FirstOrDefault(cust => cust.customerid == bookings[i].Customerid)!; // Find the customer associated with the booking using customerid

        if (customer != null)
        {
            Console.WriteLine($"{i + 1}. Booking ID: {bookings[i].BookingId} | Customer: {customer.forename} {customer.lastname}");
        }
        else
        {
            Console.WriteLine($"{i + 1}. Booking ID: {bookings[i].BookingId} | Customer not found");
        }

        Console.WriteLine("------------------------------------");
    }
    Console.Write("Choose the booking that you want to remove: "); 
    int removeABooking = int.Parse("" + Console.ReadLine()) - 1; // Read the user's input as a string and convert it to an int.
    if (removeABooking >= 0 && removeABooking < bookings.Count)
    {
        bookings.RemoveAt(removeABooking); // Remove the selected booking from the list.
        Console.WriteLine($"The selected booking has been removed");
    }
}
public static bool FindBooking(List<Bookings>bookings, int RoomNr, DateOnly CustIn, DateOnly CustOut)
{
   
    bool available = true;
    foreach (Bookings a in bookings)
    {
        
        foreach (Room r in a.Bookedrooms)
        {
            if (r.RoomNr == RoomNr)
            {
                if (CustIn < a.DateOut && CustOut > a.DateIn)
                {  
                    if (CustOut < a.DateIn && CustIn < a.DateIn)
                    {

                    }
                    else 
                    {   available = false;
                        
                    }
                }
            }
        }
    }
    return available;
        
}
public static List<Bookings> SortBooking(List<Bookings>bookings)
{
    return bookings.OrderBy(x => x.DateIn).ToList();
}
    public static string PrintBooking(List<Bookings>bookings, List<Customer>customers)
    {
        List<Bookings> sortBookings = new List<Bookings>();
        string htmlout = "<p><p>";
        //sortBookings = SortBooking(bookings);
        foreach (Bookings b in bookings)
        {
            string checkedInOut = b.CheckedInOut ? "Yes" : "No";
            //htmlout += "<p>------------------------</p>";
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
public static List<Room> FindAvailableRooms(List<Room>rooms,List<Bookings>bookings, DateOnly CustIn, DateOnly CustOut)
{
    List<Room> AvailableRooms = new List<Room>();
    /*Console.WriteLine("State the in date");
    DateOnly CustIn = DateOnly.Parse(""+ Console.ReadLine());
    Console.WriteLine("State the out date");
    DateOnly CustOut = DateOnly.Parse(""+ Console.ReadLine());*/
    foreach (Room a in rooms)
    {
        //Console.Write($"|Room number: {a.RoomNr} | Number of beds: {a.NrOfBeds}|");
        if(BookingMethods.FindBooking(bookings, a.RoomNr, CustIn, CustOut)) // Check if the room is available during the specified dates
        {
            AvailableRooms.Add(a);
            //Console.WriteLine(" Available!");
        }
        else
        {
            //Console.WriteLine(" Booked!");
        }
    } return AvailableRooms;
}
}