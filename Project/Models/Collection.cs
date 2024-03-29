﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Collection
    {
        public const int MaxNameLength = 50;
        public const int MaxDescriptionLength = 1000;
        public const int MaxCustomFields = 3;
        public const string AllowedTopics = "Books|Stamps|Coins";
        [Required]
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "error_required")]
        [Display(Name = "name_name")]
        [MaxLength(MaxNameLength, ErrorMessage = "error_maxlength")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [BindNever]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        [BindNever]
        public DateTime Modified { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "name_description")]
        [MaxLength(MaxDescriptionLength, ErrorMessage = "error_maxlength")]
        public string? Description { get; set; }

        [Display(Name = "name_topic")]
        [Required(ErrorMessage = "error_required")]
        [RegularExpression(AllowedTopics, ErrorMessage = "error_invalidtopic")] 
        public string Topic { get; set; }

        [ForeignKey("CollectionImage")]
        [BindNever]
        public int? ImageId { get; set; }
        [BindNever]
        public CollectionImage? Image { get; set; }

        public List<CollectionItem> Items { get; set; } = new List<CollectionItem>();

        [BindNever]
        public string? AuthorId { get; set; }
        [BindNever]
        public ApplicationUser? Author { get; set; }

        public void UpdateFrom(Collection collection)
        {
            Name = collection.Name;
            Topic = collection.Topic;
            Description = collection.Description;
            Items[0].CustomIntFields = collection.Items[0].CustomIntFields;
            Items[0].CustomStringFields = collection.Items[0].CustomStringFields;
            Items[0].CustomTextAreaFields = collection.Items[0].CustomTextAreaFields;
            Items[0].CustomBoolFields = collection.Items[0].CustomBoolFields;
            Items[0].CustomDateFields = collection.Items[0].CustomDateFields;
        }
    }
}
