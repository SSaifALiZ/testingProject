namespace WorkFlow.Models
{
    public  class APIMapping
    {
        public string selfName { get; set; }     
        public string endPoints { get; set; }
        public string type { get; set; }
        
        public APIMapping(string _selfname,string _endPoints , string _type)
        {
            selfName = _selfname;
            endPoints= _endPoints;
            type = _type;  
        }
    }


    public static class EnvironmentConstants
    {
        public static string EnvironmentName { get; set; }
        public static string BaseURL { get; set; }
    }
}