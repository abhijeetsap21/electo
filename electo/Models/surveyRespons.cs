//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace electo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class surveyRespons
    {
        public long surveyQuestionResponseID { get; set; }
        public long surveyQuesID { get; set; }
        public long SurveyQuestionOptionId { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public long createdBy { get; set; }
    
        public virtual loginVolunteer loginVolunteer { get; set; }
        public virtual SurveyQuestionOption SurveyQuestionOption { get; set; }
        public virtual surveyQuestion surveyQuestion { get; set; }
    }
}