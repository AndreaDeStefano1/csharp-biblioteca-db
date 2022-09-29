


class Rent
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int NameId { get; set; }
    public int DocumentId { get; set; }

    public Rent(DateOnly startDate, DateOnly endDate, int userId, int documentId) { 
        StartDate = startDate;
        EndDate = endDate;
        NameId = userId;
        DocumentId = documentId;
    }
}