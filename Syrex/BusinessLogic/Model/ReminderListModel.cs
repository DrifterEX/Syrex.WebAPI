﻿namespace Syrex.BusinessLogic.Model
{
    public class ReminderListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ReminderDate { get; set; }
        public int Status { get; set; }
    }
}
