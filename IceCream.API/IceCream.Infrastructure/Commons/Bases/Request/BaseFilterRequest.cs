﻿namespace IceCream.Infrastructure.Commons.Bases.Request;

public class BaseFilterRequest : BasePaginationRequest
{
    public int? NumFilter { get; set; } = null;
    public string? TextFilter { get; set; } = null;
    public int? StateFilter { get; set; } = null;
    public string? StartDate { get; set; } = null;
    public string? EndDate { get; set; } = null;
    public bool? Download { get; set; } = false;
}
