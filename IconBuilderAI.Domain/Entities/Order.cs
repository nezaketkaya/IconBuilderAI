﻿using IconBuilderAI.Domain.Common;
using IconBuilderAI.Domain.Enums;
using IconBuilderAI.Domain.Identity;

namespace IconBuilderAI.Domain.Entities
{
    public class Order:EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public List<string> Urls { get; set; } = new List<string>();

    }
}
