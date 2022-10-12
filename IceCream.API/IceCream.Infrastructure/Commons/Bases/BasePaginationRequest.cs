﻿namespace IceCream.Infrastructure.Commons.Bases;

public class BasePaginationRequest 
{
    public int NumPage {  get; set; } = 1;
    public int NumRecordsPage { get; set; } = 7;
    private readonly int NumMaxRecordsPage = 50;

    public string Order { get; set; } = "asc";
    public string? Sort { get; set; } = null;

    public int Records
    {
        get => NumRecordsPage;
        set
        {
            NumRecordsPage = (value > NumMaxRecordsPage) ? NumMaxRecordsPage : value;
        }
    }
}
