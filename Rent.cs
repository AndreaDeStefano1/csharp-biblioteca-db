// See https://aka.ms/new-console-template for more information
class Rent
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Name { get; set; }
    public string UserFullName { get; set; }

    public Rent(DateOnly startDate, DateOnly endDate, string name, string userFullName)
    {
        StartDate = startDate;
        EndDate = endDate;
        Name = name;
        UserFullName = userFullName;
    }
}