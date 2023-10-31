using System;
using System.Collections.Generic;
using BlazorHotel.Components;

public class Bookings
{
    public int BookingId { get; set; }
    public DateOnly DateIn { get; set; }
    public DateOnly DateOut { get; set; }
    public bool CheckedInOut { get; set; }
    private string CreditCardNr { get; set; }
    public List<Room> Bookedrooms { get; set; }
    public int Customerid { get; set; }

    public Bookings(int bookingId, DateOnly dateIn, DateOnly dateOut, int customerid, bool checkedInOut, string creditCardNr, List<Room> bookedrooms)
    {
        BookingId = bookingId;
        DateIn = dateIn;
        DateOut = dateOut;
        CheckedInOut = checkedInOut;
        CreditCardNr = creditCardNr;
        Bookedrooms = bookedrooms;
        this.Customerid = customerid;
    }
    public static void AddBooking(List<Bookings>bookings, List<Room>rooms)
{
    int bookId;
        if (bookings.Count() < 1)
        {
            bookId=100;
        }
        else
        {
            bookId=bookings[bookings.Count() -1].BookingId +1;
        }
    List<Room> customerrooms = new List<Room>();
    System.Console.WriteLine("Add customer");
    int custId = int.Parse(""+ Console.ReadLine());
    System.Console.WriteLine("Add first date");
    DateOnly dateIn = DateOnly.Parse(""+ Console.ReadLine());
    System.Console.WriteLine("Add last date");
    DateOnly dateOut = DateOnly.Parse(""+ Console.ReadLine());
    System.Console.Write("checked in (Yes/No) ?");
    bool tempChecked = Console.ReadLine().ToLower().Equals("yes");
    System.Console.WriteLine("Creditcard number");
    string creditC = Console.ReadLine();


    Bookings bookings1 = new Bookings(bookId, dateIn, dateOut, custId, tempChecked, creditC, customerrooms);
    bookings.Add(bookings1);


    
}
}
