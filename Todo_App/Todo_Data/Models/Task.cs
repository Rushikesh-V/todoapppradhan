using System;
using System.Collections.Generic;

namespace Todo_Data.Models;

public partial class Task
{
    public int Id { get; set; }

    public int? AccId { get; set; }

    public string? TaskItem { get; set; }

    public int? TaskStatus { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateChecked { get; set; }

    public DateTime? DateTrash { get; set; }

    public DateTime? DateDeleted { get; set; }
}
