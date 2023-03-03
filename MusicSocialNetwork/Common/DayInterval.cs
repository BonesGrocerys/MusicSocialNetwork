namespace MusicSocialNetwork.Common;

    public struct DayInterval
    {
     public DateTime StartDate { get; set; } 
     public DateTime EndDate { get; set; }

     public DayInterval GetDate() => 
        new DayInterval
        {
            StartDate = StartDate.Date,
            EndDate = EndDate.Date
        };

    }

