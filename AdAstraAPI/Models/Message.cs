﻿using System.ComponentModel.DataAnnotations;

namespace AdAstraAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Content { get; set; }

        public DateTime SentAt { get; set; }

        //Nav-properties
        public string SenderId { get; set; }
        public AdAstraUser? Sender { get; set; }

        public string RecipientId { get; set; }
        public AdAstraUser? Recepient { get; set; }


        public Message()
        {
            SentAt = DateTime.Now;
        }
    }
}
