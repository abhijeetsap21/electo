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
    
    public partial class sp_SurveyAnalysis_BySurveyId_Result
    {
        public long surveyID { get; set; }
        public long surveyQuesID { get; set; }
        public string question { get; set; }
        public long SurveyQuestionOptionId { get; set; }
        public string OptionText { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> TotalResponse { get; set; }
    }
}
