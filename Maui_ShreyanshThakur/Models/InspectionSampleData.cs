namespace Maui_ShreyanshThakur.Models
{
    public static class InspectionSampleData
    {
        public static List<Inspection> GetInspections()
        {
            return new List<Inspection>
            {
                new Inspection
                {
                    Id = 1,
                    Title = "Equipment Safety Inspection",
                    SiteName = "Manufacturing Unit A",
                    Status = "Pending",
                    ScheduledOn = new DateTime(2026, 11, 17)
                },

                new Inspection
                {
                    Id = 2,
                    Title = "Fire Safety Inspection",
                    SiteName = "Office Building B",
                    Status = "In Progress",
                    ScheduledOn = new DateTime(2026, 11, 18)
                },

                new Inspection
                {
                    Id = 3,
                    Title = "Warehouse Quality Inspection",
                    SiteName = "Warehouse C",
                    Status = "Completed",
                    ScheduledOn = new DateTime(2026, 11, 19)
                },

                new Inspection
                {
                    Id = 4,
                    Title = "Electrical Systems Inspection",
                    SiteName = "Manufacturing Unit B",
                    Status = "Pending",
                    ScheduledOn = new DateTime(2026, 11, 20)
                },

                new Inspection
                {
                    Id = 5,
                    Title = "Environmental Compliance Inspection",
                    SiteName = "Chemical Plant A",
                    Status = "In Progress",
                    ScheduledOn = new DateTime(2026, 11, 21)
                },

                new Inspection
                {
                    Id = 6,
                    Title = "Emergency Exit Inspection",
                    SiteName = "Office Building A",
                    Status = "Completed",
                    ScheduledOn = new DateTime(2026, 11, 22)
                },

                new Inspection
                {
                    Id = 7,
                    Title = "Machinery Maintenance Inspection",
                    SiteName = "Manufacturing Unit C",
                    Status = "Pending",
                    ScheduledOn = new DateTime(2026, 11, 23)
                },

                new Inspection
                {
                    Id = 8,
                    Title = "Storage Area Inspection",
                    SiteName = "Warehouse A",
                    Status = "In Progress",
                    ScheduledOn = new DateTime(2026, 11, 24)
                },

                new Inspection
                {
                    Id = 9,
                    Title = "Workplace Hygiene Inspection",
                    SiteName = "Office Building C",
                    Status = "Completed",
                    ScheduledOn = new DateTime(2026, 11, 25)
                },

                new Inspection
                {
                    Id = 10,
                    Title = "Personal Protective Equipment Inspection",
                    SiteName = "Manufacturing Unit A",
                    Status = "Pending",
                    ScheduledOn = new DateTime(2026, 11, 26)
                },

                new Inspection
                {
                    Id = 11,
                    Title = "Fire Equipment Inspection",
                    SiteName = "Warehouse B",
                    Status = "In Progress",
                    ScheduledOn = new DateTime(2026, 11, 27)
                },

                new Inspection
                {
                    Id = 12,
                    Title = "Building Structural Inspection",
                    SiteName = "Office Building B",
                    Status = "Completed",
                    ScheduledOn = new DateTime(2026, 11, 28)
                }
            };
        }
    }
}