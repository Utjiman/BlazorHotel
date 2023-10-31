using BlazorHotel.Components;
class Service
{
    public static List<Bookings> bookings {get; set;} = new List<Bookings>();
    public static List<Room> rooms {get; set;} = new List<Room>();
    public static List<Customer> customers {get; set;} = new List<Customer>();
    public static List<CustomerReview> reviewlist {get; set;} = new List<CustomerReview>();


}